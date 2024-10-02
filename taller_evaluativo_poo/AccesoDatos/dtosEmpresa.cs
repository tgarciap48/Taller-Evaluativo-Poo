using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace taller_evaluativo_poo.AccesoDatos
{
    // Encapsulación: Las propiedades IdEmpresa, Codigo y Nombre están encapsuladas con getters y setters. 

    public class dtosEmpresa //Clase Independiente
    {
        // Uso de Data Annotations (ORM): EmpresaId es la clave primaria en la base de datos
        [Key]
        public int IdEmpresa { get; set; }

        // Propiedad requerida: Código único que identifica a la empresa.
        public required string Codigo { get; set; }

        // Propiedad requerida: Nombre de la empresa.
        public required string Nombre { get; set; }
    }
}