using taller_evaluativo_poo.AccesoDatos; // Importa la clase de acceso a datos
using taller_evaluativo_poo.LogicaNegocio; // Importa la lógica de negocio relacionada con facturas
using System;

public class CRUDFactura
{
    private LogicaFactura _LogicaFactura; // Almacena la lógica de negocio para manejar facturas

    // Constructor: Inicializa la clase y establece la lógica de negocio que se usará.
    // Aquí se recibe una instancia de LogicaFactura, lo que permite realizar operaciones sobre facturas.
    public CRUDFactura(LogicaFactura LogicaFactura)
    {
        _LogicaFactura = LogicaFactura; // Asigna la lógica de negocio a la variable privada
    }

    // Método principal que presenta un menú al usuario para gestionar facturas.
    // Ofrece opciones para listar, agregar, actualizar y eliminar facturas.
    public void MenuPrincipal()
    {
        bool continuar = true; // Controla si el menú se debe seguir mostrando

        do
        {
            // Presenta las opciones de gestión de facturas al usuario
            Console.WriteLine("Facturas:");
            Console.WriteLine("1. Listar");
            Console.WriteLine("2. Agregar");
            Console.WriteLine("3. Actualizar");
            Console.WriteLine("4. Eliminar");
            Console.WriteLine("5. Salir");
            Console.Write("Ingresa la opción: ");
            string? opcion = Console.ReadLine(); // Lee la opción seleccionada por el usuario

            // Ejecuta la acción correspondiente según la opción seleccionada
            switch (opcion)
            {
                case "1":
                    ListarFacturas(); // Muestra todas las facturas
                    break;
                case "2":
                    AgregarFactura(); // Permite al usuario agregar una nueva factura
                    break;
                case "3":
                    ActualizarFactura(); // Permite al usuario actualizar una factura existente
                    break;
                case "4":
                    EliminarFactura(); // Permite al usuario eliminar una factura
                    break;
                case "5":
                    continuar = false; // Finaliza el bucle y cierra el menú
                    break;
                default:
                    Console.WriteLine("Error, la opción no es válida. Por favor, intenta de nuevo."); // Maneja entradas incorrectas
                    break;
            }
        } while (continuar); // Continúa mostrando el menú mientras el usuario lo desee
    }

    // Método para agregar una nueva factura.
    // Solicita al usuario todos los datos necesarios para crear la factura.
    private void AgregarFactura()
    {
        try
        {
            // Solicita el número de la factura y valida su formato
            Console.WriteLine("Ingresa el número de la factura:");
            if (!long.TryParse(Console.ReadLine(), out long numero))
            {
                Console.WriteLine("El número de factura no es válido. Por favor, ingresa un número válido.");
                return; // Sale del método si la entrada es incorrecta
            }

            // Solicita y valida la fecha de la factura
            Console.WriteLine("Ingresa la fecha de la factura (formato YYYY-MM-DD):");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime fecha))
            {
                Console.WriteLine("La fecha no es correcta. Por favor, usa el formato correcto YYYY-MM-DD.");
                return;
            }

            // Solicita y valida el total de la factura
            Console.WriteLine("Ingresa el total de la factura:");
            if (!double.TryParse(Console.ReadLine(), out double total))
            {
                Console.WriteLine("El total no es correcto. Por favor, ingresa un número válido.");
                return;
            }

            // Solicita y valida el ID de la persona asociada a la factura
            Console.WriteLine("Ingresa el ID de la persona asociada a la factura:");
            if (!int.TryParse(Console.ReadLine(), out int Idpersona))
            {
                Console.WriteLine("El ID de la persona es inválido. Por favor, ingresa un número correcto.");
                return;
            }

            // Verifica que la persona asociada existe
            var persona = _LogicaFactura.ObtenerPersonaPorId(Idpersona);
            if (persona == null)
            {
                Console.WriteLine("No se encontró la persona con el ID que ingresaste.");
                return; // Sale si la persona no existe
            }

