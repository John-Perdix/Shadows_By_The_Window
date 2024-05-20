using UnityEngine;
using UnityEngine.EventSystems;

public class SetupButtonEvents : MonoBehaviour
{
    void Start()
    {
        Debug.Log($"{gameObject.name} SetupButtonEvents Start called");

        EventTrigger trigger = GetComponent<EventTrigger>();
        if (trigger == null)
        {
            trigger = gameObject.AddComponent<EventTrigger>();
            Debug.Log($"{gameObject.name} EventTrigger component added");
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

        Debug.Log($"{gameObject.name} EventTrigger entries set up");
    }
}
