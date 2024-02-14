using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Rigidbody player;
    public Text scoreText;
    public Text healthText;
    public Text WinLoseText;
    public Image WinLoseBG;

    public float move = 5000f;
    public int score = 0;
    public int health = 5;

    void Update()
    {
        if (health == 0)
        {
            WinLoseText.text = "Game Over!";
            WinLoseText.color = Color.white;
            WinLoseBG.color = Color.red;
            WinLoseBG.gameObject.SetActive(true);


            health = 5;
            score = 0;

            StartCoroutine(ReloadSceneAfterDelay(3));
        }

        SetScoreText();
        SetHealthText();
    }

    IEnumerator ReloadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("maze");
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
            //Debug.Log("Score: " + score);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Trap"))
        {
            health--;
            //Debug.Log("Health: " + health);
            SetHealthText();
        }
        if (other.CompareTag("Goal"))
        {
            //Debug.Log("You win!");
            WinLoseText.text = "You Win!";
            WinLoseText.color = Color.black;
            WinLoseBG.color = Color.green;
            WinLoseBG.gameObject.SetActive(true);
        }
    }

    void SetScoreText()
    {
        scoreText.text = score.ToString();
    }

    void SetHealthText()
    {
        healthText.text = health.ToString();
    }
}
