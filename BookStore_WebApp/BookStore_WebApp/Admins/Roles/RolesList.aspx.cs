using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BookStore.BLL;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;

namespace BookStore.WebApp.Admins.Roles
{
    public partial class RolesList : System.Web.UI.Page
    {
        private RolesService bll = new RolesService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            HttpCookie u_cookie = Request.Cookies["LoginOk"];
            HttpCookie r_cookie = Request.Cookies["RolesId"];
            if ((Session["LoginOk"] == null || Session["RolesId"] == null) && (u_cookie == null || r_cookie == null))
            {
                Response.Write("<script>alert('账号信息过期,请重新登入');location.href='../Login.aspx'</script>");
            }
            else
            {
                #region Repeater绑定

                //this.RepRolesList.DataSource = bll.GetRolesList(); //查询所有的权限信息,并且把这个集合添加到Repeater控件当中
                //this.RepRolesList.DataBind();  //绑定数据源

                GetRoles("");

                #endregion
            }

        }

        /// <summary>
        /// 页码改变事件
        /// </summary>
        /// <param name="src"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanging(object src, PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex; //重新设定分页展示的当前页码为多少
            /*
             *当我们以后如果有点击下一页的时候文本框当中的值,刷新,消失了的时候,我们需要在这给文本框重新赋值,赋的是之前输入的内容
             *this.txtKeyWords.Text = XXXX;
             */
            //下面的是绑定数据源
            GetRoles(this.txtKeyWords.Text);
        }

        protected void ibtnDelAll_OnClick(object sender, ImageClickEventArgs e)
        {

        }

        protected void ibtnGetSubmit_OnClick(object sender, ImageClickEventArgs e)
        {
            string keyword = this.txtKeyWords.Text;
            GetRoles(keyword);
        }

        /// <summary>
        /// 绑定数据源事件
        /// </summary>
        private void GetRoles(string keyword)
        {
            var dt = bll.GetRolesListByTitle(keyword);
            PagedDataSource psd = new PagedDataSource(); //实例化 分页的数据源方法
            psd.DataSource = dt; //绑定数据源
            psd.AllowPaging = true; //是否分页
            psd.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1; // PagedDataSource 当中页码是从0开始的,和我们的数组下标一样
            psd.PageSize = AspNetPager1.PageSize; //设定每页展示的数据条数
            AspNetPager1.RecordCount = dt.Count; //给分页插件设定数据的总条数
            this.RepRolesList.DataSource = psd; //给Repeater控件传入数据源,这个数据源是我们自己设定的分页的数据源
            this.RepRolesList.DataBind(); //实现Repeater数据绑定
        }
    }
}