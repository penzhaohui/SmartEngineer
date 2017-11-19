using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace SmartEngineer.Framework.Utils
{
    public sealed class ObjectUtil
    {
        /// <summary>
        /// Clones the specified list.
        /// C# List的深复制 - https://www.cnblogs.com/tianxue/p/3859214.html
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="List">The list.</param>
        /// <returns>List{``0}.</returns>
        public static List<T> Clone<T>(object List)
        {
            using (Stream objectStream = new MemoryStream())
            {
                // XmlSerializer, DataContractSerializer 和 BinaryFormatter区别与用法分析 - https://www.cnblogs.com/nankezhishi/archive/2012/05/12/serializationcompare.html
                // 两中特别有用的序列化，反序列化函数 using XmlSerializer or BinaryFormatter - http://grant.iteye.com/blog/43552
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(objectStream, List);
                objectStream.Seek(0, SeekOrigin.Begin);
                return formatter.Deserialize(objectStream) as List<T>;
            }
        }

        /// <summary><summary></summary>     
        /// Serializes object to xml string.   
        /// </summary>     
        public static string ObjectToXml(object serializableObject)
        {
            StringWriter sw = new StringWriter();
            XmlSerializer serial = new XmlSerializer(serializableObject.GetType());
            serial.Serialize(sw, serializableObject);
            return sw.ToString();
        }

        /// <summary><summary></summary>      
        /// deserialize xml to object.      
        /// </summary>      
        /// <param name="xmlString">serialized xml </param>
        /// <param name="aimObjectType"> the type of target object</param>     
        /// <returns><returns></returns>Deserialized object.</returns>      
        public static object XmlToObject(string xmlString, Type aimObjectType)
        {
            XmlSerializer xs = new XmlSerializer(aimObjectType);
            StringReader sr = new StringReader(xmlString);
            Object returnedObject = xs.Deserialize(sr);
            return returnedObject;
        }

        ///<summary></summary> <summary><summary></summary>  
        /// Serializes serializable object to base64 string.   
        /// </summary><summary></summary>   
        public static string Obj2Base64String(object serializableObject)
        {
            byte[] resultBytes = null;
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter
                   = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, serializableObject);
            resultBytes = stream.ToArray();
            stream.Close();
            string returnedData = Convert.ToBase64String(resultBytes);
            return returnedData;
        }

        ///<summary></summary> <summary><summary></summary>  
        /// Deserializes base64 string to object.   
        /// </summary><summary></summary>   
        public static object Base64String2Obj(string deserializedString)
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter
                   = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            byte[] middata = Convert.FromBase64String(deserializedString);
            stream.Write(middata, 0, middata.Length);
            //Pay attention to the following line. don't forget this line.   
            stream.Seek(0, SeekOrigin.Begin);
            object returnedData = formatter.Deserialize(stream);
            stream.Close();
            return returnedData;
        }

    }
}
