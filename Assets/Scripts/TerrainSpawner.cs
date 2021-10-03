using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawner : MonoBehaviour
{
    public GameObject currentSection;
    private float sectionWidth;
    private bool spawnSection = true;
    private GameObject prevSection;
    private List<GameObject> currentSectionObjects = new List<GameObject>();
    private List<GameObject> prevSectionObjects = new List<GameObject>();

    public bool reverse = false;

    void Start()
    {
        sectionWidth = currentSection.GetComponent<Renderer>().bounds.size.x;
    }


    void Update()
    {
        if (reverse)
        {
            if (prevSection != null && transform.position.x < prevSection.transform.position.x)
            {
                if (prevSectionObjects.Count > 0)
                    foreach (var obj in prevSectionObjects)
                    {
                        Destroy(obj);
                    }

                Destroy(prevSection);
                spawnSection = true;
            }

            if (spawnSection && transform.position.x < currentSection.transform.position.x)
            {
                spawnSection = false;

                prevSectionObjects = currentSectionObjects;
                prevSection = currentSection;

                currentSection = Instantiate(prevSection, prevSection.transform.parent);
                var nextSectionX = new Vector3(
                    prevSection.transform.position.x - sectionWidth/4,
                    prevSection.transform.position.y);

                currentSection.transform.position = nextSectionX;
            }

        }
        else
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
            }
        }

        
    }
}
