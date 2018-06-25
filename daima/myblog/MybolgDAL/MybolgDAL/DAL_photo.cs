using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mybloge.Model;
using System.Data.SqlClient;

namespace Mybolg.DAL
{

    /// <summary>
    /// 关于相册
    /// </summary>
    public  class DAL_photo
    {
        #region 查询相册表中有哪些相册
        /// <summary>
        /// 查询相册表中有哪些相册
        /// </summary>
        /// <returns>list集合</returns>
        public List<model_photoalbum> selcet_photoalbum_count()
        {
            List<model_photoalbum> list = new List<model_photoalbum>();
            SqlDataReader dr = sqlHelper.ExecuteReader("select_photoalbum_name");
            while (dr.Read())
            {

                model_photoalbum pho = new model_photoalbum();
                pho.photoalbumID = Convert.ToInt32(dr["photoalbumID"]);
                pho.photobumName = dr["photobumName"].ToString();
                list.Add(pho);
            }

            return list;
        } 
        #endregion

        #region 像图片表中插入数据
        /// <summary>
        /// 像图片表中插入数据
        /// </summary>
        /// <param name="pho">实体对象 </param>
        /// <returns> int</returns>
        public int DAL_insert_phototable(phototable pho)
        {
            SqlParameter[] parm = new SqlParameter[] 
            {
                    new SqlParameter("@photoname",pho.photoname),
                    new SqlParameter("@photodescribe",pho.photodescribe),
                    new SqlParameter("@phoaddress ",pho .phoaddress ),
                    new SqlParameter("@photoalbumID ",pho.photoalbumID )
            };

            int a = sqlHelper.ExecuteNonQuery("insert_phototable", parm);
            return a;
        }
        
        #endregion


        #region DAL根据ID查询第一张图片url

        /// <summary>
        /// DAL根据ID查询第一张图片url
        /// </summary>
        /// <param name="ID"> 相册ID</param>
        /// <returns>url 图片 </returns>
        public string DAL_select_phoaddress_where_photoalbumID(int ID)
        {
            SqlParameter[] parm = new SqlParameter[] 
            { new SqlParameter("@photoalbumID",ID)
            };
            string stri = sqlHelper.ExecuteScalar("select_phoaddress_where_photoalbumID", parm).ToString();
            return stri;            
        } 
        #endregion
        



       #region 根据相册ID查询该相册下的所有图片		
                /// <summary>
                /// 根据相册ID查询该相册下的所有图片
                /// </summary>
                /// <param name="phbumID"></param>
                /// <returns></returns>
                public List<string> DAL_select_phototable_where_photoalbumID( int phbumID )
                {
                    List<string > list = new List<string >(); 
                    SqlParameter[] parm = new SqlParameter[] 
                    { new SqlParameter("@photoalbumID",phbumID)
                    };

                    SqlDataReader dr = sqlHelper.ExecuteReader("select_phototable_where_photoalbumID",parm );
                    while(dr.Read ())
                    {
                        phototable te = new phototable();
                        string stre = dr[0].ToString();                        
                        list.Add(stre );
                    }
                    return list;
           
                } 
	#endregion


    }
}
