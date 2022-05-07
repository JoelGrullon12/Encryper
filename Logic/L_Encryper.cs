using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using System.IO;

namespace Logic
{
    public class L_Encryper
    {
        Dictionary dict = new Dictionary();
        FileSystem fs = new FileSystem();

        /// <summary>
        /// Contiene la logica para encriptar el texto dado, ya sea a traves de un archivo de texto o directamente en un texto plano
        /// </summary>
        /// <param name="readFromPath">Ruta local del archivo donde se encuentra el texto que se quiere encriptar</param>
        /// <param name="writeInPath">Ruta local de la carpeta donde se van a guardar los archivos con el texto encriptado</param>
        /// <returns></returns>
        public string[] Encript(string text)
        {
            //string text = fs.ReadFromFile(readFromPath);
            //Console.WriteLine(text);
            //Console.WriteLine(fs.msg);

            //string[] noc = { "nocXD" };
            //return noc;
            text = text.ToUpper();
            string[] letters;

            letters = new string[text.Length];

            int e = 0;

            foreach (char c in text)
            {
                letters[e] = c.ToString();
                e++;
            }

            //int[] l2n=new Int32[letters.Length];

            string t = "", k = "", o = "";

            Random r = new Random();

            for (int i = 0; i < letters.Length; i++)
            {
                int l2n = dict.L2N(letters[i]);

                int UoD = r.Next(2);

                int num = r.Next(10);

                int n2n = UoD == 1 ? l2n - num : l2n + num;

                if (n2n < 0)
                    n2n += 28;

                if (n2n > 28)
                    n2n -= 28;

                t += dict.N2L(n2n);
                k += num.ToString();
                o += UoD;
            }

            Console.WriteLine("");
            Console.WriteLine(t);
            Console.WriteLine(k);
            Console.WriteLine(o);

            string[] encripted = { t, k, o };

            //fs.SaveInNCRP(writeInPath, encripted);
            return encripted;
        }
    }
}
