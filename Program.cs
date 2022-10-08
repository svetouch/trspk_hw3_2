using System;
using System.IO;
using System.Text;
namespace hw3_2
{
    class Info
    {
        public string text;

        public Info(string t)
        {
            text = t;
        }

        public void SaveInfo(string filename)
        {
            if (File.Exists(filename))
            {
                try
                {
                    File.Delete(filename);
                }
                catch (Exception e) // если выдает ошибку
                {
                    Console.WriteLine("Не удалось удалить файл"); 
                }
            } 
            else 
            {
                Console.WriteLine("Файл не существует");
            }

            using (FileStream stream = new FileStream(filename, FileMode.OpenOrCreate))
            {
                byte[] array = Encoding.Default.GetBytes(text);

                stream.Write(array, 0, array.Length);
            }
        }

        public void ReadInfo(string filename)
        {
            using (FileStream stream = File.OpenRead(filename))
            {
                byte[] array = new byte[stream.Length];
                stream.Read(array, 0, array.Length);
                string textFromFile = Encoding.Default.GetString(array);
                text = textFromFile;
            }
        }

        public void DeleteInfo(string filename)
        {
            using (FileStream stream = File.OpenRead(filename))
            {
                byte[] array = new byte[stream.Length];
                stream.Read(array, 0, array.Length);
                string textFromFile = Encoding.Default.GetString(array);
                text = textFromFile;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите текст: ");
            Info info = new(Console.ReadLine()); // вызываем конструктор, вписываем инфу в файл
            info.SaveInfo("trspk.txt");

            Console.WriteLine("Производим чтение из файла");
            info.ReadInfo("trspk.txt");
            Console.WriteLine(info.text);

            Console.ReadKey();
        }
    }
}

