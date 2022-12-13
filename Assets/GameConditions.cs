using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameConditions : MonoBehaviour
{
    public int numberOfEnemiesDead;
    public int numberOfEnemies;
    public TMP_Text enemyCount;
    public bool timerIsOn; 

    void Start()
    {
        numberOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        numberOfEnemiesDead = numberOfEnemies - GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemyCount.text = numberOfEnemiesDead.ToString() + "/" + numberOfEnemies.ToString() + " Kills";
        timerIsOn = GameObject.Find("Timer").GetComponent<TimerCountdown>().timerOn;
    }

    
    void Update()
    {
        timerIsOn = GameObject.Find("Timer").GetComponent<TimerCountdown>().timerOn;
        numberOfEnemiesDead = numberOfEnemies - GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemyCount.text = numberOfEnemiesDead.ToString() + "/" + numberOfEnemies.ToString() + " Kills";
        Debug.Log(timerIsOn);
        if (numberOfEnemiesDead != numberOfEnemies && timerIsOn == false)
        {
            //Next scene is failure screen
            SceneManager.LoadScene("Failure Screen");
        }
        if (numberOfEnemiesDead == numberOfEnemies && timerIsOn == true)
        {
            //Next 2 scenes is the success screen
            SceneManager.LoadScene("Success Screen");
        }
    }
}
