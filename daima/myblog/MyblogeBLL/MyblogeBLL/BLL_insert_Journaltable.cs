using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mybolg.DAL;
using Mybloge.Model;
using System.Data.SqlClient;
namespace Mybloge.BLL
{
    public  class BLL_insert_Journaltable
    {
        /// <summary>
        /// 向日志表中插入数据
        /// </summary>
        /// <param name="jou"></param>
        /// <returns></returns>
        public int insert_Journaltable_where_username(Journaltable jou)
        {
            return new DAL_insert_Journaltable().insert_Journaltable_where_username(jou);
        }


        
       /// <summary>
       /// 更新日志表中的数据
       /// </summary>
       /// <param name="jou"></param>
       /// <returns></returns>
        public int update_jourelnal_where_titleID(Journaltable jou)
        {
            return new DAL_insert_Journaltable().update_jourelnal_where_titleID(jou);
        }
    }
}
