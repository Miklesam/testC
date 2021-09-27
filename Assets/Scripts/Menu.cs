using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    
    public Button musicOnOff;
    public Button play;
    public Button company;
    public Text musicText;
    public Text scoreText;

    public Boolean musicOn;

    private string sceneForPlay = "SampleScene";
    private string companyForStart = "SampleScene";

    private void Start()
    {
        play.onClick.AddListener(PlayClick);
        company.onClick.AddListener(CompanyClick);
        musicOnOff.onClick.AddListener(MusicClick);
        int score = ScoreManager.bestScore;
        
        scoreText.text = "best score:"+ ScoreManager.bestScore;
        
        musicOn = GameDataLocalStorage.LoadData().musicOn;
        musicText.text = musicOn ? "" : "OFF";
    }

    private void MusicClick()
    {
        musicOn = !musicOn;
        musicText.text = musicOn ? "" : "OFF";
        GameDataLocalStorage.SaveMusic(musicOn);
    }

    private void PlayClick()
    {
        ScoreManager.StartScore();
        SceneManager.LoadScene(sceneForPlay);
    }

    private void CompanyClick()
    { 
        SceneManager.LoadScene(companyForStart);
    }

}