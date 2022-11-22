using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace KPZ_WPF_LAB_2.Models
{
    [DataContract]
    public class Record
    {
        [DataMember]
        public Case Case { get; set; }

        [DataMember]
        public string Note { get; set; }

        [DataMember]

        public TimeShow Time { get; set; }

        public Record(Case caseRecord, string note)
        {
            Case = caseRecord;
            Note = note;
        }

        public Record() { }
       
    }
}
