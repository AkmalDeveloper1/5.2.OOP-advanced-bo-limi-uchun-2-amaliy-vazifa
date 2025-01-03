using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Linq.Expressions;

namespace _5._2.OOP_advanced_bo_limi_uchun_2_amaliy_vazifa.Classes
{
    public static class AmalKontakt
    {

        public static void Qoshish(string path)
        {
            Kontakt kontakt = new Kontakt();
            Console.Write("Kontakt nomini kiriting : ");
            kontakt.ContactName = Console.ReadLine();

            Console.Write("Kontakt raqamini kiriting : ");
            kontakt.phoneNumber = Console.ReadLine();

            using (StreamWriter sw = new StreamWriter(path, append: true))
            {
                sw.WriteLine($"{kontakt.ContactName}:{kontakt.phoneNumber}");
            }
            Actions.SetColor("Kontakt qo'shildi");
        }
        public static void Ochirish(Dictionary<string, string> dict, string path)
        {
            BarchaKorish(path);
            Console.Write("o'chirmoqchi bo'lgan kontakt nomini kiriting : ");
            string name = Console.ReadLine();
            dict.Remove(key: name);
            DictYuklash(dictYuklash: dict, path);
            Actions.SetColor("Kontakt o'chirildi !!!");
        }
        public static void Tahrirlash(Dictionary<string, string> tahrirDic, string path)
        {
            BarchaKorish(path);
            var newDict = new Dictionary<string, string>();
            Console.Write("Qaysi kontaktni tahrirlamoqchisiz : ");
            string name = Console.ReadLine();
            string numb,newName;
            if (tahrirDic.ContainsKey(name))
            {
                Console.Write("Yangi nomni kiriting: ");
                newName = Console.ReadLine();
                Console.Write("Yangi raqamlarni kiriting: ");
                numb = Console.ReadLine();
                foreach (var each in tahrirDic)
                {
                    if (each.Key == name)
                        newDict.Add(key: newName, value: numb);
                    else
                        newDict.Add(key: each.Key, value: each.Value);
                }
                Actions.SetColorLine("Kontakt Tahrirlandi !!!");
                DictYuklash(newDict, path);
            }
            else
                Actions.SetColorLine("Bunday Kontakt topilmadi !!!", ConsoleColor.Red);
        }
        public static void BarchaKorish(string path)
        {
            using (var view = new StreamReader(path))
            {
                string read;
                read = view.ReadToEnd();
                Console.Write(read);
            }
        }
        public static void NomiBoyichaKorish(Dictionary<string, string> nomKorish)
        {
            Console.Write("Ko'rmoqchi bolgan kontakt nomini kiriting: ");
            string nameKey = Console.ReadLine();
            if (nomKorish.ContainsKey(nameKey))
                Actions.SetColorLine($"Ism: {nameKey}\nRaqami: {nomKorish[nameKey] ?? "Unknown"}", ConsoleColor.Yellow);
            else
                Actions.SetColorLine("Bunday Kontakt topilmadi !!!", ConsoleColor.Red);

        }
        private static void DictYuklash(Dictionary<string, string> dictYuklash, string path) //yuklovchi dictionary
        {
            using (StreamWriter writer = new StreamWriter(path, append: false))
            {
                foreach (var item in dictYuklash)
                {
                    writer.WriteLine($"{item.Key}:{item.Value}");
                }
            }
        }

    }
}
/*
Kontaktlarni boshqarish uchun konsol ilovasini yaratishingiz kerak. Foydalanuvchi yangi kontakt qo'shish, 
kontaktni o'chirish, kontaktni tahrirlash, barcha kontaktlarni ko'rish va kontaktni nomi bo'yicha ko'rish 
imkoniyatiga ega bo'lishi kerak. Buning uchun siz barcha bilimlaringizdan, jumladan, Fayl haqidagi 
bilimingizdan foydalanishingiz kerak. 
*/