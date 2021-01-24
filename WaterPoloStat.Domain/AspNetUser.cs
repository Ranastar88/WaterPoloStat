using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WaterPoloStat.Domain
{
	public class AspNetUser : IdentityUser
	{
		[Required]
		[MaxLength(450)]
		public string LicenzaId { get; set; }

		[MaxLength(250)]
		public string Nome { get; set; }
		[MaxLength(250)]
		public string Cognome { get; set; }
	}
}
