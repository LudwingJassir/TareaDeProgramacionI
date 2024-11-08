using System;
using System.Collections.Generic;
using System.Linq;

namespace TareaDeProgramacionI
{
    public class Inventario
    {
        private List<Producto> productos;

        public Inventario()
        {
            productos = new List<Producto>();
        }

        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
        }

        public bool ActualizarPrecioProducto(string nombre, decimal nuevoPrecio)
        {
            Producto producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                producto.ActualizarPrecio(nuevoPrecio);
                return true;
            }
            return false;
        }

        public bool EliminarProductoPorNombre(string nombre)
        {
            Producto producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                productos.Remove(producto);
                return true;
            }
            return false;
        }

        public IEnumerable<Producto> FiltrarYOrdenarProductos(decimal precioMinimo)
        {
            return productos
                .Where(p => p.Precio > precioMinimo)
                .OrderBy(p => p.Precio);
        }

        public Dictionary<string, int> ContarProductosPorRangoDePrecio()
        {
            return new Dictionary<string, int>
            {
                { "Menores a 2500", productos.Count(p => p.Precio < 2500) },
                { "Entre 5000 y 8000", productos.Count(p => p.Precio >= 5000 && p.Precio <= 8000) },
                { "Mayores a 10000", productos.Count(p => p.Precio > 10000) }
            };
        }
        public void GenerarReporteResumido()
        {
            if (productos.Count == 0)
            {
                Console.WriteLine("El inventario esta vacio.");
                return;
            }

            int totalProductos = productos.Count;
            decimal precioPromedio = productos.Average(p => p.Precio);
            Producto productoMasCaro = productos.OrderByDescending(p => p.Precio).FirstOrDefault();
            Producto productoMasBarato = productos.OrderBy(p => p.Precio).FirstOrDefault();

            Console.WriteLine("\n--- Reporte Resumido del Inventario ---");
            Console.WriteLine($"Numero total de productos: {totalProductos}");
            Console.WriteLine($"Precio promedio de todos los productos: {precioPromedio:C}");
            Console.WriteLine($"Producto con el precio mas alto: {productoMasCaro?.Nombre} - {productoMasCaro?.Precio:C}");
            Console.WriteLine($"Producto con el precio mas bajo: {productoMasBarato?.Nombre} - {productoMasBarato?.Precio:C}");
        }

    }
}

