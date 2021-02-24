using System;
using System.Collections.Generic;
using System.Text;

namespace Wanda.Games.TicTacToe.Model.ViewModel
{
    public class Move
    {
        public int Id { get; set; }
        public string MoveCode { get; set; }
        public int GameId { get; set; }
        public int? PlayerId { get; set; }
        public DateTime? LastUpdated { get; set; }
        public DateTime? DateCreated { get; set; }
    }

}
