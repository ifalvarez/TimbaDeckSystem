using System;
using Timba.Cards;

namespace Timba.CardRoguelike {
    public class DrawCardBehaviour : CardBehaviour {
        public int[] Parameters { get; set; }

        /// <summary>
        /// Implements this effect behaviour
        /// </summary>
        public void Execute(Card card, object[] targets) {
            Board.Instance.player.Draw(Parameters[0]);
        }

        public string Description {
            get {
                // Implement the description of this behaviour here
                return string.Format("Draw {0} cards", Parameters[0]);
            }
        }
    }
}