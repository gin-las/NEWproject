using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class gamemanager : MonoBehaviour
{

    [Header("Game Variables")]
    public playercontrols player;
    public float time;
    public bool timeActive;

    [Header("GameUI")]
    public TMP_Text gameUI_score;
    public TMP_Text gameUI_health;
    public TMP_Text gameUI_time;

    [Header("CountDown UI")]
    public TMP_Text countdownText;
    public int countdown;

    [Header("Screens")]
    public GameObject countdownUI;
    public GameObject gameUI;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player").GetComponent<playercontrols>();

        // make sure the timer is set to zero
        time = 0;

        //disable player movement initally
        player.enabled = false;

        //set screen to countdown
        SetScreen(countdownUI);

        //start coroutine
        StartCoroutine(CountDownRoutine());

    }

    IEnumerator CountDownRoutine()
    {
        countdownText.gameObject.SetActive(true);
        countdown = 3;
        while (countdown > 0)
        {
            countdownText.text = countdown.ToString();
            yield return new WaitForSeconds(1f);
            countdown--;

        }


        countdownText.text = "GO!";
        yield return new WaitForSeconds(1f);
        //enable player movement
        player.enabled = true;



        //start game
        startGame();

    }

    void startGame()
    {
        //set screen to see stats
        SetScreen(gameUI);
        
        
        //start timer
        timeActive = true;



    }

    public void endGame()
    {
        //end timer
        timeActive = false;

        //disable player movement
        player.enabled = false;

    }


    // Update is called once per frame
    void Update()
    {
        // keep track of the time that goes by
        if(timeActive)
        {
            time = time + Time.deltaTime;

        }

        //set ui to display stats
        gameUI_score.text = "Coins: " + player.coinCount;
        gameUI_health.text = "Health: " + player.health;
        gameUI_time.text = "Time: " + (time * 10).ToString("F2");

    }

    public void SetScreen(GameObject screen)
    {
        //disable all other screens
        gameUI.SetActive(false);
        countdownUI.SetActive(false);

        //activate the requested screen
        screen.SetActive(true);
    }



}
