using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BIL
{
    public class ConsoleMenu
    {
        public static string General_Menu()
        {
            return "Choose what you want to do:\n" +
                "1. Edit database.\n" +
                "2. Read from database.\n" +
                "3. Exit the program.\n";
        }

        public static string Add_or_Delete_Menu()
        {
            return "Choose what you want to do:\n" +
                "1. Add to database.\n" +
                "2. Delete from database (search by firstname and lastname).\n";
        }

        public static string List_Of_All_Entities()
        {
            return "Choose entity:\n" +
                "1. Student\n" +
                "2. Courier\n" +
                "3. Fireman\n";
        }

        public static string Read_Student_Console_Menu()
        {
            return "Chose what you want to do with student's data:\n" +
                           "1. Show list with information about all students.\n" +
                           "2. Calculate the number of the 2nd year students who play sports.\n"+
                           "3. To study.\n"+
                           "4. To play a song on the guitar.\n";
        }

        public static string Read_Courier_Console_Menu()
        {
            return "Chose what you want to do with courier's data:\n" +
                "1. Show list with information about all couriers.\n" +
                "2. To deliver.\n" + "" +
                "3. To play a song on the guitar.\n";
        }

        public static string Read_Fireman_Console_Menu()
        {
            return "Chose what you want to do with fireman's data:\n" +
                "1. Show list with information about all fireman.\n" +
                "2. To put on a fire.\n" + "" +
                "3. To play a song on the guitar.\n";
        }

        public static string Entity_Hobby_Menu(string arg_entity)
        {
            return $"Choose what hobby the {arg_entity} has:\n" +
                "1. Sport\n" +
                "2. Painting\n" +
                "3. Signing\n" +
                "4. Playing guitar\n"+
                "5. Cooking\n";
        }


        public static string Wrong_Input()
        {
            return "Wrong input, please try again: ";
        }
    }
}
