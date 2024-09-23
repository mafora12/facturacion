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
