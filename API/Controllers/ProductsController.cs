using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        IProductService _productService;
        IMapper _mapper;

        public ProductsController(IProductService productService,IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }




        // GET: api/<ProductsController>
        [HttpGet]
        public  async Task<ActionResult<IEnumerable<ProductDTO>>> Get( string? desc, int? minPrice,  int? maxPrice, [FromQuery] int?[] categoryIds, int position = 1, int skip = 8)
        {
            IEnumerable<Product> products = await _productService.getProducts(position, skip, desc, minPrice, maxPrice, categoryIds);
            IEnumerable<ProductDTO> productsDTO = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
            if (productsDTO.Count() == 0)
            {
                return NoContent();
            }

            return Ok(productsDTO);

        }



    }
}
