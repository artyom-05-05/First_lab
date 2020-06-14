using System;
using static System.Math;

namespace Lab7
{
    class Complex_number
    {
        private double reZ; //real part of complex number
        private double imZ; //iaginary part of complex number

        public Complex_number(double reZ, double imZ)
        {
            this.reZ = reZ;
            this.imZ = imZ;
        }

        public string AlgebraicForm()
        {
            string sign;
            if (GetImZ() < 0) sign = "-";
            else if (GetImZ() > 0) sign = "+";
            else return $"{GetReZ()}";

            if ((GetImZ() == 1) || (GetImZ() == -1)) return $"{GetReZ()}{sign}i";
            else return $"{GetReZ()}{sign}{Abs(GetImZ())}i";
        }

        public Complex_number Sum(Complex_number num)
        {
            return new Complex_number(GetReZ() + num.GetReZ(), GetImZ() + num.GetImZ());
        }

        public Complex_number Difference(Complex_number num)
        {
            return new Complex_number(GetReZ() - num.GetReZ(), GetImZ() - num.GetImZ());
        }

        public Complex_number Product(Complex_number num)
        {
            double productReZ = GetReZ() * num.GetReZ() - GetImZ() * num.GetImZ();
            double productImZ = GetImZ() * num.GetReZ() + num.GetImZ() * GetReZ();

            return new Complex_number(productReZ, productImZ);
        }

        public double FindModulus()
        {
            return Sqrt(Pow(GetReZ(), 2) + Pow(GetImZ(), 2));
        }

        public double GetReZ() { return reZ; }
        public double GetImZ() { return imZ; }

        public void SetReZ(double reZ) { this.reZ = reZ; }
        public void SetImZ(double imZ) { this.imZ = imZ; }
    }
}
