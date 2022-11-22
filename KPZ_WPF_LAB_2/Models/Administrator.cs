using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security;
using System.Text;

namespace KPZ_WPF_LAB_2.Models
{
    [DataContract]
    public class Administrator : User
    {
        [DataMember]
        public List<Doctor> Doctors { get; set; }

        public Administrator(List<Doctor> doctors, string username, string password) : base(username, password)
        {
            Doctors = doctors;
           
        }
    }
}
