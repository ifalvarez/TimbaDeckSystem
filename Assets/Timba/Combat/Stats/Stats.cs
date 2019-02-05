using System.Collections;
using System.Collections.Generic;

/// <summary>
/// The full stats table of a combatant.
/// </summary>
namespace Timba.Combat{
	[System.Serializable]
	public struct Stats {
			public Stat hp;
			public Stat mp;
			public Stat armor;
			public Stat str;
			public Stat dex;
			public Stat inte;
		
		public Stats(Stat hp,Stat mp,Stat armor,Stat str,Stat dex,Stat inte) {
				this.hp = hp;
				this.mp = mp;
				this.armor = armor;
				this.str = str;
				this.dex = dex;
				this.inte = inte;
			}

		public static Stats operator +(Stats a, Stats b) {
				a.hp += b.hp;
				a.mp += b.mp;
				a.armor += b.armor;
				a.str += b.str;
				a.dex += b.dex;
				a.inte += b.inte;
				return a;
		}

		public static Stats operator -(Stats a, Stats b) {
				a.hp -= b.hp;
				a.mp -= b.mp;
				a.armor -= b.armor;
				a.str -= b.str;
				a.dex -= b.dex;
				a.inte -= b.inte;
				return a;
		}

		public static Stats zero = new Stats(Stat.zero,Stat.zero,Stat.zero,Stat.zero,Stat.zero,Stat.zero);
	}
}