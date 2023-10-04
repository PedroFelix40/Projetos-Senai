using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.tarde.Domains
{
    [Table(nameof(Consulta))]
    public class Consulta
    {
        [Key]
        public Guid IdConsulta { get; set; } = Guid.NewGuid();

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data da consulta é obrigatório!")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "O prontuario da consulta é obrigatório!")]
        public string Prontuario { get; set; }

        //ref. tabela medico
        [Required(ErrorMessage = "O usuario é obrigatório!")]
        public Guid IdMedico { get; set; }
        [ForeignKey(nameof(IdMedico))]
        public Medico? Medico { get; set; }        
        
        //ref. tabela medico
        [Required(ErrorMessage = "O usuario é obrigatório!")]
        public Guid IdPaciente { get; set; }
        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }


    }
}
