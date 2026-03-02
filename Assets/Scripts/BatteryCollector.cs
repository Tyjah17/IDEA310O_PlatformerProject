using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BatteryCollector : MonoBehaviour
{
    public TMP_Text BatteryText;
    public int BattsPerLvl = 5;
    private int batteriesCollected = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Battery"))
        {
            batteriesCollected++;
            BatteryText.text = "BATTERIES COLLECTED: " + batteriesCollected + "/" + BattsPerLvl;
            Destroy(other.gameObject);

            if (batteriesCollected >= BattsPerLvl)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
}