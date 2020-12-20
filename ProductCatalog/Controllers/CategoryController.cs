using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Models;
using ProductCatalog.Repositories;

namespace ProductCatalog.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryRepository _repository;

        public CategoryController(CategoryRepository repository)
        {
            _repository = repository;
        }

        [Route("v1/categories")]
        [HttpGet]
        [ResponseCache(Duration = 3600)]        
        // Dentro do header da requisição "ResponseCache" executar => Cache-Control: public,max-age=60 
        // cache no lado do cliente => [ResponseCache(Location = ResponseCacheLocation.Client,Duration = 60)]  
        public IEnumerable<Category> Get()
        {
            return _repository.Get();
        }

        [Route("v1/categories/{id}")]
        [HttpGet]
        public Category Get(int id)
        {
            return _repository.Get(id);
        }

        [Route("v1/categories/{id}/products")]
        [HttpGet]
        [ResponseCache(Duration = 30)]
        public IEnumerable<Product> GetProducts(int id)
        {
            return _repository.GetProducts(id);
        }

        [Route("v1/categories")]
        [HttpPost]
        public Category Post([FromBody] Category category)
        {
            return _repository.Save(category);
        }

        [Route("v1/categories")]
        [HttpPut]
        public Category Put([FromBody] Category category)
        {
            return _repository.Update(category);
        }

        [Route("v1/categories")]
        [HttpDelete]
        public Category Delete([FromBody] Category category)
        {
            return _repository.Excludes(category);
        }
    }
}
