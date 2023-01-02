using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public Enemy enemy;

    public void TakeHit(float damage)
    {
        enemy.DealDamage(damage);
    }
}
