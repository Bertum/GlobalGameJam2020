using UnityEngine;
using UnityEngine.UI;

public class WaterMeter : MonoBehaviour
{
    public Slider WaterSlider;

    public void SetWaterLevel(float level)
    {
        WaterSlider.value = level;
    }
}
