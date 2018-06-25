using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mybloge.BLL;
using Mybloge.Model;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
              if(Session ["username"]==null)
              {
                  //if (Session["NAME"] != null)//当有人点击姓名时
                  //{
                  //    string username = Session["dangName"].ToString();
                  //    List<UserRegistration> list = new BLL_Journal().BLL_select_UserRegistration_ismaster_name(username);      
                  //    int count = new BLL_Journal().BLL_select_Blogtable_count(username); //查询博客表中存在的记录数

                     
                  //    this.LblName.Text =list [0].Name ;
                  //    this.LblAdress.Text =list [0].address ;
                  //    this.LblVisitor.Text = username;
                  //    if(count !=0)
                  //    {
                  //        List<Blogtable> liste = new BLL_Journal().BLL_select_Blogtable_all(username);//查询博客表中的记录
                  //        this.LblBokeSystem.Text = liste[0].selfname;
                  //        this.LblDescribe.Text = liste[0].describe;
                  //        this.Image1.ImageUrl = liste[0].userphoto;//博客图片url
                  //        //this.LblAdress.Text = address;    //显示地址
                  //    }
                  //    else 
                  //    {
                  //        this.LblBokeSystem.Text = username;
                  //        this.LblDescribe.Text = list[0].Name+"的博客"; 
                  //        this.Image1.ImageUrl = "~/image/blogmaster.jpg";

                  //    }
                     
                      
                  //}
                  //else {
                  this.Image1.ImageUrl = "~/image/blogmaster.jpg";
                  this.LblName.Text = "lanyu";
                  this.LblAdress.Text = "无极天天";
                  this.LblVisitor.Text = "lanyu游客";
                  this.LblBokeSystem.Text = "社区博客系统";
                  this.LblDescribe.Text = "博闻天下";
                       //}
                 

              }
                  //如果不等于NuLL则如下
            else
              {
                  string username= Session["username"].ToString();
                  //if (Session["NAME"]!=null)
                  //{ username =Session ["dangName"].ToString ();}
                  
                  this.lbtngerenshezhi.Visible = true;    //个仍设置
                  this.lbtnfabiaowenzhang.Visible = true;  //发表日志
                  this.LBtnBlog.Visible = true;       //  个人博客按钮

                  this.Label1.Text = "帅哥止步，美女放行。";
                  //if (Session["NAME"] != null)
                  //{

                  //    this.LblVisitor.Text = username;

                  //}
                  //else {
                      this.LblVisitor.Visible = false;
                      this.Label2.Visible = false;
                  //}
                  //   //  
                 

                  List<UserRegistration> list = new BLL_Journal().BLL_select_UserRegistration_ismaster_name(username );                
                  int count= new BLL_Journal().BLL_select_Blogtable_count(username ); //查询博客表中存在的记录数
                  
                  int mast = list[0].usermaster;//是否是管理员
                  string Name = list[0].Name;   //姓名
                  string address = list[0].address;//地址
                  this.LblName.Text = Name;     // 姓名  
                  Session["name"] = Name;   //用户姓名
                  if( count !=0)
                  {
                      List<Blogtable> liste = new BLL_Journal().BLL_select_Blogtable_all(username);//查询博客表中的记录
                      this.LblBokeSystem.Text = liste[0].selfname;
                      this.LblDescribe.Text =liste[0].describe;
                      this.Image1.ImageUrl =liste [0].userphoto ;//博客图片url
                      this.LblAdress.Text = address;    //显示地址
                  }
                  else {
                  this.LblBokeSystem.Text = Name;  //博客名称
                  this.LblDescribe.Text =  Name +"的博客"; //博客描述
                  this.LblAdress.Text = address;    //显示地址
                       }
                   if( mast ==0)
                  {                      
                      this.lbtnshangchuantupian.Visible = true;
                      this.lbtnweihuxiangce.Visible = true;
                   }
                   this.lbtndenglu.Text = "退出";
                  
              }
                    
        
        
        }
        
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        //string stred=this.lbtndenglu .Text ;
        if( Session ["username"]!=null)
        {

            Session.Clear();
            Response.Redirect(@"~/bogleaspx/JournalList.aspx");
            
        }
        else
        {
        Response.Redirect(@"~/MimeLogin.aspx");
        }

    }

    //首页
    protected void LBtnHomePage_Click(object sender, EventArgs e)
    {
        Session["sort"] = null;
        Response.Redirect(@"~/bogleaspx/JournalList.aspx");
    }
    //个人博客主页
    protected void LBtnBlog_Click(object sender, EventArgs e)
    {
        Session["sort"] = null;
         Response.Redirect(@"~/bogleaspx/JournalList.aspx?a=1");
    }

    protected void LinkButton6_Click(object sender, EventArgs e)
    {//体育
        Session["NO"] = 1;
        Session ["sort"]="体育";
        Response.Redirect(@"~/bogleaspx/JournalList.aspx?a=2");
    }
    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        //财经
        Session["NO"] = 1;
        Session["sort"] = "财经";
        Response.Redirect(@"~/bogleaspx/JournalList.aspx?a=2");
    }
    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        //房产
        Session["sort"] = "房产"; Session["NO"] = 1;
        Response.Redirect(@"~/bogleaspx/JournalList.aspx?a=2");
    }
    protected void LinkButton9_Click(object sender, EventArgs e)
    {
        //娱乐
        Session["sort"] = "娱乐"; Session["NO"] = 1;
        Response.Redirect(@"~/bogleaspx/JournalList.aspx?a=2");
    }
    protected void LinkButton10_Click(object sender, EventArgs e)
    {
        //计算机技术
        Session["sort"] = "计算机技术"; Session["NO"] = 1;
        Response.Redirect(@"~/bogleaspx/JournalList.aspx?a=2");
    }
    protected void LinkButton11_Click(object sender, EventArgs e)
    {
        //其他
        Session["sort"] = "其他"; Session["NO"] = 1;
        Response.Redirect(@"~/bogleaspx/JournalList.aspx?a=2");
    }
    /// <summary>
    /// 个人设置
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtngerenshezhi_Click(object sender, EventArgs e)
    {

        Response.Redirect(@"~/bogleaspx/MyNes.aspx");
    }
    //上传图片
    protected void lbtnshangchuantupian_Click(object sender, EventArgs e)
    {
        Response.Redirect(@"~/bogleaspx/UploadPhotos.aspx");
    }
    //相册
    protected void LBtnphoto_Click(object sender, EventArgs e)
    {
       Response.Redirect(@"~/bogleaspx/Browsing photo.aspx");
    }
    //维护相册
    protected void lbtnweihuxiangce_Click(object sender, EventArgs e)
    {
        Response.Redirect(@"~/bogleaspx/MaintainPhoto.aspx");
    }
    /// <summary>
    /// 发表日志
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtnfabiaowenzhang_Click(object sender, EventArgs e)
    {
        Response.Redirect(@"~/bogleaspx/editorlog.aspx");
    }
}
