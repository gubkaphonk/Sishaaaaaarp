using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelStruct
{
    public struct Pixel
    {
        private int r;
        private int g;
        private int b;

        // Константы для вычисления яркости
        private const double RWeight = 0.3;
        private const double GWeight = 0.6;
        private const double BWeight = 0.1;

        public int R
        {
            get => r;
            set
            {
                if (value < 0 || value > 255)
                    throw new ArgumentException("Значение R должно быть от 0 до 255");
                r = value;
            }
        }

        public int G
        {
            get => g;
            set
            {
                if (value < 0 || value > 255)
                    throw new ArgumentException("Значение G должно быть от 0 до 255");
                g = value;
            }
        }

        public int B
        {
            get => b;
            set
            {
                if (value < 0 || value > 255)
                    throw new ArgumentException("Значение B должно быть от 0 до 255");
                b = value;
            }
        }

        public int L => (int)Math.Round(R * RWeight + G * GWeight + B * BWeight);

        public Pixel(int r, int g, int b) : this()
        {
            R = r;
            G = g;
            B = b;
        }

        public override string ToString()
        {
            return $"#{R:X2}{G:X2}{B:X2}";
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + R.GetHashCode();
                hash = hash * 23 + G.GetHashCode();
                hash = hash * 23 + B.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(Pixel left, Pixel right) => left.Equals(right);
        public static bool operator !=(Pixel left, Pixel right) => !left.Equals(right);

        public static Pixel operator *(double factor, Pixel pixel)
        {
            if (factor <= 0)
                throw new ArgumentException("Коэффициент должен быть положительным");

            int Clamp(int value)
            {
                int result = (int)Math.Round(value * factor);
                return Math.Clamp(result, 0, 255);
            }

            return new Pixel(
                Clamp(pixel.R),
                Clamp(pixel.G),
                Clamp(pixel.B)
            );
        }

        public static Pixel operator *(Pixel pixel, double factor) => factor * pixel;
    }
}
