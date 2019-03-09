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
    public class VipYearFormDal
    {
        DataTable dt;
        ExceptionHelper except;
        public VipYearFormDal()
        {
            except = new ExceptionHelper();
        }

        #region 根据时间段和分店ID选出会员消费年报表
        public List<VipYearForm> VipYearFormSelectByTime(DateTime begintime, DateTime endtime,int dpid)
        {
            string sql = "VIP_YEAR_FORM_SELECT_BY_TIME";
            List<VipYearForm> listVipYearForm = new List<VipYearForm>();
            dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
               {
                   new SqlParameter("@BEGINTIME",SqlDbType.DateTime),
                   new SqlParameter("@ENDTIME",SqlDbType.DateTime),
                   new SqlParameter("@DPID",SqlDbType.Int)

               };
                para[0].Value = begintime;
                para[1].Value = endtime;
                para[2].Value=dpid;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                VipYearForm vipYearForm;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //VYID,VIPID,VYCOST,VYTIMES,TIME
                    vipYearForm = new VipYearForm();
                    vipYearForm.VyId = Convert.ToInt32(dt.Rows[i]["VYID"]);
                    vipYearForm.VipId = Convert.ToInt32(dt.Rows[i]["VIPID"]);
                    vipYearForm.VyCost = Convert.ToDouble(dt.Rows[i]["VYCOST"]);
                    vipYearForm.VyTimes = Convert.ToInt32(dt.Rows[i]["VYTIMES"]);
                    vipYearForm.Time = Convert.ToDateTime(dt.Rows[i]["TIME"]);
                    listVipYearForm.Add(vipYearForm);
                }
                return listVipYearForm;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询分店年收入报表出错：" + ex.Message, "DepartYearFormSelectByTime", DateTime.Now);
                return null;
            }
        }
        #endregion
    }
}
