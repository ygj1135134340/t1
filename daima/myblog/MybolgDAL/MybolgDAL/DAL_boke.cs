using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mybloge.Model;
using System.Data.SqlClient;
namespace Mybolg.DAL
{
    /// <summary>
    /// 有关博客
    /// </summary>
    public  class DAL_boke
    {
        /// <summary>
        /// 个人设置中  返回受影响的行
        /// </summary>
        /// <param name="blog">实体对象  </param>
        /// <returns> int</returns>
        public int select_boge( Blogtable blog )
        {
            SqlParameter[] parm = new SqlParameter[] 
            {
                new SqlParameter ("@username",blog.username),
                new SqlParameter ("@selfname",blog.selfname),
                new SqlParameter ("@describe",blog.describe ),
                new SqlParameter ("@userphoto",blog.userphoto)
            };

            int a = sqlHelper.ExecuteNonQuery("select_Blogtable_selfnmae",parm);
            return a;

        }
    }
}
