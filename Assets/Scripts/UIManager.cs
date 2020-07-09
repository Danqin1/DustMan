using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text text;
    private GameController gameController;
    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }
    private void Update()
    {
        text.text = gameController.score.ToString();
    }
    public void GoToMainMenu()
    {
        if(gameController.score > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", gameController.score);
        }
        SceneManager.LoadScene(1);
    }
}
