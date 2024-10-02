using taller_evaluativo_poo.AccesoDatos; // Importa la clase que maneja el acceso a datos
using taller_evaluativo_poo.LogicaNegocio; // Importa la lógica de negocio para las empresas
using System;

public class CRUDEmpresa
{
    private LogicaEmpresa _LogicaEmpresa; // Instancia de la lógica de negocio para gestionar empresas

    // Constructor: Recibe una instancia de LogicaEmpresa, lo que permite realizar operaciones sobre empresas.
    public CRUDEmpresa(LogicaEmpresa LogicaEmpresa)
    {
        _LogicaEmpresa = LogicaEmpresa; // Asigna la lógica de negocio a la variable privada
    }

    // Método principal que presenta un menú al usuario para gestionar empresas.
    // Permite al usuario elegir qué operación realizar sobre las empresas.
    public void MenuPrincipal()
    {
        bool continuar = true; // Controla si el menú debe seguir mostrándose

        do
        {
            // Muestra el menú de opciones disponibles
            Console.WriteLine("Empresas:");
            Console.WriteLine("1. Listar");
            Console.WriteLine("2. Agregar");
            Console.WriteLine("3. Actualizar");
            Console.WriteLine("4. Eliminar");
            Console.WriteLine("5. Salir");
            Console.Write("Ingresa la opción: ");
            string? opcion = Console.ReadLine(); // Lee la opción seleccionada por el usuario

            // Controla qué acción se debe realizar según la opción elegida
            switch (opcion)
            {
                case "1":
                    ListarEmpresas(); // Llama al método para listar empresas
                    break;
                case "2":
                    AgregarEmpresa(); // Llama al método para agregar una nueva empresa
                    break;
                case "3":
                    ActualizarEmpresa(); // Llama al método para actualizar una empresa existente
                    break;
                case "4":
                    EliminarEmpresa(); // Llama al método para eliminar una empresa
                    break;
                case "5":
                    continuar = false; // Cambia la variable para salir del bucle
                    break;
                default:
                    // Mensaje de error si la opción no es válida
                    Console.WriteLine("Error, la opción no es válida. Por favor, intenta de nuevo.");
                    break;
            }
        } while (continuar); // Repite el menú mientras el usuario lo desee
    }

    // Método para agregar una nueva empresa.
    // Recibe datos del usuario y crea una nueva instancia de empresa.
    private void AgregarEmpresa()
    {
        try
        {
            // Solicita y lee el código de la nueva empresa
            Console.WriteLine("Ingresa el código de la empresa:");
            string? codigo = Console.ReadLine();

            // Solicita y lee el nombre de la nueva empresa
            Console.WriteLine("Ingresa el nombre de la empresa:");
            string? nombre = Console.ReadLine();

            // Crea una nueva instancia de dtosEmpresa con los datos proporcionados
            dtosEmpresa nuevaEmpresa = new dtosEmpresa
            {
                Codigo = codigo!, // El signo de exclamación indica que se asegura que no es nulo
                Nombre = nombre!
            };

            // Utiliza el servicio de lógica para agregar la nueva empresa
            _LogicaEmpresa.AgregarEmpresa(nuevaEmpresa);
            Console.WriteLine("Empresa agregada con éxito."); // Confirma la operación
        }
        catch (Exception ex)
        {
            // Captura y muestra un mensaje de error si ocurre algún problema
            Console.WriteLine($"Error al agregar la empresa: {ex.Message}");
        }
    }

    // Método para listar todas las empresas existentes.
    // Muestra al usuario la lista de empresas.
    private void ListarEmpresas()
    {
        _LogicaEmpresa.ListarEmpresas(); // Llama al servicio que lista las empresas
    }

    // Método para actualizar una empresa existente.
    // Solicita nuevos datos y actualiza la información de la empresa.
    private void ActualizarEmpresa()
    {
        try
        {
            // Solicita el ID de la empresa a actualizar
            Console.WriteLine("Ingresa el ID de la empresa para actualizar:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("El ID es incorrecto, debes ingresar un número válido.");
                return; // Sale del método si la entrada no es válida
            }

            // Solicita y valida el nuevo código de la empresa
            Console.WriteLine("Ingresa el nuevo código de la empresa:");
            string? codigo = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(codigo))
            {
                Console.WriteLine("El código no puede ser vacío."); // Mensaje si el código es inválido
                return;
            }

            // Solicita y valida el nuevo nombre de la empresa
            Console.WriteLine("Ingresa el nuevo nombre de la empresa:");
            string? nombre = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("El nombre no puede ser vacío."); // Mensaje si el nombre es inválido
                return;
            }

            // Crea un nuevo objeto de empresa con los datos actualizados
            dtosEmpresa empresaActualizada = new dtosEmpresa
            {
                Codigo = codigo, // Asigna el nuevo código
                Nombre = nombre // Asigna el nuevo nombre
            };

            // Utiliza el servicio para actualizar la empresa
            _LogicaEmpresa.ActualizarEmpresa(id, empresaActualizada);
            Console.WriteLine("Empresa actualizada satisfactoriamente."); // Confirma la operación
        }
        catch (Exception ex)
        {
            // Captura y muestra un mensaje de error si ocurre algún problema
            Console.WriteLine($"Error al actualizar la empresa: {ex.Message}");
        }
    }

    // Método para eliminar una empresa existente.
    // Solicita el ID de la empresa a eliminar y lo pasa al servicio para su eliminación.
    private void EliminarEmpresa()
    {
        try
        {
            // Solicita el ID de la empresa a eliminar
            Console.WriteLine("Ingresa el ID de la empresa para eliminar:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("El ID no es válido, debes ingresar un número correcto.");
                return; // Sale del método si la entrada no es válida
            }

            // Utiliza el servicio para eliminar la empresa
            _LogicaEmpresa.EliminarEmpresa(id);
            Console.WriteLine("Empresa eliminada con éxito."); // Confirma la eliminación
        }
        catch (Exception ex)
        {
            // Captura y muestra un mensaje de error si ocurre algún problema
            Console.WriteLine($"Error al eliminar la empresa: {ex.Message}");
        }
    }
}
