using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager1 : MonoBehaviour
{
    public float speed = 5.0f;
    Fuelbar fuelBar;
    private int score;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverText;
    public GameObject restartButton;
    public bool gameOver = false;
    public bool isFinished = false;
    // Start is called before the first frame update
    void Start()
    {
        fuelBar = FindObjectOfType<Fuelbar>();
        score = 0;
        scoreText.text = "Score:" + score;

    }

    // Update is called once per frame
    void Update()
    {
        GameOver();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            fuelBar.Refill();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Coin"))
        {
            UpdateScore(5);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Stop"))
        {
            //fuelBar.GameOver();
            Destroy(other.gameObject);
            isFinished = true;
        }

        if (other.CompareTag("Deathzone"))
        {
            gameOver = true;
            Destroy(other.gameObject);

        }


    }

    void UpdateScore(int additionalScore)
    {
        score += additionalScore;
        scoreText.text = "Score: " + score;

    }

    public void GameOver()
    {
        if (gameOver)
        {
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
        }

    }

    public void Restart()
    {

    }
}