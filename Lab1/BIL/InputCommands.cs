using DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace BIL
{
    public class InputCommands // internal class InputCommands
    {
        internal static string[] array_of_input = new string[7];

        public static string Hobby_Set(string arg_user_hobby_input) //maybe internal static void ?
        {
            switch (arg_user_hobby_input)
            {
                case "1":
                    arg_user_hobby_input = "Sport";
                    break;

                case "2":
                    arg_user_hobby_input = "Painting";
                    break;

                case "3":
                    arg_user_hobby_input = "Signing";
                    break;

                case "4":
                    arg_user_hobby_input = "Playing guitar";
                    break;

                case "5":
                    arg_user_hobby_input = "Cooking";
                    break;
            }
            return arg_user_hobby_input;
        }

        public static string[] Show_Entity_by_Firstname_and_Lastnames(int lines_counter, string firstname_lastname)
        {
            int max_data_has = 0;

            if (!ReadFromFile.Entity_Already_Exists(firstname_lastname, Human.Firstname_lastname_pattern))
            {
                throw new Exception("There is no such person in the list.\n");
            }

            max_data_has = ReadFromFile.How_Many_Data_Lines(firstname_lastname);

            string[] array_of_person_data = new string[max_data_has];

            ReadFromFile.Find_by_Firstname_and_Lastname(firstname_lastname, ref array_of_person_data, lines_counter);


            return array_of_person_data;
        }

        public static string [][] Show_all_Entities_of_Specific_Type(string preson_type, int lines_counter) //maybe internal static void ?
        {
            preson_type = char.ToUpper(preson_type[0]) + preson_type.Substring(1);

            int number_of_persons_of_specific_type = 0;
            int max_data_has = 0;

            number_of_persons_of_specific_type = ReadFromFile.Amount_of_Persons_of_Specific_Type(preson_type, lines_counter, Human.Firstname_lastname_pattern);
            max_data_has = ReadFromFile.How_Many_Data_Lines(preson_type);

            string[][] for_person_finding = new string[number_of_persons_of_specific_type][];

            ReadFromFile.Get_All_Entities_of_Same_Type(ref for_person_finding, preson_type, lines_counter, max_data_has);


            return for_person_finding;
        }
    }
}
