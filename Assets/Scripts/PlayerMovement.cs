using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer; // Capa de suelo

    private Rigidbody2D _body;
    private BoxCollider2D _box;

    private bool isGrounded;
    private float groundCheckDistance = 0.2f; // Distancia de comprobación hacia el suelo

    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _box = GetComponent<BoxCollider2D>();
    }

    private bool IsGrounded()
    {
        // Utiliza un Raycast para verificar si el personaje está tocando el suelo
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
        return hit.collider != null; // Si el Raycast toca algo que esté en la capa de suelo, retorna true
    }

    private void Update()
    {
        // Movimiento constante hacia la derecha
        _body.velocity = new Vector2(speed, _body.velocity.y);

        // Si está en el suelo y pulsamos espacio, salta
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        _body.velocity = new Vector2(_body.velocity.x, jumpForce);
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    // Visualiza el Raycast en el editor para depuración
    private void OnDrawGizmos()
    {
        Gizmos.color = IsGrounded() ? Color.green : Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
    }
}
