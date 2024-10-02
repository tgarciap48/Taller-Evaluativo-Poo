using taller_evaluativo_poo.LogicaNegocio;
using System;

public class CRUDPersona
{
    private LogicaPersona _LogicaPersona;

    // Constructor: Este método recibe una instancia del servicio LogicaPersona,
    // que se encarga de la lógica relacionada con las personas. Esto permite que esta clase
    // interactúe con esa lógica. 
    // Además, el servicio se almacena en una variable privada, accesible solo dentro de esta clase.
    public CRUDPersona(LogicaPersona LogicaPersona)
    {
        _LogicaPersona = LogicaPersona;
    }

    // Método principal que muestra un menú con opciones para gestionar personas.
    // Proporciona una interfaz sencilla para que el usuario elija entre diferentes acciones.
    public void MenuPrincipal()
    {
        bool continuar = true; // Variable que controla el bucle del menú.
        do
        {
            // Muestra el menú con las opciones disponibles.
            Console.WriteLine("Personas:");
            Console.WriteLine("1. Listar Personas");
            Console.WriteLine("2. Salir");
            Console.Write("Ingresa la opción: ");
            string? opcion = Console.ReadLine(); // Lee la opción seleccionada por el usuario.

            // Estructura de control que gestiona las diferentes opciones del menú.
            switch (opcion)
            {
                case "1":
                    ListarPersonas(); // Llama al método para listar personas.
                    break;
                case "2":
                    continuar = false; // Cambia la variable para salir del bucle.
                    break;
                default:
                    // Maneja opciones no válidas mostrando un mensaje de error.
                    Console.WriteLine("Error, la opción no es válida. Por favor, intenta de nuevo.");
                    break;
            }
        } while (continuar); // Repite el bucle mientras continuar sea verdadero.
    }

    // Método para listar todas las personas.
    // Este método se encarga de solicitar al servicio la lista de personas y mostrarla al usuario.
    private void ListarPersonas()
    {
        // Informa al usuario que se están listando las personas.
        Console.WriteLine("Listando personas...");
        // Llama al método del servicio para obtener la lista de personas.
        _LogicaPersona.ListarPersonas();
    }
}
