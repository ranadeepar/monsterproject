using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterTest.Models
{
	public class Group
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int SupplierId { get; set; }
		public Supplier Supplier { get; set; }
	}
}