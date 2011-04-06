using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Enums;

namespace Core
{
    public class GameTeam
    {
        public string TeamName = "";
        public int Scores = 0;
        public Dictionary<string, GamePlayer> Players = new Dictionary<string, GamePlayer>();
        public GameTactics Tactic = GameTactics.Tactic_4_4_2;
    }
}
