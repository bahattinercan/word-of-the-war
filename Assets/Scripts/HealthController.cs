using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public Slider slider;
    public int health;

    private void Start()
    {
        slider.value = health;
    }

    public void DecreaseHealth(int damage)
    {
        health -=damage;
        slider.value = health;
    }

    public bool isDead()
    {
        if (health <= 0)
        {
            return true;
        }
        return false;
    }
}
