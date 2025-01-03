using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _5._2.OOP_advanced_bo_limi_uchun_2_amaliy_vazifa.Classes
{
    public class Kontakt
    {
        public Kontakt(){}
        public Kontakt(string contactname,string phonenumber)
        {
            ContactName = contactname;
            phoneNumber = phonenumber;
        }
        public string ContactName { get; set; }
        public string phoneNumber { get; set; }  
    }
}