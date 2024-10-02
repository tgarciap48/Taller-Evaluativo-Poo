﻿using Microsoft.EntityFrameworkCore;
using taller_evaluativo_poo.AccesoDatos;
using taller_evaluativo_poo.LogicaNegocio;
using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Inicia un bloque "using" para asegurar que el contexto de datos se libere adecuadamente.
            using (var contexto = new Datos())
            {
                // Ejecuta las migraciones pendientes para que la base de datos esté alineada con el modelo actual.
                contexto.Database.Migrate();
                Console.WriteLine("Las migraciones se han aplicado exitosamente y la base de datos está lista para usarse.");

                // Crea instancias de los servicios que gestionan la lógica de negocio, utilizando el contexto de datos.
                var clienteService = new LogicaCliente(contexto);
                var empresaService = new LogicaEmpresa(contexto);
                var facturaService = new LogicaFactura(contexto);
                var personaService = new LogicaPersona(contexto);
                var productosPorFacturaService = new LogicaProductosPorFactura(contexto);
                var productoService = new LogicaProducto(contexto);
                var vendedorService = new LogicaVendedor(contexto);

                // Inicializa las interfaces de usuario para interactuar con los distintos servicios.
                var clienteUI = new CRUDCliente(clienteService);
                var empresaUI = new CRUDEmpresa(empresaService);
                var facturaUI = new CRUDFactura(facturaService);
                var personaUI = new CRUDPersona(personaService);
                var productosPorFacturaUI = new CRUDProductosPorFactura(productosPorFacturaService);
                var productoUI = new CRUDProducto(productoService);
                var vendedorUI = new CRUDVendedor(vendedorService);

                // Ciclo principal que permite al usuario gestionar la aplicación.
                bool continuar = true;
                while (continuar)
                {
                    // Presenta un menú de opciones al usuario para seleccionar la entidad que desea gestionar.
                    Console.WriteLine("Ingresa el número para administrar la entidad:");
                    Console.WriteLine("1. Cliente");
                    Console.WriteLine("2. Empresa");
                    Console.WriteLine("3. Factura");
                    Console.WriteLine("4. Persona");
                    Console.WriteLine("5. Producto por Factura");
                    Console.WriteLine("6. Producto");
                    Console.WriteLine("7. Vendedor");
                    Console.WriteLine("8. Salir");
                    Console.Write("Ingrese la opcion: ");
                    string? eleccion = Console.ReadLine();

                    // Control de flujo que ejecuta la lógica correspondiente según la elección del usuario.
                    switch (eleccion)
                    {
                        case "1":
                            clienteUI.MenuPrincipal();  // Abre el menú para gestionar clientes
                            break;
                        case "2":
                            empresaUI.MenuPrincipal();  // Abre el menú para gestionar empresas
                            break;
                        case "3":
                            facturaUI.MenuPrincipal();  // Abre el menú para gestionar facturas
                            break;
                        case "4":
                            personaUI.MenuPrincipal();  // Abre el menú para gestionar personas
                            break;
                        case "5":
                            productosPorFacturaUI.MenuPrincipal();  // Abre el menú para gestionar productos por factura
                            break;
                        case "6":
                            productoUI.MenuPrincipal();  // Abre el menú para gestionar productos
                            break;
                        case "7":
                            vendedorUI.MenuPrincipal();  // Abre el menú para gestionar vendedores
                            break;
                        case "8":
                            continuar = false;  // Termina el bucle y cierra la aplicación
                            break;
                        default:
                            Console.WriteLine("Error, la opción no es correcta.");  // Notifica al usuario sobre opciones inválidas
                            break;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Captura y muestra cualquier error que ocurra durante la ejecución del programa.
            Console.WriteLine($"Error durante la ejecución del programa: {ex.Message}");
        }
    }
}
