using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERC
{
    public class InputOutputMessage
    {

        public string strColdWater = "Введите данные ХВС ";
        public string strHotWater = "Введите данные ГВС ";
        public string strElectricityDay = "Введите данные ЭЭ ";
        public string[] DayNight = { "дневного", "ночного" };
        public string str = "Введите количество проживающих в квартире ";

        public void GetMessage(string str) // вывод сообщения
        {
            Console.Clear();
            Console.Write(str);
        }

        public void Input(ElectricityBill Data)
        {
            double data = 0;
            int quantity = 0;
            GetMessage(str);
            int.TryParse(Console.ReadLine(), out quantity); //Ввод кол - во жильцов
            Data.QuantityHuman = quantity;
            GetMessage(strColdWater);
            double.TryParse(Console.ReadLine(), out data); // Ввод ХВС
            Data.Hvc = data;
            GetMessage(strHotWater);
            double.TryParse(Console.ReadLine(), out data); // ввод ГВС
            Data.Gvc= data;
            Data.GvcE = data;
            GetMessage(strElectricityDay + DayNight[0]);
            double.TryParse (Console.ReadLine(), out data); //ввод ЭЭ дневного
            Data.Ii = data;
            GetMessage(strElectricityDay + DayNight[1]);
            double.TryParse(Console.ReadLine(), out data);
            Data.IiNight = data;
        }

        public void ChoiceTable()
        {
            Console.Clear();
            Console.WriteLine("1. База данных с расчетом");
            Console.WriteLine("2. База данных с показанием");
        }

        public void OutputTable(char key)
        {
            switch (key)
            {
                case '1':
                    Console.Clear();
                    using(recordDBContext db = new recordDBContext())
                    {
                        var table = db.ResultData.ToList();
                        Console.WriteLine($"{"ID",3}\t|{"Кол-во жильцов",15}\t|{"ХВС",10}\t|{"ГВС",10}\t|{"ГВС-Э",15}\t|{"ЭЭ",15}");
                        foreach(var cells in table)
                        {
                            Console.WriteLine($"{cells.Id,3}\t|{cells.QuantityHuman,15}\t|{cells.Hvc,10}\t|{cells.Gvc,10}\t|{cells.GvcE,15}\t|{cells.Ii,15}");
                        }
                    }
                    Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться назад");
                    Console.ReadKey();
                 break;
                case '2':
                    Console.Clear();
                    using (recordDBContext db = new recordDBContext())
                    {
                        var table = db.ElectricityBills.ToList();
                        Console.WriteLine($"{"ID",3}\t|{"Кол-во жильцов",15}\t|{"ХВС",6}\t|{"ГВС",6}\t|{"ЭЭ дневной",12}\t|{"ЭЭ ночной",12}|");
                        foreach (var cells in table)
                        {
                            Console.WriteLine($"{cells.Id,3}\t|{cells.QuantityHuman,15}\t|{cells.Hvc,6}\t|{cells.Gvc,6}\t|{cells.Ii,12}\t|{cells.IiNight,12}|");
                        }
                    }
                    Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться назад");
                    Console.ReadKey();
                    break;
            }
        }

    }
    
}
