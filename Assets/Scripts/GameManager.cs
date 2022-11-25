using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    
    public TextMeshProUGUI Seconds;
    public float score = 0f;
    public float scorePerSecond = 1f;
    public TextMeshProUGUI SecondsFinal;
    public GameObject GameOverText;
    // Start is called before the first frame update
    void Start()
    {
       // StartCoroutine(waiter());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Seconds.text = ((int)score).ToString();
        score += scorePerSecond * Time.fixedDeltaTime;
    }

    //IEnumerator waiter()
    //{
    //   yield return new WaitForSeconds(5);
    //
    //    GameOver();
   // }

    public void AddScore()
    {

    }

    public void GameOver()
    {
        SecondsFinal.text = ((int)score).ToString();
        GameOverText.SetActive(true);
    }
}
