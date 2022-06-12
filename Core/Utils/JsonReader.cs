using System;
using System.IO;
using System.Reflection;

namespace Core.Utils
{
    public class JsonReader
    {
        private readonly string Filename;

        public JsonReader(string filename)
        {
            Filename = filename;
        }

        public string ReadFile()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fullPathToFile = $"{basePath}{Path.DirectorySeparatorChar}{Filename}";

            try
            {
                var streamReader = new StreamReader(fullPathToFile);
                Console.Out.WriteLine($"The file {fullPathToFile} read successfully.");
                return streamReader.ReadToEnd();
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.Out.WriteLine($"The Directory {basePath} doesn't exist: {ex}");
                throw;
            }
            catch (FileNotFoundException ex)
            {
                Console.Out.WriteLine($"The File {fullPathToFile} doesn't exist: {ex}");
                throw;
            }
            catch (IOException ex)
            {
                Console.Out.WriteLine($"The File {fullPathToFile} can't be opened: {ex}");
                throw;
            }
        }
    }
}