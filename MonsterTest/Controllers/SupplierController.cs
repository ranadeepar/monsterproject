using MonsterTest.Models;
using MonsterTest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.ObjectModel;
using MonsterTest.Services;
using MonsterTest.ViewModels;
using System.Web.Services;

namespace MonsterTest.Controllers
{
	public class SupplierController : Controller
	{
		public SupplierController()
		{
			_supplierRepository = SupplierRepository.Instance;
			HttpSession.SessionSuppliers = _supplierRepository.Get();
		}
		private SupplierRepository _supplierRepository;

		public ActionResult List()
		{
			if (HttpSession.SessionSuppliers == null)
				HttpSession.SessionSuppliers = _supplierRepository.Get();
			return View(HttpSession.SessionSuppliers);
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(SupplierViewModel model)
		{
			try
			{
				Supplier supplier = new Supplier();
				supplier.Id = HttpSession.SessionSuppliers.Select(a => a.Id).Max() + 1;
				supplier.Name = model.Name;
				supplier.Address = model.Address;
				supplier.Email = model.Email;
				supplier.Phone = model.Phone;

				List<Group> groups = new List<Group>();
				foreach (var group in model.SelectedGroups)
				{
					groups.Add(new Group() { Id = Convert.ToInt32(group.Value), Name = group.Text });
				}
				supplier.Groups = groups;

				HttpSession.SessionSuppliers.Add(supplier);
				return RedirectToAction("List");
			}
			catch
			{
				return View(model);
			}
		}

		public ActionResult Edit(int id)
		{
			var supplier = _supplierRepository.Get().Where(a => a.Id == id).FirstOrDefault();
			SupplierViewModel model = new SupplierViewModel();
			model.Id = supplier.Id;
			model.Name = supplier.Name;
			model.Email = supplier.Email;
			model.Address = supplier.Address;
			model.Phone = supplier.Phone;
			List<SelectListItem> selectedGroups = new List<SelectListItem>();
			foreach (var group in supplier.Groups)
			{
				selectedGroups.Add(new SelectListItem() { Text = group.Name, Value = group.Id.ToString(), Selected = true });
			}
			model.SelectedGroups = selectedGroups;
			return View(model);
		}

		[HttpPost]
		public ActionResult Edit(int id, SupplierViewModel supplier)
		{
			try
			{
				var original = HttpSession.SessionSuppliers.Where(a => a.Id == id).FirstOrDefault();
				original.Name = supplier.Name;
				original.Address = supplier.Address;
				original.Email = supplier.Email;
				original.Phone = supplier.Phone;
				List<Group> groups = new List<Group>();
				foreach (var group in supplier.SelectedGroups)
				{
					groups.Add(GroupRepository.Instance.Get().Where(a => a.Id == Convert.ToInt32(group.Value)).FirstOrDefault());
				}
				original.Groups = groups;

				return RedirectToAction("List");
			}
			catch (Exception ex)
			{
				return View(supplier);
			}
		}

		public ActionResult Delete(int id)
		{
			if (HttpSession.SessionSuppliers != null)
			{
				Supplier supplier = HttpSession.SessionSuppliers.Where(a => a.Id == id).FirstOrDefault();
				HttpSession.SessionSuppliers.Remove(supplier);
				return RedirectToAction("List");
			}
			return View("List");
		}
		[HttpPost]
		public ActionResult ValidateEmail(string email)
		{
			if (HttpSession.SessionSuppliers != null)
				return Json(HttpSession.SessionSuppliers.Where(a => a.Email == email).Any());
			return Json(_supplierRepository.Get().Where(a => a.Email == email).Any());
		}
	}
}
