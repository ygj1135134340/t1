using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mybloge.Model;
using System.Data.SqlClient;


namespace Mybolg.DAL
{
    /// <summary>
    /// 相册维护
    /// </summary>
    public  class DAL_photoalbum
    {
        #region 维护相册查询所有相册表中相册的信息
        /// <summary>
        /// 维护相册查询所有相册表中相册的信息
        /// </summary>
        /// <returns>List</returns>
        public List<model_photoalbum> select_photoalbum_all()
        {
            List<model_photoalbum> list = new List<model_photoalbum>();
            SqlDataReader dr = sqlHelper.ExecuteReader("select_photoalbum_all");
            while (dr.Read())
            {
                model_photoalbum me = new model_photoalbum();
                me.photoalbumID = Convert.ToInt32(dr["photoalbumID"]);
                me.photobumName = dr["photobumName"].ToString();
                me.photobumcribe = dr["photobumcribe"].ToString();
                list.Add(me);
            }
  
            return list;
        } 
        #endregion



        #region 向相册表中插入相册
        /// <summary>
        /// 向相册表中插入相册
        /// </summary>
        /// <param name="pho"></param>
        /// <returns></returns>
        public int insert_photoalbum_data_ExecuteNonQuery(model_photoalbum pho)
        {
            SqlParameter[] parm = new SqlParameter[] 
            {
                new SqlParameter ("@photobumName",pho.photobumName ),
                new SqlParameter ("@photobumcribe",pho.photobumcribe)
            };
            int a = sqlHelper.ExecuteNonQuery("insert_photoalbum_data", parm);
            return a;
        } 
        #endregion

        #region 更新相册表中数据根据相册ID
        /// <summary>
        /// --更新相册表中数据根据相册ID
        /// </summary>
        /// <param name="pho"></param>
        /// <returns></returns>
        public int update_photoalbum_where_ID(model_photoalbum pho)
        {
            SqlParameter[] parm = new SqlParameter[] 
            {
                new  SqlParameter("@photoalbumID",pho.photoalbumID ), 
                new SqlParameter ("@photobumName",pho.photobumName ),
                new SqlParameter ("@photobumcribe",pho.photobumcribe)
            };
            int a = sqlHelper.ExecuteNonQuery("update_photoalbum_where_ID", parm);
            return a;
        } 
        #endregion


        #region 删除 
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int delete_photoalbum_where_ID(int ID)
        {
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@photoalbumID", ID) };
            int a = sqlHelper.ExecuteNonQuery("delete_photoalbum_where_ID", parm);
            return a;
        } 
        #endregion

       
    }
}
