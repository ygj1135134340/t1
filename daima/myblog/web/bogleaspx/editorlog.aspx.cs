using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mybloge.Model;
using Mybloge.BLL;

public partial class bogleaspx_editorlog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if( !IsPostBack )
        {
            if (Session["edittitleID"]!=null)
            {
                int a =Convert .ToInt32 ( Session["edittitleID"]);
                List<Journaltable> list = new List<Journaltable>();
                list = new BLL_Journaltable_titleID().BLL_select_Journaltable_where_titleID(a);
                this.txttitle.Text  = list[0].title;
                this.txtzhaiyao.Text = list[0].digests;
                this.FCKeditor1.Value = list[0].content;
                ViewState["Page"] = 0;
            }
            
        }

    }
    #region 保存
     protected void btn_Click(object sender, EventArgs e)
    {
        if (ViewState["Page"]!=null)
        {
            Journaltable jour = new Journaltable();
            jour.titleID = Convert .ToInt32(Session["edittitleID"]);
            jour.title = this.txttitle.Text;//标题
            jour.digests = this.txtzhaiyao.Text; //摘要
            jour.content = FCKeditor1.Value.Trim();//日志内容
            jour.iscomment = (this.CheckBox2.Checked == true ? 0 : 1);//是否可见
            jour.islook = (this.CheckBox1.Checked == true ? 0 : 1);//是否可以访问
            if (this.RadioButton1.Checked == true)
            { jour.sort = "体育"; }                          //所属分类
            else if (this.RadioButton2.Checked == true)
            { jour.sort = "财经"; }
            else if (this.RadioButton3.Checked == true)
            { jour.sort = "房产"; }
            else if (this.RadioButton4.Checked == true)
            { jour.sort = "娱乐"; }
            else if (this.RadioButton5.Checked == true)
            { jour.sort = "计算机技术"; }
            else if (this.RadioButton6.Checked == true)
            { jour.sort = "其他"; }

            int a = new BLL_insert_Journaltable().update_jourelnal_where_titleID (jour);
            if (a > 0)
            {
                Page.ClientScript.RegisterStartupScript(typeof(string), "j", "<script>alert('修改成功')</script>");
                //start();

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(typeof(string), "飞", "<script>alert('修改失败')</script>");
            }
            
       }
         else 
       {
            Journaltable jour = new Journaltable();

        jour.title= this.txttitle.Text;//标题
        jour.digests =this.txtzhaiyao.Text; //摘要
        jour.content = FCKeditor1.Value.Trim ();//日志内容
        jour.iscomment = (this.CheckBox2.Checked == true ? 0:1);//是否可见
        jour.islook=(this.CheckBox1.Checked == true ? 0:1);//是否可以访问
            if (this.RadioButton1.Checked==true)
            { jour.sort ="体育";}                          //所属分类
            else if(this.RadioButton2.Checked==true)
            { jour.sort = "财经"; }
         else if(this.RadioButton3.Checked==true)
            { jour.sort = "房产"; }
         else if(this.RadioButton4.Checked==true)
            { jour.sort = "娱乐"; }
         else if(this.RadioButton5.Checked==true)
            { jour.sort = "计算机技术"; }
         else if(this.RadioButton6.Checked==true)
            { jour.sort = "其他"; }
            try
            {
                jour.username = Session["username"].ToString();//用户名
                jour.name = Session["name"].ToString();//姓名
            }
            catch (Exception)
            {                
                throw;
            }
            jour.createtime = DateTime.Now;
             int a=  new BLL_insert_Journaltable().insert_Journaltable_where_username(jour);
             if (a>0)
             {
                 Page.ClientScript.RegisterStartupScript(typeof(string), "j", "<script>alert('保存成功')</script>");
                 //start();

             }
             else
             {
                 Page.ClientScript.RegisterStartupScript(typeof(string), "飞", "<script>alert('保存失败')</script>");
             }
       }
        


    }
    #endregion

    
}