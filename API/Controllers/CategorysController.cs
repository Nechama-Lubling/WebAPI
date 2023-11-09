using Entities;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorysController : ControllerBase
    {



        ICategoryService _categoryService;

        public CategorysController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/<CategorysController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        { 
          
                List<Category> categories = (List<Category>)await _categoryService.getCategories();
            if (categories.Count() == 0)
            {
                return NoContent();
            }

            return Ok(categories);

        }



        //// GET api/<CategorysController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<CategorysController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<CategorysController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CategorysController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
