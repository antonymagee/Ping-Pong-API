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
            var query =
                from m in item
                orderby m.Time ascending
                select m;

            if (item == null)
            {
                return BadRequest();
            }
            return new ObjectResult(query);
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
                return BadRequest();
            }

            bool gameIdExists = _ctx.Game
                           .Where(g => g.Id == game.Id)
                           .ToList().Any();
         
            bool isFourPlayer = ((game.Player4 != null) && (game.Player3 != null));

            if (gameIdExists)
            {
                ModelState.AddModelError("Id", "Id alread Exists");
            }

            if (ModelState.IsValid)
            {

                if (game.Score1 >= 21 && (game.Score1 - 2 >= game.Score2))
                {
                   game.Winner = (isFourPlayer) ? game.Player1 + "," + game.Player2 : game.Player1;
                }
                if (game.Score2 >= 21 && (game.Score2 - 2 >= game.Score1))
                {
                    game.Winner = (isFourPlayer) ? game.Player3 + "," + game.Player4 : game.Player2;
                }

                game.Time = DateTime.Now;
                _ctx.Game.Add(game);
                _ctx.SaveChanges();
                return CreatedAtRoute("GetGame", new { id = game.Id }, game);
            }
            return BadRequest(ModelState);
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

            bool isFourPlayer = ((game.Player4 != null) && (game.Player3 != null));

            if (isFourPlayer){
              item.Player3 = game.Player3;
              item.Player4 = game.Player4;
            }

            item.Player1 = game.Player1;
            item.Player2 = game.Player2;
            
            item.Id = game.Id;
            item.Score2 = game.Score2;
            item.Score1 = game.Score1;
            item.Winner = game.Winner;

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

    }
}

