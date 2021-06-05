using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Canvas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CanvasApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CanvasController
    {
        private readonly ICanvas _canvas;
        private readonly ILogger<CanvasController> _logger;

        public CanvasController(ICanvas canvas, ILogger<CanvasController> logger)
        {
            _canvas = canvas;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetDocumentBytes()
        {
            var byteArray = _canvas.GetCanvasData();

            return new FileContentResult(byteArray, "image/png");
        }
    }
}
