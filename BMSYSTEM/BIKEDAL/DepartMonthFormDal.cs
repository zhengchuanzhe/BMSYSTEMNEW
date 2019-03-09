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
    public class DepartMonthFormDal
    {
        DataTable dt;
        ExceptionHelper except;
        public DepartMonthFormDal()
        {
            except=new ExceptionHelper();
        }
        #region 根据时间段和分店ID选出分店月收入信息
        public List<DepartMonthForm> DepartMonthFormSelectByTime(DateTime begintime,DateTime endtime,int dpid)
        {
            string sql = "DEPART_MONTH_FORM_SELECT_BY_TIME";
            List<DepartMonthForm> listDepartMonthForm = new List<DepartMonthForm>();
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
                DepartMonthForm departMonthForm;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    departMonthForm = new DepartMonthForm();
                    departMonthForm.DmId = Convert.ToInt32(dt.Rows[i]["DMID"]);
                    departMonthForm.DpId = Convert.ToInt32(dt.Rows[i]["DPID"]);
                    departMonthForm.VipCost = Convert.ToDouble(dt.Rows[i]["VIPCOST"]);
                    departMonthForm.VipNoCost = Convert.ToDouble(dt.Rows[i]["VIPNOCOST"]);
                    departMonthForm.Time = Convert.ToDateTime(dt.Rows[i]["TIME"]);
                    departMonthForm.NewVipIncom = Convert.ToDouble(dt.Rows [i]["NewVipIncome"]);
                    departMonthForm.VipCharge = Convert.ToDouble(dt.Rows [i]["VipCharge"]);
                    departMonthForm.VipNoCharge = Convert.ToDouble(dt.Rows [i]["VipNoCharge"]);
                    departMonthForm.VipBalance = Convert.ToDouble(dt .Rows [i]["VipBalance"]);
                    departMonthForm.VipNoBalancel = Convert.ToDouble(dt.Rows [i]["VipNoBalance"]);
                    departMonthForm.Total = departMonthForm.NewVipIncom + departMonthForm.VipCharge + departMonthForm.VipNoCost;
                    listDepartMonthForm.Add(departMonthForm);
                }
                return listDepartMonthForm;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询分店月收入报表出错：" + ex.Message, "DepartMonthFormSelectByTime", DateTime.Now);
                return null;
            }
        }
        #endregion
    }
}
