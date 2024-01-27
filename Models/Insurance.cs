using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebEvidencPojistenychDK.Models
{
    public class Insurance
    {
        public int Id { get; set; }
        
     
        public int? InsuredPersonId { get; set; }

        [Required(ErrorMessage = "Je nezbytné vyplnit typ pojištění")]
        public string Type { get; set; } = "";

        [Range(0, int.MaxValue, ErrorMessage = "Pojistná částka musí být větší než 0")]
        public int Value { get; set; } = 0;

        [ForeignKey("InsuredPersonId")]
        public InsuredPerson? InsuredPerson { get; set; } 

         

		public override string ToString()
		{
			return $"Id: {Id}, InsuredPersonId: {InsuredPersonId}, Type: {Type}, Value: {Value}";
		}

	}
}
