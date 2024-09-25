using System;
using System.IO;

class Inventario
{
    public void CargarInventario(string rutaArchivo)
    {
        // Verificar si el archivo existe antes de intentar cargarlo
        if (!File.Exists(rutaArchivo))
        {
            Console.WriteLine("El archivo no existe. Creando un nuevo archivo.");
            // Crear el archivo con encabezados o contenido vacío
            File.WriteAllText(rutaArchivo, "ID,Nombre,Precio\n");
        }
        
        // Lógica para cargar los datos desde el archivo CSV
        string[] lineas = File.ReadAllLines(rutaArchivo);
        foreach (string linea in lineas)
        {
            Console.WriteLine(linea); // Solo imprime las líneas para ver los datos cargados
            // Aquí podrías agregar la lógica para cargar el inventario en memoria
        }
    }

    public void GuardarInventario(string rutaArchivo)
    {
        // Lógica para guardar el inventario actual en el archivo CSV
        using (StreamWriter sw = new StreamWriter(rutaArchivo))
        {
            sw.WriteLine("ID,Nombre,Precio");
            sw.WriteLine("1,Pizza,9.99");
            sw.WriteLine("2,Hamburguesa,6.49");
        }
        Console.WriteLine("Inventario guardado en: " + rutaArchivo);
    }
}
