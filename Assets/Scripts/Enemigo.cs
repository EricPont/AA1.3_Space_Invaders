using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float velocidad = 5f;
    public ControllerEnemigos controllerEnemigos;
    private Rigidbody2D rb;
    public bool disparar;
    public GameObject balaEnemigo;

    public int pointsValue;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controllerEnemigos.izquierda)
        {
            rb.velocity = Vector2.left * (velocidad + controllerEnemigos.incrementoVelocidad);
        }else
        {
            rb.velocity = Vector2.right * (velocidad + controllerEnemigos.incrementoVelocidad);
        }

        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Objeto entró en el trigger: " + other.gameObject.name);
        if (other.CompareTag("Wall"))
        {
            if (controllerEnemigos.izquierda)
            {
                controllerEnemigos.izquierda = false;
            }
            else
            {
                controllerEnemigos.izquierda = true;
            }
        }
        if (other.CompareTag("BalaJugador"))
        {
            Destroy(gameObject);
            controllerEnemigos.score += pointsValue;
            controllerEnemigos.EnemigoDerrotado();
        }

    }
    

    public void Disparar()
    {
        Instantiate(balaEnemigo, transform.position, transform.rotation);
    }
}
