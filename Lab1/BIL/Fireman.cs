using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIL
{
    public class Fireman : Human, IPlayGuitar
    {

        private short number_of_buildings_extinguished;
        public short Number_of_buildings_extinguished
        {
            get
            {
                return number_of_buildings_extinguished;
            }
            set
            {
                number_of_buildings_extinguished = value;
            }
        }

        //

        private short number_of_people_rescued;
        public short Number_of_people_rescued
        {
            get
            {
                return number_of_people_rescued;
            }
            set
            {
                number_of_people_rescued = value;
            }
        }

        public string To_Put_out_a_Fire(string firstname, string lastname)
        {
            return ($"I am {firstname} {lastname} and I put out the fire.\n");
        }

        public string play_guitar()
        {
            return "I am a fireman and I play a song on the guitar about people who were rescued during the fire.\n";
        }
    }
}
