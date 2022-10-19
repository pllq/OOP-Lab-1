using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DAL
{
    public class RegexPatternCheck 
    {
        public static bool Pattern_of_the_Data_check(string arg_data, string arg_pattern) 
        {
            Regex pattern_check = new Regex(arg_pattern);

            if (pattern_check.IsMatch(arg_data))
            {
                return true;
            }
            return false;
        }
    }
}
