using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStore.BLL;
using Wuqi.Webdiyer;

namespace BookStore.WebApp.Admins.Users
{
    public partial class UsersList : System.Web.UI.Page
    {
        private UsersService users_bll = new UsersService();
        private RolesService roles_bll = new RolesService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
                return;

            GetUsers("");

        }

        protected void AspNetPager1_OnPageChanging(object src, PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            GetUsers(this.txtKeyWords.Text);
        }

        /// <summary>
        /// 删除选中方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnDelAll_OnClick(object sender, ImageClickEventArgs e)
        {
            string checkId = "";
            //1. 遍历Repeater控件当中的所有多选按钮,查看哪个是选中状态
            //注意: Repeater当中的服务器控件,单独去查找是找不到的
            for (int i = 0; i < this.RepUsersList.Items.Count; i++) //遍历Repeater控件的所有项
            {
                CheckBox cbx = (CheckBox)RepUsersList.Items[i].FindControl("chk_Del"); //在Repeater控件当中找到多选按钮
                Label lbl = (Label) RepUsersList.Items[i].FindControl("lbl");//在Repeater控件当中找到label

                if (cbx.Checked) //判断多选按钮是否被选中
                {
                    //var data = users_bll.GetUsersById(int.Parse(lbl.Text)); //查询当前这个id是否有值
                    //users_bll.Delete(data);//删除这个用户
                    checkId += lbl.Text + ",";
                }
            }
            //1,2,3,  C# Substring(从哪开始,多少个长度)
            int rs = users_bll.DeleteList(checkId.Substring(0, checkId.Length-1));
            if(rs > 0) 
                Response.Write("<script>alert('删除成功');location.href='UsersList.aspx'</script>");
            else
                Response.Write("<script>alert('删除失败');location.href='UsersList.aspx'</script>");
        }
            

        /// <summary>
        /// 绑定用户信息
        /// </summary>
        /// <param name="keyword">要查找的昵称</param>
        public void GetUsers(string keyword)
        {
            var list = users_bll.GetUsersListByNickName(keyword);
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = list;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;
            AspNetPager1.RecordCount = list.Count;
            this.RepUsersList.DataSource = pds;
            this.RepUsersList.DataBind();
        }

        protected void ibtnGetSubmit_OnClick(object sender, ImageClickEventArgs e)
        {
            GetUsers(this.txtKeyWords.Text);
        }

        /// <summary>
        /// 得到我们主键表的权限名称
        /// </summary>
        /// <param name="rid">权限编号</param>
        /// <returns>权限名称</returns>
        public string GetRolesTitle(int rid)
        {
            var data = roles_bll.GetRoles(rid);
            if (data == null)
                return "";
            return data.Title;
        }

    }
}