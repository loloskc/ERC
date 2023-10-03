using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERC
{
    public class Calc
    {
        public readonly double waterCold = 35.78;
        public readonly double normWaterCold = 4.85;
        public readonly double electricity = 4.28;
        public readonly double normElectricity = 164;
        public readonly double electricityDay = 4.9;
        public readonly double electricityNight = 2.31;
        public readonly double waterHot = 35.78;
        public readonly double normWaterHot = 4.01;
        public readonly double waterHotE = 998.69;
        public readonly double normWaterHotE = 0.05349;


        
        public double? CountWater(double? value,int quantity,double price,double norm)
        {
            if (value==null||value<=0)
            {
                return quantity * price * norm;
            }
            else
            {
                return value * price;
            }
        }

        public double? CountHotWaterE(double? value,int quantity)
        {
            if (value == null || value <= 0)
            {
                value = 0;
                double? result = quantity * normWaterHotE * normWaterHot;
                result = result * waterHotE;
                return result;
            }
            else
            {
                double? result = value * normWaterHotE;
                result = result * waterHotE;
                return result;
            }
        }

        public double? CountII(double? valueDay, double? valueNight, int quantity)
        {
            if (valueDay == null || valueDay <= 0 || valueNight == null || valueNight <= 0)
            {
                double? result = electricity * normElectricity;
                return result;
            }
            else
            {
                double? result = valueDay*electricityDay+valueNight*electricityNight;
                return result;
            }
        }

    }
}
