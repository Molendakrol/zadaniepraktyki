using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klienci.Data
{
	
    public class Klienci
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

		[Column(TypeName = "varchar(50)")]
		public string Name { get; set; }

		[Column(TypeName = "varchar(50)")]
		public string Surname { get; set; }

		[Column(TypeName = "varchar(11)")]
		public string PESEL { get; set; }
		
		public int BirthYear { get; set; }

        public int Plec { get; set; }

    }
}
