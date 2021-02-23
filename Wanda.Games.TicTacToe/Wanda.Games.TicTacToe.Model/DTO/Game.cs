using System;
using System.Collections.Generic;
using System.Text;

namespace Wanda.Games.TicTacToe.Model.DTO
{
    public class Game
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public string Winner { get; set; }
        public DateTime? LastUpdated { get; set; }
        public DateTime? DateCreated { get; set; }
        public virtual ICollection<Move> Move { get; set; }
    }

}
