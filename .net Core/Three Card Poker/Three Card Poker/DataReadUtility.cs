//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Reflection;
//using System.Text;
//using System.Linq;


//No Time unfortunately to get this running

//namespace Three_Card_Poker
//{
//    public static class DataReadUtility
//    {
//        public static List<IPlayer> GetPlayersFromFile()
//        {
//            var players = new List<IPlayer>();

//            var output = new string[0];
//            try
//            {   // Open the text file using a stream reader.
                
//                string currentDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
//                string archiveFolder = Path.Combine(currentDirectory, "tests");
//                string[] filePaths = Directory.GetFiles(archiveFolder);
//                foreach(var path in filePaths)
//                {
//                    var content = File.ReadAllText(path);
//                    var testContent = content.Split("\n\n");
//                    output = testContent[1].Split("\n");
                    
//                }
//            }
//            catch (IOException e)
//            {
//                //log
//                Console.WriteLine("The file could not be read:");
//                Console.WriteLine(e.Message);
//            }
//            return output;
//        }


//        public static void ReadFileTwo()
//        {

//            // The files used in this example are created in the topic
//            // How to: Write to a Text File. You can change the path and
//            // file name to substitute text files of your own.

//            // Example #1
//            // Read the file as one string.

//            var path = Path.GetTempPath();
//            string text = System.IO.File.ReadAllText(@"C:\Users\Public\TestFolder\WriteText.txt");

//            // Display the file contents to the console. Variable text is a string.
//            System.Console.WriteLine("Contents of WriteText.txt = {0}", text);

//            // Example #2
//            // Read each line of the file into a string array. Each element
//            // of the array is one line of the file.
//            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\TestFolder\WriteLines2.txt");

//            // Display the file contents by using a foreach loop.
//            System.Console.WriteLine("Contents of WriteLines2.txt = ");
//            foreach (string line in lines)
//            {
//                // Use a tab to indent each line of the file.
//                Console.WriteLine("\t" + line);
//            }

//        }

//    }
//}
