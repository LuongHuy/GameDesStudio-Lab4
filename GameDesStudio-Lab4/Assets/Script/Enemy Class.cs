using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyClass : MonoBehaviour
{
    [SerializeField] protected float movespeed;
    protected Rigidbody2D rb;

    protected void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    protected void Move()
    {
        if (rb == null)
        {
            Debug.Log("No rigidbody2d found");
        }
        else
        {
            rb.velocity = Vector2.up * -1 * movespeed;
        }
    }
    protected EnemyClass DeepClone()
    {
        EnemyClass clone = (EnemyClass) MemberwiseClone();

        return clone;
    }
    protected abstract void Action();

}
