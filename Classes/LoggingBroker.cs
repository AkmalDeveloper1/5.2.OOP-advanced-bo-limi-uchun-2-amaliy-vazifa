using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _5._2.OOP_advanced_bo_limi_uchun_2_amaliy_vazifa.Classes
{
    public static class LoggingBroker
    {
        private static string logFilePath = "log.txt";
        private static void LogToFile(string message)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(logFilePath, append: true))
                {
                    sw.WriteLine($"{DateTime.Now}: {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Log yozishda xatolik: {ex.Message}");
            }
        }
        public static void LogFileNotFoundException(string filePath)
        {
            LogToFile($"ERROR: Fayl topilmadi: {filePath}");
        }

        public static void LogUnauthorizedAccessException(string message)
        {
            LogToFile($"ERROR: Ruxsat etilmagan kirish: {message}");
        }

        public static void LogException(string message)
        {
            LogToFile($"ERROR: {message}");
        }
    }
}