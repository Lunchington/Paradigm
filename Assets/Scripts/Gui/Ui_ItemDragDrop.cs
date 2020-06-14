using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ui_ItemDragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler,IEndDragHandler,IDragHandler
{
    private RectTransform recTransform;
    private Canvas mainCanvas;
    private CanvasGroup canvasGroup;

    private Transform startParent;
    private Vector3 startPosition;

    private void Awake()
    {
        recTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent < CanvasGroup>();
        mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .5f;
        canvasGroup.blocksRaycasts = false;

        startParent = transform.parent;
        startPosition = transform.position;

        transform.SetParent(mainCanvas.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        recTransform.anchoredPosition += eventData.delta / mainCanvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if (transform.parent == mainCanvas.transform)
        {
            transform.SetParent(startParent);
            transform.position = startPosition;
        }
     
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    
}
