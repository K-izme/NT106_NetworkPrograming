using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    [Serializable]
    public class Student
    {
        public int MSSV { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public float Diem1 { get; set; }
        public float Diem2 { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return string.Format(MSSV + " " + Name + " " + PhoneNumber + "\t" + Diem1 + " " + Diem2);
        }
    }
}

