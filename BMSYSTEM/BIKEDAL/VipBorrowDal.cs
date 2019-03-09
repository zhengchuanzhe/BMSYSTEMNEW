using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIKECOMMON;
using MODEL;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace BIKEDAL
{
    public class VipBorrowDal
    {
        DataTable dt;
        ExceptionHelper except;
        public VipBorrowDal()
        {
            except = new ExceptionHelper();
        }

        #region 会员租车添加
        /// <summary>
        /// 会员租车添加
        /// </summary>
        /// <param name="vipBorrow">租车记录</param>
        /// <param name="bkid">租车类型ID</param>
        /// <returns>若余额不足返回-2，若租车成功返回1，若租车不成功返回-1</returns>
        public int VipBorrowInsert(VipBorrowInfo vipBorrow, int bkid)
        {
            int result;
            try
            {
                string sql = "VIP_BORROW_INSERT";
                SqlParameter[] para = new SqlParameter[]
               {
                   new SqlParameter("@VIPID",SqlDbType.Int),
                   new SqlParameter("@BBKTIME",SqlDbType.DateTime),
                   new SqlParameter("@DPID",SqlDbType.Int),
                   new SqlParameter("@BBKNUM",SqlDbType.Int),
                   new SqlParameter("@BKID",SqlDbType.Int),
                   new SqlParameter("@USERID",SqlDbType.Int),
                   new SqlParameter("@RETURN",SqlDbType.Int),
                   new SqlParameter ("@MARK",SqlDbType .VarChar,1000)
               };
                para[0].Value = vipBorrow.VipId;
                para[1].Value = vipBorrow.BbkTime;
                para[2].Value = vipBorrow.DpId;
                para[3].Value = vipBorrow.BbkNumber;
                para[4].Value = bkid;
                para[5].Value = vipBorrow.UserId;
                para[para.Length - 2].Direction = ParameterDirection.ReturnValue;
                if (vipBorrow.Mark == null)
                {
                    vipBorrow.Mark = "";
                }
                para[7].Value = vipBorrow.Mark;
                result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                int rtn = int.Parse(para[6].Value.ToString());
                if (rtn == -2)
                {
                    //若余额不足
                    return rtn;
                }
                return result > 0 ? 1 : -1;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("添加会员租车出错：" + ex.Message, "VipBorrowInsert", DateTime.Now);
                return -1;
            }
        }
        #endregion

        #region 删除会员租车
        /// <summary>
        /// 删除会员租车
        /// </summary>
        /// <param name="vipBorrow"></param>
        /// <returns></returns>
        public bool VipBorrowDelete(VipBorrowInfo vipBorrow)
        {
            string sql = "VIP_BORROW_DELETE";
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@BBKID",SqlDbType.Int)
                };
                para[0].Value = vipBorrow.BbkId;
                int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("删除会员租车出错：" + ex.Message, "VipBorrowDelete", DateTime.Now);
                return false;
            }
        }
        #endregion

        #region 根据BBKID获得会员租车信息
        /// <summary>
        /// 根据BBKID获得会员租车信息
        /// </summary>
        /// <returns></returns>
        public VipBorrowInfo VipBorrowSelectById(VipBorrowInfo vipBorrow)
        {
            string sql = "VIP_BORROW_SELECT_BY_ID";
            dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@BBKID",SqlDbType.Int)
            };
                para[0].Value = vipBorrow.BbkId;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                //BBKID,VIPID,BBKTIME,DPID,BBKNUM
                VipBorrowInfo vipBorrowInfo = new VipBorrowInfo();
                vipBorrowInfo.BbkId = Convert.ToInt32(dt.Rows[0]["BBKID"]);
                vipBorrowInfo.VipId = Convert.ToInt32(dt.Rows[0]["VIPID"]);
                vipBorrowInfo.BbkTime = Convert.ToDateTime(dt.Rows[0]["BBKTIME"]);
                vipBorrowInfo.DpId = Convert.ToInt32(dt.Rows[0]["DPID"]);
                vipBorrowInfo.BbkNumber = Convert.ToInt32(dt.Rows[0]["BBKNUM"]);
                vipBorrowInfo.RkrId = Convert.ToInt32(dt.Rows[0]["RKRID"]);
                vipBorrowInfo.IsReturn = (bool)dt.Rows[0]["ISRETURN"];
                vipBorrowInfo.LeftNum = (int)dt.Rows[0]["LEFTNUM"];
                vipBorrowInfo.IsNight = (bool)dt.Rows[0]["ISNIGHT"];
                try
                {
                    vipBorrowInfo.Mark = dt.Rows[0]["MARK"].ToString();
                }
                catch (Exception)
                {
                    vipBorrowInfo.Mark = "";
                }
                return vipBorrowInfo;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询会员租车出错：" + ex.Message, "VipBorrowSelectById", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 获取所有会员租车
        /// <summary>
        /// 获取所有会员租车
        /// </summary>
        /// <returns></returns>
        public List<VipBorrowInfo> VipBorrowSelect()
        {
            string sql = "VIP_BORROW_SELECT";
            List<VipBorrowInfo> listVipBorrow = new List<VipBorrowInfo>();
            dt = new DataTable();
            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, null))
                {
                    dt.Load(dr);
                }
                VipBorrowInfo vipBorrowTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    vipBorrowTemp = new VipBorrowInfo();
                    vipBorrowTemp.BbkId = Convert.ToInt32(dt.Rows[i]["BBKID"]);
                    vipBorrowTemp.VipId = Convert.ToInt32(dt.Rows[i]["VIPID"]);
                    vipBorrowTemp.BbkTime = Convert.ToDateTime(dt.Rows[i]["BBKTIME"]);
                    vipBorrowTemp.DpId = Convert.ToInt32(dt.Rows[i]["DPID"]);
                    vipBorrowTemp.BbkNumber = Convert.ToInt32(dt.Rows[i]["BBKNUM"]);
                    vipBorrowTemp.RkrId = Convert.ToInt32(dt.Rows[i]["RKRID"]);
                    vipBorrowTemp.IsReturn = (bool)dt.Rows[i]["ISRETURN"];
                    vipBorrowTemp.LeftNum = (int)dt.Rows[i]["LEFTNUM"];
                    listVipBorrow.Add(vipBorrowTemp);
                }
                return listVipBorrow;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询会员租车出错：" + ex.Message, "VipBorrowSelect", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 根据会员ID获取租车信息
        public List<VipBorrowInfo> VipBorrowSelectByVipId(int vipId)
        {
            string sql = "VIP_BORROW_SELECT_BY_VIPID";
            List<VipBorrowInfo> listVipBorrow = new List<VipBorrowInfo>();
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
                VipBorrowInfo vipBorrowTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    vipBorrowTemp = new VipBorrowInfo();
                    vipBorrowTemp.BbkId = Convert.ToInt32(dt.Rows[i]["BBKID"]);
                    vipBorrowTemp.VipId = Convert.ToInt32(dt.Rows[i]["VIPID"]);
                    vipBorrowTemp.BbkTime = Convert.ToDateTime(dt.Rows[i]["BBKTIME"]);
                    vipBorrowTemp.DpId = Convert.ToInt32(dt.Rows[i]["DPID"]);
                    vipBorrowTemp.BbkNumber = Convert.ToInt32(dt.Rows[i]["BBKNUM"]);
                    vipBorrowTemp.RkrId = Convert.ToInt32(dt.Rows[i]["RKRID"]);
                    vipBorrowTemp.IsReturn = (bool)dt.Rows[i]["ISRETURN"];
                    vipBorrowTemp.LeftNum = (int)dt.Rows[i]["LEFTNUM"];
                    listVipBorrow.Add(vipBorrowTemp);
                }
                return listVipBorrow;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询会员租车出错：" + ex.Message, "VipBorrowSelectByVipId", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 根据会员ID和时间段获取租车信息
        public List<VipBorrowInfo> VipBorrowSelectByVipIAndTime(int vipId, DateTime startTime, DateTime endTime)
        {
            string sql = "VIP_BORROW_SELECT_BY_VIPID_AND_TIME";
            List<VipBorrowInfo> listVipBorrow = new List<VipBorrowInfo>();
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
                VipBorrowInfo vipBorrowTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    vipBorrowTemp = new VipBorrowInfo();
                    vipBorrowTemp.BbkId = Convert.ToInt32(dt.Rows[i]["BBKID"]);
                    vipBorrowTemp.VipId = Convert.ToInt32(dt.Rows[i]["VIPID"]);
                    vipBorrowTemp.BbkTime = Convert.ToDateTime(dt.Rows[i]["BBKTIME"]);
                    vipBorrowTemp.DpId = Convert.ToInt32(dt.Rows[i]["DPID"]);
                    vipBorrowTemp.BbkNumber = Convert.ToInt32(dt.Rows[i]["BBKNUM"]);
                    vipBorrowTemp.RkrId = Convert.ToInt32(dt.Rows[i]["RKRID"]);
                    vipBorrowTemp.IsReturn = (bool)dt.Rows[i]["ISRETURN"];
                    vipBorrowTemp.LeftNum = (int)dt.Rows[i]["LEFTNUM"];
                    listVipBorrow.Add(vipBorrowTemp);
                }
                return listVipBorrow;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询会员租车出错：" + ex.Message, "VipBorrowSelectByVipId", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 根据会员ID获得该会员未还的租车信息
        public List<VipBorrowInfo> VipBorrowUnreturnByVipId(int vipId)
        {
            string sql = "VIP_BORROW_UNRETURN_BY_VIPID";
            List<VipBorrowInfo> listVipBorrow = new List<VipBorrowInfo>();
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
                VipBorrowInfo vipBorrowTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    vipBorrowTemp = new VipBorrowInfo();
                    vipBorrowTemp.BbkId = Convert.ToInt32(dt.Rows[i]["BBKID"]);
                    vipBorrowTemp.VipId = Convert.ToInt32(dt.Rows[i]["VIPID"]);
                    vipBorrowTemp.BbkTime = Convert.ToDateTime(dt.Rows[i]["BBKTIME"]);
                    vipBorrowTemp.DpId = Convert.ToInt32(dt.Rows[i]["DPID"]);
                    vipBorrowTemp.BbkNumber = Convert.ToInt32(dt.Rows[i]["BBKNUM"]);
                    vipBorrowTemp.RkrId = Convert.ToInt32(dt.Rows[i]["RKRID"]);
                    vipBorrowTemp.Times = Convert.ToInt32(dt.Rows[i]["TIMES"]);
                    vipBorrowTemp.IsReturn = (bool)dt.Rows[i]["ISRETURN"];
                    vipBorrowTemp.LeftNum = (int)dt.Rows[i]["LEFTNUM"];
                    vipBorrowTemp.IsNight = (bool)dt.Rows[i]["ISNIGHT"];
                    try
                    {
                        vipBorrowTemp.Mark = dt.Rows[i]["MARK"].ToString();
                    }
                    catch (Exception)
                    {
                        vipBorrowTemp.Mark = "";
                    }

                    listVipBorrow.Add(vipBorrowTemp);
                }
                return listVipBorrow;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询未还会员租车出错：" + ex.Message, "VipBorrowUnreturnByVipId", DateTime.Now);
                return null;
            }
        }

        #endregion

        #region 根据分店ID获取租车信息(未还)
        public List<VipBorrowInfo> VipBorrowSelectByDpId(int dpId)
        {
            string sql = "VIP_BORROW_SELECT_BY_DPID";
            List<VipBorrowInfo> listVipBorrow = new List<VipBorrowInfo>();
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
                VipBorrowInfo vipBorrowTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        vipBorrowTemp = new VipBorrowInfo();
                        vipBorrowTemp.BbkId = Convert.ToInt32(dt.Rows[i]["BBKID"]);
                        vipBorrowTemp.VipId = Convert.ToInt32(dt.Rows[i]["VIPID"]);
                        vipBorrowTemp.BbkTime = Convert.ToDateTime(dt.Rows[i]["BBKTIME"]);
                        vipBorrowTemp.DpId = Convert.ToInt32(dt.Rows[i]["DPID"]);
                        vipBorrowTemp.BbkNumber = Convert.ToInt32(dt.Rows[i]["BBKNUM"]);
                        vipBorrowTemp.RkrId = Convert.ToInt32(dt.Rows[i]["RKRID"]);
                        vipBorrowTemp.IsReturn = (bool)dt.Rows[i]["ISRETURN"];
                        vipBorrowTemp.LeftNum = (int)dt.Rows[i]["LEFTNUM"];
                        listVipBorrow.Add(vipBorrowTemp);
                    }
                    catch (Exception)
                    {
                    }
                }
                return listVipBorrow;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询会员租车出错：" + ex.Message, "VipBorrowSelectByDpId", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 根据分店ID获得租车信息(已还，未还)都有
        public List<VipBorrowInfo> VipBorrowSelectAllByDpId(int dpId)
        {
            string sql = "VIP_BORROW_SELECT_ALL_BY_DPID";
            List<VipBorrowInfo> listVipBorrow = new List<VipBorrowInfo>();
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
                VipBorrowInfo vipBorrowTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    vipBorrowTemp = new VipBorrowInfo();
                    vipBorrowTemp.BbkId = Convert.ToInt32(dt.Rows[i]["BBKID"]);
                    vipBorrowTemp.VipId = Convert.ToInt32(dt.Rows[i]["VIPID"]);
                    vipBorrowTemp.BbkTime = Convert.ToDateTime(dt.Rows[i]["BBKTIME"]);
                    vipBorrowTemp.DpId = Convert.ToInt32(dt.Rows[i]["DPID"]);
                    vipBorrowTemp.BbkNumber = Convert.ToInt32(dt.Rows[i]["BBKNUM"]);
                    vipBorrowTemp.RkrId = Convert.ToInt32(dt.Rows[i]["RKRID"]);
                    vipBorrowTemp.IsReturn = (bool)dt.Rows[i]["ISRETURN"];
                    vipBorrowTemp.LeftNum = (int)dt.Rows[i]["LEFTNUM"];
                    listVipBorrow.Add(vipBorrowTemp);
                }
                return listVipBorrow;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询会员租车出错：" + ex.Message, "VipBorrowSelectByDpId", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 根据分店ID和时间段获得租车信息(已还，未还)都有
        public List<VipBorrowInfo> VipBorrowSelectAllByDpIdAndTime(int dpId, DateTime startTime, DateTime endTime)
        {
            string sql = "VIP_BORROW_SELECT_ALL_BY_DPID_AND_TIME";
            List<VipBorrowInfo> listVipBorrow = new List<VipBorrowInfo>();
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
                VipBorrowInfo vipBorrowTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    vipBorrowTemp = new VipBorrowInfo();
                    vipBorrowTemp.BbkId = Convert.ToInt32(dt.Rows[i]["BBKID"]);
                    vipBorrowTemp.VipId = Convert.ToInt32(dt.Rows[i]["VIPID"]);
                    vipBorrowTemp.BbkTime = Convert.ToDateTime(dt.Rows[i]["BBKTIME"]);
                    vipBorrowTemp.DpId = Convert.ToInt32(dt.Rows[i]["DPID"]);
                    vipBorrowTemp.BbkNumber = Convert.ToInt32(dt.Rows[i]["BBKNUM"]);
                    vipBorrowTemp.RkrId = Convert.ToInt32(dt.Rows[i]["RKRID"]);
                    vipBorrowTemp.IsReturn = (bool)dt.Rows[i]["ISRETURN"];
                    vipBorrowTemp.LeftNum = (int)dt.Rows[i]["LEFTNUM"];
                    try
                    {
                        vipBorrowTemp.Mark = dt.Rows[i]["MARK"].ToString();
                    }
                    catch (Exception)
                    {
                        vipBorrowTemp.Mark = "";
                    }
                    listVipBorrow.Add(vipBorrowTemp);
                }
                return listVipBorrow;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询会员租车出错：" + ex.Message, "VipBorrowSelectByDpId", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 根据分店ID和时间段获取租车信息(未还)
        public List<VipBorrowInfo> VipBorrowSelectByDpIdAndTime(int dpId, DateTime startTime, DateTime endTime)
        {
            string sql = "VIP_BORROW_SELECT_BY_DPID_AND_TIME";
            List<VipBorrowInfo> listVipBorrow = new List<VipBorrowInfo>();
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
                VipBorrowInfo vipBorrowTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    vipBorrowTemp = new VipBorrowInfo();
                    vipBorrowTemp.BbkId = Convert.ToInt32(dt.Rows[i]["BBKID"]);
                    vipBorrowTemp.VipId = Convert.ToInt32(dt.Rows[i]["VIPID"]);
                    vipBorrowTemp.BbkTime = Convert.ToDateTime(dt.Rows[i]["BBKTIME"]);
                    vipBorrowTemp.DpId = Convert.ToInt32(dt.Rows[i]["DPID"]);
                    vipBorrowTemp.BbkNumber = Convert.ToInt32(dt.Rows[i]["BBKNUM"]);
                    vipBorrowTemp.RkrId = Convert.ToInt32(dt.Rows[i]["RKRID"]);
                    vipBorrowTemp.IsReturn = (bool)dt.Rows[i]["ISRETURN"];
                    vipBorrowTemp.LeftNum = (int)dt.Rows[i]["LEFTNUM"];
                    vipBorrowTemp.IsNight = (bool)dt.Rows[i]["ISNIGHT"];
                    try
                    {
                        vipBorrowTemp.Mark = dt.Rows[i]["MARK"].ToString();
                    }
                    catch (Exception)
                    {
                        vipBorrowTemp.Mark = "";
                    }
                    listVipBorrow.Add(vipBorrowTemp);
                }
                return listVipBorrow;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询会员租车出错：" + ex.Message, "VipBorrowSelectByDpId", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 会员更改租车备注
        public bool vipMarkUpdate(string BBID,string MARK)
        {

            try
            {
                string sql = "VIP_MARK_UPDATE";
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

        #region 转为包夜功能
        /// <summary>
        /// 转为包夜功能
        /// </summary>
        /// <param name="BBID">租车id</param>
        /// <param name="isVip">是否为会员</param>
        /// <returns></returns>
        public bool nightBorrow(string BBID, bool isVip)
        {
            try
            {
                string sql = "VIPNIGHTBORROW";
                SqlParameter[] param = new SqlParameter[]{
                new SqlParameter ("@BBID",SqlDbType .Int ),
                new SqlParameter ("ISVIP",SqlDbType .Bit )
            };
                param[0].Value = BBID;
                param[1].Value = isVip;
                int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, param);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region 取消包夜功能
        /// <summary>
        /// 取消包夜功能
        /// </summary>
        /// <param name="BBID">租车ID</param>
        /// <param name="isVip">是否为会员</param>
        /// <returns></returns>
        public bool notNightBorrow(string BBID, bool isVip)
        {
            try
            {
                string sql = "VIPNOTNIGHTBORROW";
                SqlParameter[] param = new SqlParameter[]{
                new SqlParameter ("@BBID",SqlDbType .Int ),
                new SqlParameter ("ISVIP",SqlDbType .Bit )
            };
                param[0].Value = BBID;
                param[1].Value = isVip;
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
