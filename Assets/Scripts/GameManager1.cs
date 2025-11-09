using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public float speed = 5.0f;
    Fuelbar fuelBar;
    private int score;
    public TextMeshProUGUI scoreText;
    public GameObject winText;
    public GameObject gameOverText;
    public GameObject restartButton;
    public Button restartBtn;
    private Rigidbody playerRb;
    public bool gameOver = false;
    public bool isFinished = false;
    public AudioSource audioSource;
    public AudioClip coinSound;
    public AudioClip canisterSound;
    public AudioClip gameoverSound;
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
        GameStatus();
   


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            audioSource.PlayOneShot(canisterSound, 2f);
            fuelBar.Refill();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Coin"))
        {
            audioSource.PlayOneShot(coinSound, 2f);
            UpdateScore(5);
            Destroy(other.gameObject);
            
        }

        if (other.CompareTag("Stop"))
        {
            Destroy(other.gameObject);
            isFinished = true;
        }

        if (other.CompareTag("Deathzone"))
        {
            gameOver = true;
            Destroy(other.gameObject);
            audioSource.PlayOneShot(gameoverSound, 2f);

        }


    }

    void UpdateScore(int aditionalScore)
    {
        score += aditionalScore;
        scoreText.text = "Score: " + score;

    }

    public void GameStatus()
    {
        if (gameOver)
        {
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
            playerRb.constraints = RigidbodyConstraints.FreezeAll;


        }

        if (isFinished)
        {
            restartButton.SetActive(true);
            winText.SetActive(true);
            playerRb.constraints = RigidbodyConstraints.FreezeAll;

        }

    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}