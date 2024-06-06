using Clase4Modulo2.Domain.Entities;
using Clase4Modulo2.Repository;
using Microsoft.EntityFrameworkCore;

namespace Clase4Modulo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Archivos
            //    //string pathFile = "C:\\Users\\aleja\\Desktop\\CDA CURSO NET\\MODULO 2\\info.txt";
            //    string pathFile = "C:\\Users\\aleja\\Desktop\\CDA CURSO NET\\MODULO 2\\data.csv";
            //    //bool flagExist = File.Exists(pathFile);



            //    //var fileStream = File.Open(pathFile, FileMode.Open);

            //    ////Archivo 
            //    //var file = File.ReadAllLines(pathFile); // Consumir 2gb 

            //    var file = File.ReadAllLines(pathFile);

            //    var lstVenta = new List<Venta>();

            //    for (int i = 0; i < file.Length; i++) 
            //    {

            //        if (i != 0) 
            //        {
            //            //Console.WriteLine( file[i] );

            //            var values = file[i].Split(";");


            //            var newVenta = new Venta() 
            //            {
            //                Impuesto =  int.Parse( values[0] ),
            //                Monto = int.Parse(values[1] ),
            //                Total = int.Parse(values[2] ),

            //            };

            //            lstVenta.Add(newVenta);
            //        }

            //    }

            //    foreach (var vent in lstVenta)
            //    {
            //        Console.WriteLine($"Total: {vent.Total}");
            //    }

            //}
            #endregion

            #region GroupBy

            //var lstPersonas = new List<Persona>()
            //{
            //    new Persona() 
            //    {
            //        Nombre = "Fer",
            //        Sexo = "M"
            //    },
            //    new Persona()
            //    {
            //        Nombre = "Ale",
            //        Sexo = "M"
            //    },
            //    new Persona()
            //    {
            //        Nombre = "Carla",
            //        Sexo = "F"
            //    }
            //};


            //var result = lstPersonas.GroupBy(g =>  new { g.Sexo ,g.Nombre})
            //                        .Select(s => new 
            //                        {
            //                            Sexo = s.Key,
            //                            Total = s.Count(),
            //                            ListaValores = s.ToList()

            //                        }).ToList();

            // Group by SEXO =>  M => 2 registros
            //                    F=> 1 registro 
            // Sexo: M , Count = 2 , ListaValores

            #endregion


            #region EntityFrameworkCore

            //Entity => 

            var optionsBuilder = new DbContextOptionsBuilder<Ejercicio4Modulo2Context>()
                                        .UseSqlServer("Data Source= localhost\\SQL2022; Initial Catalog = Ejercicio4Modulo2; Integrated Security = True");

                

            var context = new Ejercicio4Modulo2Context(optionsBuilder.Options);

            //Eliminar
            // Logica => id, key, value, state => true/false 1 o 0 => Update 
            // Fisica => delete id  

            // Change tracker 
            //var result = context.Parametria.Where(w => w.Id == 1).FirstOrDefault();

            //result.Value = "fecha"; //Update

            //context.SaveChanges();

            //var result = context.Parametria.Where(w => w.Id == 1).FirstOrDefault();

            //context.Parametria.Remove(result); //Fisicamente
            //context.SaveChanges();

            var newParametria = new Parametria()
            {
                 Key = "fecha_proceso",
                 Value = "2023-10-31"
            };
            context.Parametria.Add(newParametria);
            context.SaveChanges();

            #endregion


        }

        //public class Persona 
        //{
        //    public string Nombre { get; set; }
        //    public string Sexo { get; set; }
        //}

        //public class Venta 
        //{
        //    public int Impuesto { get; set; }
        //    public int Monto { get; set; }
        //    public int Total { get; set; }
        //}
    }
}