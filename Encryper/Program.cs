using Data;

namespace Encryper
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary p=new Dictionary();

            string text;
            string[] letters;

            Console.Write("Escriba el texto que quiera encriptar: ");
            text = Console.ReadLine();

            text = text.ToUpper();

            letters=new string[text.Length];

            int o = 0;

            foreach(char c in text)
            {
                letters[o] = c.ToString();
                o++;
            }

            //int[] l2n=new Int32[letters.Length];

            string t = "", n = "", k = "";

            Random r = new Random();

            for (int i = 0; i < letters.Length; i++)
            {
                int l2n = p.L2N(letters[i]);

                int UoD = r.Next(2);

                int num = r.Next(10);

                int n2n = UoD == 1 ? l2n - num : l2n + num;

                if (n2n < 0)
                    n2n += 28;

                if (n2n > 28)
                    n2n -= 28;

                t += p.N2L(n2n);
                n += num.ToString();
                k += UoD;

                //Console.WriteLine(letters[i]);
            }

            Console.WriteLine(t);
            Console.WriteLine(n);
            Console.WriteLine(k);

            //for (int i = 0; i < 30; i++)
            //{
            //    Console.WriteLine(r.Next(2).ToString());
            //}

        }
    }
}