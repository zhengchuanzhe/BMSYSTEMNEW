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
    public class LogDal
    {
        DataTable dt;
        ExceptionHelper except;
        public LogDal()
        {
            except = new ExceptionHelper();
        }

        #region 日志添加
        /// <summary>
        /// 日志添加
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        public bool LogInsert(LogInfo log)
        {
            int result;
            try
            {
                string sql = "LOG_INSERT";
                SqlParameter[] para = new SqlParameter[]
               {
                   new SqlParameter("@USERID",SqlDbType.Int),
                   new SqlParameter("@CONTENT",SqlDbType.VarChar,200),
                   new SqlParameter("@LOGTIME",SqlDbType.DateTime),
                   new SqlParameter("@DPID",SqlDbType.Int)

               };
                para[0].Value = log.UserId;
                para[1].Value = log.Content;
                para[2].Value = log.LogTime;
                para[3].Value = log.DpId;
                result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("添加日志出错：" + ex.Message, "LogInsert", DateTime.Now);
                return false;
            }

        }
        #endregion

        #region 根据LOGID获得日志
        /// <summary>
        /// 根据LOGID获得日志
        /// </summary>
        /// <returns></returns>
        public LogInfo LogSelectById(LogInfo log)
        {
            string sql = "LOG_SELECT_BY_LOGID";
            dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@LOGID",SqlDbType.Int)
            };
                para[0].Value = log.LogId;
                //LOGID,USERID,CONTENT,LOGTIME
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                LogInfo logInfo = new LogInfo();
                logInfo.LogId = Convert.ToInt32(dt.Rows[0]["LOGID"]);
                logInfo.UserId = Convert.ToInt32(dt.Rows[0]["USERID"]);
                logInfo.Content = Convert.ToString(dt.Rows[0]["CONTENT"]);
                logInfo.LogTime = Convert.ToDateTime(dt.Rows[0]["LOGTIME"]);
                return logInfo;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询日志出错：" + ex.Message, "LogSelectById", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 根据USERID获得日志
        /// <summary>
        /// 根据USERID获得日志
        /// </summary>
        /// <returns></returns>
        public List<LogInfo> LogSelectByUserId(LogInfo log, DateTime start, DateTime end)
        {
            List<LogInfo> listLog = new List<LogInfo>();
            string sql = "LOG_SELECT_BY_USERID";
            dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@USERID",SqlDbType.Int),
                new SqlParameter("@STARTTIME",SqlDbType.DateTime),
                new SqlParameter("@ENDTIME",SqlDbType.DateTime)
            };
                para[0].Value = log.UserId;
                para[1].Value = start;
                para[2].Value = end;
                //LOGID,USERID,CONTENT,LOGTIME
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                LogInfo logTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    logTemp = new LogInfo();
                    logTemp.LogId = Convert.ToInt32(dt.Rows[i]["LOGID"]);
                    logTemp.UserId = Convert.ToInt32(dt.Rows[i]["USERID"]);
                    logTemp.Content = Convert.ToString(dt.Rows[i]["CONTENT"]);
                    logTemp.LogTime = Convert.ToDateTime(dt.Rows[i]["LOGTIME"]);
                    listLog.Add(logTemp);
                }
                return listLog;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询日志出错：" + ex.Message, "LogSelectByUserId", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 获取所有日志
        /// <summary>
        /// 获取所有日志
        /// </summary>
        /// <returns></returns>
        public List<LogInfo> LogSelect()
        {
            string sql = "LOG_SELECT";
            List<LogInfo> listLog = new List<LogInfo>();
            dt = new DataTable();
            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, null))
                {
                    dt.Load(dr);
                }
                LogInfo logTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    logTemp = new LogInfo();
                    logTemp.LogId = Convert.ToInt32(dt.Rows[i]["LOGID"]);
                    logTemp.UserId = Convert.ToInt32(dt.Rows[i]["USERID"]);
                    logTemp.Content = Convert.ToString(dt.Rows[i]["CONTENT"]);
                    logTemp.LogTime = Convert.ToDateTime(dt.Rows[i]["LOGTIME"]);
                    listLog.Add(logTemp);
                }
                return listLog;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询日志出错：" + ex.Message, "LogSelect", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 获取一段时间内所有日志
        /// <summary>
        /// 获取一段时间内的所有日志
        /// </summary>
        /// <returns></returns>
        public List<LogInfo> LogSelectByTime(DateTime start, DateTime end)
        {
            string sql = "LOG_SELECT_BY_TIME";
            List<LogInfo> listLog = new List<LogInfo>();
            dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@STARTTIME",SqlDbType.DateTime),
                new SqlParameter("@ENDTIME",SqlDbType.DateTime)
            };
                para[0].Value = start;
                para[1].Value = end;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, null))
                {
                    dt.Load(dr);
                }
                LogInfo logTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    logTemp = new LogInfo();
                    logTemp.LogId = Convert.ToInt32(dt.Rows[i]["LOGID"]);
                    logTemp.UserId = Convert.ToInt32(dt.Rows[i]["USERID"]);
                    logTemp.Content = Convert.ToString(dt.Rows[i]["CONTENT"]);
                    logTemp.LogTime = Convert.ToDateTime(dt.Rows[i]["LOGTIME"]);
                    listLog.Add(logTemp);
                }
                return listLog;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询日志出错：" + ex.Message, "LogSelect", DateTime.Now);
                return null;
            }
        }
        #endregion

        /// <summary>
        /// 获得日志时间列表
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        public List<LogInfo> logTimeSelect()
        {
            string sql = "LOG_TIME_SELECT";
            List<LogInfo> listLog = new List<LogInfo>();
            dt = new DataTable();
            try
            {
                //LOGID,USERID,CONTENT,LOGTIME
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, null))
                {
                    dt.Load(dr);
                }
                LogInfo logTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    logTemp = new LogInfo();
                    logTemp.LogTime = Convert.ToDateTime(dt.Rows[i]["LOGTIME"]);
                    listLog.Add(logTemp);
                }
                return listLog;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询日志出错：" + ex.Message, "LogSelectByUserId", DateTime.Now);
                return null;
            }

        }


        public List<LogInfo> logSelectByDpId(int dpId, DateTime start, DateTime end)
        {
            string sql = "LOG_SELECT_BY_DPID";
            dt = new DataTable();
            List<LogInfo> logList = new List<LogInfo>();
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@DPID",SqlDbType.Int),
                    new SqlParameter("@BEGINTIME",SqlDbType.DateTime),
                    new SqlParameter("@ENDTIME",SqlDbType.DateTime)
                };
                para[0].Value = dpId;
                para[1].Value = start;
                para[2].Value = end;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                LogInfo logTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    logTemp = new LogInfo();
                    logTemp.Content = dt.Rows[i]["CONTENT"].ToString();
                    logTemp.LogId = (int)dt.Rows[i]["LOGID"];
                    logTemp.LogTime = (DateTime)dt.Rows[i]["LOGTIME"];
                    logTemp.UserId = (int)dt.Rows[i]["USERID"];
                    logList.Add(logTemp);
                }
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询日志出错：" + ex.Message, "logSelectByDpId", DateTime.Now);
                return null;
            }
            return logList;
        }

    }
}
