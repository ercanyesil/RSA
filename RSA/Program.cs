using System;
using System.Text;

namespace RSA
{
    class Program
    {
        static int Main()
        {
           // Console.WriteLine(UstelMod(69,47,73));

            int p, q;

            Console.Write("Bir asal sayı giriniz : ");
            p = int.Parse(Console.ReadLine());

            Console.Write("Bir asal sayi daha giriniz : ");
            q = int.Parse(Console.ReadLine());


            int n = p * q;
            int phi = Totient(n); //int phi=(p-1)*(q-1);

            int e = 0;
           
            Console.WriteLine("-------Seçilebilecek sayılar-------");

            for(int i = 2; i < phi; i++)
            {               
                if (OBEB(phi,i) == 1)
                {
                    Console.Write("{0} ", i);
                }
            }

            Console.WriteLine("\ne : ");
            e = int.Parse(Console.ReadLine());

            Console.WriteLine("({0},{1})",n,e);

            Console.WriteLine("Metin giriniz :");
            string text = Console.ReadLine();

            text = RSA(text, n, e);

            Console.WriteLine("Cipher text : "+text);

            Console.ReadLine();

            return 0;
        }

        static int OBEB(int x,int y)
        {
            int min = Math.Min(x, y);
            int obeb = 1;

            for (int i = 2; i <= min; i++)
            {
                if (x % i == 0 && y % i == 0)
                {
                    obeb = i;
                }
            }
            return obeb;
        }

        static int UstelMod(int a, int b, int n)//a^b(mod(n)) 69^47 73...
        {
            int _a = a % n;
            int _b = b;

            if (b == 0)
            {
                return 1;
            }
            while (_b > 1)
            {
                _a *= a;
                _a %= n;
                _b--;
            }
            return _a;
        }

        static int Totient(int n)
        {
            int adet = 0;

            for (int i = 1; i < n; i++)
            {
                if (OBEB(n,i) == 1)
                {
                    adet++;
                }
            }
            return adet;
        }

        static string RSA(string metin, int n, int e)// m^e(mod(n))
        {
            char[] chars = metin.ToCharArray();

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < chars.Length; i++)
            {
                builder.Append(Convert.ToChar(UstelMod(chars[i], e, n)));
            }
            return builder.ToString();
        }
       
    }
}