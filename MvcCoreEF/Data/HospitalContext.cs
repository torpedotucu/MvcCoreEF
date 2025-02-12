using Microsoft.EntityFrameworkCore;
using MvcCoreEF.Models;

namespace MvcCoreEF.Data
{
    public class HospitalContext:DbContext
    {
        /*
         * TENDREMOS UN CONSTRUCTOR QUE RECIBIRA LAS OPCIONES 
         * DE INICIO PARA EL CONTEXT, COMO LA CADENA DE CONEXION
         */
        public HospitalContext(DbContextOptions<HospitalContext> options)
            :base(options)
        { }

        /*
         * EN ESTA CLASE ESTARAN LOS MODELOS QUE SERAN LOS QUE SE UTILICEN MEDIANTE LINQ
         */
        public DbSet<Hospital> Hospitales { get; set; }

    }
}
