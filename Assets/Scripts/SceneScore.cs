using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneScore : MonoBehaviour
{
    public Text scoreText;
    
    void Update()
    {
        scoreText.text = ScoreManager.CurrentScore().ToString();
    }
}
