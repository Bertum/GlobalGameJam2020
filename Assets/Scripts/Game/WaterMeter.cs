using UnityEngine;
using UnityEngine.UI;

public class WaterMeter : MonoBehaviour
{
    private Slider WaterSlider;

    private void Awake()
    {
        WaterSlider = GetComponent<Slider>();
    }

    public void SetWaterLevel(float level)
    {
        WaterSlider.value = level;
    }
}
