using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Data
{
    public class FileSystem
    {
        StreamReader sr;
        StreamWriter sw;

        public string msg;

        /// <summary>
        /// Lee el texto contenido en un archivo, no necesariamente .txt
        /// </summary>
        /// <param name="path">Ruta local del archivo</param>
        /// <returns>Un string con el texto leido del archivo</returns>
        public string ReadFromFile(string path)
        {
            try
            {
                sr = new StreamReader(path);
                string text = "";
                string line;
                do
                {
                    line = sr.ReadLine();
                    text += line + " ";
                } while (line != null);

                sr.Close();
                return text;

            }
            catch (Exception e)
            {
                msg = e.Message;
                return "0";
            }
}

        /// <summary>
        /// Lee el texto encriptado contenido en 3 archivos .ncrp guardados por Encryper
        /// </summary>
        /// <param name="path">Ruta local de la carpeta que contiene los tres archivos</param>
        /// <returns>Un arreglo de tipo strings con el texto, la clave y el orden binario respectivamente</returns>
        public string[] ReadFromNCRP(string path)
        {
            path += !path.EndsWith("\\") ? "\\" : "";

            try
            {
                if (!File.Exists(path + "text.ncrp"))
                {
                    string[] err = new string[1];
                    if (!Directory.Exists(path))
                    {
                        err[1] = "3";
                        return err;
                    }

                    err[1] = "2";
                    return err;
                }
                else
                {
                    string[] text = new string[3];
                    string[] names = { "text", "key", "order" };

                    for (int i = 0; i < text.Length; i++)
                    {
                        sr = new StreamReader(path + names + ".ncrp");
                        while (sr.ReadLine != null)
                        {
                            text[i] += sr.ReadLine();
                        }
                        sr.Close();
                    }
                    return text;
                }
            }
            catch (Exception e)
            {
                msg = e.Message;
                string[] err = { "0" };
                return err;
            }
        }

        /// <summary>
        /// Guarda el texto encriptado en tres archivos de tipo .ncrp cada uno con el texto, llave y orden binario
        /// </summary>
        /// <param name="path">Ruta local de la carpeta donde se van a guardar los tres archivos</param>
        /// <param name="encryped">Arreglo de tipo string que contiene el texto encriptado, la llave y el orden binario respectivamente</param>
        /// <returns>Un valor de tipo entero que indica si el procesor se realizo correctamente</returns>
        public int SaveInNCRP(string path, string[] encryped)
        {
            path += !path.EndsWith("\\") ? "\\" : "";
            string[] names = { "text", "key", "order" };

            try
            {
                for (int i = 0; i < encryped.Length; i++)
                {
                    sw = new StreamWriter(path + names[i] + ".ncrp");
                    sw.WriteLine(encryped[i]);
                    sw.Close();

                }

                return 1;
            }
            catch (Exception e)
            {
                msg = e.Message;
                return 0;
            }
        }


        /// <summary>
        /// Guarda el texto desencriptado en un archivo .txt
        /// </summary>
        /// <param name="path">Ruta local del archivo donde se va a guardar el texto desencriptado</param>
        /// <param name="text">Texto desencriptado por decryper</param>
        /// <returns>Un valor numerico de tipo entero que indica si el proceso se ha realizado correctamente</returns>
        public int SaveInTxt(string path, string text)
        {
            path += !path.ToUpper().EndsWith(".TXT") ? ".txt" : "";

            try
            {
                sw = new StreamWriter(path);
                sw.WriteLine(text);
                sw.Close();
                return 1;
            }
            catch (Exception e)
            {
                msg = e.Message;
                return 0;
            }
        }

    }
}
