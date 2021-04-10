using System;
using System.Collections.Generic;

using System.IO;
using System.Xml.Serialization;

namespace ActividadEstudiante
{
    class Program
    {
        private const int V = 20;
        static List<Estudiante> ListaEstudiantes = new List<Estudiante>();
        static Validaciones Validar = new Validaciones();
        static void Main(string[] args)
        {
            int Menu;
            string aux;
            bool entradaVal = false;

            do
            {
                Console.Clear();
                Console.WriteLine("1) Agregar Estudiantes.");
                Console.WriteLine("2) Listar Estudiantes.");
                Console.WriteLine("3) Buscar Estudiantes.");
                Console.WriteLine("0) Salir...");
                Console.WriteLine("5) Guardar Archivo... ");
                Console.WriteLine("6) Cargar Archivo...");

                do
                {
                    Console.WriteLine("Digite una opcion: ");
                    aux = Console.ReadLine();
                    if (!Validar.Vacio(aux))
                        if (Validar.Numero(aux))
                            entradaVal = true;
                } while (!entradaVal);

                Menu = Convert.ToInt32(aux);

                switch (Menu)
                {
                    case 1:
                        AgregarEstudiantes();
                        break;
                    case 2:
                        ListarEstudiantes();
                        break;
                    case 3:
                        BuscarEstudiantes();
                        break;
                    case 5:
                        EscribirXml();
                        break;
                    case 6:
                        LeerXml();
                        break;
                    case 0:
                        Console.WriteLine("Gracias y hasta luego ......");
                        break;
                    default:
                        Console.WriteLine("Opcion incorrecta");
                        break;

                }
                Console.WriteLine();
                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadLine();

            } while (Menu > 0);

        }

        static void AgregarEstudiantes()
        {
            string nombre, correo, codigo, nota1, nota2, nota3;
            bool nomVal = false;
            bool correoVal = false;
            bool codVal = false;
            bool notas1 = false;
            bool notas2 = false;
            bool notas3 = false;

            Console.Clear();
            Console.WriteLine("Ingrese datos...");
            Console.WriteLine("---------------------------------------");

            //---------------------------------------------------------------

            do
            {
                Console.WriteLine("Ingrese el codigo del nuevo estudiante: ");
                codigo = Console.ReadLine();
                if (!Validar.Vacio(codigo))
                    if (Validar.Numero(codigo))
                        codVal = true;
            } while (!codVal);

            if (Existe(Convert.ToInt32(codigo)))
                Console.WriteLine("El codigo" + codigo + " ya existe en el programa.");
            else
            {


                //----------------------------------------------------------------

                do
                {
                    Console.WriteLine("Ingrese el nombre del nuevo estudiante: ");
                    nombre = Console.ReadLine();
                    if (!Validar.Vacio(nombre))
                        if (Validar.TipoTexto(nombre))
                            nomVal = true;
                } while (!nomVal);

                //----------------------------------------------------------------

                do
                {
                    Console.WriteLine("Ingrese el correo del nuevo estudiante: ");
                    correo = Console.ReadLine();
                    if (!Validar.Vacio(correo))
                        if (Validar.Mail(correo))
                            correoVal = true;
                } while (!correoVal);


                //-----------------------------------------------------------------

                do
                {
                    Console.WriteLine("Ingrese su 1ra Nota:  ");
                    nota1 = Console.ReadLine();
                    nota1 = nota1.Replace('.', ',');
                    if (!Validar.Vacio(nota1))
                        if (Validar.Numero(nota1))
                            notas1 = true;
                } while (!notas1);

                //--------------------------------------------------------------

                do
                {
                    Console.WriteLine("Ingrese su 2da Nota:  ");
                    nota2 = Console.ReadLine();
                    nota2 = nota2.Replace('.', ',');
                    if (!Validar.Vacio(nota2))
                        if (Validar.Numero(nota2))
                            notas2 = true;
                } while (!notas2);

                //----------------------------------------------------------------

                do
                {
                    Console.WriteLine("Ingrese su 3ra Nota:  ");
                    nota3 = Console.ReadLine();
                    nota3 = nota3.Replace('.', ',');
                    if (!Validar.Vacio(nota3))
                        if (Validar.Numero(nota3))
                            notas3 = true;
                } while (!notas3);

                //----------------------------------------------------

                Estudiante myEstudiante = new Estudiante();
                myEstudiante.cod = Convert.ToInt32(codigo);
                myEstudiante.nom = nombre;
                myEstudiante.email = correo;
                myEstudiante.n1 = Double.Parse(nota1);
                myEstudiante.n2 = Double.Parse(nota2);
                myEstudiante.n3 = Double.Parse(nota3);

                //-----------------------------------------------------
                ListaEstudiantes.Add(myEstudiante);
            }
        }

