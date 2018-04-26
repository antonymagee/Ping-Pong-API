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
            _ctx.Game.Add(new GameObject { Player1 = "antony", Player2 = "james", Player1score = 15, Player2score = 21, Time = masterTime.AddDays(3)});
            _ctx.Game.Add(new GameObject { Player1 = "dean", Player2 = "greg", Player1score = 21, Player2score = 20, Time = masterTime.AddDays(1)});
            _ctx.Game.Add(new GameObject { Player1 = "jim", Player2 = "ken", Player1score = 25, Player2score = 23, Time = masterTime.AddDays(19)});
            _ctx.Game.Add(new GameObject { Player1 = "dalan", Player2 = "chris", Player1score = 2, Player2score = 21, Time = masterTime.AddDays(15)});
            _ctx.Game.Add(new GameObject { Player1 = "ken", Player2 = "doug", Player1score = 21, Player2score = 15, Time = masterTime.AddDays(9)});
            _ctx.SaveChanges();
        }
    }
    }