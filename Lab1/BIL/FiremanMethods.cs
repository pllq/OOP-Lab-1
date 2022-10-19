using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIL
{
    public class FiremanMethods
    {
        public static void Add_Fireman_To_The_Database(Human reciever, Fireman fireman_to_create)
        {
                fireman_to_create.First_Name = reciever.First_Name;
                fireman_to_create.Last_Name = reciever.Last_Name;
                fireman_to_create.Identification_code = reciever.Identification_code;
                fireman_to_create.Hobby = reciever.Hobby;


                InputCommands.array_of_input[0] = $"Fireman {fireman_to_create.First_Name}{fireman_to_create.Last_Name}\n";
                InputCommands.array_of_input[1] = $"{{ \"Firstname\": \"{fireman_to_create.First_Name}\",\n";
                InputCommands.array_of_input[2] = $"\"Lastname\": \"{fireman_to_create.Last_Name}\",\n";
                InputCommands.array_of_input[3] = $"\"IdentificationCode\": \"{fireman_to_create.Identification_code}\"\n";
                InputCommands.array_of_input[4] = $"\"Hobby\": \"{fireman_to_create.Hobby}\"\n";
                InputCommands.array_of_input[5] = $"\"NumberOfBuildingsExtinguished\": \"{fireman_to_create.Number_of_buildings_extinguished}\"\n";
                InputCommands.array_of_input[6] = $"\"NumberOfPeopleRescued\": \"{fireman_to_create.Number_of_people_rescued}\"}};\n";

                WriteToFile.Add_To_Database(InputCommands.array_of_input);
        }
    }
}
