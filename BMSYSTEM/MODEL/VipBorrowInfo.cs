using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    /// <summary>
    /// 会员租车信息表
    /// </summary>
    public class VipBorrowInfo
    {
        //租车编号
        private int bbkId;
        public int BbkId
        {
            get { return bbkId; }
            set { bbkId = value; }
        }
        //会员ID
        private int vipId;
        public int VipId
        {
            get { return vipId; }
            set { vipId = value; }
        }
        //租车开始时间
        private DateTime bbkTime;
        public DateTime BbkTime
        {
            get { return bbkTime; }
            set { bbkTime = value; }
        }
        //租车地编号
        private int dpId;
        public int DpId
        {
            get { return dpId; }
            set { dpId = value; }
        }
        //租车数量
        private int bbkNumber;
        public int BbkNumber
        {
            get { return bbkNumber; }
            set { bbkNumber = value; }
        }

        //租车类型ID//日租月租年租
        private int rkrId;
        public int RkrId
        {
            get { return rkrId; }
            set { rkrId = value; }
        }
        //是否删除
        private bool isDelete;
        public bool IsDelete
        {
            get { return isDelete; }
            set { isDelete = value; }
        }
        /// <summary>
        /// 租车次数
        /// </summary>
        private int times;
        public int Times
        {
            get { return times; }
            set { times = value; }
        }
        /// <summary>
        /// 是否已经还车
        /// </summary>
        private bool isReturn;
        public bool IsReturn
        {
            get { return isReturn; }
            set { isReturn = value; }
        }
        /// <summary>
        /// 未还车辆
        /// </summary>
        private int leftNum;
        public int LeftNum
        {
            set { leftNum = value; }
            get { return leftNum; }
        }
        /// <summary>
        /// 备注信息
        /// </summary>
        private string mark;
        public string Mark
        {
            set { mark = value; }
            get { return mark; }
        }

        /// <summary>
        /// 是否为包夜租车
        /// </summary>
        private bool isNight;
        public bool IsNight
        {
            set { isNight = value; }
            get { return isNight; }
        }

        /// <summary>
        /// 用户Id
        /// </summary>
        private int userId;
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
    }
}
