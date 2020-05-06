<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersPermissionList.aspx.cs" Inherits="BookStore.WebApp.Admins.UsersPermission.UsersPermissionList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>UsersPermissionList ---- 权限分配管理</title>
    <link href="../css/style.css" rel="stylesheet" />
    <script src="../js/jquery.js"></script>
</head>
<body>
    <form id="formUsersPermissionList" runat="server">
        <div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="../main/Main.aspx">首页</a></li>
                <li><a href="UsersPermissionList.aspx">权限分配管理</a></li>
            </ul>
        </div>
        <div class="rightinfo">
            <div class="tools">
                <div class="ss_kuang">
                    <p>选择角色:</p>
                    <asp:DropDownList ID="ddlRolesList" runat="server" CssClass="dropdownlist"></asp:DropDownList>
                    <div style="float: right; ">
                        <asp:Button ID="btnChecked" Text="确认选择" runat="server" CssClass="btn" OnClick="btnChecked_OnClick" />
                    </div>
                </div>
            </div>

            <div style="height: 10px; float: left; width: 46%;">
                <p>用户已拥有权限:
                    <asp:Button ID="btnDel" Text="移除选定的权限" runat="server" CssClass="btn" OnClick="btnDel_OnClick" /></p>

                <table class="tablelist">
                    <thead>
                        <tr>
                            <th width="2%">
                                <asp:CheckBox ID="chk_JSOne" runat="server" OnCheckedChanged="chk_JSOne_CheckedChanged" AutoPostBack="true" />
                            </th>
                            <th width="2%">编号</th>
                            <th width="10%">菜单名称</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="RepUsersOwn" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="chk_DelOne" runat="server" />
                                        <asp:Label ID="lblOne" runat="server" Text='<%#Eval("Id") %>' Visible="False"></asp:Label>
                                    </td>
                                    <td>
                                        <%# Container.ItemIndex + 1 %>
                                    </td>
                                    <td>
                                        <%# GetSystemMenuTitle(int.Parse(Eval("SystemMenuId").ToString())) %>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>

            </div>
            <div style="height: 10px; float: right;  width: 46%;">
                <p>用户未拥有权限:
                    <asp:Button ID="btnAdd" Text="添加选定的权限" runat="server" CssClass="btn" OnClick="btnAdd_OnClick" /></p>

                <table class="tablelist">
                    <thead>
                    <tr>
                        <th width="2%">
                            <asp:CheckBox ID="chk_JSTwo" runat="server" OnCheckedChanged="chk_JSTwo_CheckedChanged" AutoPostBack="true" />
                        </th>
                        <th width="2%">编号</th>
                        <th width="10%">菜单名称</th>
                    </tr>
                    </thead>
                    <tbody>
                    <asp:Repeater ID="RepUsersNoOwn" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chk_AddTwo" runat="server" />
                                    <asp:Label ID="lblTwo" runat="server" Text='<%#Eval("Id") %>' Visible="False"></asp:Label>
                                </td>
                                <td>
                                    <%# Container.ItemIndex + 1 %>
                                </td>
                                <td>
                                    <%# Eval("Title") %>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    </tbody>
                </table>

            </div>
        </div>
    </form>
</body>
</html>
