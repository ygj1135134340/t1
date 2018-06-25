using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mybloge.BLL;
using Mybloge.Model;

public partial class bogleaspx_MyNes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //保存
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (fulpath.HasFile)//是否存在头像
        {
            //if (fulpath.PostedFile.ContentType.ToLower() == "image/jpeg")//文件格式
            //{
                Blogtable blogabout = new Blogtable();
                blogabout.username = Session ["username"].ToString ();
                blogabout.describe  =txtdescribe .Text  ;
                blogabout.userphoto = @"~\blog image\" + Session["username"].ToString() + ".jpg";
                blogabout.selfname = txtname.Text ;
                int a=new BLL_blog ().BLL_select_bolge(blogabout);
                if (a!=0)
                {
                    string filenamessvr = Server.MapPath(@"~\blog image\" + Session["username"] + ".jpg");
                    fulpath.PostedFile.SaveAs(filenamessvr);
                    Page.ClientScript.RegisterStartupScript(typeof(string), "s", "<script>alert('更新成功')</script>");
                    Response.Redirect(@"~/bogleaspx/JournalList.aspx");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(typeof(string), "s", "<script>alert('更新失败')</script>");
                }
            //}
            //else
            //{
            //    Page.ClientScript.RegisterStartupScript(typeof(string), "s", "<script>alert('文件内容不是image/jpeg格式')</script>");
            //}
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(typeof(string), "s", "<script>alert('文件不存在')</script>");
        }
    }
}