using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security;
using System.Text;

namespace KPZ_WPF_LAB_2.Models
{
    [DataContract]
    public class Doctor : User
    {
        [DataMember]
        public string Name { get; set; }
        
        [DataMember]
        public string Surname { get; set; }
        
        [DataMember]
        public string Speciality { get; set; }
        
        [DataMember]
        public List<DaySchedule> DoctorSchedule { get; set; }


        public Doctor(string name, string surname, string speciality, List<DaySchedule> doctorSchedule, string username, string password) : base(username, password)
        {
            Name = name;
            Surname = surname;
            Speciality = speciality;
            DoctorSchedule = doctorSchedule;
        }
    }
}
