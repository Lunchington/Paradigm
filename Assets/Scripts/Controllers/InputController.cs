using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour
{
    [SerializeField] private GameObject playerPanel;
    [SerializeField] private ItemSlot[] hotBarSlots;
    [SerializeField] private ItemSlot[] characterPanelSlots;
    [SerializeField] private ItemSlot[] inventoryPanelSlots;


    // Start is called before the first frame update
    void Awake()
    {

        playerPanel.SetActive(!playerPanel.activeSelf);
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
            pointerEventData.position = Input.mousePosition;


            List<RaycastResult> rayCastResult = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerEventData, rayCastResult);
            for (int i = 0; i < rayCastResult.Count; i++)
            {

                if (rayCastResult[i].gameObject.GetComponent<ItemSlot>() != null)
                {
                    Debug.Log(rayCastResult[i].gameObject.GetComponent<ItemSlot>().name);
                }
            }

        }
        
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
            playerPanel.SetActive(!playerPanel.activeSelf);
        }
    }
}
