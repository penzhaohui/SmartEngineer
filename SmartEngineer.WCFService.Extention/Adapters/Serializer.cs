using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SmartEngineer.WCFService.Ext.Adapters
{
    /// <summary> 
    /// 序列化门户 API 
    /// </summary> 
    public static class Serializer
    {
        /// <summary> 
        /// 使用二进制序列化对象。 
        /// </summary> 
        /// <param name="value"></param> 
        /// <returns></returns> 
        public static byte[] SerializeBytes(object value)
        {
            if (value == null) return null;

            var stream = new MemoryStream();
            new BinaryFormatter().Serialize(stream, value);

            //var dto = Encoding.UTF8.GetString(stream.GetBuffer()); 
            var bytes = stream.ToArray();
            return bytes;
        }

        /// <summary> 
        /// 使用二进制反序列化对象。 
        /// </summary> 
        /// <param name="bytes"></param> 
        /// <returns></returns> 
        public static object DeserializeBytes(byte[] bytes)
        {
            if (bytes == null) return null;

            //var bytes = Encoding.UTF8.GetBytes(dto as string); 
            var stream = new MemoryStream(bytes);

            var result = new BinaryFormatter().Deserialize(stream);

            return result;
        }
    }
}
