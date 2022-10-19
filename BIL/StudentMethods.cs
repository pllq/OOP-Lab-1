using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIL
{
    public class StudentMethods
    {
        //Student methods:

        public static void Add_Student_To_The_Database(Human reciever, Student student_to_create) //maybe internal static void ?
        {
                student_to_create.First_Name = reciever.First_Name;
                student_to_create.Last_Name = reciever.Last_Name;
                student_to_create.Identification_code = reciever.Identification_code;
                student_to_create.Hobby = reciever.Hobby;

                InputCommands.array_of_input[0] = $"Student {student_to_create.First_Name}{student_to_create.Last_Name}\n";
                InputCommands.array_of_input[1] = $"{{ \"Firstname\": \"{student_to_create.First_Name}\",\n";
                InputCommands.array_of_input[2] = $"\"Lastname\": \"{student_to_create.Last_Name}\",\n";
                InputCommands.array_of_input[3] = $"\"IdentificationCode\": \"{student_to_create.Identification_code}\"\n";
                InputCommands.array_of_input[4] = $"\"Hobby\": \"{student_to_create.Hobby}\"\n";
                InputCommands.array_of_input[5] = $"\"YearOfStudy\": \"{student_to_create.Year_of_study}\"\n";
                InputCommands.array_of_input[6] = $"\"StudentID\": \"{student_to_create.Student_ID}\"}};\n";

                WriteToFile.Add_To_Database(InputCommands.array_of_input);
        }

        public static int Calculate_Number_Of2NdYear_Who_Play_Sport() //maybe internal static void ?
        {
            int number_of2nd_year_students_who_play_sport = 0;

                number_of2nd_year_students_who_play_sport = ReadFromFile.Sport_plus_SecondYearStudent();

            return number_of2nd_year_students_who_play_sport;
        }
    }
}
