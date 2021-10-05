using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    void Start()
    {
        Debug.Log(GameDataLocalStorage.LoadData().musicOn);
        GetComponent<AudioSource>().mute = !GameDataLocalStorage.LoadData().musicOn;
    }
}
