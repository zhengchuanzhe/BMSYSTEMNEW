using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using BIKECOMMON;
using MODEL;

namespace BIKEDAL
{
    /// <summary>
    /// 积分管理
    /// </summary>
    public class IntegralDal
    {
        Integral integral;
        ExceptionHelper except;
        public IntegralDal()
        {
            integral = new Integral();
            except = new ExceptionHelper();
        }
        /// <summary>
        /// 查出该比例
        /// </summary>
        /// <returns></returns>
        public Integral GetIntegralMessage()
        {
            Integral intTemp = new Integral();
            try
            {
                DataTable dt = new DataTable();
                string sql = "WHOLE_CONFIG_SELECT";
                SqlParameter[] para = new SqlParameter[]
               {
                   new SqlParameter("@ID",SqlDbType.Int)
               };
                para[0].Value = Integral.id;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    intTemp.Meaning = dt.Rows[i]["MEANING"].ToString();
                    intTemp.Value = Convert.ToInt32(dt.Rows[i]["VALUE"].ToString());
                    intTemp.IsDelete = (bool)dt.Rows[i]["ISDELETE"];
                }
                return intTemp;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询比例出错：" + ex.Message, "GetIntegralMessage", DateTime.Now);
                return null;
            }
        }
        /// <summary>
        /// 更新比例信息
        /// </summary>
        /// <param name="inte"></param>
        /// <returns></returns>
        public bool UpdateIntegralMessage(Integral inte)
        {
            string sql = "WHOLE_CONFIG_UPDATE";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@ID",SqlDbType.Int),
                new SqlParameter("@MEANING",SqlDbType.VarChar,200),
                new SqlParameter("@VALUE",SqlDbType.VarChar,200),
                new SqlParameter("@ISDELETE",SqlDbType.Bit)
            };
            try
            {
                para[0].Value = Integral.id;
                para[1].Value = inte.Meaning;
                para[2].Value = inte.Value;
                para[3].Value = inte.IsDelete;
                int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("更新比例信息出错：" + ex.Message, "UpdateIntegralMessage", DateTime.Now);
                return false;
            }
        }
    }
}
