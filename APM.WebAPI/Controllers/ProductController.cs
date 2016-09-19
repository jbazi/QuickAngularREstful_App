using APM.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData;

namespace APM.WebAPI.Controllers
{
    [EnableCorsAttribute("http://localhost:64566/", "*", "*")]
    public class ProductController : ApiController
    {
        // GET: api/Product
        [EnableQuery()] //the enable query is an action filter
        public IQueryable<Product> Get()
        {
            var productRepository = new ProductRepository();
            return productRepository.Retrieve().AsQueryable();
        }

        //get by search string
        public IEnumerable<Product> Get(string search)
        {
            var productRepository = new ProductRepository();
            var products = productRepository.Retrieve();
            return products.Where(p => p.ProductCode.Contains(search));
        }

        // GET: api/Product/5
        public Product Get(int id)
        {
            Product product;
            var productRepository = new ProductRepository();
            if (id > 0)
            {
                var products = productRepository.Retrieve();
                product = products.FirstOrDefault(p => p.ProductId == id);
            }
            else
            {
                product = productRepository.Create();
            }
            return product;
        }

        // POST: api/Product
        public void Post([FromBody]Product product)
        {
            var productRepository = new Models.ProductRepository();
            var newProduct = productRepository.Save(product);
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]Product product)
        {
            var productRepository = new Models.ProductRepository();
            var updatedProduct = productRepository.Save(id, product);
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
