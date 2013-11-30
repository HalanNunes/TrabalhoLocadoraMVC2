using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrabalhoLocadoraMVC2.Models
{
    public class Cliente
    {
        [Key]
        [Required]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public String Nome { get; set; }

        [Required]
        [RegularExpression("F|M")]
        [StringLength(1)]
        public String Sexo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Nascimento { get; set; }

        [StringLength(200)]
        public String Endereco { get; set; }

        public int NumeroEndereco { get; set; }

        [StringLength(50)]
        public String Bairro { get; set; }

        [StringLength(50)]
        public String Complemento { get; set; }

        [StringLength(50)]
        public String Cidade { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Saldo { get; set; }

        public virtual ICollection<Locacao> Locacoes { get; set; }
    }
}