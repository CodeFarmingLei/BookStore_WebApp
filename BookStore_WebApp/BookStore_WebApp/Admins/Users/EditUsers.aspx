<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUsers.aspx.cs" Inherits="BookStore_WebApp.Admins.Users.EditUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>EditUsers ---- 编辑用户信息</title>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="formEditUsers" runat="server">
        <div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="../main/Main.aspx">首页</a></li>
                <li><a href="UsersList.aspx">角色管理</a></li>
            </ul>
        </div>
    
        <div class="formbody">
            <div class="formtitle"><span>角色信息</span></div>
            <ul class="forminfo">
                <li>
                    <label>用户编号</label>
                    <asp:TextBox ID="UsersId" runat="server" CssClass="dfinput" ReadOnly="True"></asp:TextBox>
                </li>
                <li>
                    <label>用户邮箱</label>
                    <asp:TextBox ID="UsersEmail" runat="server" CssClass="dfinput"></asp:TextBox>
                    <i>
                        *必须填写
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="用户邮箱不能为空" ControlToValidate="UsersEmail" Display="Dynamic"></asp:RequiredFieldValidator>
                    </i>
                </li>
                <li>
                    <label>用户密码</label>
                    <asp:TextBox ID="UsersPwd" runat="server" CssClass="dfinput"></asp:TextBox>
                    <i>
                        *必须填写
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="用户密码不能为空" ControlToValidate="UsersPwd" Display="Dynamic"></asp:RequiredFieldValidator>
                    </i>
                </li>
                <li>
                    <label>用户昵称</label>
                    <asp:TextBox ID="UsersNikeName" runat="server" CssClass="dfinput"></asp:TextBox>
                    <i>
                        *必须填写
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="用户昵称不能为空" ControlToValidate="UsersNikeName" Display="Dynamic"></asp:RequiredFieldValidator>
                    </i>
                </li>
                <li>
                    <label>用户头像</label>
                    <asp:TextBox ID="UsersPhoto" runat="server" CssClass="dfinput"></asp:TextBox>
                    <asp:FileUpload ID="FileUploadTitle" runat="server" CssClass="dfinput" OnDataBinding="FileUploadTitle_DataBinding" />
                    <i>
                        *必须选择头像文件
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="用户头像不能为空" ControlToValidate="UsersPhoto" Display="Dynamic"></asp:RequiredFieldValidator>
                    </i>
                </li>
                <li>
                    <label>创建时间</label>
                    <asp:TextBox ID="UsersCreateTime" runat="server" CssClass="dfinput"></asp:TextBox>
                </li>
                <li>
                    <label>权限编号</label>
                    <asp:TextBox ID="UsersRolesId" runat="server" CssClass="dfinput"></asp:TextBox>
                    <i>
                        *必须填写
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="权限编号不能为空" ControlToValidate="UsersRolesId" Display="Dynamic"></asp:RequiredFieldValidator>
                    </i>
                </li>
                <li>
                    <label>&nbsp;</label>
                    <asp:Button ID="btnSumbit" runat="server" Text="确认保存" CssClass="btn" OnClick="btnSumbit_Click" />
                </li>
            </ul>
        </div>
    </form>
</body>
</html>
