<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="head.ascx.cs" Inherits="BookStore.WebApp.Web.head" %>

<!-- 下面我们正常的去写页面代码即可 -->
<div class="top">
            <div class="top_nr">
                <p>您好欢迎您来到好信速贷！</p>
                <b>加入收藏</b>
                <b>|</b>
                <b>设为首页</b>
            </div>
        </div>
        <div class="nav">
            <div class="nav_l"><a href="index.html"><img src="images/logo.jpg" width="214" height="86" /></a></div>
            <div class="nav_r">
                <ul>
                    <asp:Repeater ID="RepNavi" runat="server">
                        <ItemTemplate>
                            <li><a href='<%#Eval("Link") %>'><%#Eval("Title") %></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul> 
                <div class="curBg"></div>
                <div class="cls"></div>
            </div>
        </div>
        <div class="banner">
            <div class="banner_nr">
                <div class="banner_1">
                    <div class="banner_2">
                        立即预约<span><img src="images/banner_2.png" width="149" height="36" /></span>
                        <div class="clear"></div>
                    </div>
                    <div class="banner_3">
                        <div class="banner_31">
                            <p>您的姓名:</p>
                           <%-- <asp:TextBox ID="txtName" runat="server" class="banner_31_r" placeholder="如张先生"></asp:TextBox>--%>
                            <input type="text" name="txtName" id="txtName" class="banner_31_r" placeholder="如张先生" value="" /> 
                            <div class="clear"></div>
                        </div>
                        <div class="banner_31">
                            <p>手机号码:</p>
                            <%--<asp:TextBox ID="txtTel" runat="server" class="banner_31_r" placeholder="您的手机号"></asp:TextBox>--%>
                            <input type="tel" name="txtTel" id="txtTel" class="banner_31_r" placeholder="您的手机号" value="" />
                            <div class="clear"></div>
                        </div>
                        <div class="banner_31">
                            <p>申贷金额:</p>
                           <%-- <asp:TextBox ID="txtAmount" runat="server" TextMode="Number" class="banner_31_r" placeholder="输入金额(万)"></asp:TextBox>--%>
                            <input type="text" name="txtAmount" id="txtAmount" class="banner_31_r" placeholder="输入金额(万)" value="" />
                            <div class="clear"></div>
                        </div>
                        <div class="clear"></div>
                    </div>
                    <div class="banner_4">
                        <%--<a href="#">

                        </a>--%>
                        <button type="button">
                            <img src="images/banner_5.png" onclick="Add()"/>
                        </button>
                       <%-- <asp:ImageButton ID="btnSubmit" ImageUrl="images/banner_5.png" runat="server" OnClick="btnSubmit_OnClick" />--%>
                    </div>
                </div>
                <div class="clear"></div>
            </div>
        </div>

<script>

    function Add() {
        //1. 先去获取3个文本框的值,我们要玩Ajax提交的话,一定要把服务器空间转换为正常html标签
        var txtName = $("#txtName").val();
        var txtTel = $("#txtTel").val();
        var txtAmount = $("#txtAmount").val();
        $.ajax({
            url: "../Hanlder/AddAppointmentHandler.ashx",
            type: "post",
            data: { name: txtName, tel: txtTel, amount: txtAmount },
            dataType: "text",
            success: function(rs) {
                console.log(rs);
                if (rs == "True") {
                    alert('预约成功,稍后客户会通过电话联系您,请保持通话畅通');
                } else {
                    alert('预约失败');
                }
            }
        });
    }

</script>

