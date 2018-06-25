using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mybloge.Model;
using Mybloge.BLL;
using System.Data.SqlClient;



public partial class bogleaspx_discussBolge : System.Web.UI.Page
{
    //List<Journaltable> list = new BLL_Journaltable_titleID();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        
        
        if(!IsPostBack )
        {
          int a = Convert.ToInt32(Session["ISD"]);
            List<Journaltable> list = new BLL_Journaltable_titleID().BLL_select_Journaltable_where_titleID(a);
            this.lbltitle.Text = list[0].title;
            this.lbltime.Text = list[0].createtime.ToString("yyyy-MM-dd hh:mm:00");
            this.lbtnname.Text = list[0].name;
            this.lbldetails.Text = list[0].content;
            this.lbldiscussd.Text =  list[0].commentnum.ToString ();
            this.lblclick.Text = list[0].Clicks.ToString();
            int pp = list[0].iscomment;//是否可评论
            if(pp==1)
            { this.btnsubmit.Visible = false;this.Repeater1.Visible = false;this.Label2.Visible = false; this.txtdiscuss.Visible = false; this.CheckBoxdiscuss.Visible = false;
            
            
            }
            this.Repeater1.DataSource = new BLL_Journaltable_titleID().BLL_select_commenttable_where_titleID(a);
            this.Repeater1.DataBind();
        }

    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    //提交
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        int a = Convert.ToInt32(Session["ISD"]);
        comment ct = new comment();
        ct.comments = this.txtdiscuss.Text;
        ct.commentname = (CheckBoxdiscuss.Checked==true?"游客":Session["username"].ToString ());
        ct.titleID =a;
        ct.commenttime = DateTime.Now;
        int c= new BLL_Journaltable_titleID().insert_commenttable_titleID(ct);
        if(c>0)
        { Page.ClientScript.RegisterStartupScript(typeof(string), "j", "<script>alert('提交成功')</script>"); 
          
        }
        else {

              Page.ClientScript.RegisterStartupScript(typeof(string), "j", "<script>alert('提交失败')</script>");
        }
    }
}


      // <div style=" text-align :center ; font-size :large ; font-weight :bold;">
      //    <div><asp:Label ID="Label2" runat="server" Text="评论"></asp:Label></div>
      //    <asp:TextBox ID="txtdiscuss" runat="server" TextMode="MultiLine" 
      //        Height="177px" Width="531px"></asp:TextBox><br />
      //    <asp:CheckBox ID="CheckBoxdiscuss" runat="server"  Text ="匿名选项"/>
      //    <br />
      //    &nbsp;<asp:Button ID="btnsubmit" runat="server" Text="提交评论" 
      //        ForeColor ="#6e0d0d"  Font-Size="Large" Font-Bold="True" 
      //        onclick="btnsubmit_Click" />

      //</div>