using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    [SerializeField] protected float movespeed;
    protected Rigidbody2D rb;

    protected virtual void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // might change so Enemy Manager call this instead
    protected void Update()
    {
        Move();
    }

    public virtual void Move()
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

    public virtual GameObject DeepClone(Vector2 pos)
    {
        GameObject clone = Instantiate(gameObject, pos, Quaternion.identity);

        return clone;
    }

}
