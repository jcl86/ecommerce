using Ecommerce.Domain;
using Ecommerce.Model;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route(Endpoints.Products.Base)]
    public class ProductController : ControllerBase
    {
        private readonly ProductCreator creator;
        private readonly ProductFinder finder;
        private readonly ProductLister lister;
        private readonly ProductUpdater updater;
        private readonly ProductEraser eraser;

        public ProductController(ProductCreator creator, 
            ProductFinder finder, 
            ProductLister lister, 
            ProductUpdater updater, 
            ProductEraser eraser)
        {
            this.creator = creator;
            this.finder = finder;
            this.lister = lister;
            this.updater = updater;
            this.eraser = eraser;
        }

        [HttpGet, Route("{productId}")]
        public async Task<Model.Product> Get(Guid id)
        {
            var entity = await finder.Find(id);
            var result = entity.Map();
            return result;
        }

        [HttpGet]
        public async Task<IEnumerable<Model.Product>> GetAll()
        {
            var entityList = await lister.ToList();
            var result = entityList.Map();
            return result;
        }

        [HttpPost]
        public async Task<Model.Product> Create(Model.CreateProduct dto)
        {
            var entity = await creator.Create(dto);
            var result = entity.Map();
            return result;
        }

        [HttpPatch, Route("{productId}")]
        public async Task<IActionResult> Update(Guid productId, Model.UpdateProduct dto)
        {
            await updater.Update(productId, dto);
            return NoContent();
        }
        
        [HttpDelete, Route("{productId}")]
        public async Task<IActionResult> Delete(Guid productId)
        {
            await eraser.Delete(productId);
            return NoContent();
        }
    }
}
