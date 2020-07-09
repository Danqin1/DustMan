using System.Numerics;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    RaycastHit hit;
    Ray ray;
    public GameObject star;
    public int score;
    void Start()
    {
        score = 0;
    }
    private void OnApplicationQuit()
    {
        if(score > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "RedTrash" || hit.collider.gameObject.tag == "BlueTrash" || hit.collider.gameObject.tag == "YellowTrash" || hit.collider.gameObject.tag == "GreenTrash")
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
                if (hit.collider.gameObject.tag == "RedTrash" || hit.collider.gameObject.tag == "BlueTrash" || hit.collider.gameObject.tag == "YellowTrash" || hit.collider.gameObject.tag == "GreenTrash")
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
                    ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider.gameObject.tag == "RedTrash" || hit.collider.gameObject.tag == "BlueTrash" || hit.collider.gameObject.tag == "YellowTrash" || hit.collider.gameObject.tag == "GreenTrash")
                        {
                            hit.collider.gameObject.GetComponent<Obstacle>().hold = true;
                            //hit.collider.gameObject.transform.position = ray.origin;
                        }
                    }
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
                    ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider.gameObject.tag == "RedTrash" || hit.collider.gameObject.tag == "BlueTrash" || hit.collider.gameObject.tag == "YellowTrash" || hit.collider.gameObject.tag == "GreenTrash")
                        {
                            hit.collider.gameObject.GetComponent<Obstacle>().hold = false;
                            //hit.collider.gameObject.transform.position = ray.origin;
                        }
                    }
                }
            }
        }
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        //------------------------------------------touch input--------------------------------------------------------------
    }
    public void SpawnStar(UnityEngine.Vector3 pos)
    {
        Instantiate(star, pos, UnityEngine.Quaternion.identity);
    }
}
