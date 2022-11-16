using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;

namespace Редактор
{
    internal class Program
    {
        public static List<geometry> geometries = new List<geometry>() { 
         new geometry("Прямоугольник","90","120")
        };
        static void Main()
        {
            Console.WriteLine("Введите файл который хотите открыть (.txt, .json, .xml)");
            Console.WriteLine("--------------------------------------------------------");
            string savafile = Console.ReadLine();
            ToFile(savafile);
        }
        public static void ToFile(string Line)
        {
            SaveOrCreateFile.YUR = Line;
            if (File.Exists(SaveOrCreateFile.YUR))
            {
                Console.Clear();
                SaveOrCreateFile.Opened();
            }
            else
            {
                if (SaveOrCreateFile.Create())
                {
                    Console.WriteLine("Новый файл создаю. Та-да ");
                }
                else
                {
                    Console.WriteLine("Создание файла провалилось. Квак-квак, попробуйте снова ");
                    Exit();
                }
            }
        }
        public static void Exit()
        {
            Environment.Exit(0);
        }
    }
}