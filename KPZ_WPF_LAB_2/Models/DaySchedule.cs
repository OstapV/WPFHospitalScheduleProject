using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace KPZ_WPF_LAB_2.Models
{
    [DataContract]
    public class DaySchedule
    {
        [DataMember]
        public List<Record> Records { get; set; }

        [DataMember]
        public DateTime DayScheduleDate { get; set; }

        [DataMember]
        public TimeSpan DayStart { get; set; }

        [DataMember]
        public TimeSpan DayEnd { get; set; }

        [DataMember]
        public TimeSpan Interval { get; set; }

        public DaySchedule(TimeSpan dayStart, TimeSpan dayEnd, TimeSpan interval, DateTime date, List<Record> recList)
        {
            DayStart = dayStart;
            DayEnd = dayEnd;
            Interval = interval;
            DayScheduleDate = date;

            var totalTime = dayEnd - dayStart;
            var count = Convert.ToInt32(Math.Ceiling(totalTime.Divide(interval)));
            Records = recList;

            TimeSpan curDate = dayStart;
            for (int i = 0; i < count; i++)
            {
                if (i < recList.Count)
                {
                    TimeSpan newDate = curDate.Add(interval);
                    if (newDate > dayEnd)
                        newDate = dayEnd;
                    Records[i].Time = new TimeShow(curDate, newDate);
                    curDate = newDate;
                }
                else
                {
                    Records.Add(new Record());
                    TimeSpan newDate = curDate.Add(interval);
                    if (newDate > dayEnd)
                        newDate = dayEnd;
                    Records[i].Time = new TimeShow(curDate, newDate);
                    curDate = newDate;
                }
            }
        }
    }
}
