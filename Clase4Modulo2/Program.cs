using Clase4Modulo2.Domain.Entities;
using Clase4Modulo2.Repository;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clase4Modulo2
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string path = $"{AppDomain.CurrentDomain.BaseDirectory}\\data.txt";

            var optionBuilder = new DbContextOptionsBuilder<Ejercicio4Modulo2Context>()
           .UseSqlServer("Data Source=DESKTOP-KICGD37;Initial Catalog=Ejercicio4Modulo2;Integrated Security=True;Trust Server Certificate=True");

            var contexto = new Ejercicio4Modulo2Context(optionBuilder.Options);

            var file = File.ReadAllLines(path);
            String parametria = (contexto.Parametria.Select(para => para.Value).Single());
            for (int i = 0; i < file.Length; i++)
            {
                String archivo = file[i];
                String fecha = archivo.Substring(0, 10);
                String codVendedor = archivo.Substring(10, 3);
                decimal ventaVendedor = decimal.Parse(archivo.Substring(13, 11));
                String ventaEmpresa = archivo.Substring(24, 1);


                string validacion = validarVenta(parametria, fecha, codVendedor, ventaEmpresa);
                if (validacion.Equals("OK"))
                {
                    VentasMensuales venta = new VentasMensuales(DateTime.Parse(fecha), codVendedor, ventaVendedor, ventaEmpresa);
                    contexto.VentasMensuales.Add(venta);
                }


                else contexto.Rechazos.Add(new Rechazos(validacion, archivo));

            }
            // pregunto si hay registros en la base
            if (contexto.VentasMensuales.Count() == 0 && contexto.Rechazos.Count() == 0)  contexto.SaveChanges();
           
            Console.WriteLine("*** Venta mayor a 100000 ***");
            foreach (var vendedor in contexto.VentasMensuales.Where(vendedor => vendedor.Venta > 100000))
            {
               vendedor.mostrarVenta();
            };
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("*** Venta igual o menor a 100000 ***");
            foreach (var vendedor in contexto.VentasMensuales.Where(vendedor => vendedor.Venta <= 100000))
            {
                vendedor.mostrarVenta();
            };

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("*** Vendedores con ventas a empresas grandes ***");
            foreach (var vendedor in contexto.VentasMensuales.Where(vendedor => vendedor.VentaEmpresaGrande))
            {
                Console.WriteLine("CodVendedor: " + vendedor.CodVendedor); 
            };

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("*** Rechazos ***");
            foreach (var rechazo in contexto.Rechazos.Select(vendedor => vendedor))
            {
                Console.WriteLine(rechazo.ToString());
            };
        }

        private static string validarVenta(String parametria, String fechaArchivo,
            string codVend, string ventaEmpresaGrande)
        { 
            StringBuilder errores = new StringBuilder(); 
 
            if (!parametria.Equals(fechaArchivo))
              errores.Append("La fecha del informe debe ser igual a la fecha que se inserto en la tabla de parametria. ");
            
            if (codVend.Contains(" "))
              errores.Append("Siempre debe venir un codigo de vendedor. ");
              
            if (!ventaEmpresaGrande.Equals("S") && !ventaEmpresaGrande.Equals("N"))
              errores.Append("El atributo VentaEmpresaGrande solo puede ser 'S' o 'N'.");

            else if (parametria.Equals(fechaArchivo) && !codVend.Contains(" ") &&
                (ventaEmpresaGrande.Equals("S") || ventaEmpresaGrande.Equals("N")) )
            {
                errores = new StringBuilder("OK");

            }
            return errores.ToString();

        }



       

       
    }
}