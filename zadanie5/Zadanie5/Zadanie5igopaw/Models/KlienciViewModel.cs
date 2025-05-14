using System.ComponentModel;

namespace Zadanie5.Models
{
	public class KlienciViewModel
	{
		[DisplayName("Id")]
		public int Id { get; set; }

		[DisplayName("Name")]
		public string Name { get; set; }
		[DisplayName("Surname")]
		public string Surname { get; set; }

		[DisplayName("PESEL")]
		public string PESEL { get; set; }

		[DisplayName("BirthYear")]
		public int BirthYear { get; set; }

		[DisplayName("Plec")]
		public int Plec { get; set; }

	
	}
}
