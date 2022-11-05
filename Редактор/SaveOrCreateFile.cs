using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;

namespace Редактор
{
    internal class SaveOrCreateFile
    {
        public static string YUR;
        public static void Open()
        {
            Console.WriteLine("Сохранить файл в одном из трёх фрагментов (txt, json, xml) - F1.  Escape - Закрыть программу");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            string extension = Path.GetExtension(YUR);
            if (extension == ".txt")
            {
                string[] list = File.ReadAllLines(YUR);
                foreach (var item in list) Console.WriteLine(item);
            }
            else if (extension == ".json")
            {
                string text = File.ReadAllText(YUR);
                List<geometry> geometries = JsonConvert.DeserializeObject<List<geometry>>(text);
                foreach (geometry item in geometries)
                {
                    Console.WriteLine(item.figure);
                    Console.WriteLine(item.Linelength.ToString());
                    Console.WriteLine(item.width.ToString());
                }
            }
            else if (extension == ".xml")
            {
                XmlSerializer xml = new XmlSerializer(Program.geometries.GetType());
                using (FileStream fs = new FileStream(YUR, FileMode.OpenOrCreate))
                {
                    List<geometry> list = (List<geometry>)xml.Deserialize(fs);
                    foreach (geometry item in list)
                    {
                        Console.WriteLine(item.figure);
                        Console.WriteLine(item.Linelength.ToString());
                        Console.WriteLine(item.width.ToString());
                    }
                }
            }
            Button();
        }
        public static bool Create()
        {
            string extension = Path.GetExtension(YUR);
            if (extension == ".txt")
            {
                using StreamWriter sw = new StreamWriter(YUR);
                for (int i = 0; i < Program.geometries.Count; i++)
                {
                    sw.WriteLine(Program.geometries[i].figure);
                    sw.WriteLine(Program.geometries[i].Linelength.ToString());
                    sw.WriteLine(Program.geometries[i].width.ToString());
                }
            }
            else if (extension == ".json")
            {
                using StreamWriter sw = File.CreateText(YUR); for (int i = 0; i < Program.geometries.Count; i++)
                {
                    sw.WriteLine(Program.geometries[i].figure);
                    sw.WriteLine(Program.geometries[i].Linelength.ToString());
                    sw.WriteLine(Program.geometries[i].width.ToString());
                }
                sw.WriteLine(JsonConvert.SerializeObject(Program.geometries));
            }
            else if (extension == ".xml")
            {
                XmlSerializer xml = new XmlSerializer(Program.geometries.GetType());
                using FileStream fs = new FileStream(YUR, FileMode.OpenOrCreate);
                xml.Serialize(fs, Program.geometries); 
            }
            else return false;
            return true;
        }
       
        private static void Save()
        {
            Console.Clear();
            Console.WriteLine("Введите путь файла, куда вы хотите его сохранить ");
            Console.WriteLine("------------------------------------------------");
            string readLine = Console.ReadLine();
            SaveOrCreateFile.YUR = readLine;
            if (SaveOrCreateFile.Create())
            {
                Console.WriteLine("Успешно сохранено ! Спасибо, что воспользовались текстовым редактором! ");
            }
            else Console.WriteLine("Файл не удалось сохранить! Попробуйте снова, извините за неудобства {{ (>_<) }}");
            Program.Close();
        }
        private static void Button()
        {
            ConsoleKeyInfo button = Console.ReadKey();
            if (button.Key == ConsoleKey.Escape) Program.Close();
            else if (button.Key == ConsoleKey.F1) SaveOrCreateFile.Save();
            else
            {
                Console.Clear();
                Program.ToFile(SaveOrCreateFile.YUR);
            }
        }
    }
}
