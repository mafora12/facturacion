using System;
using System.Collections.Generic;

namespace Facturacion
{
    public class Mesa
    {
        // Propiedades privadas de la clase Mesa
        private int Numero { get; set; } // Número de la mesa (propiedad privada)
        private List<Producto> Productos { get; set; } = new List<Producto>(); // Lista de productos en la mesa (inicializada como una lista vacía)

        // Método para obtener el número de la mesa
        public int GetNumero() => Numero;

        // Método para establecer el número de la mesa
        public void SetNumero(int numero) => Numero = numero;

        // Método para agregar un producto a la lista de productos de la mesa
        public void AgregarProducto(Producto producto) => Productos.Add(producto);
  // Método para eliminar un producto de la lista de productos de la mesa por su ID
        public void EliminarProducto(int idProducto)
        {
            // Busca el producto en la lista usando el ID
            Producto? producto = Productos.Find(p => p.GetId() == idProducto);
            
            // Si el producto es encontrado, lo elimina de la lista y muestra un mensaje
            if (producto != null)
            {
                Productos.Remove(producto);
                Console.WriteLine("Producto eliminado de la mesa.");
            }
            else
            {
                // Si el producto no es encontrado, muestra un mensaje de error
                Console.WriteLine("Producto no encontrado en la mesa.");
            }
        }
          // Método para calcular el total de los precios de los productos en la mesa
        public decimal ObtenerTotal()
        {
            decimal total = 0; // Inicializa el total en 0
            
            // Recorre cada producto en la lista y suma su precio al total
            foreach (var producto in Productos)
            {
                total += producto.GetPrecio();
            }
            
            // Devuelve el total calculado
            return total;
        }

        // Método para imprimir la cuenta de la mesa
        public void ImprimirCuenta()
        {
            // Imprime el encabezado con el número de la mesa
            Console.WriteLine($"Cuenta para la mesa {Numero}:");
            
            // Recorre la lista de productos y los imprime
            foreach (var producto in Productos)
            {
                Console.WriteLine(producto.ToString());
            }
            
            // Imprime el total final de la cuenta
            Console.WriteLine($"Total: ${ObtenerTotal()}");
        }
    }
}