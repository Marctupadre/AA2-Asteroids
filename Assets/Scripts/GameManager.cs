using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;

    public float respawnTime = 3.0f;

    public int lives = 3;

    public int score = 0;

    public TMP_Text Highscore;

    public TMP_Text LivesText;


    public void PlayerDied()
    {
        lives--;
        LivesText.text = lives.ToString();

        if (lives < 0) {
            GameOver(lives);
            Debug.Log("Playerdied");
        } else {
            Debug.Log("Respawn");
            Invoke(nameof(Respawn), this.respawnTime);
        }

        //Invoke(nameof(Respawn), this.respawnTime);
    }

    private void Respawn()
    {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.SetActive(true);
    }

    public void AsteroidDestroyed(Asteroiide asteroid)
    {
       // explosionEffect.transform.position = asteroid.transform.position;
       // explosionEffect.Play();

       if (asteroid.size < 0.7f)
        {
            Debug.Log("Muy pequeño");
            SetScore(score + 100); // small asteroid
        }
        else if (asteroid.size < 1.4f)
        {
            Debug.Log("Muy mediano");
            SetScore(score + 50); // medium asteroid
        }
        else
        {
            Debug.Log("Muy grande");
            SetScore(score + 25); // large asteroid
        }
       
    }
    private void SetScore(int score)
    {
        this.score = score;
        Highscore.text = score.ToString();
    }
    private void GameOver(int lives)
    {
        if (lives == -1)
        {
            Debug.Log("GameOver");
            Debug.Log(lives);
            SceneManager.LoadScene(2);
        }
        Debug.Log(lives);
        // this.lives = 3;
        //this.score = 0;

        //Invoke(nameof(Respawn), this.respawnTime);
    }
}

