using Microsoft.EntityFrameworkCore;
using System;
using Wanda.Games.TicTacToe.Model.DTO;

namespace Wanda.Games.TicTacToe.DAL.Seed.SeedData
{
    public static class PlayerSeedData
    {
        public static void AddPlayerSeedDataa(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().HasData(
            new Player { Id = 1, PlayerName = "Computer", PlayerDescription = "BB-8 (or Beebee-Ate) AKA droid", Symbol = "o", DateCreated = DateTime.Now, LastUpdated = DateTime.Now },
            new Player { Id = 2, PlayerName = "Player1", PlayerDescription = "You AKA Human", Symbol = "x", DateCreated = DateTime.Now, LastUpdated = DateTime.Now }
          );
        }
    }
}
