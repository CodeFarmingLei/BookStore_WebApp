<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="EditAbout.aspx.cs" Inherits="BookStore.WebApp.Admins.About.EditAbout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>EditAbout ---- 编辑关于我们</title>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="formEditAbout" runat="server">
        <div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="../main/Main.aspx">首页</a></li>
                <li><a href="EditAbout.aspx?action=1">关于我们管理</a></li>
            </ul>
        </div>
        <div class="formbody">
            <div class="formtitle">
                <span>关于我们</span> 
            </div>
            <div class="formbody">
                <ul class="forminfo">
                    <li style="display: none">
                        <label>关于我们编号:</label>
                        <asp:TextBox runat="server" id="txtId" Text="" CssClass="dfinput" ReadOnly="True" />
                    </li>
                    <li>
                        <label>关于我们名称:</label>
                        <asp:TextBox ID="txtTitle" runat="server" CssClass="dfinput"></asp:TextBox>
                        <i>
                        
                        </i>
                    </li>
                    <li>
                        <label>关于我们详情:</label>
                        <textarea id="txtContent" style="width: 700px; height: 400px; visibility: hidden;" runat="server"></textarea>
                        <i>
                        
                        </i>
                    </li>
                    <li>
                        <label>关于我们图片:</label>
                        <img id="imgAbout" runat="server" src="../../upload/about/<%=imgSrc %>" width="150" height="150"/>
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="dfinput" />
                    </li>
                    <li>
                        <asp:Button ID="btnSubmit" runat="server" Text="提交" CssClass="btn" OnClick="btnSubmit_OnClick" />
                    </li>  
                </ul>
            </div>
        </div>
    </form>
    <script src="../../kindeditor/kindeditor.js"></script>
    <script src="../../kindeditor/lang/zh_CN.js"></script>
    <script src="../../kindeditor/plugins/code/prettify.js"></script>
    <script type="text/javascript">
        KindEditor.ready(function (K) {
            var editor1 = K.create('#txtContent', {
                cssPath: '../../kindeditor/plugins/code/prettify.css',
                uploadJson: '../../kindeditor/asp.net/upload_json.ashx',
                fileManagerJson: '../../kindeditor/asp.net/file_manager_json.ashx',
                allowFileManager: true,
                afterCreate: function () {
                    var self = this;
                    K.ctrl(document, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                    K.ctrl(self.edit.doc, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                }
            });
            prettyPrint();
        });
    </script>
</body>
</html>
