using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encore.Models
{
    public class GamePlayed
    {
        public int GameID { get; set; }
        public int UserID { get; set; }
        public int Score { get; set; }
        public int BoardID { get; set; }
        public DateTime Date { get; set; }
    }
}
