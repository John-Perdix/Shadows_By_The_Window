using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWindowController : MonoBehaviour
{
    [SerializeField] private Animator janela = null;
    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;

    private void onTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger)
            {
                janela.Play("window-open", 0, 0.0f);
                gameObject.SetActive(false);
            }
        }
        else if (closeTrigger)
        {
            janela.Play("window-close", 0, 0.0f);
            gameObject.SetActive(false);
        }
    }
}
