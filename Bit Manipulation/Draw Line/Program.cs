using System;

namespace Draw_Line
{
    class Program
    {
        static void DrawLine(byte[] screen,
               int width,
               int x_1,
               int x_2,
               int y)
        {
            if (x_1 == x_2) return;
            
            int first_byte = width * y;
            if (first_byte > screen.Length) return;

            int lower_byte = first_byte + (x_1 / 8);
            int upper_byte = first_byte + (x_2 / 8);

            x_1 %= 8;
            x_2 %= 8;

            if (lower_byte == upper_byte)
            {
                screen[lower_byte] = (byte)(((1 << (x_2 - x_1)) - 1) << (8 - x_2));
            }

            else
            {
                screen[lower_byte] = (byte)(0xFF >> x_1);

                screen[upper_byte] = (byte)(0xFF << (8 - x_2));

                for (++lower_byte; lower_byte < upper_byte; ++lower_byte)
                {
                    screen[lower_byte] = 0xFF;
                }
            }

        }

        public static void Main()
        {
            byte[] screen = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            DrawLine(screen, 4, 0, 17, 3);

            for (int i = 0; i < 16; ++i)
            {
                if (i % 4 == 0) Console.WriteLine("\n");

                Console.WriteLine(Convert.ToString(screen[i], 2));

                if ((i + 1) % 4 != 0) Console.WriteLine("|");
            }

            Console.WriteLine();
        }
    }
}
