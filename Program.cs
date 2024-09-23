using System;

namespace Facturacion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crea una nueva instancia de la clase Restaurante
            Restaurante restaurante = new Restaurante();
            bool continuar = true;
// Ciclo que mantiene el programa en ejecución hasta que el usuario decida salir
            while (continuar)
            {
                // Muestra el menú principal con las opciones disponibles para el usuario
                Console.WriteLine("\n===== Menú del Programa =====");
                Console.WriteLine("1. Imprimir menú del restaurante");
                Console.WriteLine("2. Agregar nuevo producto al menú del restaurante");
                Console.WriteLine("3. Agregar producto a una mesa");
                Console.WriteLine("4. Editar productos de una mesa");
                Console.WriteLine("5. Imprimir cuenta de una mesa");
                Console.WriteLine("6. Buscar producto por ID");
                Console.WriteLine("0. Salir");
                Console.WriteLine("=============================");
                Console.Write("Seleccione una opción: ");
                // Lee la opción ingresada por el usuario
                string? opcion = Console.ReadLine();

                // Estructura switch que ejecuta la lógica según la opción seleccionada
                switch (opcion)
                {
                    case "1":
                        // Imprime el menú del restaurante
                        restaurante.ImprimirMenu();
                        break;

                    case "2":
                        // Solicita al usuario los datos del nuevo producto y lo agrega al menú
                        Console.Write("Ingrese el ID del producto: ");
                        int nuevoId = int.Parse(Console.ReadLine()); // Leer ID del producto
                        Console.Write("Ingrese el nombre del producto: ");
                        string? nuevoNombre = Console.ReadLine(); // Leer nombre del producto
                        Console.Write("Ingrese el precio del producto: ");
                        decimal nuevoPrecio = decimal.Parse(Console.ReadLine()); // Leer precio del producto
                        // Agregar producto al menú del restaurante
                        restaurante.EditarMenu(nuevoId, nuevoNombre, nuevoPrecio, true);
                        break;
                    case "3":
                        // Solicita el número de mesa y el ID del producto para agregarlo a la mesa
                        Console.Write("Ingrese el número de la mesa: ");
                        int numMesaAgregar = int.Parse(Console.ReadLine()); // Leer número de mesa
                        Console.Write("Ingrese el ID del producto que desea agregar: ");
                        int idProductoAgregar = int.Parse(Console.ReadLine()); // Leer ID del producto
                        // Agregar producto a la mesa especificada
                        restaurante.AgregarProductoAMesa(numMesaAgregar, idProductoAgregar);
                        break;

                    case "4":
                        // Solicita la mesa y el producto para agregar o eliminar en dicha mesa
                        Console.Write("Ingrese el número de la mesa: ");
                        int numMesaEditar = int.Parse(Console.ReadLine()); // Leer número de mesa
                        Console.Write("¿Qué desea hacer? (1-Agregar, 2-Eliminar): ");
                        int opcionEdicion = int.Parse(Console.ReadLine()); // Leer opción de edición (Agregar o Eliminar)
                        Console.Write("Ingrese el ID del producto: ");
                        int idProductoEditar = int.Parse(Console.ReadLine()); // Leer ID del producto
                        // Editar productos de la mesa (agregar o eliminar)
                        restaurante.EditarProductosMesa(numMesaEditar, opcionEdicion, idProductoEditar);
                        break;

                    case "5":
                        // Solicita el número de mesa e imprime la cuenta de dicha mesa
                        Console.Write("Ingrese el número de la mesa: ");
                        int numMesaCuenta = int.Parse(Console.ReadLine()); // Leer número de mesa
                        restaurante.ImprimirCuentaMesa(numMesaCuenta); // Imprimir cuenta
                        break;
                    case "6":
                        // Solicita el ID del producto y busca dicho producto en el menú
                        Console.Write("Ingrese el ID del producto: ");
                        int idProductoBuscar = int.Parse(Console.ReadLine()); // Leer ID del producto
                        // Buscar el producto por ID
                        Producto? producto = restaurante.BuscarProductoPorId(idProductoBuscar);
                        if (producto != null)
                        {
                            // Si el producto existe, se imprime su información
                            Console.WriteLine(producto.ToString());
                        }
                        else
                        {
                            // Si el producto no se encuentra, se informa al usuario
                            Console.WriteLine("Producto no encontrado.");
                        }
                        break;

                    case "0":
                        // Si se elige la opción de salir, se termina el ciclo
                        continuar = false;
                        break;

                    default:
                        // Manejo de opción inválida
                        Console.WriteLine("Opción inválida. Inténtelo de nuevo.");
                        break;
                }
            }
        }
    }
}
