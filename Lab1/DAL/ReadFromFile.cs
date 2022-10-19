using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL
{
    public class ReadFromFile
    {
        private static Regex regex_check_if_exists; //= new Regex(@"\s\b\w+\b"); // "\s\b\w+\b" // or: "\b\w+\s\w+\b"
        private static Match match_check_if_exists;
        private static string to_check_if_exists;
        private static StreamReader reader;
        
        
        //


        public static string Read_Everything_From_Database()
        {
            using (reader = new StreamReader(Database.Database_file_path.Name)) 
            {
                return reader.ReadToEnd();
            }
        }


        public static void Get_All_Entities_of_Same_Type(ref string [][]array_for_saving, string preson_type, int lines_counter, int max_data_has)
        {
            string line_needed = "";

            int size_for_array_for_saving = 0;
            //bool leave_method = false;
            using (reader = new StreamReader(Database.Database_file_path.Name))
            {

                for (int i = 0; i < lines_counter; i++)
                {
                    line_needed = reader.ReadLine(); //Student

                    if (line_needed.Contains(preson_type))
                    {
                        string[] aray_info_about_peson = new string[max_data_has];

                        for (int j = 0; j < aray_info_about_peson.Length; j++)
                        {
                            aray_info_about_peson[j] = line_needed;

                            if (j < aray_info_about_peson.Length - 1) 
                            {
                                line_needed = reader.ReadLine(); // Courier
                            }
                            i++;

                            if (j + 1 == aray_info_about_peson.Length) 
                            {
                                array_for_saving[size_for_array_for_saving] = aray_info_about_peson;
                                size_for_array_for_saving++;
                            }
                        }
                    }
                    if (array_for_saving.Length == size_for_array_for_saving)
                    {
                        break;
                    }
                }
            }
        }


        public static void Find_by_Firstname_and_Lastname(string firstname_and_lastname, ref string[] array_of_person_data, int lines_counter)
        {
            bool doesnt_contain = true;

            using (reader = new StreamReader(Database.Database_file_path.Name))
            {
                int j = lines_counter;
                for (int i = 0; i < j; i++)
                {
                    string to_the_next_line = reader.ReadLine();
                    if (to_the_next_line.Contains(firstname_and_lastname) && RegexPatternCheck.Pattern_of_the_Data_check(to_the_next_line,
                                                                                    @"\b[A-Z][A-Z]\b|\b[A-Z][A-Z][a-z]+\b|\b[A-Z][a-z]+[A-Z]\b|\b[A-Z][a-z]+[A-Z][a-z]+\b")) 
                    {
                        doesnt_contain = false;

                        for (int k = 0; k < array_of_person_data.Length; k++) 
                        {
                            array_of_person_data[k] = to_the_next_line;
                            to_the_next_line = reader.ReadLine();
                        }

                        break;
                    }
                }
            }

            if (doesnt_contain) 
            {
                throw new Exception("This person doesn't exist in the database.");
            }
        }


        public static int Lines_Counter()
        {
            int lines_counter = 0;

            using (reader = new StreamReader(Database.Database_file_path.Name))
            {
                while (reader.ReadLine() != null)
                {
                    lines_counter++;
                }
            }

            return lines_counter;
        }


        public static int How_Many_Data_Lines(string enitity_type) 
        {
            int how_many_data_does_enityty_has = 0;

            using (reader = new StreamReader(Database.Database_file_path.Name))
            {
                string to_read_next_line = reader.ReadLine();
                string temp_for_loop = "";
                while (to_read_next_line != null && (temp_for_loop != enitity_type || !to_read_next_line.Contains(";")))
                {
                    if (to_read_next_line.Contains(enitity_type))
                    {
                        while (!to_read_next_line.Contains(";"))
                        {
                            to_read_next_line = reader.ReadLine();
                            temp_for_loop = enitity_type;
                            how_many_data_does_enityty_has++;
                        }
                        break;
                    }
                    to_read_next_line = reader.ReadLine();
                }
            }
            how_many_data_does_enityty_has++;

            return how_many_data_does_enityty_has;
        }//how many lines of data does entity has (for everyone can be different number)


        public static int Amount_of_Persons_of_Specific_Type(string enitity_type, int lines_counter, string arg_pattern)
        {
            int number_of_persons_of_specific_type = 0;
            using (reader = new StreamReader(Database.Database_file_path.Name))
            {
                for (int i = 0; i < lines_counter; i++)
                {
                    string to_the_next_line = reader.ReadLine();
                    if (to_the_next_line.Contains(enitity_type) && RegexPatternCheck.Pattern_of_the_Data_check(to_the_next_line, arg_pattern)) //@"^\b[A-Z][a-z]+\b" //@"\b[A-Z][a-z]+\b" 
                    {
                        number_of_persons_of_specific_type++;
                    }
                }
            }

            if (number_of_persons_of_specific_type == 0)
            {
                throw new Exception("There are no humans of such type.");
            }

            return number_of_persons_of_specific_type;
        }


        public static int Sport_plus_SecondYearStudent()
        {
            int sport_and_secondyearStudent = 0;
            int how_many_lines = How_Many_Data_Lines("Student");
            string next_line = "";

            using (reader = new StreamReader(Database.Database_file_path.Name))
            {
                next_line = reader.ReadLine();
                while (next_line != null)
                {
                    if (next_line.Contains("Student ") /*&& next_line != null*/)
                    {
                        int i = 0;
                        while (i != how_many_lines) 
                        {

                            if (i < how_many_lines - 1)
                            {
                                next_line = reader.ReadLine();
                            }
                            i++;

                            if (next_line.Contains("Hobby") && next_line.Contains("Sport"))
                            {
                                next_line = reader.ReadLine();
                                i++;

                                if (next_line.Contains("YearOfStudy") && next_line.Contains("2"))
                                {
                                    next_line = reader.ReadLine();
                                    i++;
                                    sport_and_secondyearStudent++;
                                }
                            }
                        }
                    }

                    next_line = reader.ReadLine();
                }
            }

            return sport_and_secondyearStudent;
        }

        public static bool Entity_Already_Exists(string data_to_write_in_file, string arg_pattern)
        {
            regex_check_if_exists = new Regex(arg_pattern);

            match_check_if_exists = regex_check_if_exists.Match(data_to_write_in_file);

            to_check_if_exists = match_check_if_exists.Value;

            using (reader = new StreamReader(Database.Database_file_path.Name)) 
            {
                if (reader.ReadToEnd().Contains(to_check_if_exists))
                {
                    return true; //enitity exists, exception accures
                }
            }
            return false;
        }//checks if smth is already exists, by taking data (which will be checked) and pattern
    }
}
