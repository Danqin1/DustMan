
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 4f;
    Vector2 target;
    public bool hold = false;
    // Start is called before the first frame update

    private void Update()
    {
        float step = speed * Time.deltaTime;
        target = new Vector2(transform.position.x, -5);
        if (!hold)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, step);
        }else if(hold)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector3.Lerp(transform.position,new Vector3(mousePos.x,mousePos.y,0), 1);
        }
        if(transform.position.y <-4.9f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
