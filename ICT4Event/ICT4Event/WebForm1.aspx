<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ICT4Event.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<!--[if lt IE 7]>      <html class="no-js lt-ie9 lt-ie8 lt-ie7" lang=""> <![endif]-->
<!--[if IE 7]>         <html class="no-js lt-ie9 lt-ie8" lang=""> <![endif]-->
<!--[if IE 8]>         <html class="no-js lt-ie9" lang=""> <![endif]-->
<!--[if gt IE 8]><!-->
<html class="no-js" lang="">
<!--<![endif]-->

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title></title>
    <meta name="description" content="">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="apple-touch-icon" href="apple-touch-icon.png">
    <link rel="stylesheet" href="css/bootstrap.css">
    <style>
    body {
        padding-top: 50px;
        padding-bottom: 20px;
    }
    </style>
    <link rel="stylesheet" href="css/bootstrap-theme.min.css">
    <link rel="stylesheet" href="css/main.css">
    <script src="js/vendor/modernizr-2.8.3-respond-1.4.2.min.js"></script>
</head>

<body>
    <form runat="server">
    <!--[if lt IE 8]>
            <p class="browserupgrade">You are using an <strong>outdated</strong> browser. Please <a href="http://browsehappy.com/">upgrade your browser</a> to improve your experience.</p>
        <![endif]-->
    <nav class="navbar navbar-fixed-top" role="navigation">
        <div class="container">
            <div class="navbar-header logo">
                <div class="logoTxt">
                    <a href="#"><asp:Button ID="Button1" runat="server" Text="ICT4Events" OnClick="Button1_Click"/></a>
                   
                </div>
                <div class="logoBot">
                    <a href="#">Medewerker</a>
                </div>
            </div>
            <div id="navbar">
                <ul class="flex-container navMenuTop">
                    <li class="flex-item" id="i-incheck"><a href="#">INCHECK</a></li>
                    <li class="flex-item" id="i-account"><a href="#">ACCOUNT</a></li>
                    <li class="flex-item" id="i-reserveren"><a href="#">RESERVEREN</a></li>
                    <li class="flex-item" id="i-admin"><a href="#">ADMIN</a></li>
                    <li class="flex-item" id="i-opties"><a href="#">OPTIES</a></li>
                </ul>
            </div>
        </div>
    </nav>
        <nav class="sub-navbar">
            <div class="container">
                <div class="nav-account">
                    <ul class="sub-flex-container sub sub-account">
                        <li class="sub-flex-item">Account Maken</li>
                    </ul>
                </div>
                <div class="nav-reserveren">
                    <ul class="sub-flex-container sub sub-resereven">
                        <li class="sub-flex-item">Item</li>
                        <li class="sub-flex-item">Plek</li>
                    </ul>
                </div>

                <div class="nav-admin">
                    <ul class="sub-flex-container sub sub-admin">
                        <li class="sub-flex-item">Event</li>
                        <li class="sub-flex-item">Media</li>
                    </ul>
                </div>

                <div class="nav-opties">
                    <ul class="sub-flex-container sub sub-opties">
                        <li class="sub-flex-item">
                            <select>
                                <option value="sme">SME</option>
                            </select>
                        </li>
                        <li class="sub-flex-item">Uitloggen</li>
                    </ul>
                </div>
            </div>
        </nav>
        <!-- Main jumbotron for a primary marketing message or call to action -->
        <div class="jumbotron">
            <div class="container">
                <h1>Hello, world!</h1>
                <p>This is a template for a simple marketing or informational website. It includes a large callout called a jumbotron and three supporting pieces of content. Use it as a starting point to create something more unique.</p>
                <p><a class="btn btn-primary btn-lg" href="#" role="button">Learn more &raquo;</a></p>
            </div>
        </div>
        <div class="container">
            <!-- Example row of columns -->
            <div class="row">
                <div class="col-md-4">
                    <h2>Heading</h2>
                    <p>Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Etiam porta sem malesuada magna mollis euismod. Donec sed odio dui. </p>
                    <p><a class="btn btn-default" href="#" role="button">View details &raquo;</a></p>
                </div>
                <div class="col-md-4">
                    <h2>Heading</h2>
                    <p>Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Etiam porta sem malesuada magna mollis euismod. Donec sed odio dui. </p>
                    <p><a class="btn btn-default" href="#" role="button">View details &raquo;</a></p>
                </div>
                <div class="col-md-4">
                    <h2>Heading</h2>
                    <p>Donec sed odio dui. Cras justo odio, dapibus ac facilisis in, egestas eget quam. Vestibulum id ligula porta felis euismod semper. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus.</p>
                    <p><a class="btn btn-default" href="#" role="button">View details &raquo;</a></p>
                </div>
            </div>
            <hr>
            <footer>
                <p>&copy; Company 2015</p>
            </footer>
        </div>
        <!-- /container -->
        <script src="js/vendor/jquery-2.1.4.js"></script>
        <script>
            window.jQuery || document.write("<script src=\"js/vendor/jquery-2.1.4.js\"><\/script>")
        </script>
        <script src="js/vendor/bootstrap.min.js"></script>
        <script src="js/main.js"></script>
        <!-- Google Analytics: change UA-XXXXX-X to be your site's ID. -->
        <script>
            (function (b, o, i, l, e, r) {
                b.GoogleAnalyticsObject = l;
                b[l] || (b[l] =
                    function () {
                        (b[l].q = b[l].q || []).push(arguments);
                    });
                b[l].l = +new Date;
                e = o.createElement(i);
                r = o.getElementsByTagName(i)[0];
                e.src = '//www.google-analytics.com/analytics.js';
                r.parentNode.insertBefore(e, r);
            }(window, document, 'script', 'ga'));
            ga('create', 'UA-XXXXX-X', 'auto');
            ga('send', 'pageview');
        </script>
    </form>
</body>

</html>

</html>
