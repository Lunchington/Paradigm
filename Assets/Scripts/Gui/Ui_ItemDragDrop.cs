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
        startParent.GetComponent<Ui_ItemSlot>().ItemText = null;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if (transform.parent == mainCanvas.transform)
        {
            transform.SetParent(startParent);
            transform.position = startPosition;
            startParent.GetComponent<Ui_ItemSlot>().ItemText = transform.Find("Count").GetComponent<TextMeshProUGUI>();
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
            Item droppingItem = GetComponent<Ui_Item>().GetItem();

            Inventory inv = WorldController.Instance.GetPlayerInventory();


            Vector3 playerPos = WorldController.Instance.GetPlayer().transform.position;

            inv.RemoveItem(droppingItem);
            playerPos = new Vector3(playerPos.x + 1, playerPos.y, playerPos.z+1);

            ItemWorld.SpawnItemWorld(playerPos, droppingItem);
            Destroy(this.gameObject);

        }

    }


}
