using UnityEngine;

public class Booster : MonoBehaviour
{
    public float fallSpeed = 2f; // Speed of falling booster

    void Start()
    {
        // Ensure Rigidbody2D is present and set correctly
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>(); // Add Rigidbody if missing
        }
        rb.gravityScale = 0; // Prevent Unity's default gravity
        rb.velocity = new Vector2(0, -fallSpeed); // Move downward
    }

    void Update()
    {
        // Destroy the booster if it falls out of screen
        if (transform.position.y < -6f) // Adjust based on game area
        {
            Destroy(gameObject);
        }
    }
}