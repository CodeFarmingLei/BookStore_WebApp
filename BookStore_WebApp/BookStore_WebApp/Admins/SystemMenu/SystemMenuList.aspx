<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemMenuList.aspx.cs" Inherits="BookStore_WebApp.Admins.SystemMenu.SystemMenuList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>系统菜单列表</title>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script language="JavaScript" src="../js/jquery.js"></script>
    <script type="text/javascript">
        $(function(){	
            //导航切换
            $(".menuson li").click(function(){
                $(".menuson li.active").removeClass("active")
                $(this).addClass("active");
            });
	
            $('.title').click(function(){
                var $ul = $(this).next('ul');
                $('dd').find('ul').slideUp();
                if($ul.is(':visible')){
                    $(this).next('ul').slideUp();
                }else{
                    $(this).next('ul').slideDown();
                }
            });
        })	
    </script>
</head>
<body style="background:#f0f9fd;">
    <form id="form1" runat="server">
        <div class="lefttop"><span></span>主页面</div>
        <dl class="leftmenu">
            <dd>
                <div class="title"><span><img src="../images/leftico01.png" /></span>系统设置</div>
    	        <ul class="menuson">
                    <li><cite></cite><a href="#" target="rightFrame">角色管理</a><i></i></li>
                    <li><cite></cite><a href="#" target="rightFrame">用户管理</a><i></i></li>
                    <li><cite></cite><a href="#" target="rightFrame">系统菜单管理</a><i></i></li>
                    <li><cite></cite><a href="#" target="rightFrame">角色权限分配管理</a><i></i></li>
                </ul>    
            </dd>

            <dd>
                <div class="title"><span><img src="../images/leftico02.png" /></span>网站设置</div>
    	        <ul class="menuson">
                    <li><cite></cite><a href="#" target="rightFrame">网站菜单管理</a><i></i></li>
                </ul>    
            </dd>

            <dd>
                <div class="title"><span><img src="../images/leftico03.png" /></span>优化设置</div>
    	        <ul class="menuson">
                    <li><cite></cite><a href="#" target="rightFrame">Seo优化管理</a><i></i></li>
                    <li><cite></cite><a href="#" target="rightFrame">友情链接管理</a><i></i></li>
                </ul>    
            </dd>

            <dd>
                <div class="title"><span><img src="../images/leftico04.png" /></span>版权设置</div>
    	        <ul class="menuson">
                    <li><cite></cite><a href="#" target="rightFrame">版权信息管理</a><i></i></li>
                </ul>    
            </dd>
        </dl>
    </form>
</body>
</html>
