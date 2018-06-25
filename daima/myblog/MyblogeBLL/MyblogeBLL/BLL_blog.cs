using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mybolg.DAL;
using Mybloge.Model;
using System.Data.SqlClient;

namespace Mybloge.BLL
{
    /// <summary>
    /// 博客表
    /// </summary>
    public   class BLL_blog
    {
        /// <summary>
        /// 返回数据库搜影响的行
        /// </summary>
        /// <param name="ble"></param>
        /// <returns>int</returns>
        public int BLL_select_bolge(Blogtable ble )
        {
            return new DAL_boke().select_boge(ble);
        }


    }
}
