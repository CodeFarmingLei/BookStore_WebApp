<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUsers.aspx.cs" Inherits="BookStore.WebApp.Admins.Users.AddUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>AddUsers ---- 新增用户信息</title>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="formAddUsers" runat="server">
        <div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="../main/Main.aspx">首页</a></li>
                <li><a href="RolesList.aspx">角色管理</a></li>
            </ul>
        </div>
    
        <div class="formbody">
            <div class="formtitle"><span>用户信息</span></div>
            <ul class="forminfo">
                <li>
                    <label>邮箱地址:</label>
                    <asp:TextBox ID="Email" runat="server" CssClass="dfinput"></asp:TextBox>
                    <i>
                        *必须填写
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="邮箱地址不能为空" ControlToValidate="Email" Display="Dynamic"></asp:RequiredFieldValidator>
                    </i>
                </li>
                <li>
                    <label>用户密码:</label>
                    <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="dfinput"></asp:TextBox>
                    <i>
                        *必须填写
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="用户密码不能为空" ControlToValidate="Password" Display="Dynamic"></asp:RequiredFieldValidator>
                    </i>
                </li>
                <li>
                    <label>重新输入密码:</label>
                    <asp:TextBox ID="RePassword" runat="server" TextMode="Password" CssClass="dfinput"></asp:TextBox>
                    <i>
                        *必须填写
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="重新输入密码不能为空" ControlToValidate="RePassword" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="两次输入的密码不相同,请重新输入" ControlToValidate="RePassword" ControlToCompare="Password"></asp:CompareValidator>
                    </i>
                </li>
                <li>
                    <label>昵称:</label>
                    <asp:TextBox ID="NickName" runat="server"  CssClass="dfinput"></asp:TextBox>
                    <i>
                        *必须填写
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="昵称不能为空" ControlToValidate="NickName" Display="Dynamic"></asp:RequiredFieldValidator>
                    </i>
                </li>
                <li>
                    <label>上传头像</label>
                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="dfinput" />
                </li>
                <li>
                    <label>选择权限:</label>
                    <asp:DropDownList ID="RolesList" runat="server" CssClass="dropdownlist"></asp:DropDownList>
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
