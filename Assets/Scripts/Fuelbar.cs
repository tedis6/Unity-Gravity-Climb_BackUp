using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Fuelbar : MonoBehaviour
{
    Slider slider;
    public float fuelTime = 10.0f;
    float timer = 0f;
    public GameManager1 gameManager;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        slider.value = Mathf.Lerp(1f, 0f, timer / fuelTime);
        
        if (slider.value <= 0f && gameManager.gameOver==false)
        {
            gameManager.gameOver = true;
        }

    }

    public void Refill()
    {
        timer = 0f;
        slider.value = 1.0f;
    }
}
