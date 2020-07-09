
using UnityEngine;

public class StarScript : MonoBehaviour
{
    private Vector3 leftCorner;
    public float speed = 10f;
    // Update is called once per frame
    private void Start()
    {
        leftCorner = new Vector3(-2, 4.5f, 0);
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, leftCorner, Time.deltaTime * speed);
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, 0.01f);
        if (transform.position == leftCorner)
        {
            Destroy(this.gameObject);
        }
    }
}
