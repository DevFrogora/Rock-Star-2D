using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPool : MonoBehaviour
{
    public GameObject starPrefab;

    public List<GameObject> starPool = new List<GameObject>();
    public int starPoolSize = 10;
    // Start is called before the first frame update
    void Start()
    {
        InstantiateStar();
    }

    public void InstantiateStar()
    {
        for (int i = 0; i < starPoolSize; i++)
        {
            GameObject star = Instantiate(starPrefab);
            starPool.Add(star);
            star.SetActive(false);
        }
    }

    public GameObject GetStar(Vector3 Onposition)
    {
        if (starPool.Count > 0)
        {
            for (int i = 0; i < starPoolSize; i++)
            {
                if (!starPool[i].activeInHierarchy)
                {
                    GameObject star = starPool[i];
                    star.transform.position = Onposition;
                    star.transform.rotation = Quaternion.identity;
                    return star;
                }
            }
        }
        else
        {
            GameObject star = Instantiate(starPrefab);
            star.transform.position = Onposition;
            star.transform.rotation = Quaternion.identity;
            return star;
        }

        return null;
    }
}
