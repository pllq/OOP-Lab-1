using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIL
{
    public class Student : Human, IPlayGuitar
    {
        private byte year_of_study;
        public byte Year_of_study
        {
            get
            {
                return year_of_study;
            }
            set
            {
                year_of_study = value;
            }
        }

        private string student_ID;
        public string Student_ID
        {
            get
            {
                return student_ID;
            }
            set
            {
                student_ID = value;
            }
        }
        private static string student_ID_pattern = @"^[a-zA-Z]{2}\d{10}$";
        public static string Student_ID_pattern
        {
            get => student_ID_pattern;
        }

        public string To_Study(string firstname, string lastname)
        {
            return ($"I am {firstname} {lastname} and I study.\n");
        }

        public string play_guitar()
        {
            return "I am student and I play a song on the guitar about my college.\n";
        }
    }
}
