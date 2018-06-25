using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mybloge.Model;
using Mybloge.BLL;
using System.Data.SqlClient;

public partial class bogleaspx_MaintainPhoto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            this . GVwMaintainPhoto.DataSource = new BLL_photoalbum().BLL_select_photoalbum_all();
            this.GVwMaintainPhoto.DataBind();
           
        }
    }
    /// <summary>
    /// gridview_RowEditing
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GVwMaintainPhoto_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GVwMaintainPhoto.EditIndex = e.NewEditIndex;
  
    }



    protected void GVwMaintainPhoto_SelectedIndexChanged(object sender, EventArgs e)
    {

    }



    protected void GVwMaintainPhoto_RowUpdating(object sender, GridViewUpdateEventArgs e)
 {        
        model_photoalbum bum = new model_photoalbum();
        bum.photoalbumID =Convert .ToInt32 ( this.GVwMaintainPhoto.DataKeys[e.RowIndex ].Value );        
        TextBox box=GVwMaintainPhoto.Rows[e.RowIndex].Cells[0].FindControl ("TextBox1")as TextBox;
        TextBox boc = GVwMaintainPhoto.Rows[e.RowIndex].Cells[0].FindControl("TextBox2") as TextBox;       
        bum.photobumName= box.Text ;
        bum.photobumcribe = boc.Text;
        int a = new BLL_photoalbum().update_photoalbum_where_ID(bum);
    }
    /// <summary>
    /// 取消
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GVwMaintainPhoto_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GVwMaintainPhoto.EditIndex = -1;
        this.GVwMaintainPhoto.DataSource = new BLL_photoalbum().BLL_select_photoalbum_all();
        this.GVwMaintainPhoto.DataBind();

    }
    protected void GVwMaintainPhoto_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //
         int photoalbumID = Convert.ToInt32(this.GVwMaintainPhoto.DataKeys[e.RowIndex].Value);
         int c = new BLL_photoalbum().update_photoalbum_where_ID(photoalbumID);
         this.GVwMaintainPhoto.DataSource = new BLL_photoalbum().BLL_select_photoalbum_all();
         this.GVwMaintainPhoto.DataBind();
    }
    //添加按钮
    protected void btnadd_Click(object sender, EventArgs e)
    {
        if (this.txtphotoname.Text == null || this.txtcribe.Text == null)
        { 
            { Page.ClientScript.RegisterStartupScript(typeof(string), "飞", "<script>alert(' 请输入相关信息')</script>"); }
        }
        else
        {
            model_photoalbum bum = new model_photoalbum();
            bum.photobumName = this.txtphotoname.Text.Trim();
            bum.photobumcribe = this.txtcribe.Text.Trim();

            int a = new BLL_photoalbum().BLL_insert_photoalbum_data_ExecuteNonQuery(bum);
            if (a > 0)
            { Page.ClientScript.RegisterStartupScript(typeof(string), "飞", "<script>alert('添加成功')</script>"); }
            else
            {
                Page.ClientScript.RegisterStartupScript(typeof(string), "飞", "<script>alert('添加失败')</script>");
            }
            this.GVwMaintainPhoto.DataSource = new BLL_photoalbum().BLL_select_photoalbum_all();
            this.GVwMaintainPhoto.DataBind();
        }
    }
    
}