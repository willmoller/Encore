using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encore
{
    
    
    public class Dice
    {
        public Dictionary<String, Die> DiceList { get; set; }
        public List<String> DiceListKeys { get; set; }

        private Random r = new Random();

        public Dice(List<string> diceKeys)
        {
            
            DiceListKeys = diceKeys;
            DiceList = new Dictionary<string, Die>();
        }

        public void RollDice()
        {
            foreach(String die in DiceListKeys)
            {
                DiceList[die].Roll(r.Next(1, 7));
            }
        }

    }
}
