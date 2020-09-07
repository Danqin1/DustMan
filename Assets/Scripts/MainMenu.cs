using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button[] lvls = new Button[4];
    public GameObject LevelPanel;
    public GameObject MainPanel;
    public GameObject BackButtonFromLVLS;
    public Text highScore;
    public void Play()
    {
        LevelPanel.SetActive(true);
        MainPanel.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void PlayLevel(int lvl)
    {
        SceneManager.LoadScene(lvl);
    }
    public void BackToMainMenu()
    {
        LevelPanel.SetActive(false) ;
        MainPanel.SetActive(true);
    }
    private void Start()
    {
        LevelPanel.SetActive(false);
        PlayerPrefs.SetInt("lvl1", 1);
        for (int i = 0; i < lvls.Length; i++)
        {
            if (PlayerPrefs.GetInt(lvls[i].name,0) == 0)
            {
                lvls[i].interactable = false;
            }
            else
            {
                lvls[i].interactable = true;
            }
        }
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Exit();
        }
    }
}
