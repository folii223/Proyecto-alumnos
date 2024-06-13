using System.Transactions;

namespace ProyectoAlumnos
{
    internal class Program
    {
        static string leerOpcionAlumno()
        {
            Console.WriteLine("*------------------------------------*");
            Console.WriteLine("*    Ingrese una opcion válida       *");
            Console.WriteLine("*      1- Alta de usuario:           *");
            Console.WriteLine("*      2- Baja de usuario:           *");
            Console.WriteLine("*      3- Modificación de usuario:   *");
            Console.WriteLine("*      0- Salir del menú             *");
            Console.WriteLine("*------------------------------------*");
            Console.Write("Opción: ");

            string opcion;
            do
            {
                leerOpcionAlumno();
                opcion = Console.ReadLine();
                if (opcion == "1")
                {
                    //alta usuario
                }
                else if (opcion == "2")
                {
                    //baja usuario
                }
                else if (opcion == "3")
                {
                    //modificacion usuario
                }


            } while (opcion != "0");

                
            
        }
        static void Main(string[] args)
        {         
            string opcionMenuAlumno;
            
            
            do
            {


                opcionMenuAlumno = leerOpcionAlumno();
            
            
            } while (true);
        }
    }
}
