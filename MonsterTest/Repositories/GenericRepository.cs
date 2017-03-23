using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterTest.Repositories
{
	public class GenericRepository<T> where T : class
	{
		protected GenericRepository(List<T> list)
		{
			_list = list;
		}
		private List<T> _list;
		public List<T> Get()
		{
			return _list;
		}
		public bool Add(T entity)
		{
			if (entity != null)
			{
				_list.Add(entity);
				return true;
			}
			return false;
		}
		public bool AddRange(List<T> entities)
		{
			if (entities.Any())
			{
				_list.AddRange(entities);
				return true;
			}
			return false;
		}

		public bool Remove(T entity)
		{
			if (entity != null)
			{
				return _list.Remove(entity);
			}
			return false;
		}
		public bool RemoveRange(List<T> entities)
		{
			if (entities != null)
			{
				foreach (var entity in entities)
				{
					_list.Remove(entity);
				}
				return true;
			}
			return false;
		}
	}
}