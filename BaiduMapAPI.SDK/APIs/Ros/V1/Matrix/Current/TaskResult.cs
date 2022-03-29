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
        public TaskResultResult this[int index] { get => list[index]; set => list[index] = value; }

        public int Count => list.Count;

        public bool IsReadOnly => false;

        public void Add(TaskResultResult item)
        {
            list.Add(item);
        }

        public void Clear()
        {
            list.Clear();
        }

        public bool Contains(TaskResultResult item)
        {
            return list.Contains(item);
        }

        public void CopyTo(TaskResultResult[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<TaskResultResult> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public int IndexOf(TaskResultResult item)
        {
            return list.IndexOf(item);
        }

        public void Insert(int index, TaskResultResult item)
        {
            list.Insert(index, item);
        }

        public bool Remove(TaskResultResult item)
        {
            return list.Remove(item);
        }

        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }

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
