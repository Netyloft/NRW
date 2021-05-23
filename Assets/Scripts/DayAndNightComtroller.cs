using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DayAndNightComtroller : MonoBehaviour
{
    [SerializeField] private Gradient directionalLightGradient;
    [SerializeField] private Gradient ambientLightGradient;
    [SerializeField, Range(1, 3600)] private float timeDayInSeconds = 60;
    [SerializeField, Range(0f, 1f)] private float timeProgress;
    [SerializeField] private Light directLight;
    [SerializeField] private bool isFreezTime;

    private Vector3 defaultAngless;
    void Start()
    {
        defaultAngless = directLight.transform.localEulerAngles;
    }
    
    void Update()
    {
        if (Application.isPlaying && !isFreezTime)
            timeProgress += Time.deltaTime / timeDayInSeconds;

        if (timeProgress > 1f)
            timeProgress = 0f;

        directLight.color = directionalLightGradient.Evaluate(timeProgress);
        RenderSettings.ambientLight = ambientLightGradient.Evaluate(timeProgress);
        
        directLight.transform.localEulerAngles = new Vector3(360f * timeProgress - 45, defaultAngless.x, defaultAngless.z);
    }
}
