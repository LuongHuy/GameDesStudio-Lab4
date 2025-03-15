using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
   public float health;
    public int scoreAdd;
    public void ApplyDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            ScoreManager.instance.UpdateScore(scoreAdd);
        }
    }
}
