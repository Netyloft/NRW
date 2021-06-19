using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class ControllerPannedWithBuildings : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject main;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _panel.SetActive(!_panel.activeSelf);
        }
    }

    private void OnEnable()
    {
        MainObject.MainBuildet += DestroyMain;
    }

    private void OnDisable()
    {
        MainObject.MainBuildet -= DestroyMain;
    }

    private void DestroyMain()
    {
        Destroy(main);
    }
}
