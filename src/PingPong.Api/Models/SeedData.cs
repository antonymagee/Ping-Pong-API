using System;
using System.Linq;
using Anow.PingPong.Api.Models;

public class SeedData
{
    private readonly GameContext _ctx;
    public SeedData(GameContext ctx)
    {
        _ctx = ctx;      
    }

    public void Seed()
    {
        _ctx.Database.EnsureCreated();
        
        DateTime masterTime = new DateTime(2018, 4, 12);

        if (!_ctx.Game.Any())
        {
            _ctx.Game.Add(new GameObject { Player1 = "antony", Player2 = "james", Score1 = 15, Score2 = 21, Time = masterTime.AddDays(3)});
            _ctx.Game.Add(new GameObject { Player1 = "dean", Player2 = "greg", Score1 = 21, Score2 = 20, Time = masterTime.AddDays(1)});
            _ctx.Game.Add(new GameObject { Player1 = "jim", Player2 = "ken", Score1 = 25, Score2 = 23, Time = masterTime.AddDays(19)});
            _ctx.Game.Add(new GameObject { Player1 = "dalan", Player2 = "chris", Score1 = 2, Score2 = 21, Time = masterTime.AddDays(15)});
            _ctx.Game.Add(new GameObject { Player1 = "ken", Player2 = "doug", Score1 = 21, Score2 = 15, Time = masterTime.AddDays(9)});
            _ctx.SaveChanges();
        }
    }
    }