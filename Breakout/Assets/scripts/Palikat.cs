using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palikat : MonoBehaviour
{
    public event EventHandler BlockDestroyedevent;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision object is the ball (you can tag the ball in Unity with "Ball")
        if (collision.gameObject.CompareTag("Pallo"))
        {
            // Destroy the block
            Destroy(gameObject);

            // Reflect the ball's velocity (to make it bounce)
            Rigidbody2D ballRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            if (ballRigidbody != null)
            {
                // Reflect the ball's velocity
                Vector2 normal = collision.contacts[0].normal;
                ballRigidbody.velocity = Vector2.Reflect(ballRigidbody.velocity, normal);
            }
        }
    }
    private void OnDestroy()
    {
        BlockDestroyedevent(this,EventArgs.Empty);
    }
}
