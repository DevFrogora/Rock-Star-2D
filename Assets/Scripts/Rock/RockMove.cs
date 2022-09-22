using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RockMove : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }
    float deltaX;
    float deltaY;

    Touch touch;
    Vector2 touchPos;
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            RaycastHit2D hit = Physics2D.Raycast(touchPos, Camera.main.transform.forward);

            if (hit)
            {

                //Debug.Log(hit.transform.gameObject.name);
                if(hit.transform.tag == "Rock")
                {
                    switch (touch.phase)
                    {
                        case TouchPhase.Began:
                            deltaX = touchPos.x - transform.position.x;
                            deltaY = touchPos.y - transform.position.y;
                            break;

                        case TouchPhase.Moved:
                            transform.position = new Vector2(touchPos.x - deltaX,
                                                             touchPos.y - deltaY);
                            break;

                        default:
                            break;

                    }
                }

            }


        }

    }

}
