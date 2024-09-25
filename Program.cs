using System;

namespace Facturacion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instancia del restaurante y del inventario
            Restaurante restaurante = new Restaurante();
            Inventario inventario = new Inventario();

            // Intentar cargar el inventario desde un archivo si existe
            inventario.CargarInventario(@"C:\Users\MARIANA\Downloads\facturas.csv");

            // Variable para controlar si el ciclo del menú sigue ejecutándose
            bool continuar = true;

            // Bucle principal del programa para interactuar con el menú
            while (continuar)
            {
                // Muestra el menú de opciones en la consola
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

                // Leer la opción seleccionada por el usuario
                string? opcion = Console.ReadLine();

                // Estructura switch para manejar las opciones del menú
                switch (opcion)
                {
                    case "1":
                        // Opción 1: Imprimir el menú del restaurante
                        restaurante.ImprimirMenu();
                        break;

                    case "2":
                        // Opción 2: Agregar un nuevo producto al menú
                        Console.Write("Ingrese el ID del producto: ");
                        // Validar que el ID ingresado sea un número entero
                        if (int.TryParse(Console.ReadLine(), out int nuevoId))
                        {
                            Console.Write("Ingrese el nombre del producto: ");
                            string? nuevoNombre = Console.ReadLine();
                            // Validar que el nombre no esté vacío
                            if (!string.IsNullOrEmpty(nuevoNombre))
                            {
                                Console.Write("Ingrese el precio del producto: ");
                                // Validar que el precio ingresado sea un número decimal
                                if (decimal.TryParse(Console.ReadLine(), out decimal nuevoPrecio))
                                {
                                    // Agregar el producto al menú
                                    restaurante.EditarMenu(nuevoId, nuevoNombre, nuevoPrecio, true);
                                }
                                else
                                {
                                    // Mensaje de error si el precio no es válido
                                    Console.WriteLine("Error: El precio ingresado no es válido.");
                                }
                            }
                            else
                            {
                                // Mensaje de error si el nombre está vacío
                                Console.WriteLine("Error: El nombre del producto no puede estar vacío.");
                            }
                        }
                        else
                        {
                            // Mensaje de error si el ID no es válido
                            Console.WriteLine("Error: El ID ingresado no es válido.");
                        }
                        break;

                    case "3":
                        // Opción 3: Agregar un producto a una mesa
                        Console.Write("Ingrese el número de la mesa: ");
                        // Validar que el número de mesa sea un número entero
                        if (int.TryParse(Console.ReadLine(), out int numMesaAgregar))
                        {
                            Console.Write("Ingrese el ID del producto que desea agregar: ");
                            // Validar que el ID del producto sea un número entero
                            if (int.TryParse(Console.ReadLine(), out int idProductoAgregar))
                            {
                                // Agregar el producto a la mesa
                                restaurante.AgregarProductoAMesa(numMesaAgregar, idProductoAgregar);
                            }
                            else
                            {
                                // Mensaje de error si el ID del producto no es válido
                                Console.WriteLine("Error: El ID del producto no es válido.");
                            }
                        }
                        else
                        {
                            // Mensaje de error si el número de mesa no es válido
                            Console.WriteLine("Error: El número de mesa no es válido.");
                        }
                        break;

                    case "4":
                        // Opción 4: Editar productos de una mesa
                        Console.Write("Ingrese el número de la mesa: ");
                        // Validar que el número de mesa sea un número entero
                        if (int.TryParse(Console.ReadLine(), out int numMesaEditar))
                        {
                            Console.Write("¿Qué desea hacer? (1-Agregar, 2-Eliminar): ");
                            // Validar la opción de edición
                            if (int.TryParse(Console.ReadLine(), out int opcionEdicion) && (opcionEdicion == 1 || opcionEdicion == 2))
                            {
                                Console.Write("Ingrese el ID del producto: ");
                                // Validar que el ID del producto sea un número entero
                                if (int.TryParse(Console.ReadLine(), out int idProductoEditar))
                                {
                                    // Editar los productos en la mesa
                                    restaurante.EditarProductosMesa(numMesaEditar, opcionEdicion, idProductoEditar);
                                }
                                else
                                {
                                    // Mensaje de error si el ID del producto no es válido
                                    Console.WriteLine("Error: El ID del producto no es válido.");
                                }
                            }
                            else
                            {
                                // Mensaje de error si la opción no es válida
                                Console.WriteLine("Error: Opción inválida.");
                            }
                        }
                        else
                        {
                            // Mensaje de error si el número de mesa no es válido
                            Console.WriteLine("Error: El número de mesa no es válido.");
                        }
                        break;

                    case "5":
                        // Opción 5: Imprimir la cuenta de una mesa
                        Console.Write("Ingrese el número de la mesa: ");
                        // Validar que el número de mesa sea un número entero
                        if (int.TryParse(Console.ReadLine(), out int numMesaCuenta))
                        {
                            // Imprimir la cuenta de la mesa
                            restaurante.ImprimirCuentaMesa(numMesaCuenta);
                        }
                        else
                        {
                            // Mensaje de error si el número de mesa no es válido
                            Console.WriteLine("Error: El número de mesa no es válido.");
                        }
                        break;

                    case "6":
                        // Opción 6: Imprimir factura con impuestos y propina
                        Console.Write("Ingrese el número de la mesa: ");
                        // Validar que el número de mesa sea un número entero
                        if (int.TryParse(Console.ReadLine(), out int numMesaFactura))
                        {
                            Console.Write("Ingrese el impuesto: ");
                            // Validar que el impuesto sea un número decimal
                            if (decimal.TryParse(Console.ReadLine(), out decimal impuesto))
                            {
                                Console.Write("Ingrese la propina: ");
                                // Validar que la propina sea un número decimal
                                if (decimal.TryParse(Console.ReadLine(), out decimal propina))
                                {
                                    // Imprimir la cuenta de la mesa
                                    restaurante.ImprimirCuentaMesa(numMesaFactura);
                                    // Buscar la mesa correspondiente para generar la factura
                                    Mesa? mesaFactura = restaurante.BuscarMesaPorNumero(numMesaFactura);
                                    // Si la mesa existe, imprimir la factura con impuestos y propina
                                    if (mesaFactura != null)
                                    {
                                        mesaFactura.ImprimirFactura(impuesto, propina);
                                    }
                                }
                                else
                                {
                                    // Mensaje de error si la propina no es válida
                                    Console.WriteLine("Error: La propina ingresada no es válida.");
                                }
                            }
                            else
                            {
                                // Mensaje de error si el impuesto no es válido
                                Console.WriteLine("Error: El impuesto ingresado no es válido.");
                            }
                        }
                        else
                        {
                            // Mensaje de error si el número de mesa no es válido
                            Console.WriteLine("Error: El número de mesa no es válido.");
                        }
                        break;

                    case "7":
                        // Opción 7: Guardar el inventario actual en un archivo CSV
                        inventario.GuardarInventario("inventario.csv");
                        break;

                    case "8":
                        // Opción 8: Cargar facturas desde un archivo CSV
                        var facturasCargadas = restaurante.CargarFacturas("facturas.csv");
                        // Imprimir todas las facturas cargadas
                        foreach (var f in facturasCargadas)
                        {
                            f.ImprimirCuenta();
                        }
                        break;

                    case "0":
                        // Opción 0: Salir del programa
                        continuar = false;
                        break;

                    default:
                        // Mensaje en caso de que se ingrese una opción inválida
                        Console.WriteLine("Opción inválida. Inténtelo de nuevo.");
                        break;
                }
            }
        }
    }
}
