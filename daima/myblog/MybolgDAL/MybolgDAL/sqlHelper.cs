using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Mybolg.DAL
{


    //ExecuteReader（） 返回sqlDataReader  对象  以方便在业务逻辑层   list 集合对象调用
    // ExecuteNonQuery(string spName, params SqlParameter[] cmdParms)返回受影响行数  以方便验证对数据库的增删改查  是否成功
    // ExecuteScalar(string spName, params SqlParameter[] cmdParms)返回第一行第一列，可以验证注册新用户时，是否有同名账户
    // PrepareCommand(SqlCommand cmd, CommandType commandType, SqlConnection conn, string commandText, params SqlParameter[] cmdParms)
    //执行对数据库的增删改查
    public class sqlHelper
    {
        public static string stringconnection = ConfigurationManager.ConnectionStrings["Mineblog"].ConnectionString;

        
        #region 返回sqlDataReader  对象  以方便在业务逻辑层   list 集合对象调用
        /// <summary>
        ///  执行sql命令   返回sqlDataReader  对象  以方便在业务逻辑层   list 集合对象调用
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="commandType">命令类型</param>
        /// <param name="commandText">存储过程名</param>
        /// <param name="commandParameters">传入的参数</param>
        /// <returns>SqlDataReader 对象</returns>
        public static SqlDataReader ExecuteReader(string commandText, params SqlParameter[] commandParameters)
        {

            SqlConnection conn = new SqlConnection(stringconnection);
            try
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, CommandType.StoredProcedure, conn, commandText, commandParameters);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }
        
        #endregion
        #region 返回受影响行数  以方便验证对数据库的增删改查  是否成功
        /// <summary>
        /// 执行Sql Server存储过程
        /// 注意：不能执行有out 参数的存储过程
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="spName">存储过程名</param>
        /// <param name="parameterValues">对象参数</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteNonQuery(string spName, params SqlParameter[] cmdParms)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(stringconnection))
                {
                    SqlCommand cmd = new SqlCommand();

                    PrepareCommand(cmd, CommandType.StoredProcedure, conn, spName, cmdParms);
                    int val = cmd.ExecuteNonQuery();

                    return val;
                }
            }
            catch (Exception )
            {
                  
                throw;
            }
        } 
        #endregion
        #region 返回第一行第一列，可以验证注册新用户时，是否有同名账户
        /// <summary>
        /// 返回第一行第一列，可以验证注册新用户时，是否有同名账户
        /// 执行对数据库的增删改查
        /// </summary>
        /// <param name="spName">存储过程名称</param>
        /// <param name="cmdParms">要传入的参数数组SqlParameter类</param>
        /// <returns>第一行第一列的值</returns>
        public static object ExecuteScalar(string spName, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(stringconnection))
            {

                PrepareCommand(cmd, CommandType.StoredProcedure, conn, spName, cmdParms);
                object val = cmd.ExecuteScalar();

                return val;
            }
        } 
        #endregion
        #region 执行对数据库的增删改查
        /// <summary>
        /// 设置一个等待执行的SqlCommand对象
        /// </summary>
        /// <param name="cmd">SqlCommand 对象，不允许空对象</param>
        /// <param name="conn">SqlConnection 对象，不允许空对象</param>
        /// <param name="commandText">Sql 语句</param>
        /// <param name="cmdParms">SqlParameters  对象,允许为空对象</param>
        private static void PrepareCommand(SqlCommand cmd, CommandType commandType, SqlConnection conn, string commandText, params SqlParameter[] cmdParms)
        {
            //打开连接
            if (conn.State != ConnectionState.Open)
                conn.Open();

            //设置SqlCommand对象
            cmd.Connection = conn;
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        } 
        #endregion
    }
}
