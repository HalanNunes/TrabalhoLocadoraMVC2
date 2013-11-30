using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrabalhoLocadoraMVC2.Models
{
    public class Copia
    {
        [Key]
        [Required]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [UIHint("TituloDropDownList")]
        [Display(Name = "Título")]
        public int TituloId { get; set; }
        public virtual Titulo Titulo { get; set; }

        [Required]
        [UIHint("TipoCopiaDropDownList")]
        [Display(Name = "Cópia")]
        public int TipoCopiaId { get; set; }
        public virtual TipoCopia TipoCopia { get; set; }

        public virtual ICollection<Locacao> Locacoes { get; set; }

        public string Descricao
        {
            get
            {
                return string.Format("{0} [{1}]", this.Titulo.Nome, this.TipoCopia.Descricao);
            }
        }
    }
}