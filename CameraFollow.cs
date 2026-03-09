using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;       // O alvo que a câmera vai seguir
    public Vector3 offset;         // A posição relativa da câmera em relação ao alvo
    public float smoothSpeed = 0.125f; // Velocidade de suavização do movimento da câmera

    void LateUpdate()
    {
        // Calcula a nova posição desejada
        Vector3 desiredPosition = target.position + offset;
        // Suaviza o movimento da câmera para a nova posição
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // Define a posição da câmera
        transform.position = smoothedPosition;

        // Se você quiser que a câmera olhe para o alvo, descomente a linha abaixo
        // transform.LookAt(target);
    }
}