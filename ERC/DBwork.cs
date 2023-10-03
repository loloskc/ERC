using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERC
{
    public class DBwork
    {
        Predicate<double?> Check =(double? x) =>x > 0||x==null;

        private int GetLenghtDB()
        {
            int lenght = 0;
            using(recordDBContext db = new recordDBContext())
            {
                lenght =  db.ElectricityBills.Count();
            }
            return lenght;
        }

        public ResultDatum Calculation(ElectricityBill data)
        {
            Calc calc = new Calc();
            ResultDatum dataResult = new ResultDatum();
            dataResult.QuantityHuman = data.QuantityHuman;
            if (GetLenghtDB() == 0)
            {
                dataResult.Hvc = calc.CountWater(data.Hvc, data.QuantityHuman, calc.waterCold, calc.normWaterCold);
                dataResult.Gvc = calc.CountWater(data.Gvc, data.QuantityHuman, calc.waterHot, calc.normWaterHot);
                dataResult.GvcE = calc.CountHotWaterE(data.Gvc, data.QuantityHuman);
                dataResult.Ii = calc.CountII(data.Ii, data.IiNight, data.QuantityHuman);
            }
            else
            {
                using (recordDBContext db = new recordDBContext())
                {
                    var dataArray = db.ElectricityBills.ToArray();

                    if (Check(dataArray[dataArray.Length - 1].Hvc))
                    {
                        dataResult.Hvc = calc.CountWater(data.Hvc - dataArray[dataArray.Length - 1].Hvc, data.QuantityHuman, calc.waterCold, calc.normWaterCold);
                    }
                    else
                    {
                        dataResult.Hvc = calc.CountWater(data.Hvc, data.QuantityHuman, calc.waterCold, calc.normWaterCold);
                    }
                    if (Check(dataArray[dataArray.Length - 1].Gvc))
                    {
                        dataResult.Gvc = calc.CountWater(data.Gvc - dataArray[dataArray.Length - 1].Gvc, data.QuantityHuman, calc.waterHot, calc.normWaterHot);
                        dataResult.GvcE = calc.CountHotWaterE(data.Gvc- dataArray[dataArray.Length - 1].Gvc, data.QuantityHuman); 
                    }
                    else
                    {
                        dataResult.Gvc = calc.CountWater(data.Gvc, data.QuantityHuman, calc.waterHot, calc.normWaterHot);
                        dataResult.GvcE = calc.CountHotWaterE(data.Gvc,data.QuantityHuman);
                    }
                    if (Check(dataArray[dataArray.Length - 1].Ii))
                    {
                        dataResult.Ii = calc.CountII(data.Ii - dataArray[dataArray.Length-1].Ii, data.IiNight - dataArray[dataArray.Length-1].IiNight, data.QuantityHuman) ;
                    }
                    else
                    {
                        dataResult.Ii = calc.CountII(data.Ii, data.IiNight, data.QuantityHuman);
                    }
                }

            }
            return dataResult;
        }
















        public void RecordDB(ResultDatum data)
        {
            using(recordDBContext db = new recordDBContext())
            {
                db.ResultData.Add(data);
                db.SaveChanges();
            }
        }
        public void RecordDB(ElectricityBill data)
        {
            using (recordDBContext db = new recordDBContext())
            {
                db.ElectricityBills.Add(data);
                db.SaveChanges();
            }
        }



    }
}
