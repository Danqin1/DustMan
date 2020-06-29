using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    RaycastHit hit;
    Ray ray;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject.tag == "Trash")
                {
                    hit.collider.gameObject.GetComponent<Obstacle>().hold = true;
                    //hit.collider.gameObject.transform.position = ray.origin;
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject.tag == "Trash")
                {
                    hit.collider.gameObject.GetComponent<Obstacle>().hold = false;
                    //hit.collider.gameObject.transform.position = ray.origin;
                }
            }
        }
        //------------------------------------------touch input--------------------------------------------------------------
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
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
        //------------------------------------------touch input--------------------------------------------------------------
    }
}
