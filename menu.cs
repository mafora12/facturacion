using System;
using System.Collections.Generic;

namespace Facturacion
{
    // Clase que representa el menú del restaurante
    public class Menu
    {
        private List<Producto> productos = new List<Producto>(); // Lista privada que almacena los productos del menú

        // Método público para imprimir todos los productos del menú
        public void ImprimirMenu()
        {
            Console.WriteLine("Menú del restaurante:");
            
            foreach (var producto in productos) 
            {
                Console.WriteLine(producto.ToString()); // Imprime cada producto en el menú
            }
        }
        
        // Método público para agregar un nuevo producto al menú
        public void AgregarProducto(Producto producto, bool mostrarMensaje = true)
        {
            if (productos.Exists(p => p.Id == producto.Id)) 
            {
                Console.WriteLine("El ID ya está en uso, elija otro."); // Mensaje si ya existe un ID igual.
         }
            else 
            {
                productos.Add(producto); 
                if (mostrarMensaje)
                {
                    Console.WriteLine("Producto agregado al menú."); 
                }
            }
        }

       // Método público para editar un producto existente en el menú
       public void EditarProducto(int id, string nuevoNombre, decimal nuevoPrecio)
       {
         Producto? producto = productos.Find(p => p.Id == id); // Busca el producto por su ID

           if (producto != null) 
           {
               producto.Nombre = nuevoNombre;  // Actualiza nombre y precio del producto.
               producto.Precio = nuevoPrecio;
               Console.WriteLine("Producto editado en el menú."); 
           }
           else 
           {
               Console.WriteLine("Producto no encontrado."); 
           }
       }

       // Método público para buscar un producto en el menú por su ID
       public Producto? BuscarProductoPorId(int id) => productos.Find(p => p.Id == id); 
   }
}