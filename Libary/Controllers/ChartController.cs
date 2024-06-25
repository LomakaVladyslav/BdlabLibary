using Libary.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LibraryWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private readonly DblibaryContext _context;

        public ChartController(DblibaryContext context)
        {
            _context = context;
        }

        [HttpGet("JsonData")]
        public JsonResult JsonData()
        {
            var categories = _context.Publications.ToList();
            List<object> catBook = new List<object>();
            catBook.Add(new[] { "Категорія", "Кількість книжок" });
            foreach (var c in categories)
            {
                catBook.Add(new object[] { c.BookName, c.Price });
            }
            return new JsonResult(catBook);
        }

        [HttpGet("PublicationAutorData")]
        public JsonResult PublicationAutorData()
        {
            var publicationAutorCounts = _context.PublicationAutors
                .GroupBy(pa => pa.Publication.BookName)
                .Select(g => new
                {
                    PublicationName = g.Key,
                    Count = g.Count()
                })
                .ToList();

            List<object> pubAutorData = new List<object>();
            pubAutorData.Add(new[] { "Publication", "Number of Authors" });
            foreach (var item in publicationAutorCounts)
            {
                pubAutorData.Add(new object[] { item.PublicationName, item.Count });
            }

            return new JsonResult(pubAutorData);
        }
    }
}