using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIL
{
    public class Human
    {
        private string first_name;
        public string First_Name
        {
            get
            {
                return first_name;
            }
            set
            {
                first_name = value;
            }
        }
        //
        private string last_name;
        public string Last_Name
        {
            get
            {
                return last_name;
            }
            set
            {
                last_name = value;
            }
        }
        private static string separately_for_firstname_and_lastname_pattern = @"^[a-zA-Z]+$"; //@"^[a-zA-Z]+$"
        public static string Separately_for_firstname_and_lastname_pattern
        {
            get => separately_for_firstname_and_lastname_pattern;
        }

        //

        private static string firstname_lastname_pattern = @"\b[A-Z][A-Z]\b|\b[A-Z][A-Z][a-z]+\b|\b[A-Z][a-z]+[A-Z]\b|\b[A-Z][a-z]+[A-Z][a-z]+\b";
        public static string Firstname_lastname_pattern
        {
            get => firstname_lastname_pattern;
        }

        //

        private string identification_code;
        public string Identification_code
        {
            get
            {
                return identification_code;
            }
            set
            {
                identification_code = value;
            }
        }
        private static string identification_code_pattern = @"^[0-9]{10}$";
        public static string Identification_code_pattern
        {
            get => identification_code_pattern;
        }
        //
        private string hobby;
        public string Hobby
        {
            get
            {
                return hobby;
            }
            set
            {
                hobby = value;
            }
        }
    }
}
