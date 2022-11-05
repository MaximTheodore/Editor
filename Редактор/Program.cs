using Newtonsoft.Json;
using System;
using System.Xml.Serialization;
using System.Xml;
namespace Редактор
{
    internal class Program
    {
        public static List<geometry> geometries = new List<geometry>() { new geometry("Прямоугольник","90","120") } ;
        static void Main(string[] args)
        {
            Console.WriteLine("Введите файл который хотите открыть (.txt, .json, .xml)");
            Console.WriteLine("--------------------------------------------------------");
            string savafile = Console.ReadLine();
            ToFile(savafile);
        }
        public static void ToFile(string readLine)
        {
            SaveOrCreateFile.YUR = readLine;
            if (File.Exists(SaveOrCreateFile.YUR))
            {
                Console.Clear();
                SaveOrCreateFile.Open();
            }
            else
            {
                Console.WriteLine("Файл не найден!");
                if (SaveOrCreateFile.Create())
                {
                    Console.WriteLine("Новый файл создаю. Та-да ");
                }
                else Console.WriteLine("Создание файла провалилось. Квак-квак, попробуйте снова ");
                Close();
            }
        }
        public static void Close()
        {
            Environment.Exit(0);
        }
    }
}