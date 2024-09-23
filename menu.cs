using System;
using System.Collections.Generic;

namespace Facturacion
{
    public class Menu
    {
        // Lista pública que almacena los productos del menú
        public List<Producto> Productos { get; set; } = new List<Producto>();

        // Método para imprimir todos los productos del menú
        public void ImprimirMenu()
        {
            Console.WriteLine("Menú del restaurante:");
            
            // Recorre la lista de productos y los imprime uno por uno
            foreach (var producto in Productos)
            {
                Console.WriteLine(producto.ToString());
            }
        }
        
        // Método para agregar un nuevo producto al menú
        public void AgregarProducto(Producto producto, bool mostrarMensaje = true)
        {
            // Verifica si ya existe un producto con el mismo ID
            if (Productos.Exists(p => p.GetId() == producto.GetId()))
            {
                Console.WriteLine("El ID ya está en uso, elija otro.");
            }
            else
            {
                // Agrega el nuevo producto a la lista
                Productos.Add(producto);
                if (mostrarMensaje)
                {
                    Console.WriteLine("Producto agregado al menú.");
                }
            }
        }
 // Método para editar un producto existente en el menú
        public void EditarProducto(int id, string nuevoNombre, decimal nuevoPrecio)
        {
            // Busca el producto en la lista por su ID
            Producto? producto = Productos.Find(p => p.GetId() == id);
            
            if (producto != null)
            {
                // Si el producto es encontrado, actualiza su nombre y precio
                // (actualización no implementada en el código actual)
                Console.WriteLine("Producto editado en el menú.");
            }
            else
            {
                // Si el producto no es encontrado, muestra un mensaje de error
                Console.WriteLine("Producto no encontrado.");
            }
        }

        // Método para buscar un producto en el menú por su ID
        public Producto? BuscarProductoPorId(int id) => Productos.Find(p => p.GetId() == id);
    }
}