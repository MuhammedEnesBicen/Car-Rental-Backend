using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        IImageService _imageService;

        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost("add")]
        public IActionResult Add(Image image)
        {
            
           
            var result = _imageService.Add(image);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycarid")]
        public IActionResult GetAll(int carId)
        {
            var result = _imageService.GetByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("deletebycarid")]
        public IActionResult DeleteByCarId(int carId)
        {
            var result =_imageService.DeleteByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

            //var temp = _imageService.GetByCarId(carId);

            //if (temp.Success)
            //{
            //    List<Image> images = temp.Data;
            //    foreach (var item in images)
            //    {
            //        _imageService.DElete(item);
            //    }

            //}


            //return Ok("deleteting images succesfull");


        }
    }
}
