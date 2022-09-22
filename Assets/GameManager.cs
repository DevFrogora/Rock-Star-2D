using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;

    public event Action gameStart, gameEnd;
    public event Action<int> scoreUpdate;
    StarSpawn spawnStar;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        StartCoroutine(SpawnAtNextFrame());
        spawnStar = GetComponent<StarSpawn>();
    }

    IEnumerator SpawnAtNextFrame()
    {
        yield return new WaitForEndOfFrame();
        GameStarted();
    }


    public void GameStarted()
    {
        gameStart?.Invoke();
    }
    public void GameEnded()
    {
        gameEnd?.Invoke();
    }

    public void UpdateScore(int score)
    {
        scoreUpdate?.Invoke(score);
        if (spawnStar.totalStarToSpawn == score)
        {
            GameEnded();
        }
    }
}
