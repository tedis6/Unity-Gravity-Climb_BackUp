using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager1 : MonoBehaviour
{
    public float speed = 5.0f;
    Fuelbar fuelBar;
    private int score;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverText;
    public GameObject restartButton;
    public Button restartBtn;
    private Rigidbody playerRb;
    public bool gameOver = false;
    public bool isFinished = false;
    // Start is called before the first frame update
    void Start()
    {
        fuelBar = FindObjectOfType<Fuelbar>();
        score = 0;
        scoreText.text = "Score:" + score;
        playerRb = GetComponent<Rigidbody>();
        restartBtn.onClick.AddListener(Restart);
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

    void UpdateScore(int aditionalScore)
    {
        score += aditionalScore;
        scoreText.text = "Score: " + score;

    }

    public void GameOver()
    {
        if (gameOver)
        {
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
            playerRb.constraints = RigidbodyConstraints.FreezeAll;


        }

    }

    public void Restart()
    {
        fuelBar.Refill();
        playerRb.constraints = RigidbodyConstraints.None;
        playerRb.velocity = Vector3.zero;
        isFinished = false;
        gameOver = false;
        gameOverText.SetActive(false);
        restartButton.SetActive(false);
        transform.position = new Vector3(50f, 4f, 0.7f);

    }
}