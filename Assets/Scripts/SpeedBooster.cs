using UnityEngine;

public class SpeedBooster : MonoBehaviour
{
    public float speedBoost = 2f; // Factor de aumento de velocidad
    public float duration = 5f;    // Duración del aumento de velocidad

    private void OnTriggerEnter(Collider other)
    {
        // Verificamos si el objeto que colisiona es el jugador
        if (other.CompareTag("Player"))
        {
            // Llamamos al método de aumento de velocidad en el jugador
            other.GetComponent<FlyerMovement>().BoostSpeed(speedBoost, duration);

            // Destruimos el objeto potenciador (opcional)
            Destroy(gameObject);
        }
    }
}
