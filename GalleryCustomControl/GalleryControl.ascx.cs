using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Models;

namespace WebApplication
{
    public partial class GalleryControl : System.Web.UI.UserControl
    {
        List<Album> albums = new List<Album>();
        List<Models.Image> images = new List<Models.Image>();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["StyleSheetTheme"] != null && Session["StyleSheetTheme"].ToString() != "")
            {
                Page.Theme = Session["StyleSheetTheme"].ToString();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ContentInfoLoader cil = new ContentInfoLoader();

            

            string galleriesPath = "";

            if (Session["PicRootPath"] != null && Session["PicRootPath"].ToString() != "")
            {
                galleriesPath = Session["PicRootPath"].ToString();
            }
            else
            {
                galleriesPath = cil.PicRootDefaultPath;
                Session["PicRootPath"] = galleriesPath;
            }
            CreateThumbs(galleriesPath, cil);
            albums = LoadAlbums(galleriesPath, cil);
            AlbumList.DataSource = albums;
            AlbumList.DataBind();

            if (Request["gallery"] != "" && Request["gallery"] != null)
            {

                images = LoadImages(Request["gallery"], galleriesPath, cil);
                Photos.DataSource = images;
                Photos.DataBind();
            }
            
        }

        public void CreateThumbs(string galleriesPath, ContentInfoLoader cil)
        {
            string[] galleryPathList = new string[1];
            if (galleriesPath != "")
            {
                galleryPathList = cil.GetGalleryPaths(Server.MapPath(galleriesPath));
            }

            foreach(string galleryPath in galleryPathList)
            {
                string[] photoList = new string[1];
                string galleryName = galleryPath.Substring(galleryPath.LastIndexOf("\\") + 1);

                if (galleriesPath != "")
                {
                    photoList = cil.GetPhotoList(galleryName, Server.MapPath(galleriesPath));
                }

                string[] thumbList = new string[1];
                List<string> thumbNames = new List<string>();
                if (galleriesPath != "")
                {
                    thumbList = cil.GetThumbList(galleryName, Server.MapPath(galleriesPath));
                }

                
                if (thumbList != null)
                {
                    
                    foreach (string thumbPath in thumbList)
                    {
                        thumbNames.Add(thumbPath.Substring(thumbPath.LastIndexOf("\\")));
                    }
                }

                foreach (string photoName in photoList)
                {
                    string photoFileName = photoName.Substring(photoName.LastIndexOf("\\"));
                    

                    if (thumbList != null)
                    {

                        bool thumbReady = thumbNames.Contains(photoFileName);

                        if (!thumbReady)
                        {
                            //string path = galleriesPath + galleryName +"/"+ "/thumbnails/";
                            System.Drawing.Image bigPic = System.Drawing.Image.FromFile(photoName);
                            System.Drawing.Image thumbnail = bigPic.GetThumbnailImage(300, 170, () => false, IntPtr.Zero);
                            
                            string outputFileName = galleryPath + "\\thumbnails\\" + photoFileName;
                            using (MemoryStream memory = new MemoryStream())
                            {
                                using (FileStream fs = new FileStream(outputFileName, FileMode.Create, FileAccess.ReadWrite))
                                {
                                    thumbnail.Save(memory, ImageFormat.Jpeg);
                                    byte[] bytes = memory.ToArray();
                                    fs.Write(bytes, 0, bytes.Length);
                                }
                            }

                            
                            //oSave.Save(galleriesPath + galleryName + "/" + "/thumbnails/");
                        }
                    }
                }
            }
        }


        public List<Album> LoadAlbums(string galleriesPath, ContentInfoLoader cil)
        {
            List<Album> albums = new List<Album>();
            string[] galleryPathList = new string[1];

            // Load the path info for all the galleries
            if (galleriesPath != "")
            {
                galleryPathList = cil.GetGalleryPaths(Server.MapPath(galleriesPath));
            }

            // Generate the navigation for the galleries
            foreach (string galleryPath in galleryPathList)
            {
                string galleryName = galleryPath.Substring(galleryPath.LastIndexOf("\\") + 1);
                Album currentAlbum = new Album();
                
                currentAlbum.Name = galleryName;
                currentAlbum.Path = Path.GetFileNameWithoutExtension(this.Page.Request.Url.AbsolutePath) + "?gallery=" + galleryName;

               
                // add the anchor to the list
                albums.Add(currentAlbum);
            }

            return albums;

        }

        public List<Models.Image> LoadImages(string galleryName, string galleriesPath, ContentInfoLoader cil)
        {
            List<Models.Image> images = new List<Models.Image>();

            string[] photoList = new string[1];

            if (galleriesPath != "")
            {
                photoList = cil.GetPhotoList(galleryName, Server.MapPath(galleriesPath));
            }

            foreach (string iPhotoName in photoList)
            {
                Models.Image currentImage = new Models.Image();
                string photoName;
                photoName = iPhotoName.Substring(iPhotoName.LastIndexOf("\\") + 1);
                
                string originalPhotoName = photoName;
                char[] charSeparators = new char[] { '~', '.' };
                string photoTitle = "";
                if (photoName.Contains("~"))
                {
                    photoTitle = photoName.Split(charSeparators)[1];
                    photoName = photoName.Split(charSeparators)[0] + ".JPG";
                }


                currentImage.Name = photoName;
                currentImage.Path = galleriesPath.Substring(2)+Request["gallery"]+"/" + photoName;
                currentImage.ThumbPath = galleriesPath.Substring(2) + Request["gallery"] + "/thumbnails/" + photoName;
                images.Add(currentImage);
            }
            
            return images;
        }
    }
}