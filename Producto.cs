namespace Facturacion
{
    public class Producto
    {
        // Propiedades privadas del producto
        private int Id { get; set; } // Identificador único del producto (propiedad privada)
        private string Nombre; // Nombre del producto (campo privado)
        private decimal Precio; // Precio del producto (campo privado)

        // Constructor que inicializa las propiedades del producto
        public Producto(int id, string nombre, decimal precio)
        {
            Id = id; // Asigna el ID del producto
            Nombre = nombre; // Asigna el nombre del producto
            Precio = precio; // Asigna el precio del producto
        }

        // Método para obtener el ID del producto (getter)
        public int GetId() => Id;

        // Método para obtener el nombre del producto (getter)
        public string GetNombre() => Nombre;

        // Método para obtener el precio del producto (getter)
        public decimal GetPrecio() => Precio;

        // Sobrescribe el método ToString() para devolver una representación en cadena del producto
        // Devuelve el ID, nombre y precio del producto formateado en una cadena legible
        public override string ToString() => $"{Id}. {Nombre} - ${Precio}";
    }
}