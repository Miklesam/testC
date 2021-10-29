using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public List<GameObject> coachs;
    public GameObject portal;
    public float respawnTime = 1.0f;
    private float respawnPortal = 14.5f;
    public GameObject player;
    private Vector2 screenBounds;
    private List<GameObject> allObjects = new List<GameObject>();
    private float startYPos = 0.0f;
    public bool reverse = false;
    public bool reverseGravity = false;
    private float lastCouchWidth = 0;
    private bool portalSpawned;

    void Start()
    {
        startYPos = player.transform.position.y - player.GetComponent<SpriteRenderer>().bounds.extents.y;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(coachWave());
        StartCoroutine(portalWave());
    }

    [System.Obsolete]
    private void spawnCouch()
    {
        
        GameObject a = Instantiate(coachs[Random.Range(0, coachs.Count)]);
        int randY = 0;
        if (reverseGravity)
        {
            randY = Random.RandomRange(-1, 1);
        }
        else
        {
            randY =Random.RandomRange(0, 2);
        }

        if (reverse)
        {
            a.transform.position = new Vector2(
                player.transform.position.x - 2*screenBounds.x - lastCouchWidth, 
                calculateYPoint(a));
        }
        else {
            a.transform.position = new Vector2(
                player.transform.position.x + 2*screenBounds.x + lastCouchWidth, 
                calculateYPoint(a));
        }
        lastCouchWidth = a.GetComponent<SpriteRenderer>().bounds.extents.x;
        allObjects.Add(a);
    }
    private void spawnPortal()
    {
        portalSpawned = true;
        
        GameObject a = Instantiate(portal);
        if (reverse)
        {
            a.transform.position = new Vector2(player.transform.position.x - (screenBounds.x * 4), calculateYPoint(portal));
        }
        else
        {
            a.transform.position = new Vector2(player.transform.position.x + (screenBounds.x * 4), calculateYPoint(portal));
        }
        allObjects.Add(a);
    }

    IEnumerator coachWave()
    {
        while (!portalSpawned)
        {
            float randRespawn = Random.RandomRange(1.4f, 2.8f);
            yield return new WaitForSeconds(randRespawn);
            spawnCouch();
        }
    }

    IEnumerator portalWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnPortal);
            spawnPortal();
        }
    }

    void Update()
    {
        allObjects.ForEach(checkForDelete);
    }

    private void checkForDelete(GameObject gameObject) {
        if (reverse)
        {
            if (gameObject.transform.position.x > player.transform.position.x + screenBounds.x * 2)
            {
                allObjects.Remove(gameObject);
                Destroy(gameObject);
            }
        }
        else
        {
            if (gameObject.transform.position.x < player.transform.position.x - screenBounds.x * 2)
            {
                allObjects.Remove(gameObject);
                Destroy(gameObject);
            }
        }
        
    }

    float calculateYPoint(GameObject gameObject)
    {
        var halfHeight = gameObject.GetComponent<SpriteRenderer>().bounds.extents.y;
        if (reverse)
            return halfHeight - startYPos;
        else
            return halfHeight + startYPos;    
        
        
    }
}
