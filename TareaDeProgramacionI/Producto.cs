using System;

namespace TareaDeProgramacionI
{
    public class Producto
    {
        public Producto(string nombre, decimal precio)
        {
            Nombre = nombre;
            Precio = precio;
        }

        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Producto: {Nombre}, Precio: {Precio:C}");
        }

        public void ActualizarPrecio(decimal nuevoPrecio)
        {
            Precio = nuevoPrecio;
        }
    }
}

