using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using KPZ_WPF_LAB_2.Serialization;

namespace KPZ_WPF_LAB_2.Models
{
    [DataContract]
    public class DataModel
    {
        

        [DataMember]
        public List<Administrator> Administrators { get; set; }

        [DataMember]
        public List<Doctor> Doctors { get; set; }

        public static string DataPath = "./dm_serialize.txt";

        public static DataModel Load()
        {
            if(File.Exists(DataPath))
            {
                return DataSerializer.XmlDeserialize(DataPath);
            }

            return new DataModel();
        }

        public void Save()
        {
            DataSerializer.XmlSerialize(this, DataPath);
        }

    }
}
