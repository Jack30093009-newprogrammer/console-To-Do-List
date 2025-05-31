//КОНСОЛЬНЫЙ To-Do List
//
//Задача: через консоль 1)создавать текстовые файлы в пути (пусть это пока папка на рабочем столе)
//2) редактировать название и содержимое файла
//3)открывать эти файлы

//Пусть пока все будет в 1 классе программ

//Алгоритм действй программы:
//1.Приветствие
//2.Выбор операции
//3.1-создание файла с расширением .txt в папке на рабочий стол ToDoFiles
//4.2-выводит все названия файлов в столбик
//5.вводится доступное название - выводится содержимое файла с возможностью редактировать
//6 как подпункт 2 ьакже столбик названий пишется само название и открывается блокнот
using System;
using System.IO;
using System.Diagnostics;


class Settings
{
    public static void PrintTheArr() //выводит все файлы находящиеся в папке
    {
        string path = @"C:\Users\serge\Desktop\ToDoFiles\";
        string[] files = Directory.GetFiles(path, "*.txt");

        foreach (string file in files) { 
            Console.WriteLine(file);
        }
    }
}
class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Добро пожаловать в КОНСОЛЬНЫЙ To-Do List");
        Console.WriteLine("Все файлы сохраняются в папку на рабочий стол ToDoFiles!");

        Console.WriteLine("");
        Console.WriteLine("Введите цифру операции:\n1-Создать файл\n2-едактировать файл\n3-Открыть файл");
        Console.WriteLine("Цифра операции: ");

        int num = Convert.ToInt32(Console.ReadLine());
        

        //конструкция switch
        switch (num) {
            case 1:
                Console.WriteLine("Создаём новый текстовый файл!");
                Console.WriteLine("Название файла без расширения:");
                string nameOfFile = Console.ReadLine();
                string nameOfPathFile = @$"C:\Users\serge\Desktop\ToDoFiles\{nameOfFile}.txt";

                File.Create(nameOfPathFile).Close();
                break;
            case 2:
                //вывести названия всех файлов в папке через метод 
                //ввод названия без ткст метод
                //построчный ввод через enter
                //если есть klo1klo1 то запись окончена
                Settings.PrintTheArr();
                Console.Write("\nВведите название файла для редактирования (без .txt): ");
                string fileToEdit = Console.ReadLine();
                string editPath = @$"C:\Users\serge\Desktop\ToDoFiles\{fileToEdit}.txt";

                if (File.Exists(editPath))
                {
                    Console.WriteLine("\nТекущее содержимое:");
                    Console.WriteLine(File.ReadAllText(editPath));

                    Console.WriteLine("\nВводите текст построчно. Для завершения введите 'klo1klo1':");
                    using (StreamWriter writer = new StreamWriter(editPath))
                    {
                        while (true)
                        {
                            string line = Console.ReadLine();
                            if (line == "klo1klo1")
                                break;
                            writer.WriteLine(line);
                        }
                    }
                    Console.WriteLine("Файл сохранен!");
                }
                else
                {
                    Console.WriteLine("Файл не найден!");
                }
                break; 
            case 3:
                //также список - название. открыть документ
                Settings.PrintTheArr();
                string fileToOpen = Console.ReadLine();
                string path = @$"C:\Users\serge\Desktop\ToDoFiles\{fileToOpen}.txt";
                Process.Start("notepad.exe", path);
                break;

        
        }
        //запихнуть в бесконечный цикл - осмотрим)
    }
}




/*
    ПРАВКИ
    1)Уведомления - по времени приходит уведомление справа снизу и 
возможность скипнуть или открыть ткст файл
    2)Цветной текст
    3)повторяющиеся задачи
    4) залить на гитхаб
 */