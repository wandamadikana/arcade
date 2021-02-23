using Microsoft.EntityFrameworkCore;
using Wanda.Games.TicTacToe.DAL.Seed.SeedData;

namespace Wanda.Games.TicTacToe.DAL.Seed
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.AddPlayerSeedDataa();
        }
    }
}
