using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Web;

namespace TrabalhoLocadoraMVC2.Models
{
    public class Titulo
    {
        [Key]
        [Required]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public String Nome { get; set; }

        [Required]
        public string Sinopse { get; set; }

        [Required]
        [StringLength(100)]
        public string OrigemTitulo { get; set; }

        [Required]
        public short Ano { get; set; }

        public int TipoTituloId { get; set; }
        public virtual TipoTitulo TipoTitulo { get; set; }

        public virtual ICollection<Genero> Generos { get; set; }
        public IEnumerable<string> ArrayGeneros = new List<string>();

        public virtual ICollection<Ator> Atores { get; set; }
        public IEnumerable<string> ArrayAtores = new List<string>();

        public virtual ICollection<Copia> Copias { get; set; }

        public string DescricaoAtores
        {
            get
            {
                if (this.Atores.Count > 0)
                {
                    StringBuilder content = new StringBuilder();

                    foreach (var ator in this.Atores)
                    {
                        content.AppendFormat("{0}, ", ator.Nome);
                    }

                    int virgulaEEspaco = content.Length - 2;
                    return content.Remove(virgulaEEspaco, 2).ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public string DescricaoGeneros
        {
            get
            {
                if (this.Generos.Count > 0)
                {
                    StringBuilder content = new StringBuilder();

                    foreach (var genero in this.Generos)
                    {
                        content.AppendFormat("{0}, ", genero.Descricao);
                    }

                    int virgulaEEspaco = content.Length - 2;
                    return content.Remove(virgulaEEspaco, 2).ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
}