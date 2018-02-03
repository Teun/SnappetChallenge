using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SnappetChallenge.Core;

namespace SnappetChallenge.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageProvider imageProvider;

        public ImageController(IImageProvider imageProvider)
        {
            this.imageProvider = imageProvider;
        }
        
        public IActionResult GetImage(int imageId)
        {
            var image = imageProvider.FindImage(imageId);
            if (image == null)
                return NotFound();
            return Redirect(image.ImageUrl);
        }
    }
}