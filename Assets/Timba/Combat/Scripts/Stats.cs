using System.Collections;
using System.Collections.Generic;

/// <summary>
/// The full stats table of a combatant.
/// </summary>
[System.Serializable]
public struct Stats {
	public Stat attack;
	public Stat hp;
	public Stat mp;
	public Stat armor;
	
	public Stats(Stat attack,Stat hp,Stat mp,Stat armor) {
		this.attack = attack;
		this.hp = hp;
		this.mp = mp;
		this.armor = armor;
    }

    public static Stats operator +(Stats a, Stats b) {
		a.attack += b.attack;
		a.hp += b.hp;
		a.mp += b.mp;
		a.armor += b.armor;
        return a;
    }

    public static Stats operator -(Stats a, Stats b) {
		a.attack -= b.attack;
		a.hp -= b.hp;
		a.mp -= b.mp;
		a.armor -= b.armor;
        return a;
    }

	public static Stats zero = new Stats(Stat.zero,Stat.zero,Stat.zero,Stat.zero);
}
