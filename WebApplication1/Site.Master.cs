using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace WebApplication1
{
    public partial class SiteMaster : MasterPage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            //使用者未登入
            
            if (!Page.User.Identity.IsAuthenticated)
            {
                //導向登入頁面
                FormsAuthentication.RedirectToLoginPage();
            }
            else
            {
                Response.Write("您已通過使用者身份驗證" + "<br/>");
                Response.Write("使用者帳號：" + Page.User.Identity.Name + "<br/>");
                Response.Write("驗證狀態：" + Page.User.Identity.IsAuthenticated + "<br/>");
                Response.Write("驗證模式：" + Page.User.Identity.AuthenticationType + "<br/>");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}