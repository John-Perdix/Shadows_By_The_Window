using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField] private GameObject painelMenuPrincipal;
    [SerializeField] private GameObject painelOpcoes;
    [SerializeField] private GameObject painelPauseMenu;
    [SerializeField] private GameObject painelSettings;

    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }

    public void AbrirOpcoes()
    {
        painelMenuPrincipal.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void AbrirSettings()
    {
        painelPauseMenu.SetActive(false);
        painelSettings.SetActive(true);
    }

    public void SairOpcoes()
    {
        painelOpcoes.SetActive(false);
        painelMenuPrincipal.SetActive(true);
    }

    public void SairSettings()
    {
        painelSettings.SetActive(false);
        painelPauseMenu.SetActive(true);
    }

    public void SairJogo()
    {
        Application.Quit();
    }


}
