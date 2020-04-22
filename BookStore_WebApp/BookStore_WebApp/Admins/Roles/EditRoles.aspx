<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditRoles.aspx.cs" Inherits="BookStore.WebApp.Admins.Roles.EditRoles" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新增角色信息</title>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
      
            <!-- 
                CompareValidator           做的是对比两次输入内容是否相同
                RangeValidator             做的是范围筛选
                RegularExpressionValidator 做的是正则表达式的验证
                RequiredFieldValidator     做的是非空验证
                ValidationSummary          展示错误信息用的,把页面内容所有的验证信息都展示在这
            -->
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
                    <label>角色编号</label>
                    <asp:TextBox ID="RolesId" runat="server" CssClass="dfinput" ReadOnly="True"></asp:TextBox>
                </li>
                <li>
                    <label>角色名称</label>
                    <asp:TextBox ID="RolesTitle" runat="server" CssClass="dfinput"></asp:TextBox>
                    <i>
                        *必须填写
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                    ErrorMessage="角色名称不能为空" ControlToValidate="RolesTitle"
                                                    Display="Dynamic">

                        </asp:RequiredFieldValidator>
                    </i>
                </li>
               <!-- 验证标签我们需要给他加上属性,1.ControlToValidate = "要验证的控件id" 提示给哪个控件做的验证 
                                            2.Display="Dynamic"    用于怎么显示  Dynamic 动态    
               -->
                <li>
                    <label>&nbsp;</label>
                    <asp:Button ID="btnSumbit" runat="server" Text="确认保存" CssClass="btn" OnClick="btnSumbit_OnClick" />
                </li>
            </ul>
        </div>
    </form>
</body>
</html>
