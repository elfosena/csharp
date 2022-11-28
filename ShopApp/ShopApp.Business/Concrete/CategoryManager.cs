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
			_categoryDal.Create(category);
		}

		public void Delete(Category category)
		{
			_categoryDal.Delete(category);
		}

		public List<Category> GetAll()
		{
			return _categoryDal.GetAll();
		}

		public Category GetById(int id)
		{
			return _categoryDal.GetById(id);
		}

		public Category GetByIdWithProducts(int id)
		{
			return _categoryDal.GetByIdWithProducts(id);
		}

		public void Update(Category category)
		{
			_categoryDal.Update(category);
		}

		//ask dilek
		void ICategoryService.DeleteFromCategory(int categoryId, int productId)
		{
            _categoryDal.DeleteFromCategory(categoryId, productId);
        }
	}
}
