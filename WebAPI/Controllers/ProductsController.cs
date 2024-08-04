using Business.Abstracts;
using Business.Concretes;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;
using Entities.Concretes;
    
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //c sharp da attirbute java da annatation... bu classın controller oldugunu söyler
    public class ProductsController : ControllerBase
    {
        IProductService _productService;
        
        public ProductsController(IProductService productService)
        {
            _productService = productService; //IoC  
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            Thread.Sleep(500);
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpPost("add")]
        public IActionResult Add(Product product) 
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id) 
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);  
        }

        [HttpGet("getallbycategory")]
        public IActionResult GetAllCategoryId(int id)
        {
            var result = _productService.GetAllByCategory(id);
            if(result.Success)
            { 
            return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getproductdetails")]
        public IActionResult GetProductDetails()
        {
            var result = _productService.GetProductDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallunitprice")]
        public IActionResult GetAllUnitPrice(decimal min , decimal max)
        {
            var result = _productService.GetAllUnitPrice(min,max);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Product product)
        {
            var result = _productService.Delete(product);
            if (result.Success) 
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
