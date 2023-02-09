using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  //  public int scoreToWin;
    public static int curScore=0;

    public bool gamePaused; 
    public Player Player;

    // instance
    public static GameManager instance;

    void Awake ()
    {
        // set the instance to this script
        instance = this;
    }

    void Start ()
    {
        Time.timeScale = 1.0f;
    }

    void Update ()
    {
        if(Input.GetButtonDown("Cancel"))
            TogglePauseGame();
    }

    public void TogglePauseGame ()
    {
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused == true ? 0.0f : 1.0f;

        Cursor.lockState = gamePaused == true ? CursorLockMode.None : CursorLockMode.Locked;

        // toggle the pause menu
        if (!Player.InShop)
        { GameUI.instance.TogglePauseMenu(gamePaused); }
    }

    public void AddScore (int score)
    {
        curScore += score;

        // update the score text
        GameUI.instance.UpdateScoreText(curScore);

        // have we reached the score to win?
      //  if(curScore >= scoreToWin)
     //       WinGame();
    }

    public void WinGame ()
    {
        // set the end game screen
        GameUI.instance.SetEndGameScreen(true, curScore);

        Time.timeScale = 0.0f;
        gamePaused = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoseGame ()
    {
        // set the end game screen
        GameUI.instance.SetEndGameScreen(false, curScore);

        Time.timeScale = 0.0f;
        gamePaused = true;
        Cursor.lockState = CursorLockMode.None;
    }
}