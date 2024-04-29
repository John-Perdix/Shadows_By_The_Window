using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PressKeyOpenDoor : MonoBehaviour
{
    public GameObject InstructionOpen;
    public GameObject InstructionClose;
    public GameObject AnimeObject1;
    public GameObject AnimeObject2;
    public GameObject ThisTrigger;
    public AudioSource DoorOpenSound;
    public bool Action = false;
    public bool windowClosed = true;
    public Animator animator;


    void Start()
    {
        InstructionOpen.SetActive(false);
        InstructionClose.SetActive(false);

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            InstructionOpen.SetActive(true);
            Action = true;
            print("Colliding");
            print(Action);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        InstructionOpen.SetActive(false);
        Action = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Action == true)
            {
                //add instruction close to true
                //adicionar um bool para saber se está aberto ou fechado
                //se esta fechado -> fazer a animação de abrir
                //se estiver aberto -> fazer animação para fechar
                CheckAnimation();
                if (!isAnimating)
                {
                    if (windowClosed == true)
                    {
                        InstructionOpen.SetActive(false);
                        InstructionClose.SetActive(true);
                        AnimeObject1.GetComponent<Animator>().Play("open-window");
                        AnimeObject2.GetComponent<Animator>().Play("open-window-dir");
                        //ThisTrigger.SetActive(false);
                        DoorOpenSound.Play();
                        //Action = false;
                        windowClosed = false;
                    }
                    else
                    {
                        InstructionOpen.SetActive(true);
                        InstructionClose.SetActive(false);
                        AnimeObject1.GetComponent<Animator>().Play("close-window");
                        AnimeObject2.GetComponent<Animator>().Play("close-window-dir");
                        //ThisTrigger.SetActive(false);
                        DoorOpenSound.Play();
                        windowClosed = true;
                        //Action = false;
                    }
                }
                //ORIGINAL CODE
                /*Instruction.SetActive(false);
                AnimeObject1.GetComponent<Animator>().Play("open-window");
                AnimeObject2.GetComponent<Animator>().Play("open-window-dir");
                ThisTrigger.SetActive(false);
                DoorOpenSound.Play();
                Action = false; */
            }
        }

    }

bool isAnimating = false;
void CheckAnimation()
{
    // Get the current state information of the animator
    AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);

    // Check if the animation is playing
    if ((currentState.IsName("open-window") || currentState.IsName("close-window")) && currentState.normalizedTime < 1.0f)
    {
        // Set the flag to indicate that the animation is currently playing
        isAnimating = true;
    }
    else
    {
        // Reset the flag if the animation has finished playing
        isAnimating = false;
    }
}

}