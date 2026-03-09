using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Referência ao CanvaMenu
    private bool isPaused = false; // Estado do jogo

    void Start()
    {
        // Esconder o menu de pausa ao iniciar o jogo
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        // Verifica se a tecla Escape foi pressionada
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();  // Se o jogo está pausado, retome
            }
            else
            {
                Pause();   // Se o jogo não está pausado, pause
            }
        }
    }

    public void Resume()
    {
        Debug.Log("Resume chamado"); // Verificação se o método está sendo chamado

        pauseMenuUI.SetActive(false);  // Esconder o menu de pausa
        Time.timeScale = 1f;           // Retomar o tempo normal do jogo
        isPaused = false;              // Atualizar o estado do jogo

        Debug.Log("Time.timeScale após retomar: " + Time.timeScale); // Verificação do estado do Time.timeScale
    }




    void Pause()
    {
        pauseMenuUI.SetActive(true);   // Mostrar o menu de pausa
        Time.timeScale = 0f;           // Pausar o tempo do jogo
        isPaused = true;               // Atualizar o estado do jogo
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
