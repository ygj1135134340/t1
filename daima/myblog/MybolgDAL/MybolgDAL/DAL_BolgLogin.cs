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



    public  class DAL_BolgLogin
    {
        #region DAL 验证在注册表中  是否  存在 该用户
        /// <summary>
        /// DAL 验证在注册表中  是否  存在 该用户
        /// </summary>
        /// <param name="tion"> 注册表实体对象</param>
        /// <returns> 返回int类型 如果大于0或等于1 则可登陆成功</returns>
        public int DAL_Login_UserRegistration(UserRegistration tion)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@username",tion.UserName),
                new SqlParameter("@pwd",tion.PassWord )
            };
            int a = Convert.ToInt32(sqlHelper.ExecuteScalar("proc_check_UserRegistration", parm));
            return a;
        } 
        #endregion

        #region 获取用户的ID  和  是 用户类型  1 表示普通用户，0表示管理员
        /// <summary>
        /// 获取用户的ID  和  是 用户类型  1 表示普通用户，0表示管理员
        /// </summary>
        /// <param name="tion">注册表实力对象</param>
        /// <returns> 返回list 集合  获取用户类型  1 表示普通用户，0表示管理员</returns>
        public   List <UserRegistration > DAL_select_userID_UserRegistration(UserRegistration tion)
        {
            List<UserRegistration> list = new List<UserRegistration>();          
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@username",tion.UserName)               
            };
            SqlDataReader dr = sqlHelper.ExecuteReader("proc_selcet_userID_usermaster", parm);
           while (dr.Read ())
           {
                UserRegistration tions = new UserRegistration();
                 tions. userID = Convert.ToInt32(dr["userID"]);
                 tions. usermaster = Convert.ToInt32(dr["usermaster"]);
                  list.Add(tions);  
           }
           return list;
        } 

        #endregion


        #region 根据注册对话框中输入的参数 验证注册表中名称是否已被占用
        /// <summary>
        /// 根据注册对话框中输入的参数 验证注册表中名称是否已被占用
        /// </summary>
        /// <param name="username">输入用户名参数</param>
        /// <returns>int类型</returns>
        public int DAL_selcete_username(string username)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@username",username )
            };
            int a = Convert.ToInt32(sqlHelper.ExecuteScalar("proc_check_username2", parm));
            return a;
        } 
        #endregion

        #region 向注册表中添加注册用户输入的信息
        /// <summary>
        /// 向注册表中添加注册用户输入的信息
        /// </summary>
        /// <param name="tion">实体类UserRegistration 对象 </param>
        /// <returns>返回int类型数值  确认是否插入成功 </returns>
        public int DAL_insert_UserRegistration(UserRegistration tion)
        {
            //@UserName,@Name,@PassWord,@sex,@Email,@tel,@address
            SqlParameter[] parm = new SqlParameter[] 
            {
                new SqlParameter("@UserName",tion.UserName),
                new SqlParameter("@Name",tion .Name),
                new SqlParameter("@PassWord",tion.PassWord),
                new SqlParameter("@sex",tion.sex ),
                new SqlParameter("@Email",tion.Email ),
                new SqlParameter("@tel",tion.tel ),
                new SqlParameter("@address",tion.address )
             };
            int a = sqlHelper.ExecuteNonQuery("insert_UserRegistration", parm);
            return a;



        } 
        #endregion
    }
}
