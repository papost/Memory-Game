using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryMatchingGame
{
    public class Player
    {
        public string name;
        public int tries;
        public Player(string n, int t)
        {
            name = n;                               //player's name
            tries = t;                              //player's tries.
        }
    }
}
