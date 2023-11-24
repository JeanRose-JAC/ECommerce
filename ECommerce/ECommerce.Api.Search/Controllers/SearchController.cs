using ECommerce.Api.Search.Interfaces;
using ECommerce.Api.Search.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Api.Search.Controllers
{
    /*
    * Course: 		Web Programming 3
    * Assessment: 	Milestone 3
    * Created by: 	JEAN ROSE MANIGBAS - 2127668
    * Date: 		24 NOV 2023
    * Class Name: 	SearchController.cs
    * Description: 	The search controller class handles the functions that get called when a http request is made to the api.
    */
    [Route("api/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService search)
        {
            this.searchService = search;
        }

        [HttpPost]
        public async Task<IActionResult> SearchAsync (SearchTerm term)
        {
            var result = await searchService.SearchAsync(term.CustomerId);
            if(result.IsSuccess)
            {
                return Ok(result.SearchResults);
            }
            return NotFound();
        }
    }
}
