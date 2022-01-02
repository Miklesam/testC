using System;
using System.Collections.Generic;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Portal : Collectable
{
    public string[] sceneNames;
    private Vector2 flipVector = new Vector2(1,1);
    
    

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "player")
        {
            //GameManager.instance.SaveState();
            // Scene scene = SceneManager.GetActiveScene();
            // List<string> tmp = new List<string>(sceneNames);
            // tmp.Remove(scene.name);
            // sceneNames = tmp.ToArray();
            // string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
            // SceneManager.LoadScene(sceneName);
            if (PlayerMovement.moveSpeedInc < 1f)
            {
                PlayerMovement.moveSpeedInc += 0.15f;
            }
            var camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();

            camera.ResetWorldToCameraMatrix();
            camera.ResetProjectionMatrix();
            
            rotation();
            
            camera.projectionMatrix = 
                camera.projectionMatrix * Matrix4x4.Scale(new Vector3(flipVector.x, flipVector.y, 1));

            GetComponent<BoxCollider2D>().enabled = false;
        }

        base.OnCollide(coll);
    }

    private void rotation()
    {
        Vector2 vector2 = new Vector2();

        if (randomBool())
            vector2.x = 1;
        else
            vector2.x = -1;

        if (randomBool())
            vector2.y = 1;
        else
            vector2.y = -1;

        if (vector2.Equals(flipVector))
            rotation();
        else
            flipVector = vector2;
    }
    private bool randomBool()
    {
        var b = Random.Range(0f, 1f);
        return b >= 0.5;
    }
    
    
}