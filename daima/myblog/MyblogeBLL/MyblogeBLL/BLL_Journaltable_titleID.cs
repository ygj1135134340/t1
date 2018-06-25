using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mybloge.Model;
using Mybolg.DAL;
using System.Data.SqlClient;


namespace Mybloge.BLL
{
    public  class BLL_Journaltable_titleID
    {
        #region   根据日志id查询日志信息
        /// <summary>
        /// 根据日志id查询日志信息
        /// </summary>
        /// <param name="a"> id </param>
        /// <returns>list集合</returns>
        public List<Journaltable> BLL_select_Journaltable_where_titleID(int a)
        {
            return new DAL_Journaltable_titleID().select_Journaltable_where_titleID(a);
        } 
        #endregion




        #region 查询评论
        /// <summary>
        /// 查询评论
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public List<comment> BLL_select_commenttable_where_titleID(int a)
        {
            return new DAL_Journaltable_titleID().select_commenttable_where_titleID(a);
        }
        
        #endregion



        #region 评论表中插入数据
        /// <summary>
        /// 评论表中插入数据
        /// </summary>
        /// <returns></returns>
        public int insert_commenttable_titleID(comment ct)
        {
            return new DAL_Journaltable_titleID().insert_commenttable_titleID(ct);
        } 
        #endregion
    }
}
