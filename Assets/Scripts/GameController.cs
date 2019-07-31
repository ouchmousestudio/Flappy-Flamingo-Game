using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject gameOverText;
    public bool gameOver = false;
    public Text scoreText;
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
        if (gameOver == true && Input.GetMouseButtonDown(0) && canContinue == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
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
        StartCoroutine(DeathDelay(1f));
    }

    IEnumerator DeathDelay(float delayTime)
    {
        gameOver = true;
        yield return new WaitForSeconds(delayTime);
        canContinue = true;
    }
}
