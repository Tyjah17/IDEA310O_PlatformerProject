using UnityEngine;
using System.Collections;

public class AcidGeyserEffect : MonoBehaviour
{
    [Header("References")]
    public ParticleSystem acidParticles;

    // This is the invisible trigger volume that kills the player
    public Collider damageTrigger;

    [Header("Timing")]
    public float offTime = 2f;
    public float onTime = 3f;

    [Header("State (read-only)")]
    public bool isActive { get; private set; }

    private void Awake()
    {
        // Auto-find if you forgot to drag it
        if (acidParticles == null)
            acidParticles = GetComponentInChildren<ParticleSystem>();

        if (damageTrigger == null)
            damageTrigger = GetComponent<Collider>();

        // Make sure the trigger starts OFF
        SetActiveState(false);
    }

    private void Start()
    {
        if (acidParticles == null)
            Debug.LogError("[AcidGeyserEffect] acidParticles is not assigned/found.");

        if (damageTrigger == null)
            Debug.LogError("[AcidGeyserEffect] damageTrigger is not assigned/found.");

        // If particles exist, make sure they aren't looping/auto-playing
        if (acidParticles != null)
        {
            var main = acidParticles.main;
            main.loop = false;
            main.playOnAwake = false;
        }

        StartCoroutine(GeyserRoutine());
    }

    private IEnumerator GeyserRoutine()
    {
        while (true)
        {
            // OFF
            SetActiveState(false);
            Debug.Log("[AcidGeyserEffect] OFF");
            yield return new WaitForSeconds(offTime);

            // ON
            SetActiveState(true);
            Debug.Log("[AcidGeyserEffect] ON");
            if (acidParticles != null) acidParticles.Play();
            yield return new WaitForSeconds(onTime);

            // stop emitting (lets existing particles fade)
            if (acidParticles != null)
                acidParticles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }
    }

    private void SetActiveState(bool active)
    {
        isActive = active;

        if (damageTrigger != null)
            damageTrigger.enabled = active;
    }
}