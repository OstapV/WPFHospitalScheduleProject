using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace KPZ_WPF_LAB_2.Models
{
    [DataContract]
    public class TimeShow
    {
        [DataMember]
        public TimeSpan StartTime { get; set; }

        [DataMember]
        public TimeSpan EndTime { get; set; }

        public override string ToString()
        {
            return $"{DateTime.FromBinary(StartTime.Ticks).ToShortTimeString()}-{DateTime.FromBinary(EndTime.Ticks).ToShortTimeString()}";
        }

        public TimeShow(TimeSpan startTime, TimeSpan endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
