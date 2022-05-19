using Logic;

namespace Decryper
{
    class Decryper
    {
        static void Main(string[] args)
        {
            L_Decryper ld=new L_Decryper();

            Console.WriteLine("Desencriptar Textos");

            string t, o, k;

            t = o = k = "";


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
            Console.WriteLine("Escriba la clave numerica: ");
            k = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Escriba el orden binario: ");
            o = Console.ReadLine();

            //Console.WriteLine(o);

            string text = ld.Decript(t, k, o);
            

            Console.WriteLine();
            Console.WriteLine(text);

            //*/
        }
    }
}