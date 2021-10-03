using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private GameObject blood;

    //private Animator anim;
    private Rigidbody2D rb;

    [SerializeField] private AudioSource dyingSoundEffect;

    // Start is called  the first frame update 
    private void Start()
    {
        //anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            // RestartLevel();
            Die();
        }
    }

    private void Die()
    {
        ScoreManager.finishScore();
        Instantiate(blood, transform);
        RestartLevel();
        //Invoke("LoadMenu", 0.3f);
        //anim.SetTrigger("death");
        //rb.bodyType = RigidbodyType2D.Static;
        //dyingSoundEffect.Play();
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}