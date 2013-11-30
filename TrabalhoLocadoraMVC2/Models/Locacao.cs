using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrabalhoLocadoraMVC2.Models
{
    public class Locacao
    {
        [Key]
        [Required]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [UIHint("ClienteDropDownList")]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        [Required]
        [UIHint("CopiaDropDownList")]
        [Display(Name = "Cópia")]
        public int CopiaId { get; set; }
        public virtual Copia Copia { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataLocacao { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DataDevolucao { get; set; }

        public bool PossuiCreditos()
        {
            if (this.Cliente.Saldo >= this.Copia.Titulo.TipoTitulo.Creditos)
            {
                this.Cliente.Saldo -= this.Copia.Titulo.TipoTitulo.Creditos;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}