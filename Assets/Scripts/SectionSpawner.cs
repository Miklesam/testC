using System.Collections.Generic;
using UnityEngine;

public class SectionSpawner : MonoBehaviour
{
    public GameObject currentSection;
    public GameObject trapBox;
    public GameObject trap2Box;
    public GameObject trapAir;
    public GameObject portal;
    private GameObject prevSection;
    public float yOfObj;

    private int countSpawned = 0;
    private float sectionWidth;
    private bool spawnSection = true;
    private int barriersSize = 1;
    private List<GameObject> currentSectionObjects = new List<GameObject>();
    private List<GameObject> prevSectionObjects = new List<GameObject>();

    void Start()
    {
        sectionWidth = currentSection.GetComponent<Renderer>().bounds.size.x;
        Debug.Log("startsection");
        Debug.Log(sectionWidth.ToString());
    }


    void Update()
    {
        if (prevSection != null && transform.position.x > prevSection.transform.position.x + sectionWidth)
        {
            if (prevSectionObjects.Count > 0)
                foreach (var obj in prevSectionObjects)
                {
                    Destroy(obj);
                }

            Destroy(prevSection);
            spawnSection = true;
        }

        if (spawnSection && transform.position.x >= currentSection.transform.position.x)
        {
            spawnSection = false;

            prevSectionObjects = currentSectionObjects;
            prevSection = currentSection;

            currentSection = Instantiate(prevSection, prevSection.transform.parent);
            var nextSectionX = new Vector3(
                prevSection.transform.position.x + sectionWidth,
                prevSection.transform.position.y);

            currentSection.transform.position = nextSectionX;

            SpawnObjects(barriersSize);
        }
    }

    private void SpawnObjects(int size)
    {
        float nextSectionStartX = currentSection.transform.position.x - (sectionWidth / 2);
        float xRandomItemWidth = sectionWidth / 2* size;

        currentSectionObjects = new List<GameObject>();

        bool poratalSpawned = false;
        for (int i = 0; i < size; i++)
        {
            if (poratalSpawned)
            {
                break;
            }
            
            int randomNewSectionX =
                Random.Range((int) nextSectionStartX, (int) (nextSectionStartX += xRandomItemWidth));

            GameObject spawnObject;
            var objectType = Random.Range(0, 7);
            Debug.Log(objectType);
            Debug.Log("countSpawned" + countSpawned);

            if (countSpawned > 6)
            {
                spawnObject = Instantiate(portal);
                poratalSpawned = true;
            }
            else if (objectType < 2)
                spawnObject = Instantiate(trapBox);
            else if (objectType < 3)
                spawnObject = Instantiate(trapBox);
            else if (objectType < 4)
                spawnObject = Instantiate(trapBox);
            else 
                spawnObject = Instantiate(trapBox);

            currentSectionObjects.Add(spawnObject);
            spawnObject.transform.position = new Vector3(randomNewSectionX, yOfObj);

            countSpawned += 1;
        }
    }
}