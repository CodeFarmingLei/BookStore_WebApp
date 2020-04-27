<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRoles.aspx.cs" Inherits="BookStore.WebApp.Admins.Roles.AddRoles" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>AddRoles ---- 新增角色信息</title>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="formAddRoles" runat="server">
        <div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="../main/Main.aspx">首页</a></li>
                <li><a href="RolesList.aspx">角色管理</a></li>
            </ul>
        </div>
        <div class="formbody">
            <div class="formtitle"><span>角色信息</span></div>
            <ul class="forminfo">
                <li>
                    <label>角色名称</label>
                    <asp:TextBox ID="RolesTitle" runat="server" CssClass="dfinput"></asp:TextBox>
                    <i>
                        *必须填写
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="角色名称不能为空" ControlToValidate="RolesTitle" Display="Dynamic"></asp:RequiredFieldValidator>
                    </i>
                </li>
                <li>
                    <label>&nbsp;</label>
                    <asp:Button ID="btnSumbit" runat="server" Text="确认保存" CssClass="btn" OnClick="btnSumbit_OnClick" />
                </li>
            </ul>
        </div>
    </form>
</body>
</html>
