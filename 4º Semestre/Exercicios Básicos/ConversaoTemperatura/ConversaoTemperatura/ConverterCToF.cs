using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversaoTemperatura
{
    public static class ConverterCToF
    {
        public static double ConvercaoCToF(double tempC)
        {
			try
			{
                var fahrenheit = (tempC * 9 / 5) +32;

                return fahrenheit;

            }
            catch (Exception)
			{

				throw;
			}
        }
    }
}
