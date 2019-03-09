using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using BIKECOMMON;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace BIKEDAL
{
    /// <summary>
    /// 包夜租车操作类
    /// </summary>
    public class NightBorrowDal
    {
        ExceptionHelper except;
        DataTable dt;
        public NightBorrowDal()
        {
            except = new ExceptionHelper();
        }

        #region 包夜扣费规则修改
        /// <summary>
        /// 包夜扣费规则修改
        /// </summary>
        /// <param name="NB"></param>
        /// <returns></returns>
        public bool RuleUpdate(NightBorrow NB)
        {
            try
            {
                string sql = "NIGHT_BORROW_RULE_UPDATE";
                SqlParameter[] param = new SqlParameter[] {
                new SqlParameter ("@ID",SqlDbType .Int ),
                new SqlParameter ("@COST",SqlDbType .Int ),
                new SqlParameter ("@BEGINTIME",SqlDbType .Int ),
                new SqlParameter ("@ENDTIME",SqlDbType .Int ),
              };
                param[0].Value = NB.Id;
                param[1].Value = NB.Cost;
                param[2].Value = NB.BeginTime;
                param[3].Value = NB.EndTime;
                int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, param);
                return result > 0 ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region 取出包夜扣费规则
        /// <summary>
        /// 取出包夜扣费规则
        /// </summary>
        /// <param name="id">扣费规则ID</param>
        /// <returns></returns>
        public NightBorrow nightBorrowSelect(string id)
        {
            try
            {
                dt = new DataTable();
                string sql = "NIGHT_BORROW_SELECT_BY_ID";
                SqlParameter[] param = new SqlParameter[]{
                new SqlParameter ("@ID",id )
               };
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, param))
                {
                    dt.Load(dr);
                }
                NightBorrow Nb = new NightBorrow();
                Nb.Cost = dt.Rows[0]["VIPCOST"].ToString();
                Nb.BeginTime =dt.Rows[0]["BEGINTIME"].ToString();
                Nb.EndTime = dt.Rows[0]["ENDTIME"].ToString();
                return Nb;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

    }
}
