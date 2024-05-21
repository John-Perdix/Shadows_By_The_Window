using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private Transform _selection;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_selection != null)
        {
            _selection = null;
        }
        Vector3 screenCenter = new(Screen.width / 2f, Screen.height / 2f, 0f);
        //Vector3 screenCenter = Camera.main.ScreenToViewportPoint(new Vector3(Screen.width/2f, Screen.height/2f, 0.0f));
        //Ray ray = Camera.main.ScreenPointToRay(screenCenter);

        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red);

        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag("Selectable"))
            {
                Debug.Log("ray tracing is tracing");
            }
            else
            {
                Debug.Log("Not Tracing");
            }
        }
    }
}
