using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class PlayerConveyor : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float conveyorSpeed = 1f;
    [SerializeField] private Vector3 direction = Vector3.forward;
    [SerializeField] private List<GameObject> onBelt = new List<GameObject>();

    private Material material;

    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        material.mainTextureOffset += new Vector2(0, 1) * conveyorSpeed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        Vector3 conveyorVelocity = direction.normalized * speed;

        for (int i = onBelt.Count - 1; i >= 0; i--)
        {
            if (onBelt[i] == null)
            {
                onBelt.RemoveAt(i);
                continue;
            }

            ThirdPersonController controller = onBelt[i].GetComponent<ThirdPersonController>();

            if (controller != null)
            {
                controller.SetConveyor(conveyorVelocity);
            }
            else
            {
                onBelt.RemoveAt(i);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (!onBelt.Contains(other.gameObject))
        {
            onBelt.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        onBelt.Remove(other.gameObject);

        ThirdPersonController controller = other.GetComponent<ThirdPersonController>();
        if (controller != null)
        {
            controller.ClearConveyor();
        }
    }
}