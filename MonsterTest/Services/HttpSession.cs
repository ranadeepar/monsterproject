using MonsterTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterTest.Services
{
	public class HttpSession
	{
		public static List<Supplier> SessionSuppliers
		{

			get
			{
				if (HttpContext.Current.Session["Suppliers"] != null)
					return HttpContext.Current.Session["Suppliers"] as List<Supplier>;
				return null;
			}
			set
			{
				HttpContext.Current.Session["Suppliers"] = value;
			}
		}
		public static List<Group> SessionGroups
		{
			get
			{
				if (HttpContext.Current.Session["Groups"] != null)
					return HttpContext.Current.Session["Groups"] as List<Group>;
				return null;
			}
			set
			{
				HttpContext.Current.Session["Groups"] = value;
			}
		}
	}
}