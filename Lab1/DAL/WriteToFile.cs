using System.Text.RegularExpressions;

namespace DAL
{
    public class WriteToFile
    {

        private static StreamWriter writer;
        private static StreamReader reader;


        //


        public static void Add_To_Database(string []array_of_input)
        {

            using (writer = new StreamWriter(Database.Database_file_path.Name, true)) 
            {
                for (int i = 0; i < array_of_input.Length; i++)
                {
                    writer.Write(array_of_input[i]);
                }
            }
        }


        public static void Delete_From_Database(string arg_firstname_lastname, int lines_counter)
        {
            int specific_line_from_which_entity_data_starts = 0;

            using (reader = new StreamReader(Database.Database_file_path.Name))
            {
                while (!reader.ReadLine().Contains(arg_firstname_lastname))
                {
                    specific_line_from_which_entity_data_starts++;
                }
            }

            string[] file_data = new string[lines_counter];

            using (reader = new StreamReader(Database.Database_file_path.Name)) 
            {
                for (int i = 0; i < file_data.Length; i++)
                {
                    file_data[i] = reader.ReadLine();
                }
            }

            int indexer_specific_line = specific_line_from_which_entity_data_starts;

            for (; indexer_specific_line < lines_counter-7; indexer_specific_line++)
            {
                file_data[indexer_specific_line] = file_data[indexer_specific_line + 7];
            }

            Array.Resize(ref file_data, indexer_specific_line);

            File.WriteAllLines(Database.Database_file_path.Name, file_data);
        }
    }
}
