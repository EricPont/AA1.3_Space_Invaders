using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemigo : MonoBehaviour
{
    public float velocidad = 3;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * velocidad * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player") || other.CompareTag("Edificio"))
        {
            Destroy(gameObject); // Destruir la bala al impactar
        }
    }
}
