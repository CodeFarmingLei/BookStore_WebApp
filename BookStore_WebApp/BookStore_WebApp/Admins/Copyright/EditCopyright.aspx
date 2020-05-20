<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditCopyright.aspx.cs" Inherits="BookStore.WebApp.Admins.Copyright.EditCopyright" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>EditCopyright ---- 编辑版权信息</title>
     <link href="../css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="formEditCopyright" runat="server">
       <div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="../main/Main.aspx">首页</a></li>
                <li><a href="EditCopyright.aspx?action=1">版权信息管理</a></li>
            </ul>
        </div>
    
        <div class="formbody">
    
            <div class="formtitle"><span>版权信息</span></div>
    
            <ul class="forminfo">
                <li style="display:none;">
                    <label>版权信息编号:</label>
                    <asp:TextBox ID="txtId" runat="server" ReadOnly="True" CssClass="dfinput"></asp:TextBox>
                </li>
                <li>
                    <label>版权信息名称:</label>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="dfinput"></asp:TextBox>
                    <i>
                        
                    </i>
                </li>
                <li>
                    <label>版权信息内容:</label>
                    <asp:TextBox ID="txtContent" runat="server"  CssClass="dfinput"></asp:TextBox>
                    <i>
                        
                    </i>
                </li>
                <li>
                    <label>公司地址:</label>
                    <asp:TextBox ID="txtAddress" runat="server"  CssClass="dfinput"></asp:TextBox>
                    <i>
                        
                    </i>
                </li>
                <li>
                    <label>联系电话1:</label>
                    <asp:TextBox ID="txtTel1" runat="server"  CssClass="dfinput"></asp:TextBox>
                    <i>
                    </i>
                </li>
                 <li>
                    <label>联系电话2:</label>
                    <asp:TextBox ID="txtTel2" runat="server"  CssClass="dfinput"></asp:TextBox>
                    <i>
                    </i>
                </li>
                 <li>
                    <label>QQ1:</label>
                    <asp:TextBox ID="txtQQNumber1" runat="server"  CssClass="dfinput"></asp:TextBox>
                    <i>
                    </i>
                </li>
                 <li>
                    <label>QQ2:</label>
                    <asp:TextBox ID="txtQQNumber2" runat="server"  CssClass="dfinput"></asp:TextBox>
                    <i>
                    </i>
                </li>
                 <li>
                    <label>微信号:</label>
                    <asp:TextBox ID="txtWechat" runat="server"  CssClass="dfinput"></asp:TextBox>
                    <i>
                    </i>
                </li>
                 <li>
                    <label>电子邮箱:</label>
                    <asp:TextBox ID="txtEmail" runat="server"  CssClass="dfinput"></asp:TextBox>
                    <i>
                    </i>
                </li>
                <li>
                    <label>Logo图像:</label>
                    <img src="../../upload/copyright/<%=imgSrc1 %>" width="150" height="150"/>
                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="dfinput" />
                </li>
                
               <li>
                    <label>上传图片:</label>
                    <img src="../../upload/copyright/<%=imgSrc2 %>" width="150" height="150"/>
                    <asp:FileUpload ID="FileUpload2" runat="server" CssClass="dfinput" />
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
