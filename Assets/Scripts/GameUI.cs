using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

public class GameUI : MonoBehaviour
{
    [Header("HUD")]
    public TextMeshProUGUI scoreText;           // text that displays our score
    public TextMeshProUGUI ammoText;            // text that displays our ammo

    public Image healthBarFill;                 // the image fill representing the health bar

    [Header("Pause Menu")]
    public GameObject pauseMenu;                // pause menu object

    [Header("Shop")]
    public GameObject ShopScreen;
    public TextMeshProUGUI Level;
    public TextMeshProUGUI Cost;

    [Header("End Game Screen")]
    public GameObject endGameScreen;            // end game screen object
    public TextMeshProUGUI endGameHeaderText;   // end game screen header text
    public TextMeshProUGUI endGameScoreText;    // end game screen displaying our final score

    // instance
    public static GameUI instance;
    private float CostPrice = 30+Mathf.Pow(Player.WeaponLevel-1,3)*10;
    void Awake ()
    {
        // set the instance to this script
        instance = this; 

    }

    public void UpdateShop()
    {
        int New = Player.WeaponLevel + 1;
        Level.text = "Upgrade: Level " + New;
        Cost.text = "Cost: "+CostPrice+" Score";
    }
    public void BuyUpgrade(){
        if (GameManager.curScore >= CostPrice){
            Player.WeaponLevel++;
            GameManager.curScore=GameManager.curScore - (int)CostPrice;
            OnResumeButtonShop();
        }
    }

    // updates the health bar fill
    public void UpdateHealthBar (int curHp, int maxHp)
    {
        healthBarFill.fillAmount = (float)curHp / (float)maxHp;
    }

    // updates the score text to show the current score
    public void UpdateScoreText (int score)
    {
        scoreText.text = "Score: " + score;
    }

    // updates the ammo text
    public void UpdateAmmoText (int curAmmo, int maxAmmo)
    {
        ammoText.text = "Ammo: " + curAmmo + " / " + maxAmmo;
    }

    // enables or disables the pause menu
    public void TogglePauseMenu (bool paused)
    {
        pauseMenu.SetActive(paused);
    }

    // activates and sets the end game screen
    public void SetEndGameScreen (bool won, int score)
    {
        endGameScreen.SetActive(true);
       // endGameHeaderText.text = won == true ? "You Win" : "You Lose";
        endGameHeaderText.color = won == true ? Color.green : Color.red;
        endGameScoreText.text = "<b>Score</b>\n" + score;
    }

    // called when we press the "Resume" button
    public void OnResumeButton ()
    {
        GameManager.instance.TogglePauseGame();
    }
    public void OnResumeButtonShop()
    {
        ShopScreen.SetActive(false);
        if (Player.InShop) 
        { GameManager.instance.TogglePauseGame();
            Player.InShop = false;
        }
        
    }
    // called when we press the "Restart" button
    public void OnRestartButton ()
    {
        SceneManager.LoadScene("Game");
    }

    // called when we press the "Menu" button
    public void OnMenuButton ()
    {
        SceneManager.LoadScene("Menu");
    }
}