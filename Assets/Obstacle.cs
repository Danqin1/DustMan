
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 4f;
    Vector2 target;
    // Start is called before the first frame update

    private void Update()
    {
        float step = speed * Time.deltaTime;
        target = new Vector2(transform.position.x, -5);
        //transform.position = Vector2.MoveTowards(transform.position, target, step);
        if(transform.position.y <-4.9f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        Destroy(this.gameObject);
    }
}
