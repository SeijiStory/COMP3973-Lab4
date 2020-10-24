using System;
using System.ComponentModel.DataAnnotations;

namespace lab4.Models {

	public class City {

		[Key]
		public int CityID { get; set; }

		[Display(Name="City")]
		public string CityName { get; set; }

		public int Population { get; set; }

		[Display(Name="Province Code")]
		public string ProvinceCode { get; set; }
		public Province Province { get; set; }
	}
}
