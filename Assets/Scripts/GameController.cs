using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject gameOverText;
    public GameObject highScoreObj;
    public bool gameOver = false;
    public Text scoreText;
    public Text highScoreText;
    private bool canContinue = false;

    private int score = 0;

    //Singleton
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void BirdScored()
    {
        if (gameOver)
        {
            return;
        }
        score++;
        scoreText.text = "Score : " + score.ToString();
    }

    public void BirdDied()
    {

        gameOverText.SetActive(true);
        highScoreObj.SetActive(true);
        if (score > PlayerPrefsController.GetHighScore() && PlayerPrefsController.GetEasyToggle() ==0)
        {
            PlayerPrefsController.SetHighScore(score);
            highScoreText.text = "High Score : " + score.ToString();
        }
        else
        {
            highScoreText.text = "High Score : " + PlayerPrefsController.GetHighScore().ToString();
        }
        StartCoroutine(DeathDelay(0.2f));
    }

    IEnumerator DeathDelay(float delayTime)
    {
        gameOver = true;
        yield return new WaitForSeconds(delayTime);
        canContinue = true;
    }
}
