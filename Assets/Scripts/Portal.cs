using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : Collectable
{

    public string[] sceneNames;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "player")
        {
            //GameManager.instance.SaveState();
            Scene scene = SceneManager.GetActiveScene();
            List<string> tmp = new List<string>(sceneNames);
            tmp.Remove(scene.name);
            sceneNames = tmp.ToArray();
            string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
            PlayerMovement.moveSpeedInc += 0.15f;
            SceneManager.LoadScene(sceneName);

        }
        base.OnCollide(coll);
    }
}
