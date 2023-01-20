using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class UI_Setting : MonoBehaviour
{
    public GameObject GameOverTextObj =null;
    public TMP_Text ClearText = null;

    public TMP_Text ScoreText = null;

    public TMP_Text BestScore = null;

    private bool isGameOver = false;

    private const string  BEST_SCORE_TEXT ="Score";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Enemy_Pooling.instance.BossCount);
        if (Player.instance.player_hp <= 0)
        {

            EndGame();
        }
        if (Player.instance.playerScore >= 10000)
        {
            
            WinGame();

        }



        ScoreText.text = $"Score: {Player.instance.playerScore}";

    }
    void EndGame()
    {
        GameOverTextObj.SetActive(true);
        GameOverTextObj.transform.localScale = Vector3.one;
        float bestSore = PlayerPrefs.GetFloat(BEST_SCORE_TEXT);
        
        
        if(bestSore < Player.instance.playerScore){
            bestSore = Player.instance.playerScore;
            PlayerPrefs.SetFloat(BEST_SCORE_TEXT, bestSore);
            BestScore.text = $"Best Score : {bestSore}";
        }else{
            BestScore.text = $"Best Score : {bestSore}";;
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Play_Main");
            GameOverTextObj.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Application.Quit();
        }
    }
    void WinGame()
    {
        GameOverTextObj.SetActive(true);
        ClearText.text =" Congratulations You Clear this game!!";
        GameOverTextObj.transform.localScale = Vector3.one;
        float bestSore = PlayerPrefs.GetFloat(BEST_SCORE_TEXT);
        
        
        if(bestSore < Player.instance.playerScore){
            bestSore = Player.instance.playerScore;
            PlayerPrefs.SetFloat(BEST_SCORE_TEXT, bestSore);
            BestScore.text = $"Best Score : {bestSore}";
        }else{
            BestScore.text = $"Best Score : {bestSore}";;
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Play_Main");
            GameOverTextObj.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Application.Quit();
        }
    }
}
