using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PressKeyOpenDoor : MonoBehaviour
{
    public GameObject Instruction;
    public GameObject InstructionClose;
    public GameObject AnimeObject1;
    public GameObject AnimeObject2;
    public GameObject ThisTrigger;
    public AudioSource DoorOpenSound;
    public bool Action = false;
    public bool closed = true;

    void Start()
    {
        Instruction.SetActive(false);

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            Instruction.SetActive(true);
            Action = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        Instruction.SetActive(false);
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
                if (closed==true)
                {
                    Instruction.SetActive(false);
                    InstructionClose.SetActive(true);
                    AnimeObject1.GetComponent<Animator>().Play("open-window");
                    AnimeObject2.GetComponent<Animator>().Play("open-window-dir");
                    //ThisTrigger.SetActive(false);
                    DoorOpenSound.Play();
                    //Action = false;
                    closed = false;
                }
                else
                {
                    Instruction.SetActive(true);
                    InstructionClose.SetActive(false);
                    AnimeObject1.GetComponent<Animator>().Play("close-window");
                    AnimeObject2.GetComponent<Animator>().Play("close-window-dir");
                    //ThisTrigger.SetActive(false);
                    DoorOpenSound.Play();
                    closed = true;
                    //Action = false;
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
}
