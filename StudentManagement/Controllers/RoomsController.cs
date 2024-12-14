using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly StudentManagementContext _studentManagementContext;

        public RoomsController(StudentManagementContext studentManagementContext)
        {
            _studentManagementContext = studentManagementContext;
        }

        [HttpGet]
        [Route("/")]
        public IActionResult GetRooms()
        {
            var rooms = _studentManagementContext.Rooms.ToList();
            return Ok(rooms);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetRoomByGuid([FromRoute] Guid id)
        {
            var rooms = _studentManagementContext.Rooms.Where(room => room.Id.Equals(id));
            if (rooms.Count() == 0) return NotFound("Room Not Found");
            return Ok(rooms);
        }

        [HttpPost]
        public IActionResult CreateRoom([FromBody] Room room)
        {
            _studentManagementContext.Rooms.Add(room);
            var result = _studentManagementContext.SaveChanges();
            if (result < 1)
            {
                BadRequest("Room Delete Failed");
            }

            return Ok(room);
        }


        [HttpDelete]
        public IActionResult DeleteRoom([FromBody] Guid roomId)
        {
            var room = _studentManagementContext.Rooms.FirstOrDefault(x => x.Id.Equals(roomId));
            if (room == null) return NotFound("Room Not Found");
            _studentManagementContext.Remove(room);
            var result = _studentManagementContext.SaveChanges();
            if (result < 1) return BadRequest("Room Delete Failed");
            return Ok(room);
        }

        [HttpGet]
        [Route("/hello-world")]
        public IActionResult HelloWorld()
        {
            return Ok("Hello World");
        }
    }
}