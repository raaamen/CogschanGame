using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public Enemy enemy;
    public float multiplier = 1f;

    public void TakeHit(float damage)
    {
        enemy.DealDamage(multiplier * damage);
    }
}
