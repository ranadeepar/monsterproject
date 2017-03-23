using MonsterTest.Models;
using MonsterTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterTest.Repositories
{
	public class GroupRepository
	{
		private GroupRepository()
		{
			_groups = new List<Group>()
			{
				new Group()
				{
					Id = 1,
					Name = "Cleaners",
					SupplierId = 1
				},
				new Group()
				{
					Id = 2,
					Name = "Office supply",
					SupplierId = 1
				},
				new Group()
				{
					Id = 3,
					Name = "Telephone service",
					SupplierId = 2
				},
				new Group()
				{
					Id = 4,
					Name = "Security",
					SupplierId = 2
				}
			};
		}
		private List<Group> _groups;

		private static GroupRepository _groupRepository;
		public static GroupRepository Instance
		{
			get
			{
				if (_groupRepository == null)
					_groupRepository = new GroupRepository();
				return _groupRepository;
			}
		}

		public List<Group> Get()
		{
			if (HttpSession.SessionGroups != null)
				return HttpSession.SessionGroups;
			return _groups;
		}
	}
}