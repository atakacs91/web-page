<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GalleryControl.ascx.cs" Inherits="WebApplication.GalleryControl" %>

<div class="container">

    <asp:ListView ID="AlbumList" runat="server">
        <ItemTemplate>
            <a href=<%#Eval("Path") %>><%#Eval("Name") %></a>
        </ItemTemplate>
    </asp:ListView>
</div>
<div class="container">
    <asp:ListView ID="Photos" runat="server">
        <ItemTemplate>
            <a href=<%#Eval("Path") %>><img src=<%# Eval("ThumbPath") %> style="width: 300px;"/></a>
        </ItemTemplate>
    </asp:ListView>
</div>
