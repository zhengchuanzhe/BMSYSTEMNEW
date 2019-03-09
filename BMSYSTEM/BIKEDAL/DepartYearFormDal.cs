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
    public class DepartYearFormDal
    {
        DataTable dt;
        ExceptionHelper except;

        public DepartYearFormDal()
        {
            except=new ExceptionHelper();
        }
        #region 根据时间段和分店ID选出分店年收入信息
        public List<DepartYearForm> DepartYearFormSelectByTime(DateTime begintime,DateTime endtime,int dpid)
        {
            string sql = "DEPART_YEAR_FORM_SELECT_BY_TIME";
            List<DepartYearForm> listDepartYearForm = new List<DepartYearForm>();
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
                para[2].Value = dpid;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                DepartYearForm departYearForm;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    departYearForm = new DepartYearForm();
                    departYearForm.DyId = Convert.ToInt32(dt.Rows[i]["DYID"]);
                    departYearForm.DpId = Convert.ToInt32(dt.Rows[i]["DPID"]);
                    departYearForm.VipCost = Convert.ToDouble(dt.Rows[i]["VIPCOST"]);
                    departYearForm.VipNoCost = Convert.ToDouble(dt.Rows[i]["VIPNOCOST"]);
                    departYearForm.Time = Convert.ToDateTime(dt.Rows[i]["TIME"]);
                    departYearForm.NewVipIncome = Convert.ToDouble(dt.Rows[i]["NewVipIncome"]);
                    departYearForm.VipCharge = Convert.ToDouble(dt.Rows [i]["VipCharge"]);
                    departYearForm.VipNoCharge = Convert.ToDouble(dt.Rows[i]["VipNoCharge"]);
                    departYearForm.Total = departYearForm.VipNoCost + departYearForm.VipCharge + departYearForm.NewVipIncome;
                    listDepartYearForm.Add(departYearForm);
                }
                return listDepartYearForm;
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
