using UnityEngine;

public class AgarrarGemas : MonoBehaviour
{
    public float velocidad = 5f;
    private Rigidbody2D rb;
    private Vector2 direccion;
    public int gemas = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        direccion = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    void FixedUpdate()
    {
        rb.velocity = direccion * velocidad;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gema"))
        {
            Destroy(other.gameObject);
            gemas = gemas + 10;
            Debug.Log("Agarre una gema, llevo: " + gemas);
        }

        if (other.CompareTag("Cereza"))
        {
            Destroy(other.gameObject);
            gemas = gemas - 5;
            Debug.Log("Agarre una cereza, llevo: " + gemas);
        }
    }
}