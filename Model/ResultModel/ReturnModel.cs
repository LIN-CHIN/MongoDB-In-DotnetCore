using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ResultModel
{
    public class ReturnModel
    {
        /// <summary>
        /// 回傳代碼
        /// </summary>
        [JsonConverter(typeof(EnumerationJsonConverter))]
        public ResponseCode Code { get; set; }

        /// <summary>
        /// 訊息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 訊息細節 ( throw exception 內容 或 其他描述 )
        /// </summary>
        public string Detail { get; set; }

        /// <summary>
        /// 回傳資料
        /// </summary>
        public object Content { get; set; }

        /// <summary>
        /// 取得最終的結果
        /// </summary>
        /// <returns></returns>
        public ReturnModel GetResult()
        {
            return new ReturnModel
            {
                Code = Code,
                Message = Code._description ?? Code._name,
                Detail = Detail,
                Content = Content
            };
        }

    }
}
