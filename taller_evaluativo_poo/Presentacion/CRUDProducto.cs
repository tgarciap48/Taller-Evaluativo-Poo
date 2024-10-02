using taller_evaluativo_poo.AccesoDatos;
using taller_evaluativo_poo.LogicaNegocio;
using System;

public class CRUDProducto
{
    private LogicaProducto _LogicaProducto;

    // Constructor: Se inicializa la clase con un servicio llamado LogicaProducto.
    // Este servicio se encarga de la lógica relacionada con los productos.
    // El servicio es privado, lo que significa que solo se puede usar dentro de esta clase.
    public CRUDProducto(LogicaProducto LogicaProducto)
    {
        _LogicaProducto = LogicaProducto;
    }

    // Método principal que muestra un menú para gestionar productos.
    // El usuario puede elegir diferentes opciones, como listar, agregar, actualizar o eliminar productos.
    public void MenuPrincipal()
    {
        bool continuar = true; // Controla el bucle del menú.
        do
        {
            // Muestra el menú de opciones al usuario.
            Console.WriteLine("Productos:");
            Console.WriteLine("1. Listar");
            Console.WriteLine("2. Agregar");
            Console.WriteLine("3. Actualizar");
            Console.WriteLine("4. Eliminar");
            Console.WriteLine("5. Salir");
            Console.Write("Ingresa la opción: ");
            string? opcion = Console.ReadLine();

            // Controla lo que hace el usuario según su elección.
            switch (opcion)
            {
                case "1":
                    ListarProductos(); // Llama a la función que lista todos los productos.
                    break;
                case "2":
                    AgregarProducto(); // Llama a la función que permite agregar un nuevo producto.
                    break;
                case "3":
                    ActualizarProducto(); // Llama a la función que permite actualizar un producto existente.
                    break;
                case "4":
                    EliminarProducto(); // Llama a la función que elimina un producto.
                    break;
                case "5":
                    continuar = false; // Cambia el valor para salir del bucle.
                    break;
                default:
                    Console.WriteLine("Error, la opción no es válida. Por favor, intenta de nuevo."); // Mensaje de error para opciones inválidas.
                    break;
            }
        } while (continuar);
    }

    // Método para agregar un nuevo producto.
    // Solicita al usuario los datos del nuevo producto y se los pasa al servicio para que los guarde.
    private void AgregarProducto()
    {
        try
        {
            // Pide los datos del producto al usuario.
            Console.WriteLine("Ingresa el código del producto:");
            string codigo = Console.ReadLine() ?? "";
            Console.WriteLine("Ingresa el nombre del producto:");
            string nombre = Console.ReadLine() ?? "";
            Console.WriteLine("Ingresa la cantidad de stock del producto:");
            if (!int.TryParse(Console.ReadLine(), out int stock)) // Verifica que el stock sea un número.
            {
                Console.WriteLine("La cantidad de stock es inválida. Por favor, Ingresa un número correcto.");
                return; // Sale del método si hay un error.
            }
            Console.WriteLine("Ingresa el valor unitario del producto:");
            if (!double.TryParse(Console.ReadLine(), out double valorUnitario)) // Verifica que el valor sea un número.
            {
                Console.WriteLine("El valor unitario es incorrecto. Por favor, Ingresa un número válido.");
                return; // Sale del método si hay un error.
            }

            // Crea una nueva instancia de producto con los datos proporcionados.
            dtosProducto nuevoProducto = new dtosProducto
            {
                Codigo = codigo,
                Nombre = nombre,
                Stock = stock,
                ValorUnitario = valorUnitario,
                ProductosPorFactura = new List<dtosProductosPorFactura>() // Inicializa la lista de productos por factura.
            };

            // Llama al servicio para agregar el nuevo producto.
            _LogicaProducto.AgregarProducto(nuevoProducto);
            Console.WriteLine("Producto agregado satisfactoriamente.");
        }
        catch (Exception ex)
        {
            // Muestra un mensaje de error si algo sale mal al agregar el producto.
            Console.WriteLine($"Error al agregar el producto: {ex.Message}");
        }
    }

    // Método para listar todos los productos.
    // Llama al servicio que se encarga de obtener y mostrar la lista de productos.
    private void ListarProductos()
    {
        _LogicaProducto.ListarProductos(); // Muestra la lista de productos disponibles.
    }

    // Método para actualizar un producto existente.
    // Pide al usuario el ID del producto que desea actualizar y los nuevos datos.
    private void ActualizarProducto()
    {
        try
        {
            Console.WriteLine("Ingresa el ID del producto a actualizar:");
            if (!int.TryParse(Console.ReadLine(), out int id)) // Verifica que el ID sea un número.
            {
                Console.WriteLine("El ID del producto es incorrecto. Por favor, Ingresa un número válido.");
                return; // Sale del método si hay un error.
            }

            // Verifica que el producto exista.
            var productoExistente = _LogicaProducto.ObtenerProductoPorId(id);
            if (productoExistente == null) // Si no encuentra el producto, informa al usuario.
            {
                Console.WriteLine("El producto no fue encontrado.");
                return;
            }

            // Pide los nuevos datos del producto al usuario.
            Console.WriteLine("Ingresa el nuevo código del producto:");
            string codigo = Console.ReadLine() ?? "";
            Console.WriteLine("Ingresa el nuevo nombre del producto:");
            string nombre = Console.ReadLine() ?? "";
            Console.WriteLine("Ingresa el nuevo stock del producto:");
            if (!int.TryParse(Console.ReadLine(), out int stock)) // Verifica que el nuevo stock sea un número.
            {
                Console.WriteLine("Stock inválido. Por favor, Ingresa un número entero.");
                return; // Sale del método si hay un error.
            }
            Console.WriteLine("Ingresa el nuevo valor unitario del producto:");
            if (!double.TryParse(Console.ReadLine(), out double valorUnitario)) // Verifica que el nuevo valor sea un número.
            {
                Console.WriteLine("Valor unitario inválido. Por favor, Ingresa un número válido.");
                return; // Sale del método si hay un error.
            }

            // Actualiza los valores del producto con la información proporcionada.
            productoExistente.Codigo = codigo;
            productoExistente.Nombre = nombre;
            productoExistente.Stock = stock;
            productoExistente.ValorUnitario = valorUnitario;

            // Llama al servicio para actualizar el producto con los nuevos datos.
            _LogicaProducto.ActualizarProducto(id, productoExistente);
            Console.WriteLine("Producto actualizado satisfactoriamente.");
        }
        catch (Exception ex)
        {
            // Muestra un mensaje de error si algo sale mal al actualizar el producto.
            Console.WriteLine($"Error al actualizar el producto: {ex.Message}");
        }
    }

    // Método para eliminar un producto existente.
    // Solicita el ID del producto a eliminar y llama al servicio para realizar la eliminación.
    private void EliminarProducto()
    {
        try
        {
            Console.WriteLine("Ingresa el ID del producto para eliminar:");
            if (!int.TryParse(Console.ReadLine(), out int id)) // Verifica que el ID sea un número.
            {
                Console.WriteLine("ID inválido. Por favor, Ingresa un número correcto.");
                return; // Sale del método si hay un error.
            }
            // Llama al servicio para eliminar el producto.
            _LogicaProducto.EliminarProducto(id);
            Console.WriteLine("Producto eliminado satisfactoriamente.");
        }
        catch (Exception ex)
        {
            // Muestra un mensaje de error si algo sale mal al eliminar el producto.
            Console.WriteLine($"Error al eliminar el producto: {ex.Message}");
        }
    }
}
