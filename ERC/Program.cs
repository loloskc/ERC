using System;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace ERC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            InputOutputMessage cMessage = new InputOutputMessage();
            DBwork dbWork = new DBwork();
            while (key.KeyChar != 4)
            {
                Console.Clear();
                Console.WriteLine("1. Рассчет");
                Console.WriteLine("2. Просмотр базы даныых");
                Console.WriteLine("d. Очистка базы данных");
                key= Console.ReadKey();
                switch (key.KeyChar)
                {
                    case '1':
                        ElectricityBill electricityBill = new ElectricityBill();
                        cMessage.Input(electricityBill);
                        ResultDatum result = dbWork.Calculation(electricityBill);
                        dbWork.RecordDB(electricityBill);
                        dbWork.RecordDB(result);
                        break;
                    case '2':
                        cMessage.ChoiceTable();
                        key = Console.ReadKey();
                        cMessage.OutputTable(key.KeyChar);
                        break;
                    case 'd':
                        dbWork.DeletDB();
                        break;
                        


                }

            }
            
        }
    }
}
