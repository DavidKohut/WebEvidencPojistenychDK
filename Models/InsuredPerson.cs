namespace WebEvidencPojistenychDK.Models
{
	public class InsuredPerson
	{
		public int Id { get; set; }
		/// <summary>
		/// First name of insured person
		/// </summary>
		public string FirstName { get; set; } = "";

		/// <summary>
		/// Surname of insured person
		/// </summary>
		public string Surname { get;  set;}="";

		/// <summary>
		/// Age of insured person
		/// </summary>
		public int Age { get;  set; } = 0;

		/// <summary>
		/// E-mail adress of insured person
		/// </summary>
		public string Email { get;  set; } = "";

		/// <summary>
		/// Phone number of insured person
		/// </summary>
		public int PhoneNumber { get;  set; } = 0;
		
		/// <summary>
		///Streed adress of insured person. Included  Street and House number
		/// </summary>
		public string Street { get;  set; } = "";

		/// <summary>
		/// City of insured person
		/// </summary>
		public string City { get; set; } = "";
		/// <summary>
		/// Zip code of insured person
		/// </summary>
		public int PostalCode { get; set; } = 0;

		


	}
}
