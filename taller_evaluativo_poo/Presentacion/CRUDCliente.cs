using taller_evaluativo_poo.AccesoDatos; // Importa la clase para acceder a los datos
using taller_evaluativo_poo.LogicaNegocio; // Importa la lógica de negocio relacionada con los clientes
using System;

public class CRUDCliente
{
    private LogicaCliente _LogicaCliente; // Instancia de la lógica de negocio para gestionar clientes

    // Constructor: Recibe una instancia de LogicaCliente, que proporciona los métodos para gestionar clientes.
    public CRUDCliente(LogicaCliente LogicaCliente)
    {
        _LogicaCliente = LogicaCliente; // Asigna la lógica de negocio a la variable privada
    }

    // Método principal que presenta un menú de opciones para gestionar clientes.
    public void MenuPrincipal()
    {
        bool continuar = true; // Controla el bucle del menú

        do
        {
            // Muestra el menú de opciones al usuario
            Console.WriteLine("Clientes:");
            Console.WriteLine("1. Listar");
            Console.WriteLine("2. Agregar");
            Console.WriteLine("3. Actualizar");
            Console.WriteLine("4. Eliminar");
            Console.WriteLine("5. Salir");
            Console.Write("Ingresa la opción: ");
            string? opcion = Console.ReadLine(); // Lee la opción seleccionada por el usuario

            // Estructura de control para determinar qué acción realizar
            switch (opcion)
            {
                case "1":
                    ListarClientes(); // Llama al método para listar clientes
                    break;
                case "2":
                    AgregarCliente(); // Llama al método para agregar un nuevo cliente
                    break;
                case "3":
                    ActualizarCliente(); // Llama al método para actualizar un cliente existente
                    break;
                case "4":
                    EliminarCliente(); // Llama al método para eliminar un cliente
                    break;
                case "5":
                    continuar = false; // Cambia la variable para salir del bucle
                    break;
                default:
                    // Mensaje de error si la opción ingresada no es válida
                    Console.WriteLine("Error, la opción no es válida. Por favor, intenta de nuevo.");
                    break;
            }
        } while (continuar); // Repite el menú mientras el usuario lo desee
    }

    // Método para agregar un nuevo cliente.
    private void AgregarCliente()
    {
        try
        {
            // Solicita y lee los datos del cliente
            Console.WriteLine("Ingresa el código del cliente:");
            string? codigo = Console.ReadLine();
            Console.WriteLine("Ingresa el nombre del cliente:");
            string? nombre = Console.ReadLine();
            Console.WriteLine("Ingresa el email del cliente:");
            string? email = Console.ReadLine();
            Console.WriteLine("Ingresa el teléfono del cliente:");
            string? telefono = Console.ReadLine();
            Console.WriteLine("Ingresa el crédito del cliente:");
            double credito = Convert.ToDouble(Console.ReadLine()); // Convierte la entrada a double

            // Crea una nueva instancia de dtosCliente con los datos ingresados
            dtosCliente nuevoCliente = new dtosCliente
            {
                Codigo = codigo!, // Asegura que no es nulo
                Nombre = nombre!,
                Email = email!,
                Telefono = telefono!,
                Credito = credito,
                Facturas = new List<dtosFactura>() // Inicializa la lista de facturas
            };

            // Utiliza la lógica de negocio para agregar el cliente
            _LogicaCliente.AgregarCliente(nuevoCliente);
            Console.WriteLine("Cliente agregado satisfactoriamente."); // Confirma la operación
        }
        catch (Exception ex)
        {
            // Captura y muestra cualquier error que ocurra
            Console.WriteLine($"Error al agregar el cliente: {ex.Message}");
        }
    }

    // Método para listar todos los clientes.
    private void ListarClientes()
    {
        _LogicaCliente.ListarClientes(); // Llama al método del servicio para obtener y mostrar la lista de clientes
    }

    // Método para actualizar un cliente existente.
    private void ActualizarCliente()
    {
        try
        {
            // Solicita el ID del cliente a actualizar
            Console.WriteLine("Ingresa el ID del cliente a actualizar:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                throw new ArgumentException("El ID es inválido, debe ser un número entero."); // Maneja entrada no válida
            }

            // Solicita nuevos datos del cliente
            Console.WriteLine("Ingresa el nuevo código del cliente:");
            string? codigo = Console.ReadLine();
            if (string.IsNullOrEmpty(codigo)) // Valida que el código no esté vacío
            {
                throw new ArgumentException("El código no puede ser vacío.");
            }

            Console.WriteLine("Ingresa el nuevo nombre del cliente:");
            string? nombre = Console.ReadLine();
            if (string.IsNullOrEmpty(nombre)) // Valida que el nombre no esté vacío
            {
                throw new ArgumentException("El nombre no puede ser vacío.");
            }

            Console.WriteLine("Ingresa el nuevo email del cliente:");
            string? email = Console.ReadLine();
            if (string.IsNullOrEmpty(email)) // Valida que el email no esté vacío
            {
                throw new ArgumentException("El email no puede ser vacío.");
            }

            Console.WriteLine("Ingresa el nuevo teléfono del cliente:");
            string? telefono = Console.ReadLine();
            if (string.IsNullOrEmpty(telefono)) // Valida que el teléfono no esté vacío
            {
                throw new ArgumentException("El teléfono no puede estar vacío.");
            }

            Console.WriteLine("Ingresa el nuevo crédito del cliente:");
            if (!double.TryParse(Console.ReadLine(), out double credito)) // Valida que el crédito sea un número
            {
                throw new ArgumentException("Crédito inválido, debe ser un valor numérico.");
            }

            // Crea un objeto ClienteDatos con los nuevos datos
            dtosCliente clienteActualizado = new dtosCliente
            {
                Codigo = codigo!,
                Nombre = nombre!,
                Email = email!,
                Telefono = telefono!,
                Credito = credito,
                Facturas = new List<dtosFactura>() // Inicializa la lista de facturas
            };

            // Utiliza la lógica de negocio para actualizar el cliente
            _LogicaCliente.ActualizarCliente(id, clienteActualizado);
            Console.WriteLine("Cliente actualizado con éxito."); // Confirma la operación
        }
        catch (Exception ex)
        {
            // Captura y muestra cualquier error que ocurra
            Console.WriteLine($"Error al actualizar el cliente: {ex.Message}");
        }
    }

    // Método para eliminar un cliente existente.
    private void EliminarCliente()
    {
        try
        {
            Console.WriteLine("Ingresa el ID del cliente para eliminar:");
            if (!int.TryParse(Console.ReadLine(), out int id)) // Valida que el ID sea un número entero
            {
                throw new ArgumentException("El ID debe ser un número válido.");
            }

            // Utiliza la lógica de negocio para eliminar el cliente
            _LogicaCliente.EliminarCliente(id);
            Console.WriteLine("Cliente eliminado con éxito."); // Confirma la eliminación
        }
        catch (Exception ex)
        {
            // Captura y muestra cualquier error que ocurra
            Console.WriteLine($"Error al eliminar el cliente: {ex.Message}");
        }
    }
}
