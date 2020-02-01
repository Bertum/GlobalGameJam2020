using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    private int _leakingWater = 0;
    private float _initialScale;
    private WaterMeter _slider;

    public float WaterScalePerPipePerSecond = 1F;
    public GameObject Water;
    public GameObject Waves;
    public float WaveOffset = 0.5F;
    public float WaterOffset = 3F;
    public float MaxScale = 10F;

    // Start is called before the first frame update
    void Start()
    {
        _initialScale = Water.transform.localScale.y;
        GameObject.Find("PipeManager").GetComponent<PipesManager>().BrokenPipesUpdated += OnLeakingUpdate;
        _slider = GameObject.Find("WaterSlider").GetComponent<WaterMeter>();
    }

    private void OnLeakingUpdate(int brokenPipes)
    {
        _leakingWater = Mathf.Max(brokenPipes, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Water.transform.localScale.y > (MaxScale + _initialScale)) return;
        var deltaWater = Time.deltaTime * WaterScalePerPipePerSecond * _leakingWater;
        var waterPosition = (Water.transform.localScale.y - WaterOffset) / 2;
        var wavesPosition = (Water.transform.localScale.y - WaveOffset);

        Water.transform.localScale = new Vector3(Water.transform.localScale.x, Water.transform.localScale.y + (_initialScale * deltaWater));
        Water.transform.localPosition = new Vector3(0, waterPosition, Water.transform.localPosition.z);
        Waves.transform.localPosition = new Vector3(0, wavesPosition, Waves.transform.localPosition.z);

        _slider.SetWaterLevel(((Water.transform.localScale.y - _initialScale) / MaxScale) * 100);
    }
}
