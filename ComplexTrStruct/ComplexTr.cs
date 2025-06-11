using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexTrStruct
{
    public struct ComplexTr
    {
        private const double Tolerance = 1e-13; 
        private const double TwoPI = 2 * Math.PI;

        private double abs;
        public double Abs
        {
            get => abs;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Модуль числа не может быть отрицательным");
                abs = value;
            }
        }

        private double arg;
        public double Arg
        {
            get => arg;
            set => arg = NormalizeAngle(value);
        }

        public double Re => Abs * Math.Cos(Arg);
        public double Im => Abs * Math.Sin(Arg);

        public ComplexTr(double abs, double arg) : this()
        {
            Abs = abs;
            Arg = arg;
        }

        private static double NormalizeAngle(double angle)
        {
            angle %= TwoPI;
            if (angle > Math.PI) angle -= TwoPI;
            if (angle <= -Math.PI) angle += TwoPI;
            return angle;
        }

        public override string ToString()
        {
            if (Math.Abs(Abs) < Tolerance) return "0";

            if (Math.Abs(Abs - 1) < Tolerance)
            {
                return $"cos({Arg}) + i sin({Arg})";
            }

            return $"{Abs}(cos({Arg}) + i sin({Arg}))";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ComplexTr))
                throw new ArgumentException("Объект для сравнения не является комплексным числом");

            ComplexTr other = (ComplexTr)obj;

            if (Math.Abs(Abs - other.Abs) > Tolerance)
                return false;

            double angleDiff = NormalizeAngle(Arg - other.Arg);
            return Math.Abs(angleDiff) < Tolerance ||
                   Math.Abs(Math.Abs(angleDiff) - TwoPI) < Tolerance;
        }

        public override int GetHashCode()
        {
            unchecked 
            {
                int hash = 17;
                const int prime = 23;

                hash = hash * prime + Math.Round(Abs, 13).GetHashCode();
                double normalizedArg = NormalizeAngle(Arg);
                hash = hash * prime + Math.Round(normalizedArg, 13).GetHashCode();

                return hash;
            }
        }

        public static bool operator ==(ComplexTr x, ComplexTr y) => x.Equals(y);
        public static bool operator !=(ComplexTr x, ComplexTr y) => !x.Equals(y);

        public static ComplexTr operator *(ComplexTr z1, ComplexTr z2)
        {
            return new ComplexTr(
                z1.Abs * z2.Abs,
                z1.Arg + z2.Arg);
        }

        public static ComplexTr operator /(ComplexTr z1, ComplexTr z2)
        {
            if (Math.Abs(z2.Abs) < Tolerance)
                throw new DivideByZeroException("Деление на нулевое комплексное число");

            return new ComplexTr(
                z1.Abs / z2.Abs,
                z1.Arg - z2.Arg);
        }
    }
}
