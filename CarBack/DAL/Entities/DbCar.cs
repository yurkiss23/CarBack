using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarBack.DAL.Entities
{
    [Table("tblCars")]
    public class DbCar
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Image { get; set; }
        [ForeignKey("DbMaker")]
        public int MakerId { get; set; }
        public virtual DbMaker Maker { get; set; }
    }
}
