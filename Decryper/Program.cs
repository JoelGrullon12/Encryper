using Data;

namespace Decryper
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary p = new Dictionary();

            Console.WriteLine("Desencriptar Textos");

            string t, o, k;

            t = o = k = "";
            string text = "";


            //tar[t.Length - 1] = 1;

            /*
            if(t.Lenght!=o.Lenght){
            	Console.WriteLine("La longitud del texto no coincide con el orden binario, ");
            }
            */

            Console.WriteLine();
            Console.WriteLine("Escriba el texto encriptado: ");
            t = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Escriba el orden binario: ");
            o = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Escriba la clave numerica: ");
            k = Console.ReadLine();

            //Console.WriteLine(o);


            int[] tar = new int[t.Length];
            int[] oar = new int[o.Length];
            int[] kar = new int[k.Length];

            int u = 0;
            foreach (char c in t)
            {
                tar[u] = p.L2N(c.ToString());
                u++;
            }


            //for (int i = 0; i < tar.Length; i++)
            //{
            //	Console.WriteLine(tar[i]);
            //}

            u = 0;
            foreach (char c in o)
            {
                oar[u] = Convert.ToInt32(c.ToString());
                u++;
            }

            u = 0;
            foreach (char c in k)
            {
                kar[u] = Convert.ToInt32(c.ToString());
                u++;
            }


            //for (int i = 0; i < oar.Length; i++)
            //{
            //    Console.WriteLine(oar[i]);
            //}//


            for (int i = 0; i < tar.Length; i++)
            {
                if (oar[i] == 1)
                {
                    tar[i] += kar[i];
                }
                else if (oar[i] == 0)
                {
                    tar[i] -= kar[i];
                }
                else
                {
                    Console.WriteLine("Se ha encontrado un error en el orden binario, reviselo e intentelo de nuevo");
                }

                if (tar[i] > 28)
                    tar[i] -= 28;

                if (tar[i] < 0)
                    tar[i] += 28;

                text += p.N2L(tar[i]);

                //Console.WriteLine(tar[i]);
            }

            Console.WriteLine();
            Console.WriteLine(text);

            //*/
        }
    }
}