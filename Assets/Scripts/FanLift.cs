using UnityEngine;
using StarterAssets;

public class FanLift : MonoBehaviour {
    [SerializeField] private float upSpeed = 10f;
    [SerializeField] private float accel = 40f;

    private void OnTriggerStay(Collider other) {
        var player = other.GetComponentInParent<ThirdPersonController>();
        if (!player) return;
        player.SetFan(upSpeed, accel);
    }

    private void OnTriggerExit(Collider other) {
        var player = other.GetComponentInParent<ThirdPersonController>();
        if (!player) return;
        player.ClearFan();
    }
}