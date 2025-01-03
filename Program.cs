using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using _5._2.OOP_advanced_bo_limi_uchun_2_amaliy_vazifa.Classes;
internal class Program
{
    public static void Main(string[] args)
    {
        string path = "PhoneBook.txt";
        if (File.Exists(path))
            Show(path);
        else
            LoggingBroker.LogException("Bunday fayl mavjud emas !!!");
    }
    private static void Show(string path)
    {
        Actions.SetColorLine("\t\tHUSH KELIBSIZ !!!");
        int choose;
        while (true)
        {
            Console.WriteLine("\t1.Kontakt qo'shish.");
            Console.WriteLine("\t2.Kontaktni o'chirish.");
            Console.WriteLine("\t3.Kontaktni tahrirlash.");
            Console.WriteLine("\t4.Barcha kontaktlarni ko'rish.");
            Console.WriteLine("\t5.Kontaktlarni nomi bo'yicha ko'rish.");
            Console.WriteLine("\t6.Tugatish");
            Console.Write("Quidagi amallardan birini kiriting (tartib raqami bo'yicha): ");

            int.TryParse(Console.ReadLine(), out choose);

            switch (choose)
            {
                case 1: AmalKontakt.Qoshish(path); break;
                case 2:
                    var dict = GetDictionary(path);
                    AmalKontakt.Ochirish(dict, path);
                    break;
                case 3:
                    var tahrirlash = GetDictionary(path);
                    AmalKontakt.Tahrirlash(tahrirlash, path);
                    break;
                case 4: AmalKontakt.BarchaKorish(path); break;
                case 5:
                    var dictNomBoyicha = GetDictionary(path);
                    AmalKontakt.NomiBoyichaKorish(dictNomBoyicha);
                    break;
                case 6:; break;
                default:
                    Actions.SetColor(message: "Qayta kiriting: ", color: ConsoleColor.Red);
                    break;
            }
            if (choose == 6)
            {
                Actions.SetColor(message: "Kuningiz hayirli o'tsin !!!");
                Console.ReadLine();
                Console.Clear();
                break;
            }
            Console.ReadLine();
            Console.Clear();
        }

    }
    private static Dictionary<string, string> GetDictionary(string path) // textni dictionaryga o'girish
    {
        var list = new List<string>();
        var fileInfoDic = new Dictionary<string, string>();
         try
        {
            using (var sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }
        }
        catch (FileNotFoundException ex)
        {
            LoggingBroker.LogFileNotFoundException(path);
        }
        catch (UnauthorizedAccessException ex)
        {
            LoggingBroker.LogUnauthorizedAccessException(ex.Message);
        }
        catch (Exception ex)
        {
            LoggingBroker.LogException(ex.Message);
        }

        string[] tomonlar;
        foreach (var item in list)
        {
            tomonlar = item.Split(':');
            string key = tomonlar[0] ?? "Unknown";
            string value = tomonlar[1] ?? "Unknown";
            fileInfoDic[key] = value;
        }
        return fileInfoDic;
    }
}

/*
OOP advanced bo'limi uchun 2-amaliy vazifa

Kontaktlarni boshqarish uchun konsol ilovasini yaratishingiz kerak. Foydalanuvchi yangi kontakt qo'shish, 
kontaktni o'chirish, kontaktni tahrirlash, barcha kontaktlarni ko'rish va kontaktni nomi bo'yicha ko'rish 
imkoniyatiga ega bo'lishi kerak. Buning uchun siz barcha bilimlaringizdan, jumladan, Fayl haqidagi 
bilimingizdan foydalanishingiz kerak. 

Xatoni aniqlash va uni LoggingBroker-ga yuborish uchun siz TryCatch funktsiyasidan foydalanishingiz kerak, 
ma'lumotni ushbu havolada topishingiz kerak.

Fayldan qanday foydalanish haqida ma'lumotni ushbu havolada topishingiz mumkin. 
Loyihangizda xatolarni qayd qilish uchun LoggingBroker ham bo'lishi kerak. 

LoggingBroker-da siz xatolar yoki xato xabarlarini qabul qilish va ularni konsolga yozish uchun bir nechta 
usullarni yaratishingiz kerak.




*/