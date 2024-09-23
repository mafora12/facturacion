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