using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mybloge.Model;
using Mybolg.DAL;
using System.Data.SqlClient;

namespace Mybloge.BLL
{
    /// <summary>
    /// 相册表
    /// </summary>
    public  class BLL_photoalbum
    {
        #region 向相册表中插入相册
        /// <summary>
        /// 向相册表中插入相册
        /// </summary>
        /// <param name="pho"></param>
        /// <returns></returns>
        public int BLL_insert_photoalbum_data_ExecuteNonQuery(model_photoalbum pho)
        {
            return new DAL_photoalbum().insert_photoalbum_data_ExecuteNonQuery(pho);
        } 
        #endregion





        #region 维护相册查询所有相册表中相册的信息
        /// <summary>
        /// 维护相册查询所有相册表中相册的信息
        /// </summary>
        /// <returns>List</returns>
        public List<model_photoalbum> BLL_select_photoalbum_all()
        {
            return new DAL_photoalbum().select_photoalbum_all();
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
            return new DAL_photoalbum().update_photoalbum_where_ID(pho);
        } 
        #endregion




        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int update_photoalbum_where_ID(int id)
        {
            return new DAL_photoalbum().delete_photoalbum_where_ID(id);
                //.update_photoalbum_where_ID(id);
        }
    }
}
