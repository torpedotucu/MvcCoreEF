using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCoreEF.Models
{
    [Table("DEPARTAMENTOS")]
    public class Departamento
    {
        [Key]
        [Column("DEPT_NO")]
        public int Dept_no { get; set; }
        [Column("DNOMBRE")]
        public string Nombre { get; set; }
        [Column("LOC")]
        public string Localidad { get; set; }

    }
}
