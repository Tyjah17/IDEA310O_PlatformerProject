using UnityEngine;

public class WaterRise : MonoBehaviour {
    public float riseSpeed = 0.5f;
    public float maxHeight = 20f;
    public float startDelay = 5f;

    private float timer = 0f;
    private bool rising = false;

    void Update() {
        timer += Time.deltaTime;

        // Start rising after delay
        if (!rising && timer >= startDelay) {
            rising = true;
        }

        // Move water upward
        if (rising && transform.position.y < maxHeight) {
            transform.position += Vector3.up * riseSpeed * Time.deltaTime;
        }
    }
}