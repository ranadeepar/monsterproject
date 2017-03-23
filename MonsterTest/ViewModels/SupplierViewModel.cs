using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonsterTest.ViewModels
{
	public class SupplierViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }

		[EmailAddress]
		public string Email { get; set; }
		public string Phone { get; set; }
		public IEnumerable<SelectListItem> SelectedGroups { get; set; }
	}
}