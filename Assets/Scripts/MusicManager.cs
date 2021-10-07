using UnityEngine;

public class MusicManager : MonoBehaviour
{

    private static AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.mute = !GameDataLocalStorage.LoadData().musicOn;
    }

    public static void StopPlay()
    {
        audioSource.Stop();
    }
}