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
