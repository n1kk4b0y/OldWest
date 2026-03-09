using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Certifique-se de ter esta diretiva

public class StatusMenu : MonoBehaviour
{
    public GameObject statusMenuUI; // Referência ao CanvasMenu
    private bool isPaused = false; // Estado do jogo

    // Adicione uma variável para contar os incrementos de vida
    public int vidaIncrementos = 0;
    public TMP_Text textoIncrementosVida; // Referência ao texto na interface do usuário

    void Start()
    {
        // Esconder o menu de pausa ao iniciar o jogo
        statusMenuUI.SetActive(false);
        AtualizarTextoIncrementosVida();
    }

    void Update()
    {
        // Verifica se a tecla H foi pressionada
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (isPaused)
            {
                Resume();  // Se o jogo está pausado, retome
            }
            else
            {
                Status();   // Se o jogo não está pausado, pause
            }
        }
    }

    public void Resume()
    {
        Debug.Log("Resume chamado"); // Verificação se o método está sendo chamado

        statusMenuUI.SetActive(false);  // Esconder o menu de pausa
        Time.timeScale = 1f;           // Retomar o tempo normal do jogo
        isPaused = false;              // Atualizar o estado do jogo

        Debug.Log("Time.timeScale após retomar: " + Time.timeScale); // Verificação do estado do Time.timeScale
    }

    public void Status()
    {
        statusMenuUI.SetActive(true);   // Mostrar o menu de pausa
        isPaused = true;
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

    public void IncrementarVida()
    {
        // Encontra o jogador e obtém o PlayerController
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            PlayerController playerController = player.GetComponent<PlayerController>();
            if (playerController != null)
            {
                // Verifica se o jogador tem pontos suficientes
                if (playerController.pontos > 0)
                {
                    // Incrementa a vida do jogador e reduz os pontos
                    playerController.vida += 1;
                    playerController.pontos -= 1;

                    // Incrementa o contador e atualiza o texto
                    vidaIncrementos += 1;
                    AtualizarTextoIncrementosVida();

                    Debug.Log("Vida do jogador incrementada! Vida atual: " + playerController.vida);
                    Debug.Log("Pontos do jogador após incremento: " + playerController.pontos);
                }
                else
                {
                    Debug.Log("Não há pontos suficientes para incrementar a vida.");
                }
            }
        }
    }

    public void IncrementarVelocidade()
    {
        // Encontra o jogador e obtém o PlayerController
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            PlayerController playerController = player.GetComponent<PlayerController>();
            if (playerController != null)
            {
                // Verifica se o jogador tem pontos suficientes
                if (playerController.pontos > 0)
                {
                    // Incrementa a velocidade do jogador e reduz os pontos
                    playerController.velocidade += 50f; // Ajuste o valor conforme necessário
                    playerController.pontos -= 1;

                    Debug.Log("Velocidade do jogador incrementada! Velocidade atual: " + playerController.velocidade);
                    Debug.Log("Pontos do jogador após incremento: " + playerController.pontos);
                }
                else
                {
                    Debug.Log("Não há pontos suficientes para incrementar a velocidade.");
                }
            }
        }
    }

    // Função para atualizar o texto na interface do usuário
    void AtualizarTextoIncrementosVida()
    {
        if (textoIncrementosVida != null)
        {
            textoIncrementosVida.text = "" + vidaIncrementos;
        }
    }
}
