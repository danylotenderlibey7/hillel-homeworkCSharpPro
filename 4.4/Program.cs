namespace _4._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Matrix m1 = new Matrix(3, 3);
            m1[0, 0] = 1; m1[0, 1] = 2; m1[0, 2] = 3;
            m1[1, 0] = 4; m1[1, 1] = 5; m1[1, 2] = 6;
            m1[2, 0] = 7; m1[2, 1] = 8; m1[2, 2] = 9;

            Matrix m2 = new Matrix(3, 3);
            m2[0, 0] = 10; m2[0, 1] = 11; m2[0, 2] = 12;
            m2[1, 0] = 13; m2[1, 1] = 14; m2[1, 2] = 15;
            m2[2, 0] = 16; m2[2, 1] = 17; m2[2, 2] = 18;

            Matrix m3 = new Matrix(4, 4);
            m3[0, 0] = 1; m3[0, 1] = 2; m3[0, 2] = 3; m3[0, 3] = 4;
            m3[1, 0] = 5; m3[1, 1] = 6; m3[1, 2] = 7; m3[1, 3] = 8;
            m3[2, 0] = 9; m3[2, 1] = 10; m3[2, 2] = 11; m3[2, 3] = 12;
            m3[3, 0] = 13; m3[3, 1] = 14; m3[3, 2] = 15; m3[3, 3] = 16;

            Matrix sum_m1_m2 = m1 + m2;
            Console.WriteLine("Matrix Sum(m1+m2):");
            sum_m1_m2.Print();

            Matrix sum_m1_m3 = m1 + m3;
            Console.WriteLine("Matrix Sum(m1+m3)");
            sum_m1_m3.Print();

            Matrix difference_m1_m2 = m1 - m2;
            Console.WriteLine("Matrix Difference(m1-m2):");
            difference_m1_m2.Print();

            Matrix difference_m3_m1 = m3 - m1;
            Console.WriteLine("Matrix Difference(m3-m1):");
            difference_m3_m1.Print();

            Matrix multiplication_m2_m3 = m2 * m3;
            Console.WriteLine("Matrix Multiplication(m2*m3)");
            multiplication_m2_m3.Print();

            double scalar = 3;
            Matrix scaledMatrix = m1 * scalar;
            Console.WriteLine($"Matrix m1 multiplied by {scalar}:");
            scaledMatrix.Print();

            bool areEqual = m1 == m2;
            Console.WriteLine($"Are m1 and m2 equal? {(areEqual ? "yes" : "no")}");
        }
    }
}
