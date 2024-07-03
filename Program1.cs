using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Universidad
{
    class Program
    {
        static void Main(string[] args)
        {
            MostrarMenuPrincipal();
        }

        static void MostrarMenuPrincipal()
        {
            while (true)
            {
                Console.WriteLine("Menú Principal:");
                Console.WriteLine("1. Gestión de Alumnos");
                Console.WriteLine("2. Gestión de Materias");
                Console.WriteLine("3. Gestión de Alumno_Materias");
                Console.WriteLine("4. Salir");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        MenuGestionAlumnos();
                        break;
                    case 2:
                        MenuGestionMaterias();
                        break;
                    case 3:
                        MenuGestionAlumnoMaterias();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }

        static void MenuGestionAlumnos()
        {
            List<Alumno> alumnos = new List<Alumno>();
            while (true)
            {
                Console.WriteLine("Menú Gestión de Alumnos:");
                Console.WriteLine("1. Alta de Alumno");
                Console.WriteLine("2. Baja de Alumno");
                Console.WriteLine("3. Modificación de Alumno");
                Console.WriteLine("4. Mostrar Alumnos Activos");
                Console.WriteLine("5. Mostrar Alumnos Inactivos");
                Console.WriteLine("6. Guardar y Salir");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AltaAlumno(alumnos);
                        break;
                    case 2:
                        BajaAlumno(alumnos);
                        break;
                    case 3:
                        ModificarAlumno(alumnos);
                        break;
                    case 4:
                        MostrarAlumnosActivos(alumnos);
                        break;
                    case 5:
                        MostrarAlumnosInactivos(alumnos);
                        break;
                    case 6:
                        GuardarAlumnosEnArchivo(alumnos);
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }

        static void MenuGestionMaterias()
        {
            List<Materia> materias = new List<Materia>();
            while (true)
            {
                Console.WriteLine("Menú Gestión de Materias:");
                Console.WriteLine("1. Alta de Materia");
                Console.WriteLine("2. Baja de Materia");
                Console.WriteLine("3. Modificación de Materia");
                Console.WriteLine("4. Mostrar Materias");
                Console.WriteLine("5. Guardar y Salir");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AltaMateria(materias);
                        break;
                    case 2:
                        BajaMateria(materias);
                        break;
                    case 3:
                        ModificarMateria(materias);
                        break;
                    case 4:
                        MostrarMaterias(materias);
                        break;
                    case 5:
                        GuardarMateriasEnArchivo(materias);
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }



        // Estructura para Alumno
        public struct Alumno
        {
            public int Indice;
            public string Nombre;
            public string Apellido;
            public string DNI;
            public DateTime FechaNacimiento;
            public string Domicilio;
            public bool EstaActivo;
            public string alumnos;
        }
        public struct Materia
        {
            public int Codigo;
            public string Nombre;
            public string Descripcion;
        }

        // Gestión de Alumnos
        static void AltaAlumno(List<Alumno> alumnos)
        {
            Alumno nuevoAlumno = new Alumno();
            nuevoAlumno.Indice = alumnos.Count + 1;
            Console.Write("Ingrese Nombre: ");
            nuevoAlumno.Nombre = Console.ReadLine();
            Console.Write("Ingrese Apellido: ");
            nuevoAlumno.Apellido = Console.ReadLine();
            Console.Write("Ingrese DNI: ");
            nuevoAlumno.DNI = Console.ReadLine();
            Console.Write("Ingrese Fecha de Nacimiento (dd/mm/yyyy): ");
            nuevoAlumno.FechaNacimiento = DateTime.Parse(Console.ReadLine());
            Console.Write("Ingrese Domicilio: ");
            nuevoAlumno.Domicilio = Console.ReadLine();
            nuevoAlumno.EstaActivo = true;
            alumnos.Add(nuevoAlumno);
            Console.WriteLine("Alumno agregado exitosamente.");
        }

        static void BajaAlumno(List<Alumno> alumnos)
        {
            Console.Write("Ingrese el DNI del alumno a desactivar: ");
            string dni = Console.ReadLine();
            for (int i = 0; i < alumnos.Count; i++)
            {
                if (alumnos[i].DNI == dni && alumnos[i].EstaActivo)
                {
                    alumnos[i].EstaActivo = false;
                    Console.WriteLine("Alumno desactivado exitosamente.");
                    return;
                }
            }
            Console.WriteLine("Alumno no encontrado o ya está inactivo.");
        }

        static void ModificarAlumno(List<Alumno> alumnos)
        {
            Console.Write("Ingrese el DNI del alumno a modificar: ");
            string dni = Console.ReadLine();
            for (int i = 0; i < alumnos.Count; i++)
            {
                if (alumnos[i].DNI == dni)
                {
                    Console.Write("Ingrese Nuevo Nombre (anterior: {0}): ", alumnos[i].Nombre);
                    alumnos[i].Nombre = Console.ReadLine();
                    Console.Write("Ingrese Nuevo Apellido (anterior: {0}): ", alumnos[i].Apellido);
                    alumnos[i].Apellido = Console.ReadLine();
                    Console.Write("Ingrese Nueva Fecha de Nacimiento (anterior: {0}) (dd/mm/yyyy): ", alumnos[i].FechaNacimiento.ToString("dd/MM/yyyy"));
                    alumnos[i].FechaNacimiento = DateTime.Parse(Console.ReadLine());
                    Console.Write("Ingrese Nuevo Domicilio (anterior: {0}): ", alumnos[i].Domicilio);
                    alumnos[i].Domicilio = Console.ReadLine();
                    Console.WriteLine("Alumno modificado exitosamente.");
                    return;
                }
            }
            Console.WriteLine("Alumno no encontrado.");
        }

        static void MostrarAlumnosActivos(List<Alumno> alumnos)
        {
            Console.WriteLine("Alumnos Activos:");
            foreach (var alumno in alumnos)
            {
                if (alumno.EstaActivo)
                {
                    Console.WriteLine("{0}, {1} {2}, DNI: {3}, Fecha de Nacimiento: {4}, Domicilio: {5}",
                        alumno.Indice, alumno.Nombre, alumno.Apellido, alumno.DNI,
                        alumno.FechaNacimiento.ToString("dd/MM/yyyy"), alumno.Domicilio);
                }
            }
        }

        static void MostrarAlumnosInactivos(List<Alumno> alumnos)
        {
            Console.WriteLine("Alumnos Inactivos:");
            foreach (var alumno in alumnos)
            {
                if (!alumno.EstaActivo)
                {
                    Console.WriteLine("{0}, {1} {2}, DNI: {3}, Fecha de Nacimiento: {4}, Domicilio: {5}",
                        alumno.Indice, alumno.Nombre, alumno.Apellido, alumno.DNI,
                        alumno.FechaNacimiento.ToString("dd/MM/yyyy"), alumno.Domicilio);
                }
            }
        }

        static void GuardarAlumnosEnArchivo(List<Alumno> alumnos)
        {
            using (StreamWriter sw = new StreamWriter("alumnos.txt"))
            {
                foreach (var alumno in alumnos)
                {
                    sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}",
                        alumno.Indice, alumno.Nombre, alumno.Apellido, alumno.DNI,
                        alumno.FechaNacimiento.ToString("dd/MM/yyyy"), alumno.Domicilio,
                        alumno.EstaActivo ? "true" : "false");
                }
            }
            Console.WriteLine("Datos de alumnos guardados en 'alumnos.txt'.");
        }

        static void AltaMateria(List<Materia> materias)
        {
            Materia nuevaMateria = new Materia();
            Console.Write("Ingrese Código de Materia: ");
            nuevaMateria.Codigo = int.Parse(Console.ReadLine());
            Console.Write("Ingrese Nombre de Materia: ");
            nuevaMateria.Nombre = Console.ReadLine();
            Console.Write("Ingrese Descripción de Materia: ");
            nuevaMateria.Descripcion = Console.ReadLine();

            if (materias.Any(m => m.Codigo == nuevaMateria.Codigo || m.Nombre == nuevaMateria.Nombre))
            {
                Console.WriteLine("Materia con el mismo código o nombre ya existe.");
            }
            else
            {
                materias.Add(nuevaMateria);
                Console.WriteLine("Materia agregada exitosamente.");
            }
        }

        static void BajaMateria(List<Materia> materias)
        {
            Console.Write("Ingrese el Código de la materia a eliminar: ");
            int codigo = int.Parse(Console.ReadLine());
            var materia = materias.FirstOrDefault(m => m.Codigo == codigo);
            if (materia.Equals(default(Materia)))
            {
                Console.WriteLine("Materia no encontrada.");
            }
            else
            {
                materias.Remove(materia);
                Console.WriteLine("Materia eliminada exitosamente.");
            }
        }

        static void ModificarMateria(List<Materia> materias)
        {
            Console.Write("Ingrese el Código de la materia a modificar: ");
            int codigo = int.Parse(Console.ReadLine());
            for (int i = 0; i < materias.Count; i++)
            {
                if (materias[i].Codigo == codigo)
                {
                    Console.Write("Ingrese Nuevo Nombre de Materia (anterior: {0}): ", materias[i].Nombre);
                    string nuevoNombre = Console.ReadLine();
                    Console.Write("Ingrese Nueva Descripción de Materia (anterior: {0}): ", materias[i].Descripcion);
                    string nuevaDescripcion = Console.ReadLine();

                    if (materias.Any(m => m.Nombre == nuevoNombre && m.Codigo != codigo))
                    {
                        Console.WriteLine("Ya existe una materia con ese nombre.");
                    }
                    else
                    {
                        materias[i].Nombre = nuevoNombre;
                        materias[i].Descripcion = nuevaDescripcion;
                        Console.WriteLine("Materia modificada exitosamente.");
                    }
                    return;
                }
            }
            Console.WriteLine("Materia no encontrada.");
        }

        static void MostrarMaterias(List<Materia> materias)
        {
            Console.WriteLine("Materias:");
            foreach (var materia in materias)
            {
                Console.WriteLine("{0}, {1}, Descripción: {2}",
                    materia.Codigo, materia.Nombre, materia.Descripcion);
            }
        }

        static void GuardarMateriasEnArchivo(List<Materia> materias)
        {
            using (StreamWriter sw = new StreamWriter("materias.txt"))
            {
                foreach (var materia in materias)
                {
                    sw.WriteLine("{0},{1},{2}",
                        materia.Codigo, materia.Nombre, materia.Descripcion);
                }
            }
            Console.WriteLine("Datos de materias guardados en 'materias.txt'.");
        }

       
        // Gestión de Alumno_Materias
        static void MenuGestionAlumnoMaterias()
        {
            // Implementar el menú de gestión de alumno_materias y llamar las funciones correspondientes
        }

        // Funciones de Utilidad (Lectura y Escritura de Archivos)
        static void LeerArchivoAlumnos()
        {
            // Lógica para leer el archivo de alumnos
        }

        static void EscribirArchivoAlumnos()
        {
            // Lógica para escribir en el archivo de alumnos
        }

        static void LeerArchivoMaterias()
        {
            // Lógica para leer el archivo de materias
        }

        static void EscribirArchivoMaterias()
        {
            // Lógica para escribir en el archivo de materias
        }

        static void LeerArchivoAlumnoMaterias()
        {
            // Lógica para leer el archivo de alumno_materias
        }

        static void EscribirArchivoAlumnoMaterias()
        {
            // Lógica para escribir en el archivo de alumno_materias
        }
    }
}
