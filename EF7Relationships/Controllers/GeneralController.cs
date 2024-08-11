using EF7Relationships.Data;
using Microsoft.AspNetCore.Mvc;

namespace EF7Relationships.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralController : ControllerBase
    {
        private readonly DataContext _context;
        public GeneralController(DataContext context)
        {
            this._context = context;
        }
    }
}
