using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mybloge.Model;
using Mybloge.BLL;

public partial class bogleaspx_JournalList : System.Web.UI.Page
{


    static int pagecount;//总页数

    int aaaaaa;
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            ViewState["Page"] = 1;//初始化当前页面
            aaaaaa = Convert.ToInt32(ViewState["Page"]);
            Session["NAME"] = null;
            if (Session["NAME"] != null)
            {
                start();
            }
            else { start(); }
            //start();

        }
        //if(Session["NAME"] != null)
        //{
        //     start();
        //}
    }
    protected void odsjournal_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {

    }

    #region 删除
    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void dljourer_DeleteCommand(object source, DataListCommandEventArgs e)
    {

        int index = e.Item.ItemIndex;
        //string id = this.dljourer.DataKeys[index].ToString();
        int id = Convert.ToInt32(this.dljourer.DataKeys[index]);
        int n = new BLL_Journal().BLL_delete_journaltable_where_titleID(id);
        if (n != 0)
        {
            Page.ClientScript.RegisterStartupScript(typeof(string), "j", "<script>alert('删除成功')</script>");
            start();

        }
        else
        {
            Page.ClientScript.RegisterStartupScript(typeof(string), "飞", "<script>alert('删除失败')</script>");
        }

    }
    #endregion
    #region 编辑
    /// <summary>
    ///编辑
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void dljourer_EditCommand(object source, DataListCommandEventArgs e)
    {

    }
    #endregion
    #region 项在被绑定后激发
    /// <summary>
    /// 项在被绑定后激发
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dljourer_ItemDataBound(object sender, DataListItemEventArgs e)
    {
    }
    #endregion
    #region 首页
    /// <summary>
    /// 首页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbfirstPage_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["a"] == "2")
        {
            if (Convert.ToInt32(Session["NAME"]) == 0)
            {
                ViewState["Page"] = 1;
                start();
            }
            else
            {

            }
            Session["NO"] = 1;
            start();
        }
        else
        {
            ViewState["Page"] = 1;
            start();
        }


    }
    #endregion
    #region 上一页
    /// <summary>
    ///上一页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbbeforePage_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["a"] == "6")
        {
            if (Convert.ToInt32(Session["NAME"]) == 0)
            {
                int a = Convert.ToInt32(ViewState["Page"]);
                if (a <= pagecount && a > 1)
                {
                    ViewState["Page"] = Convert.ToInt32(ViewState["Page"]) - 1;
                    start();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(typeof(string), "s", "<script>alert('已经是第一页了')</script>");
                }
            }
            else
            {
                int a = Convert.ToInt32(ViewState["Page"]);
                if (a <= pagecount && a > 1)
                {
                    Session["NO"] = Convert.ToInt32(Session["NO"]) - 1;
                    start();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(typeof(string), "s", "<script>alert('已经是第一页了')</script>");
                }
            }
        }
        else
        {
            int a = Convert.ToInt32(ViewState["Page"]);
            if (a <= pagecount && a > 1)
            {
                ViewState["Page"] = Convert.ToInt32(ViewState["Page"]) - 1;
                start();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(typeof(string), "s", "<script>alert('已经是第一页了')</script>");
            }
        }

    }
    #endregion
    #region 下一页
    /// <summary>
    /// 下一页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbafterPage_Click(object sender, EventArgs e)
    {

        if (Request.QueryString["a"] == "6")
        {
            if (Convert.ToInt32(Session["NAME"]) == 0)
            {
                if (Convert.ToInt32(ViewState["Page"]) < pagecount)
                {
                    ViewState["Page"] = Convert.ToInt32(ViewState["Page"]) + 1;
                    start();

                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(typeof(string), "s", "<script>alert('已经是最后一页了')</script>");
                }

            }
            else
            {
                if (Convert.ToInt32(Session["NO"]) < pagecount)
                {
                    Session["NO"] = Convert.ToInt32(Session["NO"]) + 1;
                    start();

                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(typeof(string), "s", "<script>alert('已经是最后一页了')</script>");
                }
            }
        }
        else
        {
            if (Convert.ToInt32(ViewState["Page"]) < pagecount)
            {
                ViewState["Page"] = Convert.ToInt32(ViewState["Page"]) + 1;
                start();

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(typeof(string), "s", "<script>alert('已经是最后一页了')</script>");
            }
        }
    }
    #endregion
    #region 跳转
    /// <summary>
    /// 跳转
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbgo_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["a"] == "2")
        {
            if (Convert.ToInt32(Session["NAME"]) == 0)
            {
                int res = 0;
                if (!int.TryParse(txtPage.Text, out res))
                {
                    Page.ClientScript.RegisterStartupScript(typeof(string), "s", "<script>alert('请输入数字')</script>");
                }
                else if (res <= pagecount && res >= 1)
                {
                    ViewState["Page"] = txtPage.Text;
                    start();

                }
            }
            else
            {
                int res = 0;
                if (!int.TryParse(txtPage.Text, out res))
                {
                    Page.ClientScript.RegisterStartupScript(typeof(string), "s", "<script>alert('请输入数字')</script>");
                }
                else if (res <= pagecount && res >= 1)
                {
                    Session["NO"] = txtPage.Text;
                    start();
                }
            }
        }
        else
        {
            int res = 0;
            if (!int.TryParse(txtPage.Text, out res))
            {
                Page.ClientScript.RegisterStartupScript(typeof(string), "s", "<script>alert('请输入数字')</script>");
            }
            else if (res <= pagecount && res >= 1)
            {
                ViewState["Page"] = txtPage.Text;
                start();

            }
        }
    }
    #endregion
    #region 尾页
    /// <summary>
    /// 尾页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lblastPage_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["a"] == "2")
        {
            if (Convert.ToInt32(Session["NAME"]) == 0)
            {
                ViewState["Page"] = pagecount;
                start();
            }
            else
            {
                Session["NO"] = pagecount;
                start();
            }
        }
        else
        {
            ViewState["Page"] = pagecount;
            start();
        }


    }
    #endregion

    #region 验证是否是管理员
    /// <summary>
    /// 验证是否是管理员
    /// </summary>
    public void start()
    {

        #region 1
        ////////////  单击个人（bolge）博客时
        if (Session["username"] != null && Request.QueryString["a"] == "1")
        {

            string username = Session["username"].ToString();//用户名
            this.dljourer.DataSource = new BLL_Journal().BLL_proc_selct_Journaltable_userblog(username, 10, Convert.ToInt32(ViewState["Page"]), ref pagecount);
            dljourer.DataBind();
            for (int i = 0; i < dljourer.Items.Count; i++)
            {
                (this.dljourer.Items[i].FindControl("lbtneditor") as LinkButton).Visible = true;
                (this.dljourer.Items[i].FindControl("lbtndelete") as LinkButton).Visible = true;
            }

        }
        #endregion


        //////////////// 如果有用户登录
        else if (Session["username"] != null && Request.QueryString["a"] != "1")   // 如果有用户登录
        {

            string stre = Session["username"].ToString();
            int a = new BLL_Journal().BLL_select_UserRegistration_ismaster(stre);  //如果等于0表示管理员登陆  如果是1 普通用户



            if (a != 0)//如果是普通用户
            {
                if (Request.QueryString["a"] == "2")//如果单击的是分类表
                {
                    if (Session["NAME"] != null)
                    {
                        string nameN = Session["UsName"].ToString();
                        this.dljourer.DataSource = new BLL_Journal().Page_select_journaltable_where_name_putongusername(nameN, 6, Convert.ToInt32(ViewState["Page"]), ref pagecount);
                        List<Journaltable> listes = new BLL_Journal().Page_select_journaltable_where_name_putongusername(nameN, 6, Convert.ToInt32(ViewState["Page"]), ref pagecount);
                        for (int j = 0; j < listes.Count; j++)
                        {
                            string astr = listes[j].username;
                            if (stre == astr)
                            {
                                (this.dljourer.Items[j].FindControl("lbtneditor") as LinkButton).Visible = true;
                                (this.dljourer.Items[j].FindControl("lbtndelete") as LinkButton).Visible = true;
                            }
                            int ao = listes[j].iscomment;
                            if (ao == 1)
                            {
                                (this.dljourer.Items[j].FindControl("lbtnVisitor") as LinkButton).Visible = false;
                            }
                        }
                    }
                    else
                    {

                        int abc = Convert.ToInt32(Session["NO"]);
                        string stsort = Session["sort"].ToString();
                        //绑定数据到数据源       
                        this.dljourer.DataSource = new BLL_Journal().BLL_proc_select_Journaltable_sort_all(stsort, 6, abc, ref pagecount);
                        dljourer.DataBind();
                        //如果用户日志禁止评论则不输出评论信息
                        List<Journaltable> liste = new BLL_Journal().BLL_proc_select_Journaltable_sort_all(stsort, 6, abc, ref pagecount);
                        for (int j = 0; j < liste.Count; j++)
                        {
                            string astr = liste[j].username;
                            if (stre == astr)
                            {
                                (this.dljourer.Items[j].FindControl("lbtneditor") as LinkButton).Visible = true;
                                (this.dljourer.Items[j].FindControl("lbtndelete") as LinkButton).Visible = true;
                            }
                            int ao = liste[j].iscomment;
                            if (ao == 1)
                            {
                                (this.dljourer.Items[j].FindControl("lbtnVisitor") as LinkButton).Visible = false;
                            }
                        }
                    }
                }
                else//如果单击的不是分类表
                {
                    if (Session["NAME"] != null)
                    {
                        string nameN = Session["UsName"].ToString();
                        this.dljourer.DataSource = new BLL_Journal().Page_select_journaltable_where_name_putongusername(nameN, 6, Convert.ToInt32(ViewState["Page"]), ref pagecount);
                        List<Journaltable> listes = new BLL_Journal().Page_select_journaltable_where_name_putongusername(nameN, 6, Convert.ToInt32(ViewState["Page"]), ref pagecount);
                        for (int j = 0; j < listes.Count; j++)
                        {
                            string astr = listes[j].username;
                            if (stre == astr)
                            {
                                (this.dljourer.Items[j].FindControl("lbtneditor") as LinkButton).Visible = true;
                                (this.dljourer.Items[j].FindControl("lbtndelete") as LinkButton).Visible = true;
                            }
                            int ao = listes[j].iscomment;
                            if (ao == 1)
                            {
                                (this.dljourer.Items[j].FindControl("lbtnVisitor") as LinkButton).Visible = false;
                            }
                        }
                    }
                    else
                    {
                        //如果是普通用户登录则进行如下：
                        string username = Session["username"].ToString();
                        this.dljourer.DataSource = new BLL_Journal().BLL_Proc_select_Journaltable_all(6, Convert.ToInt32(ViewState["Page"]), ref pagecount);
                        List<Journaltable> li = new BLL_Journal().BLL_Proc_select_Journaltable_all(6, Convert.ToInt32(ViewState["Page"]), ref pagecount);
                        dljourer.DataBind();
                        for (int i = 0; i < dljourer.Items.Count; i++)
                        {
                            string astr = li[i].username;
                            if (username == astr)
                            {
                                (this.dljourer.Items[i].FindControl("lbtneditor") as LinkButton).Visible = true;
                                (this.dljourer.Items[i].FindControl("lbtndelete") as LinkButton).Visible = true;
                            }
                        }
                    }
                }
            }


            else if (a == 0) //如果是管理员登录则 编辑 删除按钮 可显示
            {
                if (Request.QueryString["a"] == "2")
                {

                    if (Session["NAME"] != null)
                    {
                        string nameN = Session["UsName"].ToString();
                        this.dljourer.DataSource = new BLL_Journal().Page_admin_select_journaltable_where_name_putongusername(nameN, 6, Convert.ToInt32(ViewState["Page"]), ref pagecount);
                        List<Journaltable> listes = new BLL_Journal().Page_admin_select_journaltable_where_name_putongusername(nameN, 6, Convert.ToInt32(ViewState["Page"]), ref pagecount);
                        dljourer.DataBind();
                        for (int i = 0; i < dljourer.Items.Count; i++)
                        {
                            (this.dljourer.Items[i].FindControl("lbtneditor") as LinkButton).Visible = true;
                            (this.dljourer.Items[i].FindControl("lbtndelete") as LinkButton).Visible = true;
                        }
                    }
                    else
                    {
                        string sort = Session["sort"].ToString();
                        int abc = Convert.ToInt32(Session["NO"]);
                        this.dljourer.DataSource = new BLL_Journal().BLL_proc_select_Journaltable_sort_alls(sort, 6, abc, ref pagecount);
                        dljourer.DataBind();
                        for (int i = 0; i < dljourer.Items.Count; i++)
                        {
                            (this.dljourer.Items[i].FindControl("lbtneditor") as LinkButton).Visible = true;
                            (this.dljourer.Items[i].FindControl("lbtndelete") as LinkButton).Visible = true;
                        }
                    }
                }
                else
                {

                    if (Session["NAME"] != null)
                    {
                        string nameN = Session["UsName"].ToString();
                        this.dljourer.DataSource = new BLL_Journal().Page_admin_select_journaltable_where_name_putongusername(nameN, 6, Convert.ToInt32(ViewState["Page"]), ref pagecount);
                        List<Journaltable> listes = new BLL_Journal().Page_admin_select_journaltable_where_name_putongusername(nameN, 6, Convert.ToInt32(ViewState["Page"]), ref pagecount);
                        dljourer.DataBind();
                        for (int i = 0; i < dljourer.Items.Count; i++)
                        {
                            (this.dljourer.Items[i].FindControl("lbtneditor") as LinkButton).Visible = true;
                            (this.dljourer.Items[i].FindControl("lbtndelete") as LinkButton).Visible = true;
                        }
                    }
                    else
                    {
                        //将日志表中所有数据绑定到数据源 
                        this.dljourer.DataSource = new BLL_Journal().BLL_Proc_master_select_Journaltable_all(6, Convert.ToInt32(ViewState["Page"]), ref pagecount);
                        dljourer.DataBind();
                        for (int i = 0; i < dljourer.Items.Count; i++)
                        {
                            (this.dljourer.Items[i].FindControl("lbtneditor") as LinkButton).Visible = true;
                            (this.dljourer.Items[i].FindControl("lbtndelete") as LinkButton).Visible = true;
                        }
                    }
                }
            }
        }
        else if (Session["username"] == null && Request.QueryString["a"] == "2")
        {
            int aaa = Convert.ToInt32(ViewState["page"]);
            int abc = Convert.ToInt32(Session["NO"]);
            string stsort = Session["sort"].ToString();
            //绑定数据到数据源       
            this.dljourer.DataSource = new BLL_Journal().BLL_proc_select_Journaltable_sort_all(stsort, 6, abc, ref pagecount);
            dljourer.DataBind();
            //如果用户日志禁止评论则不输出评论信息
            //List<Journaltable> liste = new BLL_Journal().BLL_proc_select_Journaltable_sort_all(stsort, 2, abc, ref pagecount);
            //for (int j = 0; j < liste.Count; j++)
            //{
            //    //string a = this.dljourer.Items[j].FindControl("lbliscomment").ToString();
            //    int a = liste[j].iscomment;
            //    if (a == 1)
            //    {
            //        (this.dljourer.Items[j].FindControl("lbtnVisitor") as LinkButton).Visible = false;
            //    }
            //}
            //////如果点击的是用户的姓名
            if (Session["NAME"] != null)
            {
                string nameN = Session["UsName"].ToString();
                this.dljourer.DataSource = new BLL_Journal().Page_select_journaltable_where_name_putongusername(nameN, 6, Convert.ToInt32(ViewState["Page"]), ref pagecount);
                //List<Journaltable> listes = new BLL_Journal().Page_select_journaltable_where_name_putongusername(nameN, 2, Convert.ToInt32(ViewState["Page"]), ref pagecount);
                //for (int j = 0; j < liste.Count; j++)
                //{
                //    //string a = this.dljourer.Items[j].FindControl("lbliscomment").ToString();
                //    int a = listes[j].iscomment;
                //    if (a == 1)
                //    {
                //        (this.dljourer.Items[j].FindControl("lbtnVisitor") as LinkButton).Visible = false;
                //    }
                //}
                this.dljourer.DataBind();
            }







        }

                //当游客进入界面时如下：
        else
        {
            if (Session["NAME"] == null)
            {
                //绑定数据到数据源
                this.dljourer.DataSource = new BLL_Journal().BLL_Proc_select_Journaltable_all(6, Convert.ToInt32(ViewState["Page"]), ref pagecount);
                dljourer.DataBind();
                //如果用户日志禁止评论则不输出评论信息
                //List<Journaltable> list = new BLL_Journal().BLL_select_Journaltable_all();
                //List<Journaltable> liste = new BLL_Journal().BLL_Proc_select_Journaltable_all(2, Convert.ToInt32(ViewState["Page"]), ref pagecount);
                //for (int j = 0; j < liste.Count; j++)
                //{
                //    //string a = this.dljourer.Items[j].FindControl("lbliscomment").ToString();
                //    int a = liste[j].iscomment;
                //    if (a == 1)
                //    {
                //        (this.dljourer.Items[j].FindControl("lbtnVisitor") as LinkButton).Visible = false;
                //    }
                //}
            }
            //////////如果点击的是某用户的姓名
            else if (Session["NAME"] != null)
            {
                string nameN = Session["UsName"].ToString();
                this.dljourer.DataSource = new BLL_Journal().Page_select_journaltable_where_name_putongusername(nameN, 6, Convert.ToInt32(ViewState["Page"]), ref pagecount);
                //List<Journaltable> listes = new BLL_Journal().Page_select_journaltable_where_name_putongusername(nameN, 2, Convert.ToInt32(ViewState["Page"]), ref pagecount);
                //for (int j = 0; j < listes.Count; j++)
                //{
                //    //string a = this.dljourer.Items[j].FindControl("lbliscomment").ToString();
                //    int a = listes[j].iscomment;
                //    if (a == 1)
                //    {
                //        (this.dljourer.Items[j].FindControl("lbtnVisitor") as LinkButton).Visible = false;
                //    }
                //}
                this.dljourer.DataBind();
            }
        }

    }
    #endregion

    #region 标题绑定ID
    protected void LinkButton18_Click(object sender, EventArgs e)
    {

    }
    #endregion

    protected void dljourer_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "name")
        {
            int ID = Convert.ToInt32(e.CommandArgument);
            Session["ISD"] = ID;
            Response.Redirect(@"~/bogleaspx/discussBolge.aspx?");
        }
        else if (e.CommandName == "lbtnUserName")
        {

            string a = this.dljourer.DataKeys[e.Item.ItemIndex].ToString();//获取当前选择项的主键值
            //Session["dang"]=a;
            Label tbox = (Label)dljourer.Items[e.Item.ItemIndex].FindControl("lblusername");//获取当选择项的某控件值
            string ddd = tbox.Text.Trim();
            string name = e.CommandArgument.ToString();
            Session["UsName"] = name;//当前选择项的CommandArgument 值
            Session["NAME"] = 0;
            Session["dangName"] = ddd;
            start();//加载 某姓名的日志的方法


            //if (Session["NAME"] != null)//当有人点击姓名时
            //{
            string username = ddd;// Session["dangName"].ToString();
            List<UserRegistration> list = new BLL_Journal().BLL_select_UserRegistration_ismaster_name(username);
            int count = new BLL_Journal().BLL_select_Blogtable_count(username); //查询博客表中存在的记录数

            Label LblName = this.Master.FindControl("LblName") as Label;
            LblName.Text = list[0].Name;  //姓名

            Label LblAdress = this.Master.FindControl("LblAdress") as Label;
            LblAdress.Text = list[0].address;//地址

            Label LblVisitor = this.Master.FindControl("LblVisitor") as Label;
            if (Session["username"] != null)    //如果当前由用户登录
            {
                LblVisitor.Visible = true;
                LblVisitor.Text = username;//访问用户名
                Label Label1 = this.Master.FindControl("Label1") as Label;
                Label Label2 = this.Master.FindControl("Label2") as Label;
                Label1.Visible = true;
                Label2.Visible = true;
            }
            else//如果当前没有用户登录
            {
                LblVisitor.Text = "游客";//访问用户名
            }


            if (count != 0)
            {
                List<Blogtable> liste = new BLL_Journal().BLL_select_Blogtable_all(username);//查询博客表中的记录

                Label LblBokeSystem = this.Master.FindControl("LblBokeSystem") as Label;
                LblBokeSystem.Text = liste[0].selfname;//博客名

                Label LblDescribe = this.Master.FindControl("LblDescribe") as Label;
                LblDescribe.Text = liste[0].describe; //博客描述

                Image Image1 = this.Master.FindControl("Image1") as Image;
                Image1.ImageUrl = liste[0].userphoto;//博客图片url
                //this.LblAdress.Text = address;    //显示地址
            }
            else
            {
                Label LblBokeSystem = this.Master.FindControl("LblBokeSystem") as Label;
                LblBokeSystem.Text = username;

                Label LblDescribe = this.Master.FindControl("LblDescribe") as Label;
                LblDescribe.Text = list[0].Name + "的博客";

                Image Image1 = this.Master.FindControl("Image1") as Image;
                Image1.ImageUrl = "~/image/blogmaster.jpg";

            }

        }

        else if (e.CommandName == "UpdateClick")
        {
            int ID = Convert.ToInt32(e.CommandArgument);
            Session["edittitleID"] = ID;
            Response.Redirect(@"~/bogleaspx/editorlog.aspx");
        }


    }


    protected void LinkButton17_Click(object sender, EventArgs e)
    {//用户姓名

        //int titleID = Convert.ToInt32(this.dljourer.DataKeys.v);
        //List<Journaltable> list = new BLL_Journaltable_titleID().BLL_select_Journaltable_where_titleID(titleID);
        //string name = list[0].name;
        ////string name = e.CommandArgument.ToString();
        //Session["UsName"] = name;
        //Session["NAME"] = 0;
    }
    protected void dljourer_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}