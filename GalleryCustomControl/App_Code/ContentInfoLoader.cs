using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace WebApplication
{
    public class ContentInfoLoader
    {
        string _picRootPath;
        string _picRootDefaultPath;

        public string PicRootPath
        {
            get
            {
                return _picRootPath;
            }
        }

        public string PicRootDefaultPath
        {
            get
            {
                return _picRootDefaultPath;
            }
        }

        public ContentInfoLoader()
        {
            Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration("~/");

            if (0 < rootWebConfig.AppSettings.Settings.Count)
            {
                KeyValueConfigurationElement picRootElement = rootWebConfig.AppSettings.Settings["GalleryRootPath"];
                if (null != picRootElement)
                {
                    _picRootPath = picRootElement.Value;
                }

                picRootElement = rootWebConfig.AppSettings.Settings["GalleryRootDefaultPath"];
                if (null != picRootElement)
                {
                    _picRootDefaultPath = picRootElement.Value;
                }
            }
        }

        public string[] GetGalleryPaths(string picRootRealPath)
        {
            if (Directory.Exists(picRootRealPath))
            {
                return Directory.GetDirectories(picRootRealPath);
            }
            else
            {
                return null;
            }
        }

        public string[] GetPhotoList(string galleryName, string picRootRealPath)
        {
            string galleryPath = picRootRealPath + "\\" + galleryName + "\\";
            if (Directory.Exists(galleryPath))
            {
                return Directory.GetFiles(galleryPath, "*.JPG");
            }
            else
            {
                return null;
            }
        }

       public string[] GetThumbList(string galleryname, string picRootRealPath)
        {
            string galleryPath = picRootRealPath + "\\" + galleryname + "\\thumbnails\\";
            if (Directory.Exists(galleryPath))
            {
                return Directory.GetFiles(galleryPath, "*.JPG");
            }
            else
            {
                Directory.CreateDirectory(galleryPath);
                return null;
            }
        }


    }
}