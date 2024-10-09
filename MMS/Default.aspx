<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.Master" CodeBehind="Default.aspx.vb" Inherits="MMS._Default" %>
<%@ Register Src="~/MainMenu.ascx" TagPrefix="uc1" TagName="MainMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" media="all" href="/css/Site.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maindv">
        <div class="header">
            <img src="/images/head.jpg" class="header-img" />
        </div>
        <div class="clear"></div>
        <div class="main">
            <div class="main-right">
                <uc1:MainMenu runat="server" id="MainMenu" />
            </div>
            <div id="MainP" class="main-left" runat="server">
                
            </div>
        </div>
        <div class="clear"></div>
        <div class="footer">
            <span>پروژه سیستم مدیریت جلسات</span>
        </div>
    </div>
</asp:Content>
