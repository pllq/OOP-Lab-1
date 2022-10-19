using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIL
{
    public class Courier : Human, IPlayGuitar
    {
        private byte years_of_work_experience;
        public byte Years_of_work_experience
        {
            get
            {
                return years_of_work_experience;
            }
            set
            {
                years_of_work_experience = value;
            }
        }

        //

        private string number_of_delivered_packages;
        public string Number_of_delivered_packages
        {
            get
            {
                return number_of_delivered_packages;
            }
            set
            {
                number_of_delivered_packages = value;
            }
        }

        //
        public string To_Deliver(string firstname, string lastname)
        {
            return ($"I am {firstname} {lastname} and I deliver.\n");
        }

        public string play_guitar()
        {
            return "I am courier and I play a song on the guitar about my box that i have delivered.\n";
        }
    }
}
