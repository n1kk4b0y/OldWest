using UnityEngine;
using UnityEngine.SceneManagement;

public class Menumanagingbb : MonoBehaviour
{
    public GameObject MenuManagin; // Referência ao CanvaMenu
    private bool isPaused = false; // Estado do jogo

    void Start()
    {
        // Esconder o menu de pausa ao iniciar o jogo
        MenuManagin.SetActive(false);
    }

    void Update()
    {
       
    }

    public void Resume()
    {

        MenuManagin.SetActive(false);  // Esconder o menu de pausa
    }




    public void Pause()
    {
        MenuManagin.SetActive(true);   // Mostrar o menu de pausa
    }

    public void OnPlayButtonPressed()
    {
        Debug.Log("Botão Play pressionado");  // Adiciona uma mensagem de debug ao pressionar o botão Play
        Resume(); // Continuar o jogo ao clicar em "Play"
    }


    public void OnMainMenuButtonPressed()
    {
        Time.timeScale = 1f;           // Retomar o tempo do jogo
        SceneManager.LoadScene(0); // Carrega a cena do menu principal
    }
}
