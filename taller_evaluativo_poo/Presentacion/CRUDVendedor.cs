using taller_evaluativo_poo.AccesoDatos;
using taller_evaluativo_poo.LogicaNegocio;
using System;

public class CRUDVendedor
{
    private LogicaVendedor _LogicaVendedor;

    // Constructor: Se inicializa con una instancia de LogicaVendedor, que maneja la lógica de negocio para la entidad Vendedor.
    // Encapsulación: La variable _LogicaVendedor es privada, lo que asegura que su acceso se limite a esta clase.
    public CRUDVendedor(LogicaVendedor LogicaVendedor)
    {
        _LogicaVendedor = LogicaVendedor;
    }

    // Método que presenta el menú de opciones para administrar los vendedores.
    // Interacción: Facilita al usuario la gestión de vendedores a través de un menú.
    public void MenuPrincipal()
    {
        bool continuar = true;
        do
        {
            // Muestra el menú principal de gestión de vendedores.
            Console.WriteLine("Vendedores:");
            Console.WriteLine("1. Listar");
            Console.WriteLine("2. Agregar");
            Console.WriteLine("3. Actualizar");
            Console.WriteLine("4. Eliminar");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            string? opcion = Console.ReadLine();

            // Estructura de control que maneja las elecciones del menú.
            switch (opcion)
            {
                case "1":
                    ListarVendedores();
                    break;
                case "2":
                    AgregarVendedor();
                    break;
                case "3":
                    ActualizarVendedor();
                    break;
                case "4":
                    EliminarVendedor();
                    break;
                case "5":
                    continuar = false; // Salir del menú
                    break;
                default:
                    Console.WriteLine("Error, la opción no es válida. Por favor, intenta de nuevo.");
                    break;
            }
        } while (continuar);
    }

    // Método para añadir un nuevo vendedor.
    // Solicita información del nuevo vendedor y delega la creación a la lógica de negocio.
    private void AgregarVendedor()
    {
        try
        {
            // Captura de datos necesarios para el nuevo vendedor.
            Console.WriteLine("Ingresa el código del vendedor:");
            string codigo = Console.ReadLine() ?? "";
            Console.WriteLine("Ingresa el nombre del vendedor:");
            string nombre = Console.ReadLine() ?? "";
            Console.WriteLine("Ingresa el email del vendedor:");
            string email = Console.ReadLine() ?? "";
            Console.WriteLine("Ingresa el teléfono del vendedor:");
            string telefono = Console.ReadLine() ?? "";
            Console.WriteLine("Ingresa el carné del vendedor:");
            if (!int.TryParse(Console.ReadLine(), out int carne))
            {
                Console.WriteLine("Carné inválido. Debes ingresar un número entero.");
                return;
            }
            Console.WriteLine("Ingresa la dirección del vendedor:");
            string direccion = Console.ReadLine() ?? "";

            // Se crea una instancia de dtosVendedor con la información proporcionada.
            dtosVendedor nuevoVendedor = new dtosVendedor
            {
                Codigo = codigo,
                Nombre = nombre,
                Email = email,
                Telefono = telefono,
                Carne = carne,
                Direccion = direccion,
                Facturas = new List<dtosFactura>() // Inicializa la colección de facturas
            };

            // Se utiliza el servicio para agregar el nuevo vendedor.
            _LogicaVendedor.AgregarVendedor(nuevoVendedor);
            Console.WriteLine("Vendedor agregado exitosamente.");
        }
        catch (Exception ex)
        {
            // Captura de errores: Muestra un mensaje si ocurre una excepción durante la adición.
            Console.WriteLine($"Error al agregar el vendedor: {ex.Message}");
        }
    }

    // Método que lista todos los vendedores.
    // Interacción: Llama al servicio para obtener y mostrar la lista de vendedores.
    private void ListarVendedores()
    {
        _LogicaVendedor.ListarVendedores(); // Llama al método de servicio para listar vendedores.
    }

    // Método para actualizar un vendedor existente.
    // Solicita nueva información y delega la actualización al servicio correspondiente.
    private void ActualizarVendedor()
    {
        try
        {
            Console.WriteLine("Ingresa el ID del vendedor a actualizar:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido. Debes ingresar un número correcto.");
                return;
            }

            // Solicita nuevos datos del vendedor.
            Console.WriteLine("Ingresa el nuevo código del vendedor:");
            string codigo = Console.ReadLine() ?? "";
            Console.WriteLine("Ingresa el nuevo nombre del vendedor:");
            string nombre = Console.ReadLine() ?? "";
            Console.WriteLine("Ingresa el nuevo email del vendedor:");
            string email = Console.ReadLine() ?? "";
            Console.WriteLine("Ingresa el nuevo teléfono del vendedor:");
            string telefono = Console.ReadLine() ?? "";
            Console.WriteLine("Ingresa el nuevo carné del vendedor:");
            if (!int.TryParse(Console.ReadLine(), out int carne))
            {
                Console.WriteLine("Carné inválido. Debes ingresar un número correcto.");
                return;
            }
            Console.WriteLine("Ingresa la nueva dirección del vendedor:");
            string direccion = Console.ReadLine() ?? "";

            // Se crea una instancia de dtosVendedor con los nuevos datos.
            dtosVendedor vendedorActualizado = new dtosVendedor
            {
                IdPersona = id,
                Codigo = codigo,
                Nombre = nombre,
                Email = email,
                Telefono = telefono,
                Carne = carne,
                Direccion = direccion,
                Facturas = new List<dtosFactura>() // Inicializa la colección de facturas
            };

            // Se usa el servicio para actualizar el vendedor.
            _LogicaVendedor.ActualizarVendedor(id, vendedorActualizado);
            Console.WriteLine("Vendedor actualizado exitosamente.");
        }
        catch (Exception ex)
        {
            // Captura de errores: Muestra un mensaje si ocurre una excepción durante la actualización.
            Console.WriteLine($"Error al actualizar el vendedor: {ex.Message}");
        }
    }

    // Método para eliminar un vendedor.
    // Solicita el ID del vendedor y delega la eliminación al servicio.
    private void EliminarVendedor()
    {
        try
        {
            Console.WriteLine("Ingresa el ID del vendedor a eliminar:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido. Debes ingresar un número correcto.");
                return;
            }

            // Se utiliza el servicio para eliminar el vendedor especificado.
            _LogicaVendedor.EliminarVendedor(id);
            Console.WriteLine("Vendedor eliminado exitosamente.");
        }
        catch (Exception ex)
        {
            // Captura de errores: Muestra un mensaje si ocurre un error durante la eliminación.
            Console.WriteLine($"Error al eliminar el vendedor: {ex.Message}");
        }
    }
}
