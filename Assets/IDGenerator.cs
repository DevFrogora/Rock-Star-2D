using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDGenerator : MonoBehaviour
{
    public static IDGenerator instance;
    private void Awake()
    {
        instance = this;
    }
    int rockId = 0;
    public int GetRockId()
    {
        rockId = rockId + 1;
        return rockId;
    }

    int starId = 0;
    public int GetStarId()
    {
        starId = starId + 1;
        return starId;
    }
}
