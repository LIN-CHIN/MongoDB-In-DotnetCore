using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    /// <summary>
    /// 自定義 JsonConverter 
    /// 將 ResponseCode 的輸出 ovveride 只顯示 id ， 而不是顯示 object 
    /// ex: 
    /// Call 某 API 後 得到的Response 是：
    /// {
    ///     Code: 0
    /// }
    /// 
    /// 而不是
    /// {
    ///     Code :
    ///     {
    ///         _id : 0 ,
    ///         _name: Success,
    ///         _description: null
    ///     }
    /// }
    /// </summary>
    public class EnumerationJsonConverter : JsonConverter<Enumeration>
    {
        public override Enumeration ReadJson(JsonReader reader, Type objectType, Enumeration existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, Enumeration value, JsonSerializer serializer)
        {
            writer.WriteValue(value._id);
        }
    }
}
