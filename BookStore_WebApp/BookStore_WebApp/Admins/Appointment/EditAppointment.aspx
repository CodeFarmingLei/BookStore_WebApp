<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditAppointment.aspx.cs" Inherits="BookStore.WebApp.Admins.Appointment.EditAppointment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>预约审核</title>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="../main/Main.aspx">首页</a></li>
                <li><a href="AppointmentList.aspx">预约管理</a></li>
            </ul>
        </div>
    
        <div class="formbody">
    
            <div class="formtitle"><span>预约信息</span></div>
    
            <ul class="forminfo">
                <li style="display: none">
                    <asp:TextBox runat="server" Id="txtId" ReadOnly="True" CssClass="dfinput" ></asp:TextBox>
                </li>
                <li>
                    <label>预约人姓名:</label>
                    <asp:TextBox ID="txtName" runat="server" CssClass="dfinput" ReadOnly="True"></asp:TextBox>
                </li>
                <li>
                    <label>预约人电话:</label>
                    <asp:TextBox ID="txtTel" runat="server" CssClass="dfinput" ReadOnly="True"></asp:TextBox>
                    <i>
                    </i>
                </li>
                <li>
                    <label>预约金额:</label>
                    <asp:TextBox ID="txtAmount" runat="server" CssClass="dfinput" ReadOnly="True"></asp:TextBox>
                    <i>
                        万元
                    </i>
                </li>
                <li>
                    <label>审核状态:</label>
                    <asp:DropDownList runat="server" ID="txtStatus" CssClass="dropdownlist"></asp:DropDownList>
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
