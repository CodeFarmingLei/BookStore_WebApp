using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStore.BLL;

namespace BookStore.WebApp.Admins.UsersPermission
{
    public partial class UsersPermissionList : System.Web.UI.Page
    {
        private RolesService rolesSvc = new RolesService();
        private UsersPermissionService permissionSvc = new UsersPermissionService();
        private SystemMenuService menuSvc = new SystemMenuService();

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
                this.ddlRolesList.DataSource = rolesSvc.GetRolesList();
                this.ddlRolesList.DataTextField = "Title";
                this.ddlRolesList.DataValueField = "Id";
                this.ddlRolesList.DataBind();
            }
        }
        /// <summary>
        /// 确定按钮的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnChecked_OnClick(object sender, EventArgs e)
        {
            int id = int.Parse(this.ddlRolesList.SelectedValue); //在这我们获取的是选中的权限id
            //1. 通过我们找到的权限id,对UsersPermission表格进行查询,得到这个权限所拥有的所有SystemMenuId

            var data = permissionSvc.GetUsersPermissionsByRolesId(id); //select * from UsersPermission where RolesId = 1
            this.RepUsersOwn.DataSource = data;
            this.RepUsersOwn.DataBind();

            //2. 绑定未拥有的权限,需要我们把已拥有的系统菜单id 与 所有的系统菜单id对比

            #region 不推荐的写法
            //var allMenu = menuSvc.GetSystemMenusList(); //得到所有的系统菜单id
            //foreach (var item in data) //遍历已拥有的系统菜单id
            //{
            //    bool rs = false;
            //    foreach (var option in allMenu)
            //    {
            //        if (item.SystemMenuId == option.Id)
            //        {
            //            rs = true;
            //            break;
            //        }


            //    }

            //    if (rs == false)
            //    {
            //        //我们在这可以对其统计
            //    }
            //}


            #endregion

            string idList = ""; 
            for (int i = 0; i < data.Count; i++)
            {
                idList += data[i].SystemMenuId;
                if (i != data.Count - 1)
                {
                    idList += ",";
                }
            }

            var noOwnList = menuSvc.GetMenusListNoOwn(idList);
            this.RepUsersNoOwn.DataSource = noOwnList;
            this.RepUsersNoOwn.DataBind();
        }


        public string GetSystemMenuTitle(int id)
        {
            var data = menuSvc.GetSystemMenuById(id);
            return data.Title;
        }

        /// <summary>
        /// 移除权限的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDel_OnClick(object sender, EventArgs e)
        {
            for (int i = 0; i < RepUsersOwn.Items.Count; i++) 
            {
                CheckBox ck = (CheckBox)RepUsersOwn.Items[i].FindControl("chk_DelOne");
                Label lbl = (Label)RepUsersOwn.Items[i].FindControl("lblOne");
                if(ck != null)
                {
                    if (ck.Checked) 
                    {
                        permissionSvc.DeleteList(lbl.Text);
                    }
                }
            }

            Response.Redirect("UsersPermissionList.aspx");
        }

        /// <summary>
        /// 添加权限的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            //1. 需要我们找到Repeater控件当中,别选中的多选按钮,得到它后面的label的值
            //2. 给UsersPermission 表 进行新增操作
            //(1) 得到我们下拉列表当中选中的下拉列表值
            //(2) 把我们上面找到的label值添加到对应的SystemMenuId当中
            for (int i = 0; i < RepUsersNoOwn.Items.Count; i++)  //遍历Repeater当中的所有内容(标签)
            {
                CheckBox ck = (CheckBox)RepUsersNoOwn.Items[i].FindControl("chk_AddTwo");
                Label lbl = (Label)RepUsersNoOwn.Items[i].FindControl("lblTwo");

                if(ck != null)  //判断这个控件是否真的为多选按钮
                {
                    if (ck.Checked) //判断这个多选控件是否被选中
                    {
                        Model.UsersPermission up = new Model.UsersPermission
                        {
                            RolesId = int.Parse(this.ddlRolesList.SelectedValue),
                            SystemMenuId = int.Parse(lbl.Text)
                        };
                        permissionSvc.Add(up);
                    }
                }
            }

            Response.Redirect("UsersPermissionList.aspx");
        }

        protected void chk_JSOne_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < RepUsersOwn.Items.Count; i++)
            {
                CheckBox ck = (CheckBox)RepUsersOwn.Items[i].FindControl("chk_DelOne");
                if (ck != null)
                {
                    ck.Checked = this.chk_JSOne.Checked;
                }
            }
        }

        protected void chk_JSTwo_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < RepUsersNoOwn.Items.Count; i++)
            {
                CheckBox ck = (CheckBox)RepUsersNoOwn.Items[i].FindControl("chk_AddTwo");
                if (ck != null)
                {
                    ck.Checked = this.chk_JSTwo.Checked;
                }
            }
        }
    }
}