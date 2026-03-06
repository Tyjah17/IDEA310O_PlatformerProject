using System.Collections.Generic;
using UnityEngine;

public class ConveyorBoxMover : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private Vector3 direction = Vector3.right;
    [SerializeField] private List<Rigidbody> boxesOnBelt = new List<Rigidbody>();

    private void FixedUpdate()
    {
        Vector3 moveAmount = direction.normalized * speed * Time.fixedDeltaTime;

        for (int i = boxesOnBelt.Count - 1; i >= 0; i--)
        {
            if (boxesOnBelt[i] == null)
            {
                boxesOnBelt.RemoveAt(i);
                continue;
            }

            boxesOnBelt[i].MovePosition(boxesOnBelt[i].position + moveAmount);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ConveyorBox"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null && !boxesOnBelt.Contains(rb))
            {
                boxesOnBelt.Add(rb);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ConveyorBox"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                boxesOnBelt.Remove(rb);
            }
        }
    }
}