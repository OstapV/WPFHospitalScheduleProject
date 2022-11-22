using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace KPZ_WPF_LAB_2.Models
{
    [DataContract]
    public enum Case
    {
        [EnumMember]
        Workday,
        [EnumMember]
        Vacation,
        [EnumMember]
        Excuse

    }
}
