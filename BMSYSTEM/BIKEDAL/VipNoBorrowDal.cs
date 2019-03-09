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
    public class VipNoBorrowDal
    {
        DataTable dt;
        ExceptionHelper except;
        public VipNoBorrowDal()
        {
            except = new ExceptionHelper();
        }

        #region 非会员租车添加
        /// <summary>
        /// 非会员租车添加
        /// </summary>
        /// <param name="vipNoBorrow">非会员租车记录</param>
        /// <param name="bkid">租车类别ID</param>
        /// <returns>若余额不足则返回-2，若添加成功则返回1，若不成功返回-1</returns>
        public int VipNoBorrowInsert(VipNoBorrow vipNoBorrow, int bkid)
        {
            int result;
            try
            {
                string sql = "VIP_NO_BORROW_INSERT";
                SqlParameter[] para = new SqlParameter[]
               {
                   new SqlParameter("@VIPID",SqlDbType.Int),
                   new SqlParameter("@DPID",SqlDbType.Int),
                   new SqlParameter("@BKID",SqlDbType.Int),
                   new SqlParameter("@VNNAME",SqlDbType.VarChar,50),
                   new SqlParameter("@VNCARD",SqlDbType.VarChar,200),
                   new SqlParameter("@VNNUMBER",SqlDbType.Int),
                   new SqlParameter("@VNPHONE",SqlDbType.VarChar,50),
                   new SqlParameter("@RETURN",SqlDbType.Int),
                   new SqlParameter("@BBKTIME",SqlDbType.DateTime),
                   new SqlParameter("@USERID",SqlDbType.Int),
                   new SqlParameter ("@MARK",SqlDbType .VarChar ,1000)
               };
                para[0].Value = vipNoBorrow.VipId;
                para[1].Value = vipNoBorrow.DpId;
                para[2].Value = bkid;
                para[3].Value = vipNoBorrow.VnName;
                para[4].Value = vipNoBorrow.VnCard;
                para[5].Value = vipNoBorrow.VnNumber;
                para[6].Value = vipNoBorrow.VnPhone;
                para[7].Direction = ParameterDirection.ReturnValue;
                para[8].Value = vipNoBorrow.BbkTime;
                para[9].Value = vipNoBorrow.UserId;
                para[10].Value = vipNoBorrow.Mark;
                result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                int rtn = int.Parse(para[7].Value.ToString());
                if (rtn == -2)
                {
                    //若余额不足
                    return rtn;
                }
                return result > 0 ? 1 : -1;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("添加非会员租车出错：" + ex.Message, "VipNoBorrowInsert", DateTime.Now);
                return -1;
            }

        }
        #endregion

        #region 根据非会员ID删除非会员租车
        /// <summary>
        /// 根据非会员ID删除非会员租车
        /// </summary>
        /// <param name="vipNoBorrow"></param>
        /// <returns></returns>
        public bool VipNoBorrowDeleteByVipId(VipNoBorrow vipNoBorrow)
        {
            string sql = "VIP_NO_BORROW_DELETE_BY_VIPID";
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@VIPID",SqlDbType.Int)
                };
                para[0].Value = vipNoBorrow.VipId;
                int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("删除非会员租车出错：" + ex.Message, "VipNoBorrowDeleteByVipId", DateTime.Now);
                return false;
            }
        }
        #endregion

        #region 根据BBKID删除非会员借车记录
        public bool VipNoBorrowDeleteByBBKId(VipNoBorrow vipNoBorrow)
        {
            string sql = "VIP_NO_BORROW_DELETE_BY_BBKID";
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@BBKID",SqlDbType.Int)
                };
                para[0].Value = vipNoBorrow.BbkId;
                int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("删除非会员租车出错：" + ex.Message, "VipNoBorrowDeleteByBBKId", DateTime.Now);
                return false;
            }
        }
        #endregion

        #region 根据BBKID获得非会员租车信息
        /// <summary>
        /// 根据BBKID获得非会员租车信息
        /// </summary>
        /// <returns></returns>
        public VipNoBorrow VipNoBorrowSelectByBBKId(VipNoBorrow vipNoBorrow)
        {
            string sql = "VIP_NO_BORROW_SELECT_BY_BBKID";
            dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@BBKID",SqlDbType.Int)
            };
                para[0].Value = vipNoBorrow.BbkId;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                //BBKID,VIPID,DPID,CUID,VNNAME,VNPHONE,VNCARD,VNNUMBER
                VipNoBorrow vipNoBorrowInfo = new VipNoBorrow();
                vipNoBorrowInfo.BbkId = Convert.ToInt32(dt.Rows[0]["BBKID"]);
                vipNoBorrowInfo.VipId = Convert.ToInt32(dt.Rows[0]["VIPID"]);
                vipNoBorrowInfo.DpId = Convert.ToInt32(dt.Rows[0]["DPID"]);
                vipNoBorrowInfo.RkrId = Convert.ToInt32(dt.Rows[0]["RKRID"]);
                vipNoBorrowInfo.VnName = Convert.ToString(dt.Rows[0]["VNNAME"]);
                vipNoBorrowInfo.VnPhone = Convert.ToString(dt.Rows[0]["VNPHONE"]);
                vipNoBorrowInfo.VnCard = Convert.ToString(dt.Rows[0]["VNCARD"]);
                vipNoBorrowInfo.VnNumber = Convert.ToInt32(dt.Rows[0]["VNNUMBER"]);
                vipNoBorrowInfo.BbkTime = Convert.ToDateTime(dt.Rows[0]["BBKTIME"]);
                vipNoBorrowInfo.IsReturn = (bool)dt.Rows[0]["ISRETURN"];
                vipNoBorrowInfo.LeftNum = (int)dt.Rows[0]["LEFTNUM"];
                vipNoBorrowInfo.IsNight = (bool)dt.Rows[0]["ISNIGHT"];
                try
                {
                    vipNoBorrowInfo.Mark =dt.Rows [0]["MARK"].ToString ();
                }
                catch (Exception)
                {
                    vipNoBorrowInfo.Mark = "";
                }
                return vipNoBorrowInfo;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询非会员租车出错：" + ex.Message, "VipNoBorrowSelectByBBKId", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 获取所有非会员租车
        /// <summary>
        /// 获取所有非会员租车
        /// </summary>
        /// <returns></returns>
        public List<VipNoBorrow> VipNoBorrowSelect()
        {
            string sql = "VIP_NO_BORROW_SELECT";
            List<VipNoBorrow> listVipNoBorrow = new List<VipNoBorrow>();
            dt = new DataTable();
            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, null))
                {
                    dt.Load(dr);
                }
                VipNoBorrow vipNoBorrowTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    vipNoBorrowTemp = new VipNoBorrow();
                    vipNoBorrowTemp.BbkId = Convert.ToInt32(dt.Rows[i]["BBKID"]);
                    vipNoBorrowTemp.VipId = Convert.ToInt32(dt.Rows[i]["VIPID"]);
                    vipNoBorrowTemp.DpId = Convert.ToInt32(dt.Rows[i]["DPID"]);
                    vipNoBorrowTemp.RkrId = Convert.ToInt32(dt.Rows[i]["RKRID"]);
                    vipNoBorrowTemp.VnName = Convert.ToString(dt.Rows[i]["VNNAME"]);
                    vipNoBorrowTemp.VnPhone = Convert.ToString(dt.Rows[i]["VNPHONE"]);
                    vipNoBorrowTemp.VnCard = Convert.ToString(dt.Rows[i]["VNCARD"]);
                    vipNoBorrowTemp.VnNumber = Convert.ToInt32(dt.Rows[i]["VNNUMBER"]);
                    vipNoBorrowTemp.BbkTime = Convert.ToDateTime(dt.Rows[i]["BBKTIME"]);
                    vipNoBorrowTemp.IsReturn = (bool)dt.Rows[i]["ISRETURN"];
                    vipNoBorrowTemp.LeftNum = (int)dt.Rows[i]["LEFTNUM"];
                    listVipNoBorrow.Add(vipNoBorrowTemp);
                }
                return listVipNoBorrow;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询非会员租车出错：" + ex.Message, "VipNoBorrowSelect", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 根据非会员ID获取租车信息
        public List<VipNoBorrow> VipNoBorrowSelectByVipNoId(int vipId)
        {
            string sql = "VIP_NO_BORROW_SELECT_BY_VIPID";
            List<VipNoBorrow> listVipNoBorrow = new List<VipNoBorrow>();
            dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@VIPID",SqlDbType.Int)
            };
                para[0].Value = vipId;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                VipNoBorrow vipNoBorrowTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    vipNoBorrowTemp = new VipNoBorrow();
                    vipNoBorrowTemp.BbkId = Convert.ToInt32(dt.Rows[i]["BBKID"]);
                    vipNoBorrowTemp.VipId = Convert.ToInt32(dt.Rows[i]["VIPID"]);
                    vipNoBorrowTemp.DpId = Convert.ToInt32(dt.Rows[i]["DPID"]);
                    vipNoBorrowTemp.RkrId = Convert.ToInt32(dt.Rows[i]["RKRID"]);
                    vipNoBorrowTemp.VnName = Convert.ToString(dt.Rows[i]["VNNAME"]);
                    vipNoBorrowTemp.VnPhone = Convert.ToString(dt.Rows[i]["VNPHONE"]);
                    vipNoBorrowTemp.VnCard = Convert.ToString(dt.Rows[i]["VNCARD"]);
                    vipNoBorrowTemp.VnNumber = Convert.ToInt32(dt.Rows[i]["VNNUMBER"]);
                    vipNoBorrowTemp.BbkTime = Convert.ToDateTime(dt.Rows[i]["BBKTIME"]);
                    vipNoBorrowTemp.IsReturn = (bool)dt.Rows[i]["ISRETURN"];
                    vipNoBorrowTemp.LeftNum = (int)dt.Rows[i]["LEFTNUM"];
                    listVipNoBorrow.Add(vipNoBorrowTemp);
                }
                return listVipNoBorrow;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询非会员租车出错：" + ex.Message, "VipNoBorrowSelectByVipNoId", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 根据非会员ID和时间段获取租车信息
        public List<VipNoBorrow> VipNoBorrowSelectByVipNoIdAndTime(int vipId, DateTime startTime, DateTime endTime)
        {
            string sql = "VIP_NO_BORROW_SELECT_BY_VIPID_AND_TIME";
            List<VipNoBorrow> listVipNoBorrow = new List<VipNoBorrow>();
            dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@VIPID",SqlDbType.Int),
                new SqlParameter("@STARTTIME",SqlDbType.DateTime),
                new SqlParameter("@ENDTIME",SqlDbType.DateTime)
            };
                para[0].Value = vipId;
                para[1].Value = startTime;
                para[2].Value = endTime;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                VipNoBorrow vipNoBorrowTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    vipNoBorrowTemp = new VipNoBorrow();
                    vipNoBorrowTemp.BbkId = Convert.ToInt32(dt.Rows[i]["BBKID"]);
                    vipNoBorrowTemp.VipId = Convert.ToInt32(dt.Rows[i]["VIPID"]);
                    vipNoBorrowTemp.DpId = Convert.ToInt32(dt.Rows[i]["DPID"]);
                    vipNoBorrowTemp.RkrId = Convert.ToInt32(dt.Rows[i]["RKRID"]);
                    vipNoBorrowTemp.VnName = Convert.ToString(dt.Rows[i]["VNNAME"]);
                    vipNoBorrowTemp.VnPhone = Convert.ToString(dt.Rows[i]["VNPHONE"]);
                    vipNoBorrowTemp.VnCard = Convert.ToString(dt.Rows[i]["VNCARD"]);
                    vipNoBorrowTemp.VnNumber = Convert.ToInt32(dt.Rows[i]["VNNUMBER"]);
                    vipNoBorrowTemp.BbkTime = Convert.ToDateTime(dt.Rows[i]["BBKTIME"]);
                    vipNoBorrowTemp.IsReturn = (bool)dt.Rows[i]["ISRETURN"];
                    vipNoBorrowTemp.LeftNum = (int)dt.Rows[i]["LEFTNUM"];
                    listVipNoBorrow.Add(vipNoBorrowTemp);
                }
                return listVipNoBorrow;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询非会员租车出错：" + ex.Message, "VipNoBorrowSelectByVipNoId", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 根据分店ID获取租车信息
        /// <summary>
        /// 值查未还的
        /// </summary>
        /// <param name="dpId"></param>
        /// <returns></returns>
        public List<VipNoBorrow> VipNoBorrowSelectByDpId(int dpId)
        {
            string sql = "VIP_NO_BORROW_SELECT_BY_DPID";
            List<VipNoBorrow> listVipNoBorrow = new List<VipNoBorrow>();
            dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@DPID",SqlDbType.Int)
            };
                para[0].Value = dpId;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                VipNoBorrow vipNoBorrowTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    vipNoBorrowTemp = new VipNoBorrow();
                    vipNoBorrowTemp.BbkId = Convert.ToInt32(dt.Rows[i]["BBKID"]);
                    vipNoBorrowTemp.VipId = Convert.ToInt32(dt.Rows[i]["VIPID"]);
                    vipNoBorrowTemp.DpId = Convert.ToInt32(dt.Rows[i]["DPID"]);
                    vipNoBorrowTemp.RkrId = Convert.ToInt32(dt.Rows[i]["RKRID"]);
                    vipNoBorrowTemp.VnName = Convert.ToString(dt.Rows[i]["VNNAME"]);
                    vipNoBorrowTemp.VnPhone = Convert.ToString(dt.Rows[i]["VNPHONE"]);
                    vipNoBorrowTemp.VnCard = Convert.ToString(dt.Rows[i]["VNCARD"]);
                    vipNoBorrowTemp.VnNumber = Convert.ToInt32(dt.Rows[i]["VNNUMBER"]);
                    vipNoBorrowTemp.BbkTime = Convert.ToDateTime(dt.Rows[i]["BBKTIME"]);
                    vipNoBorrowTemp.IsReturn = (bool)dt.Rows[i]["ISRETURN"];
                    vipNoBorrowTemp.LeftNum = (int)dt.Rows[i]["LEFTNUM"];
                    listVipNoBorrow.Add(vipNoBorrowTemp);
                }
                return listVipNoBorrow;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询非会员租车出错：" + ex.Message, "VipNoBorrowSelectByDpId", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 根据分店ID获得该分店下租车信息，已还未还都查出来
        /// <summary>
        /// 已还未还都查出来
        /// </summary>
        /// <param name="dpId"></param>
        /// <returns></returns>
        public List<VipNoBorrow> VipNoBorrowSelectAllByDpId(int dpId)
        {
            string sql = "VIP_NO_BORROW_SELECT_ALL_BY_DPID";
            List<VipNoBorrow> listVipNoBorrow = new List<VipNoBorrow>();
            dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@DPID",SqlDbType.Int)
            };
                para[0].Value = dpId;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                VipNoBorrow vipNoBorrowTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    vipNoBorrowTemp = new VipNoBorrow();
                    vipNoBorrowTemp.BbkId = Convert.ToInt32(dt.Rows[i]["BBKID"]);
                    vipNoBorrowTemp.VipId = Convert.ToInt32(dt.Rows[i]["VIPID"]);
                    vipNoBorrowTemp.DpId = Convert.ToInt32(dt.Rows[i]["DPID"]);
                    vipNoBorrowTemp.RkrId = Convert.ToInt32(dt.Rows[i]["RKRID"]);
                    vipNoBorrowTemp.VnName = Convert.ToString(dt.Rows[i]["VNNAME"]);
                    vipNoBorrowTemp.VnPhone = Convert.ToString(dt.Rows[i]["VNPHONE"]);
                    vipNoBorrowTemp.VnCard = Convert.ToString(dt.Rows[i]["VNCARD"]);
                    vipNoBorrowTemp.VnNumber = Convert.ToInt32(dt.Rows[i]["VNNUMBER"]);
                    vipNoBorrowTemp.BbkTime = Convert.ToDateTime(dt.Rows[i]["BBKTIME"]);
                    vipNoBorrowTemp.IsReturn = (bool)dt.Rows[i]["ISRETURN"];
                    vipNoBorrowTemp.LeftNum = (int)dt.Rows[i]["LEFTNUM"];
                    listVipNoBorrow.Add(vipNoBorrowTemp);
                }
                return listVipNoBorrow;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询非会员租车出错：" + ex.Message, "VipNoBorrowSelectByDpId", DateTime.Now);
                return null;
            }
        }


        #endregion

        #region 根据分店ID和时间段获取租车信息
        /// <summary>
        /// 值查未还的
        /// </summary>
        /// <param name="dpId"></param>
        /// <returns></returns>
        public List<VipNoBorrow> VipNoBorrowSelectByDpIdAndTime(int dpId, DateTime startTime, DateTime endTime)
        {
            string sql = "VIP_NO_BORROW_SELECT_BY_DPID_AND_TIME";
            List<VipNoBorrow> listVipNoBorrow = new List<VipNoBorrow>();
            dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@DPID",SqlDbType.Int),
                new SqlParameter("@STARTTIME",SqlDbType.DateTime),
                new SqlParameter("@ENDTIME",SqlDbType.DateTime)
            };
                para[0].Value = dpId;
                para[1].Value = startTime;
                para[2].Value = endTime;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                VipNoBorrow vipNoBorrowTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    vipNoBorrowTemp = new VipNoBorrow();
                    vipNoBorrowTemp.BbkId = Convert.ToInt32(dt.Rows[i]["BBKID"]);
                    vipNoBorrowTemp.VipId = Convert.ToInt32(dt.Rows[i]["VIPID"]);
                    vipNoBorrowTemp.DpId = Convert.ToInt32(dt.Rows[i]["DPID"]);
                    vipNoBorrowTemp.RkrId = Convert.ToInt32(dt.Rows[i]["RKRID"]);
                    vipNoBorrowTemp.VnName = Convert.ToString(dt.Rows[i]["VNNAME"]);
                    vipNoBorrowTemp.VnPhone = Convert.ToString(dt.Rows[i]["VNPHONE"]);
                    vipNoBorrowTemp.VnCard = Convert.ToString(dt.Rows[i]["VNCARD"]);
                    vipNoBorrowTemp.VnNumber = Convert.ToInt32(dt.Rows[i]["VNNUMBER"]);
                    vipNoBorrowTemp.BbkTime = Convert.ToDateTime(dt.Rows[i]["BBKTIME"]);
                    vipNoBorrowTemp.IsReturn = (bool)dt.Rows[i]["ISRETURN"];
                    vipNoBorrowTemp.LeftNum = (int)dt.Rows[i]["LEFTNUM"];
                    vipNoBorrowTemp.IsNight = (bool)dt.Rows[i]["ISNIGHT"]; 
                    try
                    {
                        vipNoBorrowTemp.Mark = dt.Rows[i]["MARK"].ToString (); 
                    }
                    catch (Exception)
                    {
                        vipNoBorrowTemp.Mark = "";
                    }
                    listVipNoBorrow.Add(vipNoBorrowTemp);
                }
                return listVipNoBorrow;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询非会员租车出错：" + ex.Message, "VipNoBorrowSelectByDpId", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 根据分店ID和时间段获得该分店下租车信息，已还未还都查出来
        /// <summary>
        /// 已还未还都查出来
        /// </summary>
        /// <param name="dpId"></param>
        /// <returns></returns>
        public List<VipNoBorrow> VipNoBorrowSelectAllByDpIdAndTime(int dpId, DateTime startTime, DateTime endTime)
        {
            string sql = "VIP_NO_BORROW_SELECT_ALL_BY_DPID_AND_TIME";
            List<VipNoBorrow> listVipNoBorrow = new List<VipNoBorrow>();
            dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@DPID",SqlDbType.Int),
                new SqlParameter("@STARTTIME",SqlDbType.DateTime),
                new SqlParameter("@ENDTIME",SqlDbType.DateTime)
            };
                para[0].Value = dpId;
                para[1].Value = startTime;
                para[2].Value = endTime;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                VipNoBorrow vipNoBorrowTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    vipNoBorrowTemp = new VipNoBorrow();
                    vipNoBorrowTemp.BbkId = Convert.ToInt32(dt.Rows[i]["BBKID"]);
                    vipNoBorrowTemp.VipId = Convert.ToInt32(dt.Rows[i]["VIPID"]);
                    vipNoBorrowTemp.DpId = Convert.ToInt32(dt.Rows[i]["DPID"]);
                    vipNoBorrowTemp.RkrId = Convert.ToInt32(dt.Rows[i]["RKRID"]);
                    vipNoBorrowTemp.VnName = Convert.ToString(dt.Rows[i]["VNNAME"]);
                    vipNoBorrowTemp.VnPhone = Convert.ToString(dt.Rows[i]["VNPHONE"]);
                    vipNoBorrowTemp.VnCard = Convert.ToString(dt.Rows[i]["VNCARD"]);
                    vipNoBorrowTemp.VnNumber = Convert.ToInt32(dt.Rows[i]["VNNUMBER"]);
                    vipNoBorrowTemp.BbkTime = Convert.ToDateTime(dt.Rows[i]["BBKTIME"]);
                    vipNoBorrowTemp.IsReturn = (bool)dt.Rows[i]["ISRETURN"];
                    vipNoBorrowTemp.LeftNum = (int)dt.Rows[i]["LEFTNUM"];
                    listVipNoBorrow.Add(vipNoBorrowTemp);
                }
                return listVipNoBorrow;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询非会员租车出错：" + ex.Message, "VipNoBorrowSelectByDpId", DateTime.Now);
                return null;
            }
        }


        #endregion

        #region 非会员更改租车备注
        public bool vipNoMarkUpdate(string BBID, string MARK)
        {

            try
            {
                string sql = "VIP_NO_MARK_UPDATE";
                SqlParameter[] param = new SqlParameter[]{
                new SqlParameter ("@BBID",SqlDbType .Int ),
                new SqlParameter ("@MARK",SqlDbType .VarChar ,1000)
            };
                param[0].Value = BBID;
                param[1].Value = MARK;
                int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, param);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion


    }
}
