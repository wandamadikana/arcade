using System;
using System.Collections.Generic;
using System.Text;

namespace Wanda.Games.TicTacToe.Model.DTO
{
    public class Player
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public string PlayerDescription { get; set; }
        public string Symbol { get; set; }
        public DateTime? LastUpdated { get; set; }
        public DateTime? DateCreated { get; set; }
        public virtual ICollection<Move> Move { get; set; }
    }

}
