using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody player;

    public float move = 5000f;
    public int score = 0;
    public int health = 5;

    void Update()
    {
        if (health == 0)
        {
            health = 5;
            score = 0;
            SceneManager.LoadScene("maze");
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey("d"))
        {
            player.AddForce(move * Time.deltaTime,0,0);
        }
        if (Input.GetKey("a"))
        {
            player.AddForce(-move * Time.deltaTime,0,0);
        }
        if (Input.GetKey("w"))
        {
            player.AddForce(0,0, move * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            player.AddForce(0,0, -move * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            score+=100;
            Debug.Log("Score: " + score);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Trap"))
        {
            health--;
            Debug.Log("Health: " + health);
        }
        if (other.CompareTag("Goal"))
        {
            Debug.Log("You win!");
        }
    }
}
