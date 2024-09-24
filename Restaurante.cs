using System;
using System.Collections.Generic;

namespace Facturacion
{
    public class Restaurante
    {
        private Menu menu; // Instancia de la clase Menu que representa el menú del restaurante
        private List<Mesa> mesas; // Lista de instancias de la clase Mesa, representa todas las mesas en el restaurante

        // Constructor de la clase Restaurante
        public Restaurante()
        {
            // Inicializa el menú y las mesas
            menu = new Menu();
            mesas = new List<Mesa>();

            // Agrega productos iniciales al menú
            menu.AgregarProducto(new Producto(1, "Hamburguesa", 8.99m), false);
            menu.AgregarProducto(new Producto(2, "Pizza", 12.99m), false);
            menu.AgregarProducto(new Producto(3, "Ensalada", 6.50m), false);
            menu.AgregarProducto(new Producto(4, "Soda", 2.00m), false);

            // Inicializa las mesas numeradas del 1 al 10
            for (int i = 1; i <= 10; i++)
            {
                Mesa mesa = new Mesa();
                mesa.SetNumero(i); // Establece el número de la mesa
                mesas.Add(mesa); // Agrega la mesa a la lista de mesas
            }
        }

        // Método para imprimir el menú del restaurante
        public void ImprimirMenu() => menu.ImprimirMenu();

        // Método para agregar un producto a una mesa específica
        public void AgregarProductoAMesa(int numeroMesa, int idProducto)
        {
            // Busca la mesa por su número
            Mesa? mesa = mesas.Find(m => m.GetNumero() == numeroMesa);
            // Busca el producto por su ID en el menú
            Producto? producto = menu.BuscarProductoPorId(idProducto);

            if (mesa != null && producto != null)
            {
                // Si se encuentran tanto la mesa como el producto, agrega el producto a la mesa
                mesa.AgregarProducto(producto);
                Console.WriteLine("Producto agregado a la mesa.");
            }
            else
            {
                // Muestra un mensaje de error si no se encuentra la mesa o el producto
                Console.WriteLine(mesa == null ? "Mesa no encontrada." : "Producto no encontrado.");
            }
        }

        // Método para editar los productos en una mesa
        public void EditarProductosMesa(int numeroMesa, int opcion, int idProducto)
        {
            // Busca la mesa por su número
            Mesa? mesa = mesas.Find(m => m.GetNumero() == numeroMesa);
            if (mesa != null)
            {
                // Si la opción es 1, agrega el producto a la mesa
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
                // Si la opción es 2, elimina el producto de la mesa
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

        // Método para agregar o editar un producto en el menú
        public void EditarMenu(int id, string nombre, decimal precio, bool esNuevoProducto)
        {
            if (esNuevoProducto)
            {
                // Si es un nuevo producto, lo agrega al menú
                menu.AgregarProducto(new Producto(id, nombre, precio));
            }
            else
            {
                // Si es un producto existente, lo edita en el menú
                menu.EditarProducto(id, nombre, precio);
            }
        }

        // Método para imprimir la cuenta de una mesa específica
        public void ImprimirCuentaMesa(int numeroMesa)
        {
            // Busca la mesa por su número
            Mesa? mesa = mesas.Find(m => m.GetNumero() == numeroMesa);
            if (mesa != null)
            {
                // Imprime la cuenta de la mesa
                mesa.ImprimirCuenta();
            }
            else
            {
                Console.WriteLine("Mesa no encontrada.");
            }
        }

        // Método para buscar un producto en el menú por su ID
        public Producto? BuscarProductoPorId(int id) => menu.BuscarProductoPorId(id);
    }
}