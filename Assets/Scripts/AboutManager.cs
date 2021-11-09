using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AboutManager : MonoBehaviour
{
    public Button discord;
    public Button back;
    private string sceneForBack = "MenuScene";

    // Start is called before the first frame update
    void Start()
    {
        discord.onClick.AddListener(DiscordClick);
        back.onClick.AddListener(BackClick);
    }

    private void BackClick()
    {
        SceneManager.LoadScene(sceneForBack);
    }

    private void DiscordClick()
    {
        string URL = "https://discord.gg/twKyPZDn";
        Application.OpenURL(URL);
    }


}
