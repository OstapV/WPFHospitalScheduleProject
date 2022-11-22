using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;
using KPZ_WPF_LAB_2.Models;

namespace KPZ_WPF_LAB_2.Serialization
{
    public class DataSerializer
    {

        public static void XmlSerialize(DataModel data, string filePath)
        {
            var formatter = new DataContractSerializer(typeof(DataModel));
            var fileStream = new FileStream(filePath, FileMode.Create);
            formatter.WriteObject(fileStream, data);
            fileStream.Close();
        }

        public static DataModel XmlDeserialize(string filePath)
        {
            var fileStream = new FileStream(filePath, FileMode.Open);
            var formatter = new DataContractSerializer(typeof(DataModel));
            return (DataModel)formatter.ReadObject(fileStream);
        }

        //public static void XmlSerialize(Type dataType,DataModel data, string filePath)
        //{
        //    XmlSerializer xmlSerializer = new XmlSerializer(dataType);
        //    if (File.Exists(filePath)) File.Delete(filePath);
        //    TextWriter textWriter = new StreamWriter(filePath);
        //    xmlSerializer.Serialize(textWriter, data);
        //    textWriter.Close();
        //}

        //public static object XmlDeserialize(Type dataType, string filePath)
        //{
        //    object obj = null;

        //    XmlSerializer xmlSerializer = new XmlSerializer(dataType);

        //    if (File.Exists(filePath))
        //    {
        //        TextReader reader = new StreamReader(filePath);
        //        obj = xmlSerializer.Deserialize(reader);
        //        reader.Close();
        //    }

        //    return obj;
        //}
    }
}
