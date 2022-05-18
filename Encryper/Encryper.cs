using Logic;

namespace Encryper
{
    class Encryper
    {
        static L_Encryper le = new L_Encryper();
        static void Main(string[] args)
        {
            bool rot = false;
            string texto;

            if (args.Length > 0)
            {
                switch (args[0])
                {
                    case "-h":
                    case "--help":
                        Console.WriteLine("Encriptar un texto");
                        Console.WriteLine("");
                        Console.WriteLine("Modo de uso:");
                        Console.WriteLine();
                        Console.WriteLine("Para encriptar cada letra individual");
                        Console.WriteLine("ENCRYPER {-t | -f} {texto | archivo} {-fl | -d} [carpeta]");
                        Console.WriteLine("");
                        Console.WriteLine("Para encriptar un texto en ROT: (NO IMPLEMENTADO)");
                        Console.WriteLine("ENCRYPER -r {x} {-t | -f} {texto | archivo} {-fl | -d} [txt]");
                        Console.WriteLine("");
                        Console.WriteLine("Argumentos:");
                        Console.WriteLine("-h, --help\tAbrir esta ayuda");
                        Console.WriteLine("-t, --text\tIndica que se va a encriptar un texto escrito directo en la consola");
                        Console.WriteLine("-f, --file\tIndica que se va a encriptar un texto guardado en un archivo");
                        Console.WriteLine("texto\t\tEl texto plano que se quiere encriptar, si tiene espacios debe ir entre comillas (\")");
                        Console.WriteLine("archivo\t\tRuta al archivo que contiene el texto que se quiere encriptar");
                        Console.WriteLine("-fl, --folder\tGuardar el texto encriptado en tres archivos en una carpeta");
                        Console.WriteLine("-d, --direct\tMostrar el texto encriptado directamente en la consola");
                        Console.WriteLine("carpeta\t\tRuta de la carpeta donde se van a guardar los archivos");
                        Console.WriteLine("-r --rot\tEncriptar el texto en ROT");
                        Console.WriteLine("x\t\tNumero entero, numero de posiciones que se van a desplazar las letras" +
                            "\n\t\tPositivo para desplazar hacia arriba, negativo para desplazar hacia abajo");
                        Console.WriteLine("txt\t\tRuta local del archivo donde se va a guardar el texto encriptado en ROT");
                        return;

                    case "-t":
                    case "--text":
                    case "-f":
                    case "--file":
                        if(!(args.Length >= 3 && args.Length <= 4))
                            break;

                        texto=ToF(args, rot);
                        FLoD(args, texto);
                        return;

                    case "-r":
                    case "--rot":
                        if (!(args.Length >= 4 && args.Length <= 6))
                            break;

                        rot = true;
                        texto=ToF(args, rot);

                        int pos = 0;

                        try
                        {
                            pos = Convert.ToInt32(args[1]);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error al leer las posiciones de encriptado ROT");
                            Console.WriteLine(e.Message);
                            return;
                        }

                        if (args[4] == "-fl" || args[4] == "--folder")
                        {
                            if (args.Length < 4)
                            {
                                Console.WriteLine("Falta el argumento de la ruta de la carpeta");
                                break;
                            }

                            le.ROT(texto, pos, args[5]);
                        }
                        else if (args[4] == "-d" || args[4] == "--direct")
                        {
                            Console.WriteLine("");
                            string rotted = le.ROT(texto, pos);
                            Console.WriteLine(rotted);
                        }
                        else
                        {
                            Console.WriteLine("No se reconoce el argumento \"" + args[2] + "\"");
                        }
                        return;

                    default:
                        Console.WriteLine("No se reconoce el argumento \"" + args[0] + "\"");
                        Console.WriteLine("Para ver todos los argumentos use -h");
                        return;
                }

                Console.WriteLine("Cantidad de argumentos incorrecta");
                
            }
            else
            {
                string text, path;

                Console.Write("Escriba el texto que quiera encriptar: ");
                text = Console.ReadLine();

                //Console.Write("Escriba la ruta donde desea guardar los archivos encriptados: ");
                //path = Console.ReadLine();

                string[] t = le.Encript(text);

                Console.WriteLine("");
                Console.WriteLine("Resultado:");
                Console.WriteLine(t[0]);
                Console.WriteLine(t[1]);
                Console.WriteLine(t[2]);
            }

        }

        private static string ToF(string[] args, bool rot)
        {
            int r = 0;
            if (rot)
                r = 2;

            string texto = "";

            if (args[0+r] == "-t" || args[0 + r] == "--text")
            {
                texto = args[1+r];
            }
            else if (args[0 + r] == "-f" || args[0 + r] == "--file")
            {
                texto = le.L_ReadFromFile(args[1+r]);

                if (texto=="0")
                {
                    Console.WriteLine(le.msg);
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.WriteLine("No se reconoce el argumento \"" + args[1+r] + "\"");
                return "";
            }
                return texto;
        }

        public static void FLoD(string[] args, string texto)
        {
            if (args[2] == "-fl" || args[2] == "--folder")
            {
                if (args.Length < 4)
                {
                    Console.WriteLine("Falta el argumento de la ruta de la carpeta");
                    return;
                }

                le.Encript(texto, args[3]);
            }
            else if (args[2] == "-d" || args[2] == "--direct")
            {
                Console.WriteLine("");
                string[] encryped = le.Encript(texto);
                for (int i = 0; i < encryped.Length; i++)
                {
                    Console.WriteLine(encryped[i]);
                }
            }
            else
            {
                Console.WriteLine("No se reconoce el argumento \"" + args[2] + "\"");
            }
        }

    }
}