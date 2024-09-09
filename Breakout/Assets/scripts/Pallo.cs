using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pallo : MonoBehaviour
{
    public float speed = 5f; 
    private Vector2 direction; 
    private bool gameStarted = false; 
    public float resetHeight = -5f; 

    void Start()
    {
        
    }

    void Update()
    {
        
        if (!gameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            gameStarted = true;
            LaunchBall();
        }

        if (gameStarted)
        {
            
            transform.Translate(direction * speed * Time.deltaTime);

            
            Vector2 pos = Camera.main.WorldToViewportPoint(transform.position);

            if (pos.x <= 0 || pos.x >= 1)
            {
                direction = new Vector2(-direction.x, direction.y); 
                ClampToScreen();
            }
            if (pos.y >= 1)
            {
                direction = new Vector2(direction.x, -direction.y); 
                ClampToScreen();
            }

           
            if (transform.position.y < resetHeight)
            {
                RestartGame();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {
            direction = new Vector2(direction.x, -direction.y); // Reverse Y direction on paddle hit
        }

        if (collision.gameObject.CompareTag("Palikka"))
        {
            direction = new Vector2(direction.x, -direction.y); // Reverse Y direction on block hit
        }
    }

    void LaunchBall()
    {

        float randomXDirection = Random.Range(-5f, 5f); // X direction with variability
        float constantYDirection = 1f; // Fixed Y direction

        // Normalize the vector to ensure consistent magnitude
        direction = new Vector2(randomXDirection, constantYDirection).normalized;
    }

    void ClampToScreen()
    {
       
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}