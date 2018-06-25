using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mybloge.Model;
using System.Data.SqlClient;

namespace Mybolg.DAL
{
    /// <summary>
    /// 查看日志详细信息
    /// </summary>
    public  class DAL_Journaltable_titleID
    {
        #region 根据日志id查询日志信息
        /// <summary>根据日志id查询日志信息
        /// 根据日志id查询日志信息
        /// </summary>
        /// <param name="a"> id </param>
        /// <returns>list集合</returns>
        public List<Journaltable> select_Journaltable_where_titleID(int a)
        {

            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@titleID", a) };

            List<Journaltable> list = new List<Journaltable>();
            SqlDataReader dr = sqlHelper.ExecuteReader("select_Journaltable_where_titleID", parm);
            while (dr.Read())
            {
                Journaltable jour = new Journaltable();
                jour.titleID = Convert.ToInt32(dr["titleID"]);
                jour.title = dr["title"].ToString();
                jour.createtime = Convert.ToDateTime(dr["createtime"]);
                jour.username = dr["username"].ToString();
                jour.name = dr["name"].ToString();
                jour.digests = dr["digests"].ToString();
                jour.content = dr["content"].ToString();
                jour.Clicks = Convert.ToInt32(dr["Clicks"]);
                jour.commentnum = Convert.ToInt32(dr["commentnum"]);
                jour.sort = dr["sort"].ToString();
                jour.islook = Convert.ToInt32(dr["islook"]);
                jour.iscomment = Convert.ToInt32(dr["iscomment"]);

                list.Add(jour);
            }
            return list;
        } 
        #endregion

        #region 查询评论 
		/// <summary>
        /// 查询评论
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public List<comment> select_commenttable_where_titleID( int a )
        {
            List<comment> list = new List<comment>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@titleID", a) };
            SqlDataReader dr = sqlHelper.ExecuteReader("select_commenttable_where_titleID",parm );
            while ( dr.Read ())
            {
                comment ct = new comment();
                  ct.commentname =dr["number"].ToString ();
                  ct.titleID =Convert .ToInt32 ( dr["titleID"]);
                  ct.commenttime  =Convert .ToDateTime ( dr["commenttime"]);
                  ct.commentname  =dr["commentname"].ToString ();
                  ct.comments  =dr["comment"].ToString ();
                  list.Add(ct);
            }
            return list;
   

        }
      
	#endregion

        /// <summary>
        /// 评论表中插入数据
        /// </summary>
        /// <returns></returns>
        public int insert_commenttable_titleID( comment ct)
        {
            SqlParameter[] parm = new SqlParameter[] 
            {
                //new SqlParameter ("@number",ct.number ),
                new SqlParameter ("@titleID",ct.titleID ),
                new SqlParameter ("@commenttime",ct.commenttime ),
                new SqlParameter ("@commentname",ct.commentname ),
                new SqlParameter ("@comment",ct.comments )
            };
            int a = sqlHelper.ExecuteNonQuery("insert_commenttable_titleID",parm );
            return a;
        }
    }
}
    //@number   int ,    ----评论编号
    //@titleID   int ,                           ----日志编号   
    //@commenttime  datetime,        ----评论时间
    //@commentname   nvarchar(50), ----评论用户名 
    //@comment      text   -----评语