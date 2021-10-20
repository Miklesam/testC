using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    public bool reverse = false;
    private Vector2 screenBounds;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        if (reverse)
        {
            transform.position = new Vector3(player.position.x - 8 * screenBounds.x / 10, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(player.position.x + 8 * screenBounds.x / 10, transform.position.y, transform.position.z);
        }
    }
}
