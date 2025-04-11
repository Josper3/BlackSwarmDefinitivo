using UnityEngine;

public class CharacterChanger : MonoBehaviour
{
    public GameObject flyingPlayerPrefab; // Asigna tu prefab volador aqu�
    public Vector2 spawnOffset = Vector2.zero; // Por si quieres ajustar la posici�n del nuevo jugador

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Aseg�rate de que tu Player tiene el tag "Player"
        {
            // Guardamos posici�n y destruimos el personaje actual
            Vector3 oldPosition = collision.transform.position;
            Quaternion oldRotation = collision.transform.rotation;
            Destroy(collision.gameObject);

            // Instanciamos al nuevo personaje volador
            GameObject newPlayer = Instantiate(flyingPlayerPrefab, oldPosition + (Vector3)spawnOffset, oldRotation);

            // Si quieres seguir manejando c�mara, UI, etc., puedes referenciar aqu�
            CameraFollow camFollow = Camera.main.GetComponent<CameraFollow>();
            if (camFollow != null)
            {
                camFollow.target = newPlayer.transform;
            }


            Debug.Log("Personaje cambiado al volador");
        }
    }
}
