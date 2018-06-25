using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mybloge.BLL;
using Mybloge.Model;

public partial class registerBolge : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack )
        {
            Random random = new Random();
            ViewState ["test"]= random.Next(1000, 9999);
           // this.lbltest.Text = ViewState["test"].ToString ();
        } 
          
            
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

       /* if (this.txttest.Text.Trim().ToString() == null || this.txttest.Text.Trim().ToString() != ViewState["test"].ToString())
        {
            Page.ClientScript.RegisterStartupScript(typeof(string), "s", "<script>alert('验证码错误')</script>");
            Random random = new Random();
            ViewState["test"] = random.Next(1000, 9999);
            this.lbltest.Text = ViewState["test"].ToString();
        }
        else8*/
        {

            UserRegistration user = new UserRegistration();
            user.UserName = this.txtusername.Text.Trim();
            user.PassWord = this.txtpwd.Text.Trim();
            user.Name = this.txtname.Text.Trim();
            if (this.sex.Text.Trim()=="男")
                user.sex = 1;
            else
                user.sex = 0;
           /* if (this.Rbtnmen.Checked == true)
            {
                user.sex = 1;
            }
            else { user.sex = 0; }*/
            user.tel = this.txttel.Text.Trim();
            user.Email = this.txtemil.Text.Trim();
            user.address = this.txtaddress.Text.Trim();
            int ef = new BLL_BolgLogin().BLL_select_username(this.txtusername .Text .Trim ());
            int d = new BLL_BolgLogin().BLL_insert_UserRegistration(user);
            if (ef != 0)
            {
                Page.ClientScript.RegisterStartupScript(typeof(string), "s", "<script>alert('用户已存在')</script>");

            }
            else
            {
                if (d == 0)
                { Page.ClientScript.RegisterStartupScript(typeof(string), "p", "<script>alert('注册失败')</script>"); }
                else
                {
                    Session["username"] = this.txtusername.Text.Trim();
                    Response.Redirect(@"~/bogleaspx/JournalList.aspx");
                }
            }

        }
    }
}