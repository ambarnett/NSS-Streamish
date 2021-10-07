using Microsoft.AspNetCore.Mvc;
using System;
using Streamish.Models;
using Streamish.Repositories;

namespace Streamish.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IVideoRepository _videoRepositoy;

        public VideoController(IVideoRepository videoRepository)
        {
            _videoRepositoy = videoRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_videoRepositoy.GetAll());
        }

        [HttpGet("GetWithComments")]
        public IActionResult GetWithComments()
        {
            var videos = _videoRepositoy.GetAllWithComments();
            return Ok(videos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var video = _videoRepositoy.GetById(id);
            if(video == null)
            {
                return NotFound();
            }
            return Ok(video);
        }

        [HttpGet("GetVideoByIdWithComments/{id}")]
        public IActionResult GetVideoByIdWithComments(int id)
        {
            var video = _videoRepositoy.GetVideoByIdWithComments(id);
            if(video == null)
            {
                return NotFound();
            }
            return Ok(video);
        }

        [HttpPost]
        public IActionResult Post(Video video)
        {
            _videoRepositoy.Add(video);
            return CreatedAtAction("Get", new { id = video.Id }, video);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Video video)
        {
            if (id != video.Id)
            {
                return BadRequest();
            }

            _videoRepositoy.Update(video);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _videoRepositoy.Delete(id);
            return NoContent();
        }
    }
}
