using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduMapAPI.Models
{
    #region RequestBase

    /// <summary>
    /// 基础请求信息
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    public abstract class Request<TResponse>
        where TResponse : Response
    {
        /// <summary>
        /// 请求地址
        /// </summary>
        public abstract string URL { get; }
    }

    

    #endregion

    


    


}
