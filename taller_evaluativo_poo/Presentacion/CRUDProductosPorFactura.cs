using taller_evaluativo_poo.AccesoDatos;
using System;

public class CRUDProductosPorFactura
{
    private LogicaProductosPorFactura _LogicaProductosPorFactura;

    // Constructor: Se inicializa la clase con una instancia del servicio LogicaProductosPorFactura,
    // que se encarga de la lógica de negocio relacionada con la gestión de productos por factura.
    // Encapsulación: La variable _LogicaProductosPorFactura es privada, asegurando que su acceso
    // esté restringido a esta clase, promoviendo así la encapsulación.
    public CRUDProductosPorFactura(LogicaProductosPorFactura LogicaProductosPorFactura)
    {
        _LogicaProductosPorFactura = LogicaProductosPorFactura;
    }

    // Método principal que presenta un menú interactivo para la gestión de productos en facturas.
    // Este menú permite al usuario agregar productos a facturas o salir de la aplicación.
    public void MenuPrincipal()
    {
        bool continuar = true; // Variable de control del bucle del menú.
        while (continuar)
        {
            // Se presenta el menú de opciones al usuario.
            Console.WriteLine("Facturas");
            Console.WriteLine("1. Agregar producto a factura");
            Console.WriteLine("2. Salir");
            Console.Write("Ingresa la opción: ");
            string? opcion = Console.ReadLine();

            // Estructura de control para procesar la opción seleccionada por el usuario.
            switch (opcion)
            {
                case "1":
                    AgregarProductoAFactura(); // Llama al método para agregar un producto a una factura.
                    break;
                case "2":
                    continuar = false; // Cambia la variable de control para salir del bucle.
                    break;
                default:
                    Console.WriteLine("Error, la opción no es válida. Por favor, intenta de nuevo."); // Manejo de opciones no válidas.
                    break;
            }
        }
    }

    // Método dedicado a agregar un producto a una factura específica.
    // Solicita los datos necesarios (ID de factura, ID de producto y cantidad) 
    // y utiliza el servicio correspondiente para realizar la operación.
    public void AgregarProductoAFactura()
    {
        try
        {
            // Captura del ID de la factura, asegurándose de que sea un número válido.
            Console.WriteLine("Ingresa el ID de la factura:");
            if (!int.TryParse(Console.ReadLine(), out int Idfactura))
            {
                Console.WriteLine("El ID de factura es inválido. Por favor, Ingresa un número correcto.");
                return; // Sale del método si el ID no es válido.
            }

            // Captura del ID del producto, asegurándose de que sea un número válido.
            Console.WriteLine("Ingresa el ID del producto:");
            if (!int.TryParse(Console.ReadLine(), out int Idproducto))
            {
                Console.WriteLine("El ID de producto es inválido. Por favor, Ingresa un número correcto.");
                return; // Sale del método si el ID no es válido.
            }

            // Captura de la cantidad del producto, asegurándose de que sea un número válido.
            Console.WriteLine("Ingresa la cantidad del producto:");
            if (!int.TryParse(Console.ReadLine(), out int cantidad))
            {
                Console.WriteLine("La cantidad es inválida. Por favor, Ingresa un número correcto.");
                return; // Sale del método si la cantidad no es válida.
            }

            // Se invoca al servicio para agregar el producto a la factura con los datos recopilados.
            _LogicaProductosPorFactura.AgregarProductoAFactura(Idfactura, Idproducto, cantidad);
        }
        catch (Exception ex)
        {
            // Captura de errores: Muestra un mensaje informativo en caso de que ocurra una excepción.
            Console.WriteLine($"Error al agregar el producto a la factura: {ex.Message}");
        }
    }
}
