using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lab4.Models {

	public class Province {

		[Key]
		[MaxLength(4)]
		[Display(Name="Province Code")]
		public string ProvinceCode { get; set; }

		[Display(Name="Province Name")]
		public string ProvinceName { get; set; }

		public List<City> Cities { get; set; }
	}

}
