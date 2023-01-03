using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public float MaxHealth = 100;
    public UnityEvent<GameObject> OnDeath;
    public Healthbar Healthbar;

    float _health;

    void Awake()
    {
        _health = MaxHealth;
        Healthbar.UpdateValue(1);
    }

    public void DealDamage(float amount)
    {
        _health = Mathf.Max(_health - amount, 0);
        Healthbar.UpdateValue(_health / MaxHealth);

        if (_health == 0)
        {
            OnDeath.Invoke(gameObject);
            Kill();
        }
    }

    public void HealHealth(float amount)
    {
        _health = Mathf.Min(_health + amount, MaxHealth);
        Healthbar.UpdateValue(_health / MaxHealth);
    }

    void Kill()
    {
        Destroy(gameObject);
    }
}
