using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public int totalStarToSpawn;
    StarPool starPool;
    Vector3 lowerBoundX, upperBoundX, lowerBoundY, upperBoundY;
    Vector3 boundary = new Vector3(0.3f, 0.3f, 0);
    private void Start()
    {
        lowerBoundX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)) - boundary;
        upperBoundX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)) - boundary;
        lowerBoundY = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)) - boundary;
        upperBoundY = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0)) - boundary;
        // we need only x and y from this bound and the depth should be 0 , because our all gameobject drop on 0 (z)depth;
        starPool = GetComponent<StarPool>();
        GameManager.instance.gameStart += onGameStart;
    }

    void onGameStart()
    {
        spawnNumberofStar(totalStarToSpawn);
    }


    void spawnNumberofStar(int totalStar)
    {
        for (int i = 0; i < totalStar; i++)
        {
            starPool.GetStar(getRandomPosition()).SetActive(true);
        }
    }



    bool inRange(float value, float minVal, float maxVal)
    {
        if (value > minVal && value < maxVal)
        {
            return true;
        }
        return false;

    }

    // don't spawn in this range
    float rockRadius = 0.5f + 0.2f; // added 0.2 because just for gap between rock and star;

    public Vector3 getRandomPosition()
    {
        float x = Random.Range(lowerBoundX.x, upperBoundX.x); //x
        float y = Random.Range(lowerBoundY.y, upperBoundY.y);
        while (inRange(x, -rockRadius, rockRadius))
        {
            x = Random.Range(lowerBoundX.x, upperBoundX.x); //x
            Debug.Log("fall in sphere x");
        };
        while (inRange(y, -rockRadius, rockRadius))
        {
            y = Random.Range(lowerBoundY.y, upperBoundY.y);
            Debug.Log("fall in sphere z");

        };
        return new Vector3(x, y, 0);
    }


    private void OnDestroy()
    {
        GameManager.instance.gameStart -= onGameStart;
    }
}
