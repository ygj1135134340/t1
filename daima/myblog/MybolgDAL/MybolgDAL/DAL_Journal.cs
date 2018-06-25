using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mybloge.Model;
using System.Data.SqlClient;
using System.Data;

namespace Mybolg.DAL
{

    //ExecuteReader（） 返回sqlDataReader  对象  以方便在业务逻辑层   list 集合对象调用
    // ExecuteNonQuery(string spName, params SqlParameter[] cmdParms)返回受影响行数  以方便验证对数据库的增删改查  是否成功
    // ExecuteScalar(string spName, params SqlParameter[] cmdParms)返回第一行第一列，可以验证注册新用户时，是否有同名账户
    // PrepareCommand(SqlCommand cmd, CommandType commandType, SqlConnection conn, string commandText, params SqlParameter[] cmdParms)
    //执行对数据库的增删改查

    /// <summary>
    /// 对日志页面的操作
    /// </summary>
    public  class DAL_Journal
    {
     //   --titleID int IDENTITY (1,1) not null,              -----日志ID
     //--title nvarchar(50) not null ,                      ----标题
     //--createtime  datetime not null,                     ----创建时间
     //--username  nvarchar(20) not null,                  ----用户名
     //--name nvarchar(10) not null primary key ,           ----姓名 
     //--digests   text  not null,                         -----摘要
     //--content  text not null,                           ---- 内容
     //--Clicks   int  not null ,                         ----点击数
     //--commentnum   int  not null ,                       ----评论数
     //--sort    nvarchar(20) not null ,             ----所属分类
     //--islook   int    ,                          ----是否可见 0可见,1比可见
     //--iscomment  int                  ---是否允许评论  0可评论,1不可评论 


