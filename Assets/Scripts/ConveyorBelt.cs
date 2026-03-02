using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField]
    private float speed, conveyorSpeed;
    [SerializeField]
    private Vector3 direction;
    [SerializeField]
    private List<GameObject> onBelt;

    private Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        material.mainTextureOffset += new Vector2(0, 1) * conveyorSpeed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        for (int i = 0; i <= onBelt.Count - 1; i++)
        {
            onBelt[i].GetComponent<CharacterController>().Move(speed * direction.normalized * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!onBelt.Contains(other.gameObject)) onBelt.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        onBelt.Remove(other.gameObject);

        var receiver = other.GetComponentInParent<ConveyorReceiver>();
        if (receiver != null) receiver.conveyorVelocity = Vector3.one;
    }
}