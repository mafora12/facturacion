using System;
using System.Collections.Generic;

namespace Facturacion
{
    // Clase que representa una mesa en el restaurante
    public class Mesa
    {
        private int numero; // Número de la mesa (atributo privado)
        private List<Producto> productos = new List<Producto>(); // Lista de productos en la mesa

        // Método público para obtener el número de la mesa
        public int GetNumero() => numero;

        // Método público para establecer el número de la mesa
        public void SetNumero(int numero) => this.numero = numero;

        // Método público para agregar un producto a la lista de productos de la mesa
        public void AgregarProducto(Producto producto) => productos.Add(producto);

        // Método público para eliminar un producto de la lista de productos de la mesa por su ID
        public void EliminarProducto(int idProducto)
        {
            Producto? producto = productos.Find(p => p.Id == idProducto); // Busca el producto por ID
           if (producto != null) // Si se encuentra el producto
            {
                productos.Remove(producto); // Elimina el producto de la lista
                Console.WriteLine("Producto eliminado de la mesa.");
            }
            else 
            {
                Console.WriteLine("Producto no encontrado en la mesa."); // Mensaje si no se encuentra el producto
            }
        }

        // Método público para calcular el total de los precios de los productos en la mesa
        public decimal ObtenerTotal()
        {
            decimal total = 0; // Inicializa el total en 0
            
            foreach (var producto in productos) // Recorre cada producto en la lista
            {
                total += producto.Precio; // Suma su precio al total
            }
            
            return total; // Devuelve el total calculado
        }

        // Método público para imprimir la cuenta de la mesa
        public void ImprimirCuenta()
      {
            Console.WriteLine($"Cuenta para la mesa {numero}:"); // Imprime encabezado con número de mesa
            
            foreach (var producto in productos) // Recorre la lista de productos y los imprime
            {
                Console.WriteLine(producto.ToString());
            }
            
            Console.WriteLine($"Total: ${ObtenerTotal()}"); // Imprime total final de la cuenta
        }

        // Método público para imprimir factura con impuestos y propina
        public void ImprimirFactura(decimal impuesto, decimal propina)
        {
            Console.WriteLine($"Factura para la mesa {numero}:"); // Imprime encabezado con número de mesa
            
            foreach (var producto in productos) // Recorre y muestra cada producto en la factura
            {
                Console.WriteLine(producto.ToString());
            }
           decimal total = ObtenerTotal() + impuesto + propina; // Calcula total con impuestos y propina
            
            Console.WriteLine($"Impuesto: ${impuesto}"); 
            Console.WriteLine($"Propina: ${propina}");
            Console.WriteLine($"Total: ${total}"); // Imprime total final incluyendo impuestos y propina
        }
    }
}