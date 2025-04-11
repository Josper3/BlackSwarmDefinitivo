using UnityEngine;

public class FlyerMovement : MonoBehaviour
{
    [Header("Fuerzas")]
    [SerializeField] private float upwardAcceleration = 15f; // Aceleraci�n cuando pulsas espacio
    [SerializeField] private float maxUpwardSpeed = 5f;      // Velocidad m�xima hacia arriba
    [SerializeField] private float gravityScale = 1f;        // Escala de gravedad

    [Header("Movimiento horizontal")]
    [SerializeField] private float speed = 5f;               // Velocidad lateral constante

    private Rigidbody2D _body;
    private float originalSpeed; // Para guardar la velocidad original

    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _body.gravityScale = gravityScale;
        originalSpeed = speed; // Guardamos la velocidad original
    }

    private void Update()
    {
        // Movimiento constante a la derecha
        _body.velocity = new Vector2(speed, _body.velocity.y);

        if (Input.GetKey(KeyCode.Space))
        {
            // Si est� cayendo, se tarda un poco m�s en subir
            float newYVelocity = _body.velocity.y + upwardAcceleration * Time.deltaTime;

            // Limita la velocidad m�xima hacia arriba
            newYVelocity = Mathf.Min(newYVelocity, maxUpwardSpeed);

            _body.velocity = new Vector2(_body.velocity.x, newYVelocity);
        }
        // Si no se presiona, la gravedad se encarga de bajarlo
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    // M�todo para aumentar la velocidad temporalmente
    public void BoostSpeed(float boostAmount, float duration)
    {
        speed *= boostAmount; // Aumentamos la velocidad lateral
        // Restablecer la velocidad despu�s de la duraci�n
        StartCoroutine(ResetSpeedAfterTime(duration));
    }

    private System.Collections.IEnumerator ResetSpeedAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        speed = originalSpeed; // Restauramos la velocidad original
    }
}