        #region 根据用户名查找该用户的所有日志
        /// <summary>
        /// 根据用户名查找该用户的所有日志
        /// </summary>
        /// <param name="username"> 用户登录  用户名</param>
        /// <returns> 返回list Journaltable </returns> 
        public List<Journaltable> DAL_select_Journaltable(string username)
        {
            List<Journaltable> list = new List<Journaltable>();
            SqlParameter[] parm = new SqlParameter[] 
            {
                new SqlParameter ("@username",username )
            };

            SqlDataReader dr = sqlHelper.ExecuteReader("select_Journaltable_where_username", parm);

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


        #region 查询日志表中所有日志信息
        /// <summary>
        /// 查询日志表中所有日志信息
        /// </summary>
        /// <returns> list集合List Journaltable </returns>
        public List<Journaltable> DAL_select_Journaltable_all()
        {
            List<Journaltable> list = new List<Journaltable>();

            SqlDataReader dr = sqlHelper.ExecuteReader("select_journaltable");

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


        #region 根据日志id删除相应日志表记录
        /// <summary>
        /// 根据日志id删除相应日志表记录
        /// </summary>
        /// <param name="a">日志id参数 </param>
        /// <returns>删除记录数 数值类型</returns>
        public int DAL_delete_journaltable_where_titleID(int a)
        {
            SqlParameter[] parm = new SqlParameter[] 
            {  
                new SqlParameter ("@titleID",a)
               
            };
            int c = Convert.ToInt32(sqlHelper.ExecuteNonQuery ("proc_delete_journaltable", parm));
            return c;
        }
        
        #endregion


        #region 查询登录用户是不是博客管理员

        /// <summary>
        /// DAL查询登录用户是不是博客管理员
        /// </summary>
        /// <param name="username">登录用户名</param>
        /// <returns> int类型</returns>
        public int select_UserRegistration_ismaster(string username)
        {
            SqlParameter[] parm = new SqlParameter[] 
            {
                new SqlParameter ("@username",username )
            };

            return Convert.ToInt32(sqlHelper.ExecuteScalar("select_master_UserRegistration", parm));
        } 
        #endregion


        #region DAL查询登录用户是不是博客管理员 及 用户姓名
        /// <summary>
        /// DAL查询登录用户是不是博客管理员 及 用户姓名
        /// </summary>
        /// <param name="username">登录用户名</param>
        /// <returns> int类型</returns>
        public List<UserRegistration> select_UserRegistration_ismaster_name(string username)
        {
            List<UserRegistration> list = new List<UserRegistration>();
            SqlParameter[] parm = new SqlParameter[] 
            {
                new SqlParameter ("@username",username )
            };

            SqlDataReader dr = sqlHelper.ExecuteReader("select_name_master_UserRegistration", parm);
            dr.Read();
            UserRegistration tion = new UserRegistration();
            tion.usermaster = Convert.ToInt32(dr["usermaster"]);
            tion.Name = dr["Name"].ToString();
            //tion.address = dr["address"].ToString() ;
            list.Add(tion);
            return list;

        }  
        #endregion


        // username nvarchar(20) not null primary key,     ----用户名
        // selfname nvarchar (50),              ----个性设置博客名称
        // describe nvarchar(50),               ----自定义博客描述
        //userphoto nvarchar(50), 

        #region 根据用户名据查询博客表之中所有数
        /// <summary>
        /// 根据用户名据查询博客表之中所有数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public List<Blogtable> select_Blogtable_all(string str)
        {
            List<Blogtable> list = new List<Blogtable>();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@username", str) };

            SqlDataReader dr = sqlHelper.ExecuteReader("select_Blogtable_all", parm);
            dr.Read();

            Blogtable bl = new Blogtable();
            bl.username = dr["username"].ToString();
            bl.selfname = dr["selfname"].ToString();
            bl.describe = dr["describe"].ToString();
            bl.userphoto = dr["userphoto"].ToString();
            list.Add(bl);
            return list;


        }
        
        #endregion


        #region 查询博客表中是否存在改用户的博客信息
            /// <summary>
            ///  DAL 查询博客表中是否存在改用户的博客信息
            /// </summary>
            /// <param name="username"></param>
            /// <returns></returns>
        public int DAL_select_Blogtable_count(string username)
        {
            SqlParameter[] parm = new SqlParameter[] 
            {
                new SqlParameter ("@username",username )
            };

            return Convert.ToInt32(sqlHelper.ExecuteScalar("selectcount_bloge", parm));
        }  
        #endregion



        

        #region 分页存储过程查询全部可见信息

        #region 根据姓名查询所有日志信息
        /// <summary>
        /// 根据姓名查询所有日志信息
        /// </summary>
        /// <param name="name">姓名</param>
        /// <returns>list</returns>
        public List<Journaltable> select_Journaltable_where_name(string name)
        {
            List<Journaltable> list = new List<Journaltable>();
            SqlParameter []parm=new SqlParameter[]
            {
                new SqlParameter ("@name",name)
            };

            SqlDataReader dr = sqlHelper.ExecuteReader("select_journaltable",parm);

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


         /// <summary>
        /// 根据姓名查找该用户的所有日志信息
         /// </summary>
         /// <param name="name"></param>
         /// <param name="pagesize"></param>
         /// <param name="pageindex"></param>
         /// <param name="pagecounts"></param>
         /// <returns></returns>
        public List<Journaltable> Page_select_journaltable_where_name_putongusername( string name,int pagesize,int pageindex,ref int pagecounts)
        {
            List<Journaltable> list = new List<Journaltable>();

            string striconnection = sqlHelper.stringconnection;
            SqlConnection con = new SqlConnection(striconnection );
            con.Open();
            SqlCommand cmd = new SqlCommand("Page_select_journaltable_where_name_putongusername",con); 
            //cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandText = "Page_select_journaltable_where_name_putongusername";
            SqlParameter[] parm = new SqlParameter[] { 
            new SqlParameter ("@name",name),
            new SqlParameter ("@pageSize",pagesize),
            new SqlParameter ("@PageIndex",pageindex )
             
            };
            cmd.Parameters.AddRange(parm );
            SqlParameter pagecount = new SqlParameter("@count", SqlDbType.Int);//创建一个参数
            pagecount.Direction = ParameterDirection.Output;//设置参数类型为输出参数
            cmd.Parameters.Add(pagecount);//把参数添加到命令对象的参数列表中
            int page = Convert.ToInt32(pagecount.Value);
            pagecounts = page / pagesize;

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read ())
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











          /// <summary>
        /// 管理员根据员工姓名查询所有该用户的日志信息
         /// </summary>
         /// <param name="name"></param>
         /// <param name="pagesize"></param>
         /// <param name="pageindex"></param>
         /// <param name="pagecounts"></param>
         /// <returns></returns>
        public List<Journaltable> Page_admin_select_journaltable_where_name_putongusername(string name, int pagesize, int pageindex, ref int pagecounts)
        {
            List<Journaltable> list = new List<Journaltable>();

            string striconnection = sqlHelper.stringconnection;
            SqlConnection con = new SqlConnection(striconnection);
            con.Open();
            SqlCommand cmd =new SqlCommand ("Page_admin_select_journaltable_where_name_putongusername",con );
            //cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandText = "Page_admin_select_journaltable_where_name_putongusername";
            SqlParameter[] parm = new SqlParameter[] { 
            new SqlParameter ("@name",name),
            new SqlParameter ("@pageSize",pagesize),
            new SqlParameter ("@PageIndex",pageindex )
             
            };
            cmd.Parameters.AddRange(parm);
            SqlParameter pagecount = new SqlParameter("@count", SqlDbType.Int);//创建一个参数
            pagecount.Direction = ParameterDirection.Output;//设置参数类型为输出参数
            cmd.Parameters.Add(pagecount);//把参数添加到命令对象的参数列表中
            int   page = Convert.ToInt32(pagecount.Value);
            pagecounts = page / pagesize;

            SqlDataReader dr = cmd.ExecuteReader();
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








        #region 查询所有可见 日志信息
        /// <summary>
        /// 查询所有可见 日志信息
        /// </summary>
        /// <param name="pagesize">页大小</param>
        /// <param name="pageindex">也索引</param>
        /// <param name="count">中页数</param>
        /// <returns> List 集合Journaltable</returns>
        public List<Journaltable> DAl_proc_select_Journaltable_all(int pagesize, int pageindex, ref int pagecount)
        {
            List<Journaltable> list = new List<Journaltable>();
           
            string stion = sqlHelper.stringconnection;
            SqlConnection con2 = new SqlConnection(stion);
            con2.Open();
            SqlCommand cmd2 = new SqlCommand("all_Journaltable_N2", con2);
            cmd2.CommandType = CommandType.StoredProcedure;
            int a =Convert .ToInt32 ( cmd2.ExecuteScalar());
            //con2.Close();

            SqlConnection con = new SqlConnection(stion);
            con.Open();
            SqlCommand cmd = new SqlCommand("all_Journaltable", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter[] paarm = new SqlParameter[] 
            {               
               new SqlParameter ("@pageSize",pagesize),
               new SqlParameter ("@PageIndex",pageindex)                   
            };
            cmd.Parameters.AddRange(paarm );
            
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read ())
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
            pagecount = a / pagesize;
            return list;
          
            
            }
        
        #endregion




        #region  查询所有日志信息  ----管理员
        /// <summary>
        /// 查询所有日志信息  ----管理员
        /// </summary>
        /// <param name="pagesize">页大小</param>
        /// <param name="pageindex">也索引</param>
        /// <param name="count">中页数</param>
        /// <returns> List 集合Journaltable</returns>
        public List<Journaltable> DAl_proc_master_select_Journaltable_all(int pagesize, int pageindex, ref int pagecount)
        {
            return new DAL_Journal().DAl_proc_select_Journaltable_alls(pagesize, pageindex, ref pagecount, "all_Journaltable_admini");

           
        } 
        #endregion

       #region 查询所有个人日志
		 /// <summary>
        /// 查询所有个人日志
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="pagesize">页大小</param>
        /// <param name="pageindex">也索引</param>
        /// <param name="pagecount">总页数</param>
        /// <returns>List集合</returns>
        public List<Journaltable> DAL_proc_selct_Journaltable_userblog( string username ,int pagesize,int pageindex,ref int pagecount)
        {
            List<Journaltable> list = new List<Journaltable>();


            string stion = sqlHelper.stringconnection;
            SqlConnection con2 = new SqlConnection(stion);
            con2.Open();
            SqlCommand cmd2 = new SqlCommand("all_Journaltable_mine_N2", con2);
            cmd2.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parmd = new SqlParameter[] 
            {
               new SqlParameter ("@username",username )
            };
            cmd2.Parameters.AddRange(parmd );
            int a = Convert.ToInt32(cmd2.ExecuteScalar());
            con2.Close();



            SqlParameter[] parm = new SqlParameter[] 
            {
                new SqlParameter ("@username",username ),
                new SqlParameter ("@pageSize",pagesize),
                new SqlParameter ("@PageIndex",pageindex),
             };
            //parm[3].Direction = ParameterDirection.Output;           

            SqlDataReader dr = sqlHelper.ExecuteReader( "all_Journaltable_mine",parm);
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

             pagecount = a / pagesize;
            return list;
        } 
	#endregion


        #region  分页存储过程
       /// <summary>
       ///  分页存储过程----管理员
       /// </summary>
       /// <param name="pagesize">页大小</param>
       /// <param name="pageindex">也索引</param>
       /// <param name="count"> 总页数</param>
       /// <param name="proc">存储过程名字</param>
       /// <returns></returns>
        public List<Journaltable> DAl_proc_select_Journaltable_alls(int pagesize, int pageindex, ref int count, string proc)
        {
            List<Journaltable> list = new List<Journaltable>();

            string stion = sqlHelper.stringconnection;
            SqlConnection con2 = new SqlConnection(stion);
            con2.Open();
            SqlCommand cmd2 = new SqlCommand("all_Journaltable_N2", con2);
            cmd2.CommandType = CommandType.StoredProcedure;
            int a = Convert.ToInt32(cmd2.ExecuteScalar());
            con2.Close();  


            SqlParameter[] parm = new SqlParameter[] 
            {
                new SqlParameter ("@pageSize",pagesize ),
                new SqlParameter ("@PageIndex",pageindex),
                //new SqlParameter ("@pagecount",DbType .Int32)
            };

            //parm[2].Direction = ParameterDirection.Output;

            SqlDataReader dr = sqlHelper.ExecuteReader(proc, parm);
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

            count =a/ pagesize;
            return list;


        }


         
        
        #endregion




        
        #endregion





        #region 日志分类  存储过程


        #region 在分类的情况下 查询所有可见 日志信息
        /// <summary>
        /// 在分类的情况下 查询所有可见 日志信息
        /// </summary>
        /// <param name="pagesize">页大小</param>
        /// <param name="pageindex">也索引</param>
        /// <param name="count">中页数</param>
        /// <returns> List 集合Journaltable</returns>
        public List<Journaltable> DAl_proc_select_Journaltable_sort_all(string sort, int pagesize, int pageindex, ref int pagecount)
        {

            List<Journaltable> list = new List<Journaltable>();
            string stion = sqlHelper.stringconnection;
            SqlConnection con2 = new SqlConnection(stion);
            con2.Open();
            SqlCommand cmd2 = new SqlCommand("all_Journaltable_N2_sort", con2);
            cmd2.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parrmdd = new SqlParameter[] 
            {
             new SqlParameter ("@sort",sort)
            };
            cmd2.Parameters.AddRange(parrmdd);
            int a = Convert.ToInt32(cmd2.ExecuteScalar());
            con2.Close();




            SqlConnection con = new SqlConnection(stion);
            con.Open();
            SqlCommand cmd = new SqlCommand("all_Journaltable_sort", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter[] paarm = new SqlParameter[] 
            { 
               new SqlParameter ("@sort",sort) ,           
               new SqlParameter ("@pageSize",pagesize),
               new SqlParameter ("@PageIndex",pageindex) 
                  
            };
            cmd.Parameters.AddRange(paarm);

            SqlDataReader dr = cmd.ExecuteReader();
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
            pagecount = a / pagesize;
            return list;


        }

        #endregion




        /// <summary>
        ///  分页存储过程----管理员
        /// </summary>
        /// <param name="pagesize">页大小</param>
        /// <param name="pageindex">也索引</param>
        /// <param name="count"> 总页数</param>
        /// <param name="proc">存储过程名字</param>
        /// <returns></returns>
        public List<Journaltable> DAl_proc_select_Journaltable_sort_alls(string sort, int pagesize, int pageindex, ref int count)
        {
            List<Journaltable> list = new List<Journaltable>();

            string stion = sqlHelper.stringconnection;
            SqlConnection con2 = new SqlConnection(stion);
            con2.Open();
            SqlCommand cmd2 = new SqlCommand("all_Journaltable_N2_sort", con2);
            cmd2.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parmdd = new SqlParameter[] 
            {
               new SqlParameter ("@sort",sort)
            };
            cmd2.Parameters.AddRange(parmdd );
            int a = Convert.ToInt32(cmd2.ExecuteScalar());
            con2.Close();


            SqlParameter[] parm = new SqlParameter[] 
            {
                new SqlParameter ("@sort",sort),
                new SqlParameter ("@pageSize",pagesize ),
                new SqlParameter ("@PageIndex",pageindex)
               
            };
                                                                    
            //parm[2].Direction = ParameterDirection.Output;

            SqlDataReader dr = sqlHelper.ExecuteReader("all_Journaltable_admini_sort", parm);
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

            count = a / pagesize;
            return list;


        }
        #endregion

         
    }
}
