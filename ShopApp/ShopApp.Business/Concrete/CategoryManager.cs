using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopApp.Business.Abstract;
using ShopApp.Entities;
using ShopApp.DataAccess.Abstract;

namespace ShopApp.Business.Concrete
{
	public class CategoryManager : ICategoryService
	{
		private ICategoryDal _categoryDal;
		public CategoryManager(ICategoryDal categoryDal)
		{
			_categoryDal = categoryDal;
		}

		public void Create(Category category)
		{
			throw new NotImplementedException();
		}

		public void Delete(Category category)
		{
			throw new NotImplementedException();
		}

		public List<Category> GetAll()
		{
			return _categoryDal.GetAll();
		}

		public void Update(Category category)
		{
			throw new NotImplementedException();
		}
	}
}