            // Crea una nueva factura con los datos proporcionados
            dtosFactura nuevaFactura = new dtosFactura
            {
                Numero = numero,
                Fecha = fecha,
                Total = total,
                IdPersona = Idpersona,
                Persona = persona,
                ProductosPorFactura = new List<dtosProductosPorFactura>() // Inicializa la lista de productos
            };

            // Llama al servicio para agregar la nueva factura
            _LogicaFactura.AgregarFactura(nuevaFactura);
            Console.WriteLine("Factura agregada con éxito.");
        }
        catch (Exception ex)
        {
            // Manejo de errores: muestra el mensaje si algo sale mal
            Console.WriteLine($"Error al agregar la factura: {ex.Message}");
        }
    }

    // Método para listar todas las facturas existentes.
    private void ListarFacturas()
    {
        _LogicaFactura.ListarFacturas(); // Llama al servicio para obtener y mostrar las facturas
    }

    // Método para actualizar una factura existente.
    // Solicita los nuevos datos y actualiza la factura en el sistema.
    private void ActualizarFactura()
    {
        try
        {
            // Solicita el ID de la factura a actualizar
            Console.WriteLine("Ingresa el ID de la factura para actualizar:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("El ID es inválido. Por favor, ingresa un número correcto.");
                return; // Sale si la entrada es incorrecta
            }

            // Solicita y valida el nuevo número de factura
            Console.WriteLine("Ingresa el nuevo número de la factura:");
            if (!long.TryParse(Console.ReadLine(), out long numero))
            {
                Console.WriteLine("El número de factura es inválido. Por favor, ingresa un número válido.");
                return;
            }

            // Solicita y valida la nueva fecha de la factura
            Console.WriteLine("Ingresa la nueva fecha de la factura (formato YYYY-MM-DD):");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime fecha))
            {
                Console.WriteLine("La fecha es inválida. Por favor, usa el formato correcto YYYY-MM-DD.");
                return;
            }

            // Solicita y valida el nuevo total de la factura
            Console.WriteLine("Ingresa el nuevo total de la factura:");
            if (!double.TryParse(Console.ReadLine(), out double total))
            {
                Console.WriteLine("El total no es correcto. Por favor, ingresa un número válido.");
                return;
            }

            // Solicita y valida el nuevo ID de la persona asociada
            Console.WriteLine("Ingresa el nuevo ID de la persona asociada a la factura:");
            if (!int.TryParse(Console.ReadLine(), out int Idpersona))
            {
                Console.WriteLine("El ID de persona es inválido. Por favor, ingresa un número correcto.");
                return;
            }

            // Verifica que la persona asociada existe
            var persona = _LogicaFactura.ObtenerPersonaPorId(Idpersona);
            if (persona == null)
            {
                Console.WriteLine("No se encontró la persona con el ID proporcionado.");
                return;
            }

            // Crea una nueva factura con los datos actualizados
            dtosFactura facturaActualizada = new dtosFactura
            {
                Numero = numero,
                Fecha = fecha,
                Total = total,
                IdPersona = Idpersona,
                Persona = persona,
                ProductosPorFactura = new List<dtosProductosPorFactura>() // Inicializa la lista aunque esté vacía
            };

            // Llama al servicio para actualizar la factura
            _LogicaFactura.ActualizarFactura(id, facturaActualizada);
            Console.WriteLine("Factura actualizada satisfactoriamente.");
        }
        catch (Exception ex)
        {
            // Manejo de errores: captura y muestra el mensaje de error
            Console.WriteLine($"Error al actualizar la factura: {ex.Message}");
        }
    }

    // Método para eliminar una factura existente.
    private void EliminarFactura()
    {
        try
        {
            // Solicita el ID de la factura a eliminar
            Console.WriteLine("Ingresa el ID de la factura para eliminar:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("El ID es incorrecto. Por favor, ingresa un número válido.");
                return;
            }

            // Llama al servicio para eliminar la factura
            _LogicaFactura.EliminarFactura(id);
            Console.WriteLine("Factura eliminada con éxito."); // Confirma la eliminación
        }
        catch (Exception ex)
        {
            // Manejo de errores: muestra el mensaje de error si ocurre un problema
            Console.WriteLine($"Error al eliminar la factura: {ex.Message}");
        }
    }
}
