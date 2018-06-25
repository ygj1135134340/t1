using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mybloge.Model;
using System.Data.SqlClient;
namespace Mybolg.DAL
{

   public class DAL_insert_Journaltable
    {
       /// <summary>
       /// 向日志表中插入数据
       /// </summary>
       /// <param name="jou"></param>
       /// <returns></returns>
       public int insert_Journaltable_where_username(Journaltable jou)
       {
           
           SqlParameter[] parm = new SqlParameter[] 
           {
               //new SqlParameter ("@titleID",jou .titleID),
               new SqlParameter ("@title",jou.title),
               new SqlParameter ("@createtime",jou.createtime ),
               new SqlParameter ("@username",jou.username ),
               new SqlParameter ("@name",jou.name ),
               new SqlParameter ("@digests",jou.digests ),
               new SqlParameter ("@content",jou.content ),
               //new SqlParameter ("@Clicks",jou.Clicks ),
               //new SqlParameter ("@commentnum",jou.commentnum ),
               new SqlParameter ("@sort",jou.sort ),
               new SqlParameter ("@islook",jou.islook ),
               new SqlParameter ("@iscomment",jou.iscomment )

           };
           int a = sqlHelper.ExecuteNonQuery("insert_Journaltable_where_username",parm );
           return a;
       }



       /// <summary>
       /// 更新日志表中的数据
       /// </summary>
       /// <param name="jou"></param>
       /// <returns></returns>
       public int update_jourelnal_where_titleID( Journaltable jou)
       {

           SqlParameter[] parm = new SqlParameter[] 
           {
               new SqlParameter ("@titleID",jou .titleID),
               new SqlParameter ("@title",jou.title),
               //new SqlParameter ("@createtime",jou.createtime ),
               //new SqlParameter ("@username",jou.username ),
               //new SqlParameter ("@name",jou.name ),
               new SqlParameter ("@digests",jou.digests ),
               new SqlParameter ("@content",jou.content ),
               //new SqlParameter ("@Clicks",jou.Clicks ),
               //new SqlParameter ("@commentnum",jou.commentnum ),
               new SqlParameter ("@sort",jou.sort ),
               new SqlParameter ("@islook",jou.islook ),
               new SqlParameter ("@iscomment",jou.iscomment )

           };
           int a = sqlHelper.ExecuteNonQuery("update_journaltable_where_titleID", parm);
           return a;

       }

    }

}
