﻿using Microsoft.AspNetCore.Mvc;
using ShopApp.Business.Abstract;
using ShopApp.Entities;
using ShopApp.WebUI.Models;

namespace ShopApp.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;

        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService; 
        }

        [HttpGet(), Route("/admin/products")]
        public IActionResult ProductList()
        {
            return View(new ProductListModel()
            {
                Products = _productService.GetAll()
            });
        }

        [HttpGet(), Route("/admin/createproduct")]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductModel model)
        {
            var entity = new Product()
            {
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                ImageUrl = model.ImageUrl
            };
            _productService.Create(entity);
            return RedirectToAction("ProductList");
        }


        [HttpGet(), Route("/admin/products/{id:int?}")]
        public IActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _productService.GetById((int)id);
            if (entity == null)
            {
                return NotFound();
            }

            return View(new ProductModel()
            {
                Id = entity.Id,
                Name = entity.Name, 
                Price =entity.Price,
                ImageUrl = entity.ImageUrl,
                Description = entity.Description
            });
        }

        [HttpPost()]
        public IActionResult EditProduct(ProductModel model)
        {
            var entity = _productService.GetById(model.Id);

            if (entity == null)
            {
                return NotFound();
            }

            entity.Name = model.Name;
            entity.Price = model.Price;
            entity.Description = model.Description;
            entity.ImageUrl = model.ImageUrl;

            _productService.Update(entity);

            return RedirectToAction("PropductList");
        }

        [HttpPost()] 
        public IActionResult DeleteProduct(int productId)
        {
            var entity = _productService.GetById(productId);

            if (entity != null)
            {
                _productService.Delete(entity);
            }

            return RedirectToAction("ProductList");
        }

        
        public IActionResult CategoryList()
        {
            return View(new CategoryListModel()
            {
                Categories = _categoryService.GetAll()
            });
        }

        [HttpGet()]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost()]
        public IActionResult CreateCategory(CategoryModel model)
        {
            var entity = new Category()
            {
                Name = model.Name,
            };
            _categoryService.Create(entity);
            return RedirectToAction("CategoryList");
        }

        [HttpGet()]
        public IActionResult EditCategory(int id)
        {
            var entity = _categoryService.GetById(id);

            return View(new CategoryModel()
            {
                Id = entity.Id,
                Name=entity.Name,
            });
        }

        [HttpPost()]
        public IActionResult EditCategory(CategoryModel model)
        {
            var entity = _categoryService.GetById(model.Id);

            if (entity == null)
            {
                return NotFound();
            }

            entity.Name = model.Name;
            _categoryService.Update(entity);

            return RedirectToAction("CategoryList");
        }

        [HttpPost()]
        public IActionResult DeleteCategory(int categoryId)
        {
            var entity = _categoryService.GetById(categoryId);

            if (entity != null) 
            {
                _categoryService.Delete(entity);
            }

            return RedirectToAction("CategoryList");
        } 
    }
}