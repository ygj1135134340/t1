using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mybloge.Model;
using Mybloge.BLL;

public partial class bogleaspx_UploadPhotos : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
       
        
    }

    //设置
    protected void btnset_Click(object sender, EventArgs e)
    {
      
        List<BlogClass> list = new List<BlogClass>();
        int num;
        if (int.TryParse(txtcount.Text, out num))//用户输入是否是数字
        {
            for (int i = 0; i < num; i++)//根据用户输入的数字创建对象绑定数据
            {
                BlogClass bl = new BlogClass();
                list.Add(bl);
            }
            gvPic.DataSource = list;
            gvPic.DataBind();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(typeof(string), "s", "<script>alert('请输入数字')</script>");
        }


    }
    //对数据绑定后激发
    protected void gvPic_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)//绑定dropdownlist控件
        {
            DropDownList ddl = (DropDownList)e.Row.Cells[3].FindControl("ddlClass");
            ddl.DataTextField = "photobumName";
            ddl.DataValueField = "photoalbumID";
            ddl.DataSource = new BLL_photo().BLL_selcet_photoalbum_count()  ;
            ddl.DataBind();
        }
    }
    //上传按钮
    protected void btnupdown_Click(object sender, EventArgs e)
    {
        int a = 0;//更新失败的个数
        foreach (GridViewRow dr in this.gvPic.Rows)
        {
            FileUpload fu = dr.FindControl("fuphotoAdress") as FileUpload;
            TextBox txtName = dr.FindControl("txtName") as TextBox;
            TextBox txtAbout = dr.FindControl("txtAbout") as TextBox;
            DropDownList ddl = dr.FindControl("ddlClass") as DropDownList;
            if (fu.HasFile)//是否存在文件
            {
                //if (fu.PostedFile.ContentType.ToLower() == "image/gif" || fu.PostedFile.ContentType.ToLower() == "application/x-img" || fu.PostedFile.ContentType.ToLower() == "image/jpeg" || fu.PostedFile.ContentType.ToLower() == "image/png")//文件格式判断
                //{
                    string guid = GetGuid();//产生唯一标识符
                    phototable pho=new phototable ();
                    pho.photoname=txtName .Text ;
                    pho .phoaddress =@"~\Photo\" + guid + fu.FileName;
                    pho.photodescribe=txtAbout.Text;
                    pho .photoalbumID=Convert .ToInt32 ( ddl.SelectedValue);
                    int dd=new BLL_photo().DAL_insert_phototable(pho);
                    if (dd>0)//插入数据库
                    {
                        string fileadress = Server.MapPath(@"~\Photo\" + guid + fu.FileName);//上传到服务器
                        fu.PostedFile.SaveAs(fileadress);

                    }
                    else
                    {
                        a++;
                    }
                //}
                //else
                //{
                //    a++;
                //}
            }
            else
            {
                a++;
            }
        }
        string msg = "<script>alert('更新失败" + a + "个')</script>";
        Page.ClientScript.RegisterStartupScript(typeof(string), "s", msg);
    }
    public string GetGuid()//唯一标识符
    {
        Guid g = Guid.NewGuid();
        return g.ToString().Substring(25);
    }
    
}