using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    public int id;
    void Awake()
    {
        id = IDGenerator.instance.GetStarId();
    }
}
