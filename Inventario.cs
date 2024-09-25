using System;
using System.Collections.Generic;
using System.IO;

namespace Facturacion
{
    // Clase que representa al restaurante.
    public class Restaurante
    {
        private Menu menu;  // Instancia privada de la clase Menu que representa el menú del restaurante.
        private List<Mesa> mesas;  // Lista privada de instancias de la clase Mesa.

        // Constructor de la clase Restaurante.
        public Restaurante()
        {
            menu = new Menu();  // Inicializa el menú.
            mesas = new List<Mesa>();  // Inicializa las mesas.

            // Agrega productos al menú inicial.
            menu.AgregarProducto(new Producto(1, "Hamburguesa", 8.99m), false);
            menu.AgregarProducto(new Producto(2, "Pizza", 12.99m), false);
            menu.AgregarProducto(new Producto(3, "Ensalada", 6.50m), false);
            menu.AgregarProducto(new Producto(4, "Soda", 2.00m), false);

            // Inicializa las mesas numeradas del 1 al 10.
            for (int i = 1; i <= 10; i++)
            {
                Mesa mesa = new Mesa();
                mesa.SetNumero(i);  // Asigna el número a la mesa.
                mesas.Add(mesa);  // Agrega la mesa a la lista de mesas.
            }
        }

        // Método para imprimir el menú del restaurante.
        public void ImprimirMenu() => menu.ImprimirMenu();

        // Método para agregar un producto a una mesa.
        public void AgregarProductoAMesa(int numeroMesa, int idProducto)
        {
            // Busca la mesa por número.
            Mesa? mesa = mesas.Find(m => m.GetNumero() == numeroMesa);
            // Busca el producto por ID en el menú.
            Producto? producto = menu.BuscarProductoPorId(idProducto);

            // Verifica si la mesa y el producto existen.
            if (mesa != null && producto != null)
            {
                mesa.AgregarProducto(producto);  // Agrega el producto a la mesa.
                Console.WriteLine("Producto agregado a la mesa.");
            }
            else
            {
                // Muestra mensajes de error si la mesa o el producto no se encuentran.
                Console.WriteLine(mesa == null ? "Mesa no encontrada." : "Producto no encontrado.");
            }
        }

        // Método para editar productos en una mesa.
        public void EditarProductosMesa(int numeroMesa, int opcion, int idProducto)
        {
            // Busca la mesa por número.
            Mesa? mesa = mesas.Find(m => m.GetNumero() == numeroMesa);

            if (mesa != null)
            {
                // Si la opción es 1, intenta agregar el producto.
                if (opcion == 1)
                {
                    Producto? producto = menu.BuscarProductoPorId(idProducto);
                    if (producto != null)
                    {
                        mesa.AgregarProducto(producto);
                        Console.WriteLine("Producto agregado a la mesa.");
                    }
                    else
                    {
                        Console.WriteLine("Producto no encontrado.");
                    }
                }
                // Si la opción es 2, intenta eliminar el producto de la mesa.
                else if (opcion == 2)
                {
                    mesa.EliminarProducto(idProducto);
                }
            }
            else
            {
                Console.WriteLine("Mesa no encontrada.");
            }
        }

        // Método para editar el menú del restaurante.
        public void EditarMenu(int id, string nombre, decimal precio, bool esNuevoProducto)
        {
            if (esNuevoProducto)
            {
                // Si el producto es nuevo, lo agrega al menú.
                menu.AgregarProducto(new Producto(id, nombre, precio));
            }
            else
            {
                // Si el producto ya existe, lo edita.
                menu.EditarProducto(id, nombre, precio);
            }
        }

        // Método para imprimir la cuenta de una mesa específica.
        public void ImprimirCuentaMesa(int numeroMesa)
        {
            // Busca la mesa por número.
            Mesa? mesa = mesas.Find(m => m.GetNumero() == numeroMesa);
            if (mesa != null)
            {
                mesa.ImprimirCuenta();  // Imprime la cuenta de la mesa.
            }
            else
            {
                Console.WriteLine("Mesa no encontrada.");
            }
        }

        // Método para buscar una mesa por su número.
        public Mesa? BuscarMesaPorNumero(int numero) => mesas.Find(m => m.GetNumero() == numero);

        // Método para cargar facturas desde un archivo CSV.
        public List<Mesa> CargarFacturas(string rutaArchivo)
        {
            // Lista para almacenar las facturas cargadas.
            var facturasCargadas = new List<Mesa>();

            // Verifica si el archivo existe.
            if (File.Exists(rutaArchivo))
            {
                using (var reader = new StreamReader(rutaArchivo))
                {
                    string? line;
                    reader.ReadLine(); // Lee la línea de encabezado y la ignora.

                    // Lee cada línea del archivo.
                    while ((line = reader.ReadLine()) != null)
                    {
                        var values = line.Split(','); // Divide la línea por comas.

                        // Asegura que haya al menos 3 campos: número de mesa, nombre de producto, y precio.
                        if (values.Length >= 3)
                        {
                            int numeroMesa = int.Parse(values[0]);
                            string nombreProducto = values[1];
                            decimal precio = decimal.Parse(values[2]);

                            // Busca la mesa por número o la crea si no existe.
                            Mesa? mesa = facturasCargadas.Find(m => m.GetNumero() == numeroMesa);
                            if (mesa == null)
                            {
                                mesa = new Mesa();
                                mesa.SetNumero(numeroMesa);
                                facturasCargadas.Add(mesa);
                            }

                            // Agrega el producto a la mesa.
                            mesa.AgregarProducto(new Producto(0, nombreProducto, precio)); // ID puede ser ajustado según sea necesario.
                        }
                    }
                }
                Console.WriteLine("Facturas cargadas correctamente.");
            }
            else
            {
                Console.WriteLine("El archivo no existe.");
            }

            return facturasCargadas; // Retorna la lista de mesas con las facturas cargadas.
        }
    }
}
