using UnityEngine;

public class WaterRise : MonoBehaviour
{
    public float riseSpeed = 0.5f;   // how fast the water rises
    public float maxHeight = 20f;    // optional limit

    void Update()
    {
        if (transform.position.y < maxHeight)
        {
            transform.position += Vector3.up * riseSpeed * Time.deltaTime;
        }
    }
}