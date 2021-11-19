
using EFData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAppCRUD.Controllers
{
    public abstract class AbstractController  
        :  Controller
    {
        protected readonly BokforingContext _context;
        protected readonly ILogger<AbstractController> _logger;
        protected AbstractController(BokforingContext context)  
        {
            _context = context;
        }
        protected AbstractController(ILogger<AbstractController> logger)
        {
            _logger = logger;
        }
    }
}
