using System;
using System.Collections.Generic;
using System.Text;

namespace Wanda.Games.TicTacToe.Model.ViewModel
{
    public class Game
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public string Winner { get; set; }
        public DateTime? LastUpdated { get; set; }
        public DateTime? DateCreated { get; set; }
    }

}
