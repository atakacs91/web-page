<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

  <div class="container-fluid dark" >
    <div class="row col-xs-12" id="brandtop">
      <div class="col-xs-1 col-md-2 col-lg-2">
      </div>
      <div class="col-xs-3 col-md-2 col-lg-2">
        <img src="images/logo.png" class="img-responsive">
      </div>
      <div class="col-xs-8 col-md-8 col-lg-8 brand">
        <span>Company Name Ltd.</span>
      </div>
    </div>
  </div>
  <div class="container-fluid dark padding_1" id="hidemenu">
    <div class="row row-centered menu-start">
      <nav class="menu">
        <a class="menu-item" href="#">Főoldal</a>
        <a class="menu-item" href="#">Referenciák</a>
        <a class="menu-item" href="#">Galéria</a>
        <a class="menu-item" href="#">Elérhetőségek</a>
      </nav>
    </div>
  </div>

  <div class="container-fluid text-center default">
    <div class="row">
      <div class="col-sm-2">
      </div>
      <div class="col-sm-8">
      <p class="heading">
        Rólunk
      </p>
      </div>
      <div class="col-sm-2">
      </div>
  </div>

    <div class="row">
      <div class="col-sm-2"></div>
      <div class="col-sm-4">
      <p class="content">
        Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
        tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim
        veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea
        commodo consequat. Duis aute irure dolor in reprehenderit in voluptate
        velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaeca
         cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id
          est laborum.
        </p>
      </div>
      <div class="col-sm-4">
      <p class="content">
        Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
        tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim
        veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea
        commodo consequat. Duis aute irure dolor in reprehenderit in voluptate
        velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaeca
         cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id
          est laborum.
        </p>
      </div>
      <div class="col-sm-2"></div>
    </div>
  </div>

<div class="container-fluid nopadding">
  <div id="myCarousel" class="carousel slide" data-ride="carousel">
  <!-- Indicators -->
  <ol class="carousel-indicators">
    <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
    <li data-target="#myCarousel" data-slide-to="1"></li>
    <li data-target="#myCarousel" data-slide-to="2"></li>
  </ol>

  <!-- Wrapper for slides -->
  <div class="carousel-inner" role="listbox">
    <div class="item active">
      <img src="images/car-01.jpg" alt="Chania">
    </div>

    <div class="item">
      <img src="images/car-02.jpg" alt="Chania">
    </div>

    <div class="item">
      <img src="images/car-03.jpg" alt="Flower">
    </div>

  </div>

  <!-- Left and right controls -->
  <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
</div>
<div class="caption text-center">
  Galéria <br />
  <a href="#" class="linkbutton">Tovább</a>

</div>
</div>

<div class="container-fluid default">
  <div class="row" id="brandtop">
    <div class="col-sm-2">
    </div>
    <div class="col-sm-3">
      <img src="images/ref-01.jpg" class="refpic" />
    </div>
    <div class="col-sm-5 ref-content-l">
      <h3>Referencia Projekt</h3>
      <p class="content" >
      orem ipsum dolor sit amet, nec magna sapien, in in vitae tincidunt massa,
      enim velit suscipit sed, lectus elit wisi duis ipsum, dapibus lectus eu
      faucibus ullamcorper ridiculus. Elit eget lobortis arcu dui tincidunt quis,
      dis sem sed. Vivamus morbi aenean sit quis vivamus habitant.
    </p>
    </div>
    <div class="col-sm-2">
    </div>
  </div>
    <div class="row" id="brandtop">
      <div class="col-sm-2">
      </div>
      <div class="col-sm-5 ref-content-r">
        <h3>Referencia Projekt</h3>
        <p class="content" >
        orem ipsum dolor sit amet, nec magna sapien, in in vitae tincidunt massa,
        enim velit suscipit sed, lectus elit wisi duis ipsum, dapibus lectus eu
        faucibus ullamcorper ridiculus. Elit eget lobortis arcu dui tincidunt quis,
        dis sem sed. Vivamus morbi aenean sit quis vivamus habitant.
      </p>
      </div>
      <div class="col-sm-3">
        <img src="images/ref-02.jpg" class="refpic" />
      </div>
      <div class="col-sm-2">
      </div>
    </div>
    <div class="row row-centered padding_2">
      <a href="#" class="link-invert">Továbbiak</a>
    </div>
</div>

</asp:Content>
