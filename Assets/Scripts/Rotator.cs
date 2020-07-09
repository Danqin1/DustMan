using UnityEngine;


public class Rotator : MonoBehaviour
{
    int angle;
    private void Start()
    {
        angle = Random.Range(-4, 4);
    }
    private void Update()
    {
        this.transform.Rotate(0, 0, angle, Space.World);
    }
}
