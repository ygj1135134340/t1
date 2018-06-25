using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mybloge.BLL;
using Mybloge.Model;

public partial class bogleaspx_Browsing_photo : System.Web.UI.Page
{
    static List<string > list = new List<string>() { };//存储相册地址的集合，第一个地址为默认图片
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack )
        {
            ViewState["Page"] = 0;
            int ad = Convert.ToInt32(ViewState["Page"]);
            Repeater1.DataSource = new BLL_photo().BLL_selcet_photoalbum_count();
            Repeater1.DataBind();
        }
    }





    #region  返回相册表中第一张图片的urld
    /// <summary>
    /// 返回相册表中第一张图片的urld
    /// </summary>
    /// <param name="photoalbumID">相册ID </param>
    /// <returns>string</returns>
    public string iamgeurl(int photoalbumID)
    {
        return new BLL_photo().BLL_select_phoaddress_where_photoalbumID(photoalbumID);

    }
    
    #endregion





    #region     //datalist 中生成事件时激发
    //datalist 中生成事件时激发
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "image")
        {
            ViewState["Page"] = 0;
            int LogId = Convert.ToInt32(e.CommandArgument);
            list = new BLL_photo().BLL_select_phototable_where_photoalbumID(LogId);
            Imagephoto.ImageUrl = list[Convert.ToInt32(ViewState["Page"])];//根据viewstate读取list中的图片地址
            Session["Page"] = 0;
        }
    } 
    #endregion





    #region 上一张
    /// <summary>
    /// 上一张
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Lbtnprev_Click(object sender, EventArgs e)
    {
         int a=Convert.ToInt32(Session["Page"]);
            if (a-1< 0)
            {               
                string ass = list[0].ToString();
                Imagephoto.ImageUrl = list[a];

            }
            else if(a-1>=0)
            {
                Imagephoto.ImageUrl = list[a-1];
                Session["Page"] = a - 1;
            }

     

    } 
    #endregion

    #region 自动播放
    /// <summary>
    /// 自动播放
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtnautoplay_Click(object sender, EventArgs e)
    {
        if (lbtnautoplay.Text == "自动播放")
        {
            Timer.Enabled = true;
            lbtnautoplay.Text = "停止";
        }
        else
        {
            Timer.Enabled = false;
            lbtnautoplay.Text = "自动播放";
        }
    } 
    #endregion



    #region 下一张
    /// <summary>
    /// 下一张
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Lbtnnextpage_Click(object sender, EventArgs e)
    {




        int a = Convert.ToInt32(Session["Page"]);
        if (list[0] != @"~\Photo\00000000.jpg")
        {
            if (a + 1 > list.Count - 1)
            {
                Imagephoto.ImageUrl = list[0];
                Session["Page"] = 0;
            }
            else
            {
                if (a + 1 <= list.Count - 1)
                {
                    Imagephoto.ImageUrl = list[a + 1];
                    Session["Page"] = a + 1;
                }
            }
        }

      
    } 
    #endregion
    protected void Timer_Tick(object sender, EventArgs e)
    {
        int a = Convert.ToInt32(Session["Page"]);
        if (list[0] != @"~\Photo\00000000.jpg")
        {
            if (a + 1 > list.Count - 1)
            {
                Imagephoto.ImageUrl = list[0];
                Session["Page"] = 0;
            }
            else 
            {
                if(a+1<=list .Count -1)
                {
                   Imagephoto.ImageUrl = list[a+1];
                   Session["Page"] = a+1;
                }
            }
        }
        
    }
}