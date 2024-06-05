using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private Transform _selection;

    void Start()
    {
    }

    void Update()
    {
        if (_selection != null)
        {
            _selection = null;
        }

        Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
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

    private void Destroy(bool v)
    {
        throw new NotImplementedException();
    }
}
