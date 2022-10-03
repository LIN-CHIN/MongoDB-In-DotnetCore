using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class ResponseCode : Enumeration
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"> response code </param>
        /// <param name="name"> response code 中文名稱</param>
        /// <param name="description"> response 描述 </param>
        public ResponseCode(int id, string name, string description = null) : base(id, name, description)
        {
        }

        /// <summary>
        /// 成功
        /// </summary>
        public static ResponseCode Success = new ResponseCode(0, "Success");

        /// <summary>
        /// 系統錯誤 throw catch
        /// </summary>
        public static ResponseCode SystemError = new ResponseCode(10001, "SystemError", "system catch error ");

    }
}
