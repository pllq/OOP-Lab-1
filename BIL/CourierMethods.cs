using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIL
{
    public class CourierMethods
    {
        public static void Add_Courier_To_The_Database(Human reciever, Courier courier_to_create)
        {
                courier_to_create.First_Name = reciever.First_Name;
                courier_to_create.Last_Name = reciever.Last_Name;
                courier_to_create.Identification_code = reciever.Identification_code;
                courier_to_create.Hobby = reciever.Hobby;

                string courier_data_write_to_file =
                    $"Courier {courier_to_create.First_Name}{courier_to_create.Last_Name}\n" +
                        $"{{ \"Firstname\": \"{courier_to_create.First_Name}\",\n" +
                        $"\"Lastname\": \"{courier_to_create.Last_Name}\",\n" +
                        $"\"IdentificationCode\": \"{courier_to_create.Identification_code}\"\n" +
                        $"\"Hobby\": \"{courier_to_create.Hobby}\"\n" +
                        $"\"YearsOfWorkExperience\": \"{courier_to_create.Years_of_work_experience}\"\n" +
                        $"\"NumberOfDeliveredPackages\": \"{courier_to_create.Number_of_delivered_packages}\"}};";


                InputCommands.array_of_input[0] = $"Courier {courier_to_create.First_Name}{courier_to_create.Last_Name}\n";
                InputCommands.array_of_input[1] = $"{{ \"Firstname\": \"{courier_to_create.First_Name}\",\n";
                InputCommands.array_of_input[2] = $"\"Lastname\": \"{courier_to_create.Last_Name}\",\n";
                InputCommands.array_of_input[3] = $"\"IdentificationCode\": \"{courier_to_create.Identification_code}\"\n";
                InputCommands.array_of_input[4] = $"\"Hobby\": \"{courier_to_create.Hobby}\"\n";
                InputCommands.array_of_input[5] = $"\"YearsOfWorkExperience\": \"{courier_to_create.Years_of_work_experience}\"\n";
                InputCommands.array_of_input[6] = $"\"NumberOfDeliveredPackages\": \"{courier_to_create.Number_of_delivered_packages}\"}};\n";

                WriteToFile.Add_To_Database(InputCommands.array_of_input);
        }
    }
}
