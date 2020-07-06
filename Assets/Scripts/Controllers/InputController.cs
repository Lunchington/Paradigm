using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject playerPanel;
    [SerializeField] private GameObject hotBar;

      // Start is called before the first frame update
    void Awake()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        playerPanel.SetActive(!playerPanel.activeSelf);
    }

    // Update is called once per frame
    void Update()
    {
   
        PollKeys();
       
    }

    private void PollKeys()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            playerPanel.SetActive(!playerPanel.activeSelf);
        }

    }
}
