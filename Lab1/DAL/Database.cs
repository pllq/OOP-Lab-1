using System.IO;

namespace DAL
{
    public class Database
    {
        //private static FileStream database_file_path;

        internal static FileStream Database_file_path 
        {
            get; //=> database_file_path;
            private set; //=> database_file_path = value;
        }

        public static bool Create_Database(string arg_path)
        {
            try
            {
                Database_file_path = new FileStream(arg_path, FileMode.OpenOrCreate, FileAccess.ReadWrite);

                Database_file_path.Close();

                return false; // right result
            }
            catch (ArgumentException)
            {
                throw new ArgumentException ("Direct path to the file needed. Please try again: ");
            }
            catch (PathTooLongException) //not very common
            {
                throw new PathTooLongException("Path to the file is too long. Please try again: "); 
            }
            catch (DirectoryNotFoundException)
            {
                throw new DirectoryNotFoundException("Direct path to the file needed not to the folder with it. Please try again: ");
            }
/*            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("File not found. Please write correct path: ");
                Database_file_path = new FileStream(arg_path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                Database_file_path.Close();
            }*/
            catch (UnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException("Cannot get access to the file. Please try again: ");
            }
            catch (IOException)
            {
                throw new IOException("Unsupported file format. Please try again: ");
            }
            catch (NotSupportedException)
            {
                throw new NotSupportedException("Direct path to the file needed. Please try again: ");
            }
            return true; 
        }
    }
}