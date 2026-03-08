using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BatteryCollector : MonoBehaviour {
    public TMP_Text BatteryText;
    public int BattsPerLvl = 5;
    public AudioClip pickupSound;
    private int batteriesCollected = 0;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Battery")) {
            AudioSource.PlayClipAtPoint(pickupSound, other.transform.position);
            batteriesCollected++;
            BatteryText.text = "BATTERIES COLLECTED: " + batteriesCollected + "/" + BattsPerLvl;
            Destroy(other.gameObject);

            if (batteriesCollected >= BattsPerLvl) {
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                int totalScenes = SceneManager.sceneCountInBuildSettings;

                // if this is the last scene, go to menu
                if (currentSceneIndex == totalScenes - 1) {
                    SceneManager.LoadScene("Menu");
                } else {
                    // otherwise load next level
                    SceneManager.LoadScene(currentSceneIndex + 1);
                }
            }
        }
    }
}