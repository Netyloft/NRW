using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;

public class InterfaceController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI WoodText;
    [SerializeField] private TextMeshProUGUI StoneText;
    [SerializeField] private TextMeshProUGUI IronText;
    
    private void OnEnable()
    {
        ResourseCounter.Change += UpdateUi;
    }

    private void OnDisable()
    {
        ResourseCounter.Change -= UpdateUi;
    }

    private void UpdateUi(int wood, int stone, int iron)
    {
        WoodText.text = $"{wood}";
        StoneText.text = $"{stone}";
        IronText.text = $"{iron}";
    }
}
