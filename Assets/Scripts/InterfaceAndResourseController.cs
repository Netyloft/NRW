using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;

public class InterfaceAndResourseController : MonoBehaviour
{
    
    public static InterfaceAndResourseController instance;

    [SerializeField] private TextMeshProUGUI WoodText;
    [SerializeField] private TextMeshProUGUI StoneText;
    [SerializeField] private TextMeshProUGUI IronText;
    [SerializeField] private int WoodCount;
    [SerializeField] private int StoneCount;
    [SerializeField] private int IronCount;
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpdateUi();
    }

    public void AddResource(MapObjectType type, int count)
    {
        switch (type)
        {
            case MapObjectType.Tree:
                WoodCount += count;
                UpdateUi();
                break;
            case MapObjectType.Stone:
                StoneCount += count;
                UpdateUi();
                break;
            case MapObjectType.Iron:
                IronCount += count;
                UpdateUi();
                break;
        }
    }

    private void UpdateUi()
    {
        WoodText.text = $"{WoodCount}";
        StoneText.text = $"{StoneCount}";
        IronText.text = $"{IronCount}";
    }
}
