using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BaiduMapAPI.APIs.Ros.V1.Matrix.Current
{
    /// <summary>
    /// 路网任务执行时间查询接口 返回值
    /// </summary>
    public class TaskResult : Models.ResponseNew, IList<TaskResultResult>
    {
        private List<TaskResultResult> list = new List<TaskResultResult>();

        /// <summary>
        /// 获取指定下标实体
        /// </summary>
        /// <param name="index">列表下标（从0开始）</param>
        /// <returns></returns>
        public TaskResultResult this[int index] { get => list[index]; set => list[index] = value; }
        /// <summary>
        /// 列表总数
        /// </summary>
        public int Count => list.Count;
        /// <summary>
        /// 是否只读列表
        /// </summary>
        public bool IsReadOnly => false;
        /// <summary>
        /// 往列表中添加
        /// </summary>
        /// <param name="item"></param>
        public void Add(TaskResultResult item)
        {
            list.Add(item);
        }
        /// <summary>
        /// 清空列表
        /// </summary>
        public void Clear()
        {
            list.Clear();
        }
        /// <summary>
        /// 判断列表中是否已包含指定对象
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(TaskResultResult item)
        {
            return list.Contains(item);
        }
        /// <summary>
        /// 将列表复制到指定数组中
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(TaskResultResult[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }
        /// <summary>
        /// 获取枚举器
        /// </summary>
        /// <returns></returns>
        public IEnumerator<TaskResultResult> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        /// <summary>
        /// 寻找指定对象在列表中的下标
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(TaskResultResult item)
        {
            return list.IndexOf(item);
        }

        /// <summary>
        /// 往指定下标中插入对象
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, TaskResultResult item)
        {
            list.Insert(index, item);
        }
        /// <summary>
        /// 从列表中移除对象
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(TaskResultResult item)
        {
            return list.Remove(item);
        }
        /// <summary>
        /// 从列表中移除指定下标的对象
        /// </summary>
        /// <param name="index">要移除对象的列表下标</param>
        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
        }
        /// <summary>
        /// 获取枚举器
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }
    /// <summary>
    /// 结果
    /// </summary>
    public class TaskResultResult
    {
        /// <summary>
        /// 路网ID
        /// </summary>
        [Newtonsoft.Json.JsonProperty("matrixId")]
        public string MatrixId { get; set; }

        /// <summary>
        /// 路网版本
        /// <para>增加网点删除网点更新网点 路网版本会变化，路网ID不变</para>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("commitId")]
        public string CommitId { get; set; }


        /// <summary>
        /// 计算状态
        /// </summary>
        [Newtonsoft.Json.JsonProperty("status")]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public PostResultStatus? Status { get; set; }

        /// <summary>
        /// 时间信息
        /// </summary>
        [Newtonsoft.Json.JsonProperty("time")]
        public string Time { get; set; }
    }
    /// <summary>
    /// 计算状态
    /// </summary>
    public enum PostResultStatus
    {

        /// <summary>
        /// 计算中
        /// </summary>
        [Description("计算中")]
        RUNNING = 0,

        /// <summary>
        /// 已完成
        /// </summary>
        [Description("已完成")]
        FINISHED = 1,

        /// <summary>
        /// 异常
        /// </summary>
        [Description("异常")]
        ERROR = 2,
    }
}
