using DAL;
using BIL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IllustrationProject
{
    public class ConsoleApp
    {
        private static string Firstname
        {
            get;
            set;
        }

        private static string Lastname
        {
            get;
            set;
        }

        private static string Firstname_Lastname 
        {
            get;
            set;
        }

        private static Human reciever = new Human();


        //


        private static Human Common_Human_Data_Input(string what_person)  //Human Add_Person_To_The_Database(string what_person)
        {
            Human person_to_create = new Human();

            Console.Write("Input First name: ");
            person_to_create.First_Name = Input_by_User(Human.Separately_for_firstname_and_lastname_pattern).ToLower();
            person_to_create.First_Name = char.ToUpper(person_to_create.First_Name[0]) + person_to_create.First_Name.Substring(1);// to make first letter Upper case and others lower case//= char.ToUpper(courier_to_create.First_Name[0]);
            Console.WriteLine();

            Console.Write("Input Last name: ");
            person_to_create.Last_Name = Input_by_User(Human.Separately_for_firstname_and_lastname_pattern).ToLower();
            person_to_create.Last_Name = char.ToUpper(person_to_create.Last_Name[0]) + person_to_create.Last_Name.Substring(1);
            Console.WriteLine();

            if (ReadFromFile.Entity_Already_Exists(person_to_create.First_Name + person_to_create.Last_Name, Human.Firstname_lastname_pattern)) //false if doesnt contain, true if contain such garbonzo
            {
                throw new Exception("This person is already on the database.\n");
            }

            Console.Write("Input Identification code (consists of 10 numbers): ");
            person_to_create.Identification_code = Input_by_User(Human.Identification_code_pattern);
            Console.WriteLine();

            //Set hobby
            Console.WriteLine(ConsoleMenu.Entity_Hobby_Menu(what_person));
            Console.Write("Choose from the list (input number of the hobby): ");
            string user_hobby_input = Input_by_User(@"^[1-5]{1}$");
            Console.WriteLine();

            user_hobby_input = InputCommands.Hobby_Set(user_hobby_input);
            person_to_create.Hobby = user_hobby_input;

            return person_to_create;
        }


        private static string Input_by_User(string arg_pattern)
        {
            string return_string = Console.ReadLine();

            while (!RegexPatternCheck.Pattern_of_the_Data_check(return_string, arg_pattern))
            {
                Console.WriteLine(ConsoleMenu.Wrong_Input());
                return_string = Console.ReadLine();
            }
            return return_string;
        }


        private static void Input_Firstname_and_Lastname_of_Person() //maybe internal static void ?
        {
            do
            {
                Console.Write("Input person's Firstname: ");
                Firstname = Input_by_User(Human.Separately_for_firstname_and_lastname_pattern).ToLower();
                Firstname = char.ToUpper(Firstname[0]) + Firstname.Substring(1);
                Console.WriteLine();

                Console.Write("Input person's Lastname: ");
                Lastname = Input_by_User(Human.Separately_for_firstname_and_lastname_pattern).ToLower();
                Lastname = char.ToUpper(Lastname[0]) + Lastname.Substring(1);
                Console.WriteLine();

                Firstname_Lastname = Firstname + Lastname;

            } while (!RegexPatternCheck.Pattern_of_the_Data_check(Firstname_Lastname, Human.Firstname_lastname_pattern));
        }


        internal static void Start_Console_App() 
        {
            Student student_to_create = new Student();
            Courier courier_to_create = new Courier();
            Fireman fireman_to_create = new Fireman();
            //InputCommands inputcommands = new InputCommands();

            Console.Write("Input file path, where you want to create a database. Example: 'E:\\file_name.txt' or 'E:\\folder_name\\file_name.txt'.\n" +
                "Note you can't use such symbols when you give a NAME to your file ( \"/, *, ?, \", <, >, | )\"): ");

            string path = "";
            string path_pattern = @"^\w{1}:[^\:]+$"; // @"^\w{1}:[^\:]+$" //@"^\w{1}:" //old

            bool not_created = true;
            do
            {
                try
                {
                    path = Console.ReadLine();
                    while (!RegexPatternCheck.Pattern_of_the_Data_check(path, path_pattern) || Database.Create_Database(path))
                    {

                        if (!RegexPatternCheck.Pattern_of_the_Data_check(path, path_pattern))
                        {
                            Console.Write(ConsoleMenu.Wrong_Input());
                        }
                        path = Console.ReadLine();
                    }
                    not_created = false;
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }
            } while (not_created);
            Console.WriteLine();
            string input_according_to_ConsoleMenu_methods;
            string input_according_to_ConsoleMenu_methods_pattern = @"^[1-5]{1}$|^d$|^D$";

            bool exit_the_program = false;
            int lines_counter = 0;

            do
            {
                try
                {
                    Console.WriteLine(ConsoleMenu.General_Menu());

                    Console.Write("Choose from the list: ");
                    input_according_to_ConsoleMenu_methods = Input_by_User(input_according_to_ConsoleMenu_methods_pattern);
                    Console.WriteLine();

                    switch (input_according_to_ConsoleMenu_methods)
                    {
                        case "1": //Write

                            Console.WriteLine(ConsoleMenu.Add_or_Delete_Menu());

                            Console.Write("Choose from the list: ");
                            input_according_to_ConsoleMenu_methods = Input_by_User(input_according_to_ConsoleMenu_methods_pattern);
                            Console.WriteLine();

                            switch (input_according_to_ConsoleMenu_methods)
                            {
                                case "1": //Add

                                    Console.WriteLine(ConsoleMenu.List_Of_All_Entities());

                                    Console.Write("Choose from the list what entity you want to add: ");
                                    input_according_to_ConsoleMenu_methods = Input_by_User(input_according_to_ConsoleMenu_methods_pattern);
                                    Console.WriteLine();

                                    switch (input_according_to_ConsoleMenu_methods)
                                    {
                                        case "1": //Add Student
                                            reciever = Common_Human_Data_Input("student");

                                                  //Year of study
                                            Console.Write("Input year of study: ");
                                            student_to_create.Year_of_study = byte.Parse(Input_by_User(@"^[1-6]{1}$")); //convert string to byte
                                            Console.WriteLine();

                                            //Student ID
                                            Console.Write("Input student ID (2 letters and 10 numbers): ");
                                            student_to_create.Student_ID = Input_by_User(Student.Student_ID_pattern).ToUpper();
                                            Console.WriteLine();

                                            StudentMethods.Add_Student_To_The_Database(reciever, student_to_create);

                                            Console.WriteLine($"Student {student_to_create.First_Name} {student_to_create.Last_Name} was successfully added to the database.\n");
                                            break;

                                        case "2": //Add Courier

                                            reciever = Common_Human_Data_Input("courier");

                                            //Years of work experience
                                            Console.Write("Input years of work experience: ");
                                            courier_to_create.Years_of_work_experience = byte.Parse(Input_by_User(@"^\d{1,2}$")); //convert string to byte
                                            Console.WriteLine();

                                            //Number of delivered packages
                                            Console.Write("Input number of delivered packages: ");
                                            courier_to_create.Number_of_delivered_packages = Input_by_User(@"^\d{1,6}$").ToUpper();
                                            Console.WriteLine();

                                            CourierMethods.Add_Courier_To_The_Database(reciever, courier_to_create);

                                            Console.WriteLine($"Courier {courier_to_create.First_Name} {courier_to_create.Last_Name} was successfully added to the database.\n");
                                            break;

                                        case "3": //Add Fireman

                                            reciever = Common_Human_Data_Input("fireman");

                                            //number of buildings extinguished
                                            Console.Write("Input a number of buildings extinguished (0 - 9999): ");
                                            fireman_to_create.Number_of_buildings_extinguished = short.Parse(Input_by_User(@"^\d{0,4}$")); //convert string to byte
                                            Console.WriteLine();

                                            //number of people rescued
                                            Console.Write("Input number of people rescued: ");
                                            fireman_to_create.Number_of_people_rescued = short.Parse(Input_by_User(@"^\d{0,5}$"));
                                            Console.WriteLine();
                                            
                                            FiremanMethods.Add_Fireman_To_The_Database(reciever, fireman_to_create);

                                            Console.WriteLine($"Fireman {fireman_to_create.First_Name} {fireman_to_create.Last_Name} was successfully added to the database.\n");
                                            break;
                                    }
                                    break;


                                case "2": //Delete

                                    lines_counter = ReadFromFile.Lines_Counter();

                                    if (lines_counter == 0)
                                    {
                                        throw new Exception("File is empty.\n");
                                    }

                                    Input_Firstname_and_Lastname_of_Person();

                                    if (!ReadFromFile.Entity_Already_Exists(Firstname_Lastname, Human.Firstname_lastname_pattern)) //@"[A-Z][a-z]+[A-Z][a-z]+"//false if doesnt contain, true if contain such garbonzo
                                    {
                                        throw new Exception("There is no such person on the list.\n");
                                    }

                                    WriteToFile.Delete_From_Database(Firstname_Lastname, lines_counter);

                                    Console.WriteLine($"{Firstname} {Lastname} was successfully deleted from the database.\n");

                                    break;
                            }
                            break;


                        //__________________________________________________________________________


                        case "2": //Read

                            lines_counter = ReadFromFile.Lines_Counter();

                            if (lines_counter == 0)
                            {
                                throw new Exception("File is empty.\n");
                            }

                            Console.WriteLine("1. Show data of specific person (search by Firstname and lastnames).");
                            Console.WriteLine("2. Show whole database.");
                            Console.WriteLine("3. Show other separate functions for different classes.\n");

                            Console.Write("Choose from the list: ");
                            input_according_to_ConsoleMenu_methods = Input_by_User(input_according_to_ConsoleMenu_methods_pattern);
                            Console.WriteLine();

                            switch (input_according_to_ConsoleMenu_methods)
                            {
                                case "1":


                                    Input_Firstname_and_Lastname_of_Person();

                                    string [] array_of_person_data = InputCommands.Show_Entity_by_Firstname_and_Lastnames(lines_counter, Firstname_Lastname);

                                    for (int i = 0; i < array_of_person_data.Length; i++) 
                                    {
                                        Console.WriteLine(array_of_person_data[i]);
                                    }

                                    Console.WriteLine();
                                    break;

                                case "2":
                                    Console.WriteLine(ReadFromFile.Read_Everything_From_Database());
                                    break;

                                case "3":

                                    Console.WriteLine(ConsoleMenu.List_Of_All_Entities());

                                    Console.Write("Choose from the list: ");
                                    input_according_to_ConsoleMenu_methods = Input_by_User(input_according_to_ConsoleMenu_methods_pattern);
                                    Console.WriteLine();

                                    switch (input_according_to_ConsoleMenu_methods)
                                    {
                                        case "1": //About Student

                                            if (!ReadFromFile.Entity_Already_Exists("Student", @"\b[A-Z][a-z]+\b"))
                                            {
                                                throw new Exception("There are no students in the file.\n");
                                            }

                                            Console.WriteLine(ConsoleMenu.Read_Student_Console_Menu());

                                            Console.Write("Choose from the list: ");
                                            input_according_to_ConsoleMenu_methods = Input_by_User(input_according_to_ConsoleMenu_methods_pattern);
                                            Console.WriteLine();

                                            switch (input_according_to_ConsoleMenu_methods)
                                            {
                                                case "1": //info about all students
                                                    string [][] for_person_finding = InputCommands.Show_all_Entities_of_Specific_Type("Student", lines_counter);
                                                    for (int i = 0; i < for_person_finding.Length; i++)
                                                    {
                                                        for (int j = 0; j < 7; j++)
                                                        {
                                                            Console.WriteLine(for_person_finding[i][j]);
                                                        }
                                                    }

                                                    Console.WriteLine();
                                                    break;

                                                case "2": // calc. number of the 2nd year students who play sports.
                                                    Console.WriteLine($"Number of the 2nd year students who play sports = {StudentMethods.Calculate_Number_Of2NdYear_Who_Play_Sport()}\n");
                                                    break;

                                                case "3":

                                                    Console.WriteLine("Input student from the list, who you want to see studying.");
                                                    Input_Firstname_and_Lastname_of_Person();

                                                    if (!ReadFromFile.Entity_Already_Exists(Firstname_Lastname, Human.Firstname_lastname_pattern)) //@"[A-Z][a-z]+[A-Z][a-z]+"//false if doesnt contain, true if contain such garbonzo
                                                    {
                                                        throw new Exception("There is no such person on the list.\n");
                                                    }

                                                    Console.WriteLine(student_to_create.To_Study(Firstname, Lastname));
                                                    break;

                                                case "4":
                                                    Console.WriteLine(student_to_create.play_guitar());
                                                    break;
                                            }
                                            break;


                                        case "2": //About Courier

                                            if (!ReadFromFile.Entity_Already_Exists("Courier", @"\b[A-Z][a-z]+\b"))
                                            {
                                                throw new Exception("There are no couriers in the file.\n");
                                            }

                                            Console.WriteLine(ConsoleMenu.Read_Courier_Console_Menu());

                                            Console.Write("Choose from the list: ");
                                            input_according_to_ConsoleMenu_methods = Input_by_User(input_according_to_ConsoleMenu_methods_pattern);
                                            Console.WriteLine();

                                            switch (input_according_to_ConsoleMenu_methods)
                                            {
                                                case "1": //info about all students
                                                    string[][] for_person_finding = InputCommands.Show_all_Entities_of_Specific_Type("Courier", lines_counter);
                                                    for (int i = 0; i < for_person_finding.Length; i++)
                                                    {
                                                        for (int j = 0; j < 7; j++)
                                                        {
                                                            Console.WriteLine(for_person_finding[i][j]);
                                                        }
                                                    }
                                                    Console.WriteLine();
                                                    break;

                                                case "2":
                                                    Console.WriteLine("Input courier from the list, who you want to see deliver.");
                                                    Input_Firstname_and_Lastname_of_Person();

                                                    if (!ReadFromFile.Entity_Already_Exists(Firstname_Lastname, Human.Firstname_lastname_pattern)) //@"[A-Z][a-z]+[A-Z][a-z]+"//false if doesnt contain, true if contain such garbonzo
                                                    {
                                                        throw new Exception("There is no such person on the list.\n");
                                                    }

                                                    Console.WriteLine(courier_to_create.To_Deliver(Firstname, Lastname));
                                                    break;

                                                case "3":
                                                    Console.WriteLine(courier_to_create.play_guitar());
                                                    break;
                                            }
                                            break;

                                        case "3": //About Fireman

                                            if (!ReadFromFile.Entity_Already_Exists("Fireman", @"\b[A-Z][a-z]+\b"))
                                            {
                                                throw new Exception("There are no fireman in the file.\n");
                                            }

                                            Console.WriteLine(ConsoleMenu.Read_Fireman_Console_Menu());

                                            Console.Write("Choose from the list: ");
                                            input_according_to_ConsoleMenu_methods = Input_by_User(input_according_to_ConsoleMenu_methods_pattern);

                                            Console.WriteLine();

                                            switch (input_according_to_ConsoleMenu_methods)
                                            {
                                                case "1": //info about all students
                                                    string[][] for_person_finding = InputCommands.Show_all_Entities_of_Specific_Type("Fireman", lines_counter);

                                                    for (int i = 0; i < for_person_finding.Length; i++)
                                                    {
                                                        for (int j = 0; j < 7; j++)
                                                        {
                                                            Console.WriteLine(for_person_finding[i][j]);
                                                        }
                                                    }
                                                    Console.WriteLine();
                                                    break;

                                                case "2":
                                                    Console.WriteLine("Input fireman from the list, who you want to see work.");
                                                    Input_Firstname_and_Lastname_of_Person();

                                                    if (!ReadFromFile.Entity_Already_Exists(Firstname_Lastname, Human.Firstname_lastname_pattern)) //@"[A-Z][a-z]+[A-Z][a-z]+"//false if doesnt contain, true if contain such garbonzo
                                                    {
                                                        throw new Exception("There is no such person on the list.\n");
                                                    }

                                                    Console.WriteLine(fireman_to_create.To_Put_out_a_Fire(Firstname, Lastname));
                                                    break;

                                                case "3":
                                                    Console.WriteLine(fireman_to_create.play_guitar());
                                                    break;

                                            }
                                            break;
                                    }
                                    break;
                            }
                            break;

                        //__________________________________________________________________________

                        case "3": //Exit
                            exit_the_program = true;
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (!exit_the_program); // if true == exit
        }
    }
}
