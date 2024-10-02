using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using taller_evaluativo_poo.AccesoDatos;

namespace taller_evaluativo_poo.AccesoDatos
{
    // 1. Encapsulación: Las propiedades ProductosPorFacturaId, Cantidad, Subtotal, FacturaId y ProductoId están encapsuladas
    //    mediante getters y setters, lo que permite controlar el acceso a estas propiedades.
    public class dtosProductosPorFactura
    {
        // Uso de Data Annotations (ORM): ProductosPorFacturaId es la clave primaria en la tabla ProductosPorFactura.
        [Key]
        public int IdProductosPorFactura { get; set; }
        public int Cantidad { get; set; }  // Propiedad Cantidad: Cantidad de productos en esta línea de la factura.
        public double Subtotal { get; set; }   // Propiedad Subtotal: Subtotal para los productos en esta línea de la factura.
        public int FacturaId { get; set; }   // Clave foránea que referencia a FacturaDatos

        // Relación UML - Asociación: Navegación hacia la clase FacturaDatos (muchos a uno).
        public required dtosFactura Factura { get; set; }
        public int ProductoId { get; set; } // Clave foránea que referencia a ProductoDatos.

        // Relación UML - Asociación: Navegación hacia la clase ProductoDatos (muchos a uno).
        public required dtosProducto Producto { get; set; }
    }
}