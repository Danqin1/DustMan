
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GameController gameController;
    private Spawner spawner;
    public float speed = 1f;
    Vector2 target;
    public bool hold = false;
    // Start is called before the first frame update
    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
        spawner = FindObjectOfType<Spawner>();
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
    }
    private void Update()
    {
        float step = speed * Time.deltaTime;
        target = new Vector2(transform.position.x, transform.position.y - 1);
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
        string thisTag = this.gameObject.tag;
        
        if(thisTag[0] == collision.gameObject.tag[0] && thisTag[1] != collision.gameObject.tag[1])
        {
            gameController.score++;
            gameController.SpawnStar(this.gameObject.transform.position);
            if (spawner.timeBetweenSpawns > 0.5f)
            {
                spawner.timeBetweenSpawns -= 0.05f;
            }
        }else if(thisTag[this.tag.Length-1] != collision.gameObject.tag[collision.gameObject.tag.Length-1])
        {
            if (gameController.score > 0)
            {
                gameController.score--;
            }
        }
        if (collision.collider.gameObject.tag != "RedTrash" || collision.collider.gameObject.tag != "BlueTrash" || collision.collider.gameObject.tag != "YellowTrash" || collision.collider.gameObject.tag != "GreenTrash")
        {
            Destroy(this.gameObject);
        }
    }
}
