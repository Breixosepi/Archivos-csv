using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf
{
    class Program
    {
        static void Main(string[] args)
        {
            EscribirCSV("Giusepi", "Russo", "Estudiante", "Venezuela");
            LeerCSV();
        }
            //Funcion para Escribir un archivo CSV a traves de un directorio
        static void EscribirCSV(String nombre, String apellido, String ocupacion, String pais) 
        {
            //Estandar de la ruta = @"ruta_DEL_ARCHIVO\NOMBRE_ARCHIVO.csv";
            String route = @"C:\Users\Usuario\Desktop\gabo things\yo\Datos.csv";
            String separator = ","; //Generalmente se usa la coma o punto y coma 
            StringBuilder salida = new StringBuilder(); /* https://learn.microsoft.com/es-es/dotnet/standard/base-types/stringbuilder */

            string datos = nombre + "," + apellido + "," + ocupacion + "," + pais;
            List < String > lista = new List < string > { datos };

            for (int i = 0; i < lista.Count; i++)
                salida.AppendLine(string.Join(separator, lista[i]));

            //File.WriteAllText(route, salida.ToString());

            // AÑADE MAS LINEAS AL ARCHIVO CSV
            File.AppendAllText(route, salida.ToString());
        }

        static void LeerCSV()
        {
            var reader = new StreamReader(File.OpenRead(@"C:\Users\Usuario\Desktop\gabo things\yo\Datos.csv"));
            List<String> lista = new List<string>();
            while (!reader.EndOfStream)
            {
                var linea = reader.ReadLine();
                var valores = linea.Split(',');
                for (int i = 0; i < valores.Length; i++)
                {
                    if ((i % 4) == 0)
                    {
                        Console.Write($"Nombre {valores[i]}, Apellido {valores[i + 1]}, ocupacion {valores[i + 2]}, Pais {valores[i + 3]} ");
                    }
                    else
                    {
                        Console.WriteLine();
                    }

                }
            }
        }
    }
}
