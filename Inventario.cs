using System;
using System.Collections.Generic;
using System.IO;

namespace Facturacion
{
    // Clase que representa el inventario del restaurante.
    public class Inventario
    {
        private Dictionary<int, Producto> productos = new Dictionary<int, Producto>();

        // Método público para agregar un nuevo producto al inventario.
        public void AgregarProducto(Producto producto)
        {
            if (!productos.ContainsKey(producto.Id))
            {
                productos[producto.Id] = producto;
                Console.WriteLine("Producto agregado al inventario.");
            }
            else
            {
                Console.WriteLine("El producto ya existe en el inventario.");
            }
        }

        // Método público para vender un producto específico.
        public void VenderProducto(int idProducto, int cantidad)
        {
            if (productos.ContainsKey(idProducto))
            {
                Console.WriteLine($"Se vendió {cantidad} de {productos[idProducto].Nombre}.");
                // Aquí puedes implementar lógica adicional si es necesario.
            }
            else
            {
                Console.WriteLine("Producto no encontrado en el inventario.");
            }
        }

        // Método público para guardar inventario a un archivo CSV.
        public void GuardarInventario(string rutaArchivo)
        {
            using (var writer = new StreamWriter(rutaArchivo))
            {
                writer.WriteLine("Id,Nombre,Precio"); // Encabezados del CSV
                foreach (var producto in productos.Values)
                {
                    writer.WriteLine($"{producto.Id},{producto.Nombre},{producto.Precio}"); // Escribe cada producto en una línea
                }
            }
            Console.WriteLine("Inventario guardado correctamente.");
        }

        // Método público para cargar inventario desde un archivo CSV.
        public void CargarInventario(string rutaArchivo)
        {
            if (File.Exists(rutaArchivo))
            {
                using (var reader = new StreamReader(rutaArchivo))
                {
                    string line;
                    reader.ReadLine(); // Lee la línea de encabezado y la ignora
                    while ((line = reader.ReadLine()) != null)
                    {
                        var values = line.Split(','); // Divide la línea por comas
                        if (values.Length == 3) // Asegura que hay tres valores
                        {
                            int id = int.Parse(values[0]);
                            string nombre = values[1];
                            decimal precio = decimal.Parse(values[2]);
                            AgregarProducto(new Producto(id, nombre, precio)); // Agrega el producto al inventario
                        }
                    }
                }
                Console.WriteLine("Inventario cargado correctamente.");
            }
            else
            {
                Console.WriteLine("El archivo no existe.");
            }
        }
    }
}