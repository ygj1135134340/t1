using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mybloge.Model;
using Mybloge.BLL;

public partial class MimeLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ( !IsPostBack )
        {
            this.txtname.Text = "lanyubaic";
            this . txtpassword.Text = "123";
        }
    }
    #region 登录按钮
    /// <summary>
    /// 登陆按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        UserRegistration usertion = new UserRegistration();
        usertion.UserName=this.txtname.Text;
        usertion .PassWord=this.txtpassword.Text;
        int a=new BLL_BolgLogin ().BLL_select_UserRegistration(usertion );
        if (a!=0)
        {
            Session["username"] = this.txtname.Text;
            Page.ClientScript.RegisterStartupScript(typeof(string), "j", "<script>alert('登陆成功')</script>");
            this.txtname.Text = this.txtpassword.Text = "";
            List<UserRegistration> liste = new BLL_BolgLogin().BLL__select_userID_UserRegistration(usertion);
            Session["userID"] = liste[0].userID;
            Session["usermaster"] = liste[0].usermaster;
            Response.Redirect(@"~/bogleaspx/JournalList.aspx");            
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(typeof(string), "s", "<script>alert('用户名或密码错误')</script>");    
        }

    } 
    #endregion
    #region 注册按钮
    /// <summary>
    /// 注册按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect(@"~/registerBolge.aspx");

    } 
    #endregion
}