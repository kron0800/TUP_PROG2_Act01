using Act_Practica_01.Data;
using Act_Practica_01.Services;
using Ej1_5_Facturacion.Domain;

namespace Act_Practica_01
{
    internal class Program
    {
        private static FacturaService facturaService;

        //public static void MainMenu()
        //{
        //    Console.WriteLine("Gestor de facturas v1\n");
        //    Console.WriteLine("Ingrese la opcion deseada:\n\n");

        //    Console.WriteLine("1 - Listar facturas");
        //    Console.WriteLine("2 - Nueva factura");
        //    Console.WriteLine("3 - Modificar una factura");
        //    Console.WriteLine("4 - Eliminar una factura");
        //    Console.WriteLine("5 - Salir\n\n");
        //    Console.Write("     > ");

        //    int.TryParse(Console.ReadLine(), out int option);

        //    switch (option)
        //    {
        //        case 0:
        //            Console.WriteLine("Opción no válida. Intente nuevamente.");
        //            break;

        //        case 1:
        //            ListAllFacturas();
        //            break;

        //        case 2:
        //            CreateNewFactura();
        //            break;

        //        case 3:
        //            Console.WriteLine("Modificar una factura");
        //            break;

        //        case 4:
        //            Console.WriteLine("Eliminar una factura");
        //            break;

        //        default:
        //            Console.WriteLine("Opción no reconocida.");
        //            break;
        //    }
        //}

        //private static void CreateNewFactura()
        //{
        //    Console.Clear();

        //    Console.Write("Ingrese el numero de factura > ");
        //    int.TryParse(Console.ReadLine(), out int nroFactura);

        //    Console.Write("Ingrese la fecha de la factura en formato dd/MM/YYYY> ");
        //    int.TryParse(Console.ReadLine(), out int nroFactura);

        //}

        //private static void ListAllFacturas()
        //{
        //    List<Factura> facturas = facturaService.GetAllFacturas();
        //    foreach (var f in facturas)
        //    {
        //        Console.WriteLine(f);
        //    }
        //}

        static void Main(string[] args)
        {
            facturaService = new FacturaService();
            //MainMenu();

            Factura factura = new Factura
            {
                NroFactura = 12345,
                Fecha = DateTime.Now,
                Cliente = "Negra gomosa",
                FormaPago = new FormaPago { IdFormaPago = 1 } 
            };

            bool ok = facturaService.SaveFactura(factura);
            Console.WriteLine(ok ? "Factura creada con exito" : "No se pudo crear la factura");
        }
    }
}
