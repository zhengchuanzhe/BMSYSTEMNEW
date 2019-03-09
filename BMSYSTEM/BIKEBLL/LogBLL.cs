using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using BIKEDAL;

namespace BIKEBLL
{
    public class LogBLL
    {
        LogDal logDal;
        UserDal userDal;
        public LogBLL()
        {
            logDal = new LogDal();
            userDal = new UserDal();
        }

        #region 日志添加
        /// <summary>
        /// 日志添加
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        public bool LogInsert(LogInfo log)
        {
            return logDal.LogInsert(log);

        }
        #endregion

        #region 根据LOGID获得日志
        /// <summary>
        /// 根据LOGID获得日志
        /// </summary>
        /// <returns></returns>
        public LogInfo LogSelectById(LogInfo log)
        {
            return logDal.LogSelectById(log);
        }
        #endregion

        #region 根据USERID获得日志
        /// <summary>
        /// 根据USERID获得日志
        /// </summary>
        /// <returns></returns>
        public List<LogInfo> LogSelectByUserId(LogInfo log,DateTime start,DateTime end)
        {
            return logDal.LogSelectByUserId(log,start,end);
        }
        #endregion

        #region 获取所有日志
        /// <summary>
        /// 获取所有日志
        /// </summary>
        /// <returns></returns>
        public List<LogInfo> LogSelect()
        {
            return logDal.LogSelect();
        }
        #endregion

        #region 根据分店ID取得该分店用户操作日志

        public List<LogInfo> SelectLogByDpId(int dpId, DateTime start, DateTime end)
        {
            //List<LogInfo> logList = new List<LogInfo>();
            //List<UserInfo> userList = userDal.SelectUserByDpId(dpId);
            //if (userList == null || userList.Count == 0)
            //{
            //    return null;
            //}
            //LogInfo logTemp = new LogInfo();
            //List<LogInfo> logTempList = new List<LogInfo>();
            //for (int i = 0; i < userList.Count; i++)
            //{
            //    logTemp.UserId = userList[i].UserId;
            //    logTempList = logDal.LogSelectByUserId(logTemp, start, end);
            //    logList.AddRange(logTempList);
            //}
            //return logList;
          return  logDal.logSelectByDpId(dpId, start, end);
        }

        #endregion

        #region 根据分店ID获得日志时间
        /// <summary>
        /// 根据分店ID获得分店内所有
        /// </summary>
        /// <param name="dpId"></param>
        /// <returns></returns>
        public List<LogInfo> SelectLogTime()
        {
            return logDal.logTimeSelect();
        }

        #endregion

        #region 获取一段时间内所有日志
        /// <summary>
        /// 获取一段时间内的所有日志
        /// </summary>
        /// <returns></returns>
        public List<LogInfo> LogSelectByTime(DateTime start, DateTime end)
        {
            return logDal.LogSelectByTime(start,end);
        }
        #endregion
    }
}