        static void ListarEstudiantes()
        {
            Double div = 0;
            Double suma = 0;
            Double curso = 0;
            int y = 20;

            Console.WriteLine("----Lista de estudiantes----");


            Console.SetCursorPosition(1, y); Console.Write("Codigo |");
            Console.SetCursorPosition(10, y); Console.Write("Nombre | ");
            Console.SetCursorPosition(30, y); Console.WriteLine("Correo | ");
            Console.SetCursorPosition(65, y); Console.WriteLine("Nota 1 |");
            Console.SetCursorPosition(75, y); Console.WriteLine("Nota 2 | ");
            Console.SetCursorPosition(85, y); Console.WriteLine("Nota 3 | ");
            Console.SetCursorPosition(95, y); Console.WriteLine("Definitiva | ");
            Console.SetCursorPosition(108, y); Console.WriteLine("Observaciones| ");

            foreach (Estudiante itemEstudiantes in ListaEstudiantes)
            {
                y++;
                suma = itemEstudiantes.n1 + itemEstudiantes.n2 + itemEstudiantes.n3;
                div = suma / 3;
                curso = div;

                Console.WriteLine();

                Console.SetCursorPosition(1, y); Console.Write(itemEstudiantes.cod);
                Console.SetCursorPosition(10, y); Console.Write(itemEstudiantes.nom);
                Console.SetCursorPosition(30, y); Console.Write(itemEstudiantes.email);
                Console.SetCursorPosition(65, y); Console.Write(string.Format("{0:0.##}", itemEstudiantes.n1));
                Console.SetCursorPosition(75, y); Console.Write(string.Format("{0:0.##}", itemEstudiantes.n2));
                Console.SetCursorPosition(85, y); Console.Write(string.Format("{0:0.##}", itemEstudiantes.n3));
                Console.SetCursorPosition(95, y); Console.Write(string.Format("{0:0.##}",div));

                if (curso < 3 == true)
                {
                    Console.SetCursorPosition(108, y); Console.WriteLine("Reprobado");
                }

                else
                    if (curso >= 3 == true)
                {
                    Console.SetCursorPosition(108, y); Console.WriteLine("Aprobado");
                }

                Console.SetCursorPosition(108, y); Console.Write(itemEstudiantes.curso);

            }
            Console.WriteLine("\n");
        }

        static void BuscarEstudiantes()
        {
            string codigo;
            bool codigVal = false;
            int y = 20;
           

            Console.Clear();
            Console.WriteLine("----Búsqueda de estudiantes----");

            do
            {
                Console.Write("Digite el codigo del estudiante a buscar: ");
                codigo = Console.ReadLine();
                if (!Validar.Vacio(codigo))
                    if (Validar.Numero(codigo))
                        codigVal = true;
            } while (!codigVal);

            if (Existe(Convert.ToInt32(codigo)))
            {

                Estudiante myEstudiante = ObtenerDatos(Convert.ToInt32(codigo));
                Console.WriteLine();

                Console.SetCursorPosition(1, y); Console.Write("Codigo: " + myEstudiante.cod);
                Console.SetCursorPosition(15, y); Console.Write("Nombre: " + myEstudiante.nom);
                Console.SetCursorPosition(30, y); Console.Write("Correo: " + myEstudiante.email);
                Console.SetCursorPosition(65, y); Console.Write("Nota 1:" + myEstudiante.n1);
                Console.SetCursorPosition(85, y); Console.Write("Nota 2: " + myEstudiante.n2);
                Console.SetCursorPosition(95, y); Console.Write("Nota 3: " + myEstudiante.n3);             
             
            }

            else
             
                Console.WriteLine("El estudiante identificado con codigo " + codigo + " no existe...");

        }

        static bool Existe(int codigo)
        {
            bool aux = false;
            foreach (Estudiante objetoEstudiante in ListaEstudiantes)
            {
                if (objetoEstudiante.cod == codigo)
                    aux = true;
            }
            return aux;
        }

        static Estudiante ObtenerDatos(int codigo)
        {
            foreach (Estudiante objetoEstudiante in ListaEstudiantes)
            {
                if (objetoEstudiante.cod == codigo)
                    return objetoEstudiante;
            }
            return null;
        }

        static void EscribirXml()
        {
            XmlSerializer codificador = new XmlSerializer(typeof(List<Estudiante>));
            TextWriter escribirXml = new StreamWriter("C:/Users/Equipo/OneDrive/Escritorio/ActividadEstudiante/TrabajoFinal.xml");
            codificador.Serialize(escribirXml, ListaEstudiantes);
            escribirXml.Close();
            Console.WriteLine(" Archivo Guardado ---- ");
        }

        static void LeerXml()
        {
            ListaEstudiantes.Clear();
            if (File.Exists("C:/Users/Equipo/OneDrive/Escritorio/ActividadEstudiante/TrabajoFinal.xml")) 
            {
                XmlSerializer codificador = new XmlSerializer(typeof(List<ActividadEstudiante.Estudiante>));
                FileStream leerXml = File.OpenRead("C:/Users/Equipo/OneDrive/Escritorio/ActividadEstudiante/TrabajoFinal.xml");
                ListaEstudiantes = (List<Estudiante>)codificador.Deserialize(leerXml);
                leerXml.Close();
            }
            Console.WriteLine("Archivo Cargado !!!!  ");
        }

       

    }
}
