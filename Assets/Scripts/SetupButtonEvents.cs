using UnityEngine;
using UnityEngine.EventSystems;

public class SetupButtonEvents : MonoBehaviour
{
    void Start()
    {

        EventTrigger trigger = GetComponent<EventTrigger>();
        if (trigger == null)
        {
            trigger = gameObject.AddComponent<EventTrigger>();
        }

        // Pointer Enter
        EventTrigger.Entry entryEnter = new EventTrigger.Entry();
        entryEnter.eventID = EventTriggerType.PointerEnter;
        entryEnter.callback.AddListener((eventData) => { GetComponent<ButtonHover>().OnPointerEnter((PointerEventData)eventData); });
        trigger.triggers.Add(entryEnter);

        // Pointer Exit
        EventTrigger.Entry entryExit = new EventTrigger.Entry();
        entryExit.eventID = EventTriggerType.PointerExit;
        entryExit.callback.AddListener((eventData) => { GetComponent<ButtonHover>().OnPointerExit((PointerEventData)eventData); });
        trigger.triggers.Add(entryExit);

    }
}
