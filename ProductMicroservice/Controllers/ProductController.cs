using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Model;
using ProductMicroservice.Repository;
using System.Threading.Tasks;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region variable
        private readonly IProductRepository _productRepository;
        #endregion

        #region constructor
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion

        #region method
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            var product= await _productRepository.GetProduct();
            if(product!=null)
                return Ok(product);
            return NotFound();
        }

        [HttpGet]
        [Route("Details")]
        public async Task<IActionResult> Details(int id)
        {
            var product = await _productRepository.GetProductDetail(id);
            if(product!=null)
                return Ok(product);
            return NotFound();
        }

        [HttpGet]
        [Route("SearchProduct")]
        public async Task<IActionResult> SearchProduct(string name)
        {
            var product = await _productRepository.SearchProduct(name);
            if (product != null)
                return Ok(product);
            return NotFound();
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(Product product)
        {
            bool resp = await _productRepository.AddProduct(product);
            if (resp)
                return Ok();
            return StatusCode(500);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(Product product)
        {
            bool resp = await _productRepository.UpdateProduct(product);
            if (resp)
                return Ok();
            return StatusCode(500);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteAll()
        {
            bool resp = await _productRepository.DeleteAllProduct();
            if (resp)
                return Ok();
            return StatusCode(500);
        }

        [HttpDelete]
        [Route("DeleteById")]
        public async Task<IActionResult> DeleteById(int id)
        {
            bool resp = await _productRepository.DeleteById(id);
            if (resp)
                return Ok();
            return StatusCode(500);
        }


        #endregion
    }
}
