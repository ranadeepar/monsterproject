using MonsterTest.Models;
using MonsterTest.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace MonsterTest.Repositories
{
	public class SupplierRepository
	{
		private SupplierRepository()
		{
			_suppliers = new List<Supplier>()
			{
				new Supplier()
				{
					Id = 1,
					Name ="Supplier 1",
					Address ="Supplier 1 address",
					Email ="supplier1@supplier1.com",
					Phone ="0111222333",
					Groups = GroupRepository.Instance.Get().Where(a=>a.SupplierId == 1).ToList()
				},
				new Supplier()
				{
					Id = 2,
					Name = "Supplier 2",
					Address = "Supplier 2 address",
					Email = "supplier2@supplier2.com",
					Phone = "0222333444",
					Groups = GroupRepository.Instance.Get().Where(a=>a.SupplierId == 2).ToList()
				}
			};
		}
		private List<Supplier> _suppliers;

		private static SupplierRepository _supplierRepository;
		public static SupplierRepository Instance
		{
			get
			{
				if (_supplierRepository == null)
					_supplierRepository = new SupplierRepository();
				return _supplierRepository;
			}
		}
		public List<Supplier> Get()
		{
			if (HttpSession.SessionSuppliers != null)
				return HttpSession.SessionSuppliers;
			return _suppliers;
		}
		public void Add(Supplier supplier)
		{
			if (HttpSession.SessionSuppliers != null)
			{
				HttpSession.SessionSuppliers.Add(supplier);
			}
		}
	}
}