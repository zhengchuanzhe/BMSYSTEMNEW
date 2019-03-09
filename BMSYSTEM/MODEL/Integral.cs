using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//积分模型
namespace MODEL
{
    public class Integral
    {
        /// <summary>
        /// 编号
        /// </summary>
        public const int id = 1;
        /// <summary>
        /// 是否删除
        /// </summary>
        private bool isDelete;
        public bool IsDelete
        {
            get { return isDelete; }
            set { isDelete = value; }
        }
        /// <summary>
        /// 含义
        /// </summary>
        private string meaning;
        public string Meaning
        {
            get { return meaning; }
            set { meaning = value; }
        }
        /// <summary>
        /// 值
        /// </summary>
        private int value;
        public int Value
        {
            get { return value; }
            set { this.value = value; }
        }
    }
}
