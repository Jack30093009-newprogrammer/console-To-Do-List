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
using System.Threading;
using System.Diagnostics;
using Microsoft.Toolkit.Uwp.Notifications;



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
        Console.WriteLine("Добро пожаловать в КОНСОЛЬНЫЙ To-Do List!");
        Console.WriteLine("Все файлы сохраняются в папку на рабочий стол ToDoFiles!");

        Console.WriteLine("");
        Console.WriteLine("Введите цифру операции:\n1-Создать файл\n2-Редактировать файл\n3-Открыть файл\n4-Поставить задачу (по времени высветиться внизу открыть и закрыть)");
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
            case 4:
                /*1)Спросить во сколько высветить уведомление (год, месяц, день, число, час, минуты)
                2) если текущее время = времени введенного ползователем вывести уведомление
                3)в увдомлении прописано открыть заметку (в нашем случае - задача) или кнопка закрыть нахуй уведомление*/
                Console.WriteLine("Во сколько высветить уведомление об открытии задачи? Формат - гмдчмс");
                int year = Convert.ToInt32(Console.ReadLine());
                int month = Convert.ToInt32(Console.ReadLine());
                int day = Convert.ToInt32(Console.ReadLine());
                int hour = Convert.ToInt32(Console.ReadLine());
                int min = Convert.ToInt32(Console.ReadLine());
                int sec = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Итак, дата заметки - {year} год, {month}-ый месяц, {day}-ый день, {hour}-ый час, {min}-ая минута, {sec}-ая секунда!");

                //создание даты
                //пихаем уведомление

                
                Console.WriteLine("Введите текст в уведомление:");
                string textOfNotification = Console.ReadLine();
                DateTime now = DateTime.Now;
                DateTime notificDate = new DateTime(year, month, day, hour, min, sec);
                while (now < notificDate)
                {
                    Thread.Sleep(100);
                }
                new ToastContentBuilder()
                        .AddText(textOfNotification)
                        .Show();
                break;

        
        }
        //запихнуть в бесконечный цикл - осмотрим)
    }
}




/*
    ПРАВКИ
    1)Уведомления toast - добавить копки открыть и закрыть
    2)Цветной текст
    3)повторяющиеся задачи
    4)сделать возможность менять папку или создавать новую где угодно
 */