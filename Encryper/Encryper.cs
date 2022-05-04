using Logic;

namespace Encryper
{
    class Encryper
    {
        static void Main(string[] args)
        {
            L_Encryper le=new L_Encryper();

            string text;

            Console.Write("Escriba el texto que quiera encriptar: ");
            text = Console.ReadLine();

            string[] t = le.Encript(text);

            Console.WriteLine(t[0]);
            Console.WriteLine(t[1]);
            Console.WriteLine(t[2]);

            //for (int i = 0; i < 30; i++)
            //{
            //    Console.WriteLine(r.Next(2).ToString());
            //}

        }
    }
}