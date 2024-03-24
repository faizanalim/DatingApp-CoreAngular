using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DataContext context;
        public UserController(DataContext context)
        {
            this.context = context;
            
        }

                [HttpGet]
        public  ActionResult<IEnumerable<AppUser>> GetUsers()
        {
            var users = context.Users.ToList();

            return users;
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await context.Users.FindAsync(id);
        }
    }
}