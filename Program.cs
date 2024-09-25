using System;
using System.Collections.Generic;
using System.IO;

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
            inventario.CargarInventario("inventario.csv");

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
                        restaurante.ImprimirMenu();
                        break;

                    case "2":
                        AgregarNuevoProducto(restaurante);
                        break;

                    case "3":
                        AgregarProductoMesa(restaurante);
                        break;

                    case "4":
                        EditarProductosMesa(restaurante);
                        break;

                    case "5":
                        ImprimirCuentaMesa(restaurante);
                        break;

                    case "6":
                        ImprimirFacturaConImpuestos(restaurante);
                        break;

                    case "7":
                        inventario.GuardarInventario(@"C:\Users\MARIANA\Desktop\facturacion-main");
                        break;

                    case "8":
                        var facturasCargadas = restaurante.CargarFacturas(@"C:\Users\MARIANA\Desktop\facturacion-main");
                        foreach (var f in facturasCargadas)
                        {
                            f.ImprimirCuenta();
                        }
                        break;

                    case "0":
                        // Guardar el inventario antes de salir
                        inventario.GuardarInventario(@"C:\Users\MARIANA\Desktop\facturacion-main");
                        continuar = false;
                        break;

                    default:
                        Console.WriteLine("Opción inválida. Inténtelo de nuevo.");
                        break;
                }
            }
        }

        // Método para agregar un nuevo producto al menú
        static void AgregarNuevoProducto(Restaurante restaurante)
        {
            Console.Write("Ingrese el ID del producto: ");
            if (int.TryParse(Console.ReadLine(), out int nuevoId))
            {
                Console.Write("Ingrese el nombre del producto: ");
                string? nuevoNombre = Console.ReadLine();
                if (!string.IsNullOrEmpty(nuevoNombre))
                {
                    Console.Write("Ingrese el precio del producto: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal nuevoPrecio))
                    {
                        restaurante.EditarMenu(nuevoId, nuevoNombre, nuevoPrecio, true);
                    }
                    else
                    {
                        Console.WriteLine("Error: El precio ingresado no es válido.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: El nombre del producto no puede estar vacío.");
                }
            }
            else
            {
                Console.WriteLine("Error: El ID ingresado no es válido.");
            }
        }

        // Método para agregar un producto a una mesa
        static void AgregarProductoMesa(Restaurante restaurante)
        {
            Console.Write("Ingrese el número de la mesa: ");
            if (int.TryParse(Console.ReadLine(), out int numMesaAgregar))
            {
                Console.Write("Ingrese el ID del producto que desea agregar: ");
                if (int.TryParse(Console.ReadLine(), out int idProductoAgregar))
                {
                    restaurante.AgregarProductoAMesa(numMesaAgregar, idProductoAgregar);
                }
                else
                {
                    Console.WriteLine("Error: El ID del producto no es válido.");
                }
            }
            else
            {
                Console.WriteLine("Error: El número de mesa no es válido.");
            }
        }

        // Método para editar productos de una mesa
        static void EditarProductosMesa(Restaurante restaurante)
        {
            Console.Write("Ingrese el número de la mesa: ");
            if (int.TryParse(Console.ReadLine(), out int numMesaEditar))
            {
                Console.Write("¿Qué desea hacer? (1-Agregar, 2-Eliminar): ");
                if (int.TryParse(Console.ReadLine(), out int opcionEdicion) && (opcionEdicion == 1 || opcionEdicion == 2))
                {
                    Console.Write("Ingrese el ID del producto: ");
                    if (int.TryParse(Console.ReadLine(), out int idProductoEditar))
                    {
                        restaurante.EditarProductosMesa(numMesaEditar, opcionEdicion, idProductoEditar);
                    }
                    else
                    {
                        Console.WriteLine("Error: El ID del producto no es válido.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: Opción inválida.");
                }
            }
            else
            {
                Console.WriteLine("Error: El número de mesa no es válido.");
            }
        }

        // Método para imprimir la cuenta de una mesa
        static void ImprimirCuentaMesa(Restaurante restaurante)
        {
            Console.Write("Ingrese el número de la mesa: ");
            if (int.TryParse(Console.ReadLine(), out int numMesaCuenta))
            {
                restaurante.ImprimirCuentaMesa(numMesaCuenta);
            }
            else
            {
                Console.WriteLine("Error: El número de mesa no es válido.");
            }
        }

        // Método para imprimir la factura con impuestos y propina
        static void ImprimirFacturaConImpuestos(Restaurante restaurante)
        {
            Console.Write("Ingrese el número de la mesa: ");
            if (int.TryParse(Console.ReadLine(), out int numMesaFactura))
            {
                Console.Write("Ingrese el impuesto: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal impuesto))
                {
                    Console.Write("Ingrese la propina: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal propina))
                    {
                        restaurante.ImprimirCuentaMesa(numMesaFactura);
                        Mesa? mesaFactura = restaurante.BuscarMesaPorNumero(numMesaFactura);
                        if (mesaFactura != null)
                        {
                            mesaFactura.ImprimirFactura(impuesto, propina);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: La propina ingresada no es válida.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: El impuesto ingresado no es válido.");
                }
            }
            else
            {
                Console.WriteLine("Error: El número de mesa no es válido.");
            }
        }
    }
}
