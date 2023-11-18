namespace Probabilidad_infarto
{
    internal class Program
    {
        static string nombre = "";
        static double altura = 0;
        static double peso = 0;
        static bool repetir = false;

        static void Main(string[] args)
        {
            do
            {
                Console.Clear(); 

                Persona();

                double IMC = IndiceMasa();

                Estres(IMC);

                Tabla(IMC);

                repetir = Repetir();


                Console.ReadKey();

            } while (repetir == true);
            
        }

        static void Persona()
        {
            Console.WriteLine("\nComo te llamas?");
            nombre = Console.ReadLine();

            Pedir_altura();

            Pedir_peso();

        }

        static void Pedir_peso()
        {
            Console.WriteLine("\nCuanto pesas?");

            while (true)
            {
                string pesoStr = Console.ReadLine();

                if (int.TryParse(pesoStr, out int pesoConvert))
                {
                    peso = pesoConvert;
                    break;
                }
                else
                { 
                    Console.WriteLine("\nIngrese un dato numerico ENTERO, sin decimales.");
                }
            }
            
        }

        static void Pedir_altura ()
        {
            Console.WriteLine("\nCuanto mides?");

            while (true)
            {
                string alturaStr = Console.ReadLine();

                if (double.TryParse(alturaStr, out double alturaConvert))
                {
                    altura = alturaConvert;
                    break;
                }
                else { Console.WriteLine("\nIngresa el dato en metros ejemplo '1,75'."); }
            }
            
        }

        static double IndiceMasa()
        {
           double imc = Math.Round(peso / Math.Pow(altura,2),1);

            Console.WriteLine($"{nombre} tu IMC es de {imc} \n");

            if(imc < 18.5)
            {
                Console.WriteLine("Estas bajo de peso.\n");
            } 
            else if (imc < 24.9)
            {
                Console.WriteLine("Tienes un peso normal.\n");

            }
            else if (imc < 29.9)
            {
                Console.WriteLine("Tienes sobrepeso.\n");

            }
            else if (imc > 30)
            {
                Console.WriteLine("Tienes obesidad.\n");

            }

            return imc;
        }
        static void Estres(double imc)
        {
            Console.WriteLine("Tienes estres? SI - NO\n");

            string stress = Console.ReadLine().ToLower();

            
            if (stress.Contains("si"))
            {
                if (imc > 24.9)
                {
                    Console.WriteLine("La probabilidad de sufir un infarto es de 62%\n");
                }
                else
                {
                    Console.WriteLine("La probabilidad de sufir un infarto es de 15%\n");
                }
            }
            else if (stress.Contains("no"))
            {
                if (imc > 24.9)
                {
                    Console.WriteLine("La probabilidad de sufir un infarto es de 18%\n");
                }
                else
                {
                    Console.WriteLine("La probabilidad de sufir un infarto es de 5%\n");
                }
            }
        }
        static bool Repetir()
        {
            Console.WriteLine("Pulsa 'R' para repetir u otra letra para salir");

            char rep = Console.ReadKey().KeyChar;

            if (rep == 'r' || rep == 'R')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Tabla(double imc)
        {
            if (imc > 24.9)
            {
                Console.WriteLine($"--------------- {nombre} ---------------");
                Console.WriteLine($"       Probabilidad de infarto ");
                Console.WriteLine($"            Con estres 62%");
                Console.WriteLine($"            Sin estres 18%");
            }
            else if (imc < 24.9)
            {
                Console.WriteLine($"--------------- {nombre} ---------------");
                Console.WriteLine($"       Probabilidad de infarto ");
                Console.WriteLine($"           Con estres 15%");
                Console.WriteLine($"           Sin estres 5%");
            }

        }

    }
}