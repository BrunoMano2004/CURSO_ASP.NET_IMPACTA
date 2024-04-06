using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Projeto.AspNet._05.BackEnd.WebAPI.Controllers.Data.Entities
{
    public class Curso
    {
        [Key]

        public int CursoId { get; set; }
        public string? CursoNome { get; set; }
        public double? CursoMensalidade { get; set; }
        //[JsonIgnore]
        [ForeignKey("Curso_FK")]
        public int EstudanteId { get; set; }
        public int EstudanteRA { get; set; }
        public Estudante? Estudante { get; set; }

    }
}
