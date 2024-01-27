using System.ComponentModel.DataAnnotations;

namespace WebEvidencPojistenychDK.Models
{
	public class InsuredPerson
	{
		public int Id { get; set; }
		/// <summary>
		/// First name of insured person
		/// </summary>
		[Required(ErrorMessage ="Zadejte prosím křestní jméno.")]
		[Range(2, 40, ErrorMessage = "Jméno musí mít alespoň 2 písmena")]

		public string FirstName { get; set; } = "";

		/// <summary>
		/// Surname of insured person
		/// </summary>
		[Required(ErrorMessage ="Zadejte prosím příjmení.")]
		[Range(2,20,ErrorMessage ="Příjmení musí mít alespoň 2 písmena")]
		public string Surname { get;  set;}="";

		/// <summary>
		/// Age of insured person
		/// </summary>
		[Required(ErrorMessage = "Zadejte prosím věk.")]
		public int Age { get;  set; } = 0;

		/// <summary>
		/// E-mail adress of insured person
		/// </summary>
		[Required(ErrorMessage = "Zadejte prosím e-mail.")] 
		public string Email { get;  set; } = "";

		/// <summary>
		/// Phone number of insured person
		/// </summary>
		[Required(ErrorMessage = "Zadejte prosím telefonní číslo.")]
		[Range(100000000,999999999,ErrorMessage ="Zadejte platné telefonní číslo bez předvolby.")]
		public int PhoneNumber { get;  set; } = 0;
		
		/// <summary>
		///Streed adress of insured person. Included  Street and House number
		/// </summary>
		[Required(ErrorMessage = "Zadejte prosím zadejte prosím adresu.")]
		[Range(2,40,ErrorMessage ="Adresa musí mít alespoň 2 písmena")]
		public string Street { get;  set; } = "";

		/// <summary>
		/// City of insured person
		/// </summary>
		[Required(ErrorMessage = "Zadejte prosím město.")] 
		[Range(2,30,ErrorMessage ="Město musí mít alespoň 2 písmena")]
		public string City { get; set; } = "";
		/// <summary>
		/// Zip code of insured person
		/// </summary>
		[Required(ErrorMessage = "Zadejte prosím poštovní směrovací číslo.")]
		[Range(10000, 99999, ErrorMessage ="Zadejte prosím plátné poštovní směrovací číslo bez mezer")]
		public int PostalCode { get; set; } = 0;
		
		/// <summary>
		/// Collection of all insurances for InsuredPerson
		/// </summary>
		public virtual ICollection<Insurance>? Insurances { get; set; }


	}
}
