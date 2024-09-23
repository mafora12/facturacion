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
