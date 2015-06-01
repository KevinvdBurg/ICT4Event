<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="template_admin.aspx.cs" Inherits="ICT4Event.index" %>

<!DOCTYPE html>

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
                    <a href="#">ICT4Event</a>
                </div>
                <div class="logoBot">
                    <a href="#">Medewerker</a>
                </div>
            </div>
            <div id="navbar">
                <ul class="flex-container navMenuTop">
                    <li class="flex-item" id="i-incheck"><a href="#">Incheck</a></li>
   
                    <li class="flex-item" id="i-account"><a href="#">Account</a></li>
                    
                    <li class="flex-item" id="i-reververingen"><a href="#">Reververingen</a></li>

                    <li class="flex-item" id="i-event"><a href="#">Event</a></li>

                    <li class="flex-item" id="i-opties"><a href="#">Opties</a></li>

                </ul>
            </div>
        </div>
        <nav class="sub-navbar">
            <div class="container">
                <div class="nav-account">
                    <ul class="sub-flex-container sub sub-account">
                        <a href=""><li class="sub-flex-item">Alle Account</li></a>
                        <a href=""><li class="sub-flex-item">Account Wijzigen</li></a>
                    </ul>
                </div>
                <div class="nav-reververingen">
                    <ul class="sub-flex-container sub sub-reververingen">
                        <a href=""><li class="sub-flex-item">Alle Reservering</li></a>
                        <a href=""><li class="sub-flex-item">Reservering Wijzigen</li></a>
                    </ul>
                </div>
                <div class="nav-event">
                    <ul class="sub-flex-container sub sub-event">
                        <a href=""><li class="sub-flex-item">Alle Event</li></a>
                        <a href=""><li class="sub-flex-item">Event Maken</li></a>
                        <a href=""><li class="sub-flex-item">Event Wijzigen</li></a>
                    </ul>
                </div>

                <div class="nav-opties">
                    <ul class="sub-flex-container sub sub-opties">
                        <a href=""><li class="sub-flex-item">
                            <asp:DropDownList ID="dropevent_admin" runat="server"></asp:DropDownList></li></a>
                        <asp:HyperLink ID="LoginUit_admin" runat="server">Uitloggen</asp:HyperLink>
                    </ul>
                </div>
            </div>
        </nav>
        <div class="container" id="wrapper">
            <!-- 2 collomen  -->
            <div class="row">
                <div class="col-md-6">
                    
                </div>
                <div class="col-md-6">
                </div>
                
            </div>
            <hr>
            <footer>
                <p>&copy; ICT4EVENT 2015</p>
            </footer>
        </div>
        <!-- /container -->
        <script src="js/vendor/jquery-2.1.4.js"></script>
        <script>
            window.jQuery || document.write('<script src="js/vendor/jquery-2.1.4.js"><\/script>')
        </script>
        <script src="js/vendor/bootstrap.min.js"></script>
        <script src="js/main.js"></script>
        
        </form>
</body>

</html>

