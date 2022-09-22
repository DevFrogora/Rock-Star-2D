using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    // Start is called before the first frame update
    public int id;
    private int score = 0;
    public List<GameObject> collectedStar;
    public Transform Bag;
    // Start is called before the first frame update
    RockMove rockDragMove;
    void Start()
    {
        collectedStar = new List<GameObject>();
        rockDragMove = GetComponent<RockMove>();
        GameManager.instance.gameStart += Instance_gameStart;
        GameManager.instance.gameEnd += Instance_gameEnd;
        id = IDGenerator.instance.GetRockId();
    }

    private void Instance_gameStart()
    {

        GameManager.instance.UpdateScore(score);
    }
    private void Instance_gameEnd()
    {
        rockDragMove.enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Star>())
        {
            collision.gameObject.SetActive(false);
            collision.gameObject.transform.parent = Bag.transform;
            collectedStar.Add(collision.gameObject);
        }
        score += 1;
        GameManager.instance.UpdateScore(score);
    }

    private void OnDestroy()
    {
        GameManager.instance.gameStart -= Instance_gameStart;
        GameManager.instance.gameEnd -= Instance_gameEnd;
    }

}
