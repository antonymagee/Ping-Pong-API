using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Anow.PingPong.Api.Models;

namespace Anow.PingPong.Api.Controllers
{
    
    [Route("api/[controller]")]
    public class GamesController : Controller
    { 
        private readonly GameContext _ctx;

        
        public GamesController(GameContext ctx) => _ctx = ctx;

        // GET ALL GAMES
        // GET api/getGames
        [HttpGet]
        public IEnumerable<GameObject> GetAll()
        {
            var item = _ctx.Game
                       .ToList();

            var query =
                from m in item
                orderby m.Time ascending
                select m;

            return query;
        }


        [HttpGet]
        [Route("ByUser/{name}")]
        public IActionResult ByName(string name)
        {
            var item = _ctx.Game
                           .Where(f => f.Player1 == name)
                           .ToList();

            if (item == null)
            {
                return BadRequest();
            }
            return new ObjectResult(item);
        }
        // GET BY ID
        // GET api/getGames/5
        [HttpGet("{id}", Name = "GetGame")]
        public IActionResult GetById(long id)
        {
            var item = _ctx.Game
                           .Where(g => g.Id == id)
                           .ToList();


            if (item == null)
            {
                return BadRequest();
            }
            return new ObjectResult(item);
        }

        // Post new Game
        // POST JSON FOR NEW GAME api/games
        [HttpPost]
        public IActionResult Post([FromBody] GameObject game)
        {
            if (game == null)
            {
                throw new ArgumentNullException(nameof(game));
            }

            _ctx.Game.Add(game);
            _ctx.SaveChanges();

            return CreatedAtRoute("GetGame", new { id = game.Id }, game);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] GameObject game)
        {
            if (game == null || game.Id != id)
            {
                return BadRequest();
            }

            var item = _ctx.Game.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            item.Player1 = game.Player1;
            item.Player2 = game.Player2;
            item.Id = game.Id;
            item.Player2score = game.Player2score;
            item.Player1score = game.Player1score;

            _ctx.Game.Update(item);
            _ctx.SaveChanges();
            return new NoContentResult();
        }

        // DELETE ID OF RECORD PASSED
        // api/games/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var item = _ctx.Game
                           .FirstOrDefault(t => t.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            _ctx.Game.Remove(item);
            _ctx.SaveChanges();
            return new NoContentResult();
        }

        // GET BY NAME
        // GET api/Games/ByUser
        
    }
}

