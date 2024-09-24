using System;

namespace Facturacion
{
    // Clase que representa un producto en el menú
    public class Producto
    {
        // Atributos privados del producto
        private int id; // Identificador único del producto
        private string nombre; // Nombre del producto
        private decimal precio; // Precio del producto

        // Propiedades públicas para acceder a los atributos privados
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public decimal Precio { get => precio; set => precio = value; }

        // Constructor que inicializa las propiedades del producto
        public Producto(int id, string nombre, decimal precio)
        {
            this.id = id; // Asigna el ID del producto
            this.nombre = nombre; // Asigna el nombre del producto
            this.precio = precio; // Asigna el precio del producto
        }

        // Sobrescribe el método ToString() para devolver una representación en cadena del producto
        public override string ToString() => $"{Id}. {Nombre} - ${Precio}";
    }
}