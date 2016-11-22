using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragAndDropBuilding : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Vector3 location;
    public static GameObject itemBeingDragged;
    Vector3 startPosition;
    Transform startParent;
    public GameObject res;

    #region IBeginDragHandler implementation

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    #endregion

    #region IDragHandler implementation

    public void OnDrag(PointerEventData eventData)
    {
        location.x = Input.mousePosition.x;
        location.z = Input.mousePosition.y;
        location.y = 3;
        transform.position = location;
    }

    #endregion

    #region IEndDragHandler implementation

    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingDragged = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        res = Resources.Load("Scaffold") as GameObject;
        location.x = eventData.position.x;
        location.z = eventData.position.y;
        location.y = 3;
        GameObject.Instantiate(res, location, Quaternion.identity);
        if (transform.parent == startParent)
        {
            transform.position = startPosition;
        }
    }

    #endregion

}
