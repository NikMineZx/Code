using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        string inputFilePath = "C:\\Code\\C#-code\\CodeParser\\CodeParser\\input.txt";
        string outputFilePath = "C:\\Code\\C#-code\\CodeParser\\CodeParser\\output.txt"; // Путь к файлу для записи уникальных строк

        // Проверяем существование входного файла
        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine("Входной файл не найден.");
            return;
        }

        // Создаем словарь для хранения уникальных строк
        var uniqueLines = new HashSet<string>();

        // Читаем строки из входного файла и добавляем их в словарь
        using (StreamReader reader = new StreamReader(inputFilePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                // Добавляем строку в словарь, если она еще не была добавлена
                if (!uniqueLines.Contains(line))
                {
                    uniqueLines.Add(line);
                }
            }
        }

        // Записываем уникальные строки в выходной файл
        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            foreach (string line in uniqueLines)
            {
                writer.WriteLine(line);
            }
        }

        Console.WriteLine("Уникальные строки записаны в файл: " + outputFilePath);
    }
}
