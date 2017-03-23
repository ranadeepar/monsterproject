using MonsterTest.Models;
using MonsterTest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonsterTest.Services
{
	public class ViewDataService
	{
		private static GroupRepository _groupRepository;
		public static IEnumerable<SelectListItem> GetGroups()
		{
			_groupRepository = GroupRepository.Instance;
			List<SelectListItem> groups = new List<SelectListItem>();
			if (HttpSession.SessionGroups != null)
			{
				foreach (var item in HttpSession.SessionGroups)
				{
					groups.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
				}
				return groups;
			}
			else
			{
				foreach (var item in _groupRepository.Get())
				{
					groups.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
				}
				return groups;
			}
		}
	}
}