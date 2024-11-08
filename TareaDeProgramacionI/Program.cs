using System;

namespace TareaDeProgramacionI
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventario inventario = new Inventario();
            Console.WriteLine("Bienvenido al sistema de gestion de inventario");

            int cantidad = SolicitarNumeroPositivo("¿Cuantos productos desea agregar?");

            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine($"\nProducto {i + 1}:");

                string nombre = SolicitarTextoNoVacio("Nombre: ");
                decimal precio = SolicitarPrecioPositivo("Precio: ");

                Producto producto = new Producto(nombre, precio);
                inventario.AgregarProducto(producto);
            }

            if (SolicitarRespuestaSiNo("\n¿Desea actualizar el precio de algun producto? (S/N): "))
            {
                string nombreProducto = SolicitarTextoNoVacio("Ingrese el nombre del producto a actualizar: ");
                decimal nuevoPrecio = SolicitarPrecioPositivo("Ingrese el nuevo precio: ");

                bool actualizado = inventario.ActualizarPrecioProducto(nombreProducto, nuevoPrecio);
                Console.WriteLine(actualizado ? "El precio del producto ha sido actualizado exitosamente." : "Producto no encontrado.");
            }

            if (SolicitarRespuestaSiNo("\n¿Desea eliminar algun producto? (S/N): "))
            {
                string nombreProducto = SolicitarTextoNoVacio("Ingrese el nombre del producto a eliminar: ");

                bool eliminado = inventario.EliminarProductoPorNombre(nombreProducto);
                Console.WriteLine(eliminado ? "El producto ha sido eliminado exitosamente." : "Producto no encontrado.");
            }

            decimal precioMinimo = SolicitarPrecioPositivo("\nIngrese el precio mínimo para filtrar los productos: ");

            var productosFiltrados = inventario.FiltrarYOrdenarProductos(precioMinimo);

            Console.WriteLine("\nProductos filtrados y ordenados: ");
            foreach (var producto in productosFiltrados)
            {
                producto.MostrarInformacion();
            }

            Console.WriteLine("\nConteo de productos por rango de precio:");
            var conteoPorRango = inventario.ContarProductosPorRangoDePrecio();
            foreach (var rango in conteoPorRango)
            {
                Console.WriteLine($"{rango.Key}: {rango.Value} producto(s)");
            }
            inventario.GenerarReporteResumido();
        }
        private static int SolicitarNumeroPositivo(string mensaje)
        {
            int numero;
            do
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine();
                if (!int.TryParse(entrada, out numero) || numero <= 0)
                {
                    Console.WriteLine("Por favor, ingrese un número entero positivo.");
                }
            } while (numero <= 0);

            return numero;
        }
        private static decimal SolicitarPrecioPositivo(string mensaje)
        {
            decimal precio;
            do
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine();
                if (!decimal.TryParse(entrada, out precio) || precio <= 0)
                {
                    Console.WriteLine("Por favor, ingrese un valor decimal positivo para el precio.");
                }
            } while (precio <= 0);

            return precio;
        }
        private static string SolicitarTextoNoVacio(string mensaje)
        {
            string texto;
            do
            {
                Console.Write(mensaje);
                texto = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(texto))
                {
                    Console.WriteLine("El nombre no puede estar vacío. Intente de nuevo.");
                }
            } while (string.IsNullOrWhiteSpace(texto));

            return texto;
        }
        private static bool SolicitarRespuestaSiNo(string mensaje)
        {
            string respuesta;
            do
            {
                Console.Write(mensaje);
                respuesta = Console.ReadLine()?.Trim().ToUpper();
                if (respuesta != "S" && respuesta != "N")
                {
                    Console.WriteLine("Por favor, ingrese 'S' para Sí o 'N' para No.");
                }
            } while (respuesta != "S" && respuesta != "N");

            return respuesta == "S";
        }

    }
}
