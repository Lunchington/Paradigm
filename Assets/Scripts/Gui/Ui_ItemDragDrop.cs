using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ui_ItemDragDrop : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler,IEndDragHandler,IDragHandler
{
    private RectTransform recTransform;
    private Canvas mainCanvas;
    private CanvasGroup canvasGroup;

    public Transform startParent;
    private Vector3 startPosition;
    private Ui_Inventory uiInventory;

    public bool isDragging = false;

    private void Awake()
    {

        recTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent < CanvasGroup>();
        mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
        uiInventory = WorldController.Instance.InventoryPanel.GetComponent<Ui_Inventory>();
        
        
    }


    public void OnBeginDrag(PointerEventData eventData)
    {

        canvasGroup.alpha = .5f;
        canvasGroup.blocksRaycasts = false;

        startParent = transform.parent;
        startPosition = transform.position;

        transform.SetParent(mainCanvas.transform);
        transform.GetChild(0).gameObject.SetActive(false);

    }

    public void OnDrag(PointerEventData eventData)
    {
        recTransform.anchoredPosition += eventData.delta / mainCanvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.GetChild(0).gameObject.SetActive(true);

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


    public void OnPointerUp(PointerEventData eventData)
    {

        //Dropping item into "world"
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            Item droppingItem = GetComponent<Ui_Item>().item;

            Inventory inv = WorldController.Instance.GetPlayerInventory();


            Vector3 playerPos = WorldController.Instance.GetPlayerPos();
            Vector3 eventPos = Camera.main.ScreenToWorldPoint(eventData.position);


            inv.RemoveItem(droppingItem);
            playerPos = new Vector3(eventPos.x, eventPos.y, -4);

            ItemWorld.SpawnItemWorld(playerPos, droppingItem);
            Destroy(this.gameObject);

        }

    }


}
