using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace taller_evaluativo_poo.AccesoDatos
{
    // 1. Encapsulación: Las propiedades FacturaId, Fecha, Numero, Total, PersonaId y Persona están encapsuladas mediante 
    //    getters y setters, lo que controla el acceso a los atributos internos. Esto asegura que los datos sean accedidos
    //    y modificados de manera controlada.
    public class dtosFactura   //Clase Independiente
    {
        // Uso de Data Annotations (ORM): FacturaId es la clave primaria de la tabla Facturas en la base de datos
        [Key]
        public int IdFactura { get; set; }
        public DateTime Fecha { get; set; }
        public long Numero { get; set; }
        public double Total { get; set; }

        // Clave foránea: PersonaId vincula la factura a una persona específica.
        public int IdPersona { get; set; } // Clave foránea de Persona
        public required dtosPersona Persona { get; set; } // Navegación - Asociación: Relación con PersonaDatos (uno a muchos).
        public required List<dtosProductosPorFactura> ProductosPorFactura { get; set; }   // Navegación - Composición: Relación con ProductosPorFacturaDatos (uno a muchos).
    }
}