namespace Waterworks.DTO
{
    public class Calc
    {

            public double AddProcent(double numeric, double procent)
            {
                procent = (procent / 100) + 1;
                return Math.Round(numeric * procent, 2);
            }
            public double SubtractProcent(double numeric, double procent)
            {
                procent = (procent / 100) + 1;
                return Math.Round(numeric / procent, 2);
            }
            public double DiffrentTax(double priceBruttoBay, double priceBruttoSell, double procent)
            {
                return Math.Round(SubtractProcent(priceBruttoSell, procent) - SubtractProcent(priceBruttoBay, procent), 2);
            }
        
    }
}
