using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MessageScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Transform npcMessage;

    //Detect if the Cursor starts to pass over the GameObject
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        //Output to console the GameObject's name and the following message
        npcMessage.gameObject.SetActive(true);
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        //Output the following message with the GameObject's name
        npcMessage.gameObject.SetActive(false);
    }
}
