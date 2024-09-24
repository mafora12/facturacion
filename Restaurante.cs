using System;
using System.Collections.Generic;
using System.IO;

namespace Facturacion
{
    // Clase que representa al restaurante.
    public class Restaurante
    {
        private Menu menu;  // Instancia privada de la clase Menu que representa el menú del restaurante.
        private List<Mesa> mesas;  // Lista privada de instancias de la clase Mesa.

        public Restaurante()
        {
            menu = new Menu();  // Inicializa el menú.
            mesas = new List<Mesa>();  // Inicializa las mesas.

            menu.AgregarProducto(new Producto(1, "Hamburguesa", 8.99m), false);
            menu.AgregarProducto(new Producto(2, "Pizza", 12.99m), false);
            menu.AgregarProducto(new Producto(3, "Ensalada", 6.50m), false);
            menu.AgregarProducto(new Producto(4, "Soda", 2.00m), false);

            for (int i = 1; i <= 10; i++)  // Inicializa las mesas numeradas del 1 al 10.
            {
                Mesa mesa = new Mesa();
                mesa.SetNumero(i);  
                mesas.Add(mesa);  
            }
        }

        public void ImprimirMenu() => menu.ImprimirMenu();  // Imprime el menú del restaurante.

        public void AgregarProductoAMesa(int numeroMesa, int idProducto)
        {
            Mesa? mesa = mesas.Find(m => m.GetNumero() == numeroMesa);  
            Producto? producto = menu.BuscarProductoPorId(idProducto);  

            if (mesa != null && producto != null)  
            {
                mesa.AgregarProducto(producto);  
                Console.WriteLine("Producto agregado a la mesa.");
            }
            else  
            {
                Console.WriteLine(mesa == null ? "Mesa no encontrada." : "Producto no encontrado.");
            }
        }

        public void EditarProductosMesa(int numeroMesa, int opcion, int idProducto)
        {
            Mesa? mesa = mesas.Find(m => m.GetNumero() == numeroMesa);

            if (mesa != null)  
            {
                if (opcion == 1)  // Opción para agregar un nuevo producto.
                {
                    Producto? producto = menu.BuscarProductoPorId(idProducto);
                    if (producto != null)  
                    {
                        mesa.AgregarProducto(producto);
                        Console.WriteLine("Producto agregado a la mesa.");
                    }
                    else  
                    {
                        Console.WriteLine("Producto no encontrado.");
                    }
                }
                else if (opcion == 2)  // Opción para eliminar un producto existente.
                {
                    mesa.EliminarProducto(idProducto);
                }
            }
            else  
            {
                Console.WriteLine("Mesa no encontrada.");
           }
       }

       public void EditarMenu(int id, string nombre, decimal precio, bool esNuevoProducto)
       {
           if (esNuevoProducto)  
           {   
               menu.AgregarProducto(new Producto(id, nombre, precio));   
           }   
           else   
           {   
               menu.EditarProducto(id, nombre, precio);   
           }   
       }

       public void ImprimirCuentaMesa(int numeroMesa)
       {   
           Mesa? mesa = mesas.Find(m => m.GetNumero() == numeroMesa);   
           if (mesa != null)   
           {   
               mesa.ImprimirCuenta();   
           }   
           else   
           {   
               Console.WriteLine("Mesa no encontrada.");   
           }   
       }

       public Mesa? BuscarMesaPorNumero(int numero) => mesas.Find(m => m.GetNumero() == numero);

       // Método público para cargar facturas desde un archivo CSV
       public List<Mesa> CargarFacturas(string rutaArchivo)
       {
           var facturasCargadas = new List<Mesa>();

           if (File.Exists(rutaArchivo))
           {
               using (var reader = new StreamReader(rutaArchivo))
               {
                   string line;
                   reader.ReadLine(); // Lee la línea de encabezado y la ignora
                   while ((line = reader.ReadLine()) != null)
                   {
                       var values = line.Split(','); // Divide la línea por comas
                       if (values.Length >= 4) // Asegura que hay suficientes valores
                       {
                           int numeroMesa = int.Parse(values[0]);
                           string nombreProducto = values[1];
                           decimal precio = decimal.Parse(values[2]);
                           // Aquí puedes agregar lógica para manejar más campos si es necesario

                           // Busca o crea la mesa correspondiente
                           Mesa mesa = facturasCargadas.Find(m => m.GetNumero() == numeroMesa);
                           if (mesa == null)
                           {
                               mesa = new Mesa();
                               mesa.SetNumero(numeroMesa);
                               facturasCargadas.Add(mesa);
                           }

                           // Agrega el producto a la mesa
                           mesa.AgregarProducto(new Producto(0, nombreProducto, precio)); // ID puede ser cero o ajustarse según sea necesario
                       }
                   }
               }
               Console.WriteLine("Facturas cargadas correctamente.");
           }
           else
           {
               Console.WriteLine("El archivo no existe.");
           }

           return facturasCargadas;
       }
   }
}
