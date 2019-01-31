using System;


namespace Timba.Cards {
    public interface CardBehaviour {
        void Execute(Card card, object[] targets);
        int[] Parameters { get; set; }
    }
}