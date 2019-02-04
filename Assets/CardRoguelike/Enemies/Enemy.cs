
using UnityEngine;

public class Enemy 
{
    public string name;
    
    public void TakeTurn() {
        Debug.LogFormat("Enemy {0} taking its turn", name);
    }
}
