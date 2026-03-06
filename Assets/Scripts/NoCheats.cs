using UnityEngine;

public class NoCheats : MonoBehaviour
{
    public Vector3 moveDirection = Vector3.right; // direction it pushes
    public float moveDistance = 3f;                // how far it moves
    public float speed = 4f;                       // how fast

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool activated = false;

    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + moveDirection.normalized * moveDistance;
    }

    void Update()
    {
        if (activated)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPos,
                speed * Time.deltaTime
            );
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            activated = true;
        }
    }
}