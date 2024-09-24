using System;

namespace Facturacion
{
    class Program
    {
        static void Main(string[] args)
        {
            Restaurante restaurante = new Restaurante();
            Inventario inventario = new Inventario();

            // Cargar inventario si existe
            inventario.CargarInventario("inventario.csv");

            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\n===== Menú del Programa =====");
                Console.WriteLine("1. Imprimir menú del restaurante");
                Console.WriteLine("2. Agregar nuevo producto al menú");
                Console.WriteLine("3. Agregar producto a una mesa");
                Console.WriteLine("4. Editar productos de una mesa");
                Console.WriteLine("5. Imprimir cuenta de una mesa");
                Console.WriteLine("6. Imprimir factura con impuestos y propina");
                Console.WriteLine("7. Guardar inventario");
                Console.WriteLine("8. Cargar facturas");
                Console.WriteLine("0. Salir");

                string? opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        restaurante.ImprimirMenu();
                        break;

                    case "2":
                        /* Solicita al usuario los datos del nuevo producto y lo agrega al menú */
                        Console.Write("Ingrese el ID del producto: ");
                        int nuevoId = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese el nombre del producto: ");
                        string? nuevoNombre = Console.ReadLine();
                        Console.Write("Ingrese el precio del producto: ");
                        decimal nuevoPrecio = decimal.Parse(Console.ReadLine());
                        restaurante.EditarMenu(nuevoId, nuevoNombre, nuevoPrecio, true);
                        break;

                    case "3":
                        /* Solicita el número de mesa y el ID del producto para agregarlo a la mesa */
                        Console.Write("Ingrese el número de la mesa: ");
                        int numMesaAgregar = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese el ID del producto que desea agregar: ");
                        int idProdutoAgregar = int.Parse(Console.ReadLine());
                        restaurante.AgregarProductoAMesa(numMesaAgregar, idProdutoAgregar);
                        break;

                    case "4":
                        /* Solicita la mesa y el ID del producto para agregar o eliminar en dicha mesa */
                        Console.Write("Ingrese el número de la mesa: ");
                        int numMesaEditar = int.Parse(Console.ReadLine());
                        Console.Write("¿Qué desea hacer? (1-Agregar, 2-Eliminar): ");
                        int opcionEdicion = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese el ID del producto: ");
                        int idProdutoEditar = int.Parse(Console.ReadLine());
                        restaurante.EditarProductosMesa(numMesaEditar, opcionEdicion, idProdutoEditar);
                        break;

                    case "5":
                        /* Solicita el número de mesa e imprime la cuenta de dicha mesa */
                        Console.Write("Ingrese el número de la mesa: ");
                        int numMesaCuenta = int.Parse(Console.ReadLine());
                        restaurante.ImprimirCuentaMesa(numMesaCuenta);
                        break;

                    case "6":
                      /* Solicitar número de mesa e impuestos/propina */
                      Console.Write("Ingrese el número de la mesa: ");
                      int numMesaFactura = int.Parse(Console.ReadLine());

                      /* Solicitar impuesto y propina */
                      Console.Write("Ingrese el impuesto: ");
                      decimal impuesto = decimal.Parse(Console.ReadLine());

                      Console.Write("Ingrese la propina: ");
                      decimal propina = decimal.Parse(Console.ReadLine());

                      restaurante.ImprimirCuentaMesa(numMesaFactura);

                      Mesa? mesaFactura = restaurante.BuscarMesaPorNumero(numMesaFactura);
                      
                      if (mesaFactura != null) 
                          mesaFactura.ImprimirFactura(impuesto, propina);

                      break;

                    case "7":
                       /* Guarda inventario a archivo CSV */
                       inventario.GuardarInventario("inventario.csv");
                       break;

                    case "8":
                       /* Carga facturas desde archivo CSV */
                       var facturasCargadas = restaurante.CargarFacturas("facturas.csv");

                       foreach (var f in facturasCargadas) 
                           f.ImprimirCuenta();  

                       break;

                    case "0":
                       continuar = false;  /* Termina ciclo si se selecciona salir */
                       break;

                    default:
                       /* Manejo de opción inválida */
                       Console.WriteLine("Opción inválida. Inténtelo de nuevo.");  
                       break;
                }
            }
        }
    }  
}
