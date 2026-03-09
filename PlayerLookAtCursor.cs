using UnityEngine;

public class PlayerLookAtCursor : MonoBehaviour
{
    public Camera playerCamera;    // A câmera do jogador
    public float rotationSpeed = 5f; // Velocidade de rotação

    void Update()
    {
        // Verifica se a câmera está atribuída
        if (playerCamera == null)
        {
            Debug.LogWarning("Câmera do jogador não atribuída.");
            return;
        }

        // Obtém a posição do cursor na tela
        Vector3 mousePosition = Input.mousePosition;

        // Obtém a posição do mundo do cursor
        Ray ray = playerCamera.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        // Verifica se o raio atinge algum objeto
        if (Physics.Raycast(ray, out hit))
        {
            // Calcula a direção que o jogador deve olhar
            Vector3 direction = hit.point - transform.position;
            direction.y = 0; // Mantém a rotação apenas no plano horizontal

            // Calcula a rotação desejada
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Suaviza a rotação
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
