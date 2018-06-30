using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ConsoleApp1
{
    class Program
    {
       

        static void Main(string[] args)
        {
            string[] fileEntries;
            int licznik = 1;
            //List<string> data;
            // data = new List<string>();

            

            Console.WriteLine("Podaj ścieżke dostepu: ");
            string file = Console.ReadLine();
            while (!Directory.Exists(file)) {
                Console.WriteLine("Podana ścieżka dostepu nie istnieje.");
                Console.WriteLine("Podaj ścieżke dostepu: ");
                file = Console.ReadLine();
            }
            if (Directory.Exists(file))
            {
                fileEntries = Directory.GetFiles(file);
                // string[,] data;
                // data = new string[fileEntries.Length, 2];
                string[] data = new string[fileEntries.Length];
                int[] index = new int[fileEntries.Length];
                string temp_data;
                int temp_index;
                string ext;


                for (int i = 0; i < fileEntries.Length; i++)
                {
                    data[i] = File.GetCreationTime(fileEntries[i]).ToString();
                    index[i] = i;      
                }
              

                for (int i = 0; i < fileEntries.Length; i++) {
                    for (int j = 0; j < fileEntries.Length; j++) {
                        if (data[i].CompareTo(data[j]) < 0)
                        {
                            temp_data = data[j];
                            temp_index = index[j];
                            data[j] = data[i];
                            index[j] = index[i];
                            data[i] = temp_data;
                            index[i] = temp_index;
                        }
                    }
                }

                for (int i = 0; i < fileEntries.Length; i++) {
                    ext = Path.GetExtension(fileEntries[index[i]]);
                    if (!File.Exists(file + "/" + licznik + ext)) {
                        
                        File.Move(fileEntries[index[i]], file + "/" + licznik + ext);
                        licznik++;
                    }
                  
                }

                Console.WriteLine("Nazwy plików zostały pomyślnie zmienione" );
                Console.ReadLine();

            }
          
          
            // File.Move();
        }
    }
}
