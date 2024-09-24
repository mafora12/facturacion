using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

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
               /* Aquí puedes implementar lógica adicional si es necesario. */
           }
           else 
           {
               Console.WriteLine("Producto no encontrado en el inventario."); 
           }
       }

       // Método público para guardar inventario a un archivo JSON.
       public void GuardarInventario(string rutaArchivo)
       {
           var json = JsonSerializer.Serialize(productos.Values); 
           File.WriteAllText(rutaArchivo, json); 
       }

       // Método público para cargar inventario desde un archivo JSON.
       public void CargarInventario(string rutaArchivo)
       {
           if (File.Exists(rutaArchivo)) 
           {
               var json = File.ReadAllText(rutaArchivo);
               var productosCargados = JsonSerializer.Deserialize<List<Producto>>(json); 

               foreach (var producto in productosCargados) 
               {
                   AgregarProducto(producto); 
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
