using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                    if(Physics.Raycast(ray, out hit))
                    {
                        if(hit.collider.gameObject.tag == "Trash")
                        {
                            hit.collider.gameObject.transform.position = ray.direction;
                        }
                    }
                }
                if(Input.GetTouch(i).phase == TouchPhase.Ended)
                {
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider.gameObject.tag == "Trash")
                        {
                            hit.collider.gameObject.transform.position = ray.direction;
                        }
                    }
                }
            }
        }
    }
}
