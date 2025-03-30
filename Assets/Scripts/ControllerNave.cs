using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerNave : MonoBehaviour
{
    public float velocidad = 5f;
    public float limiteIzquierda;
    public float limiteDerecha;

    public HpController hpController;

    public GameObject balaJugador;
    public GameObject GameEndedUI;
    public GameObject GameOverTexto;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento
        float movimientoHorizontal = Input.GetAxis("Horizontal") * velocidad * Time.deltaTime;
        transform.position += new Vector3(movimientoHorizontal, 0, 0);

        if (limiteIzquierda > transform.position.x)
        {
            transform.position = new Vector3(limiteIzquierda, transform.position.y, transform.position.z);

        }else if (limiteDerecha < transform.position.x){
            transform.position = new Vector3(limiteDerecha, transform.position.y, transform.position.z);

        }


        if (Input.GetKeyDown(KeyCode.Space)) // Disparar con la tecla ESPACIO
        {
            Instantiate(balaJugador, transform.position, transform.rotation);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("BalaEnemigo"))
        {
            --hpController.playerHp;
            playerDied();
        }

    }

    public void playerDied()
    {
        
        if (hpController.playerHp != 0)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z); 
        }
        else
        {
            Destroy(gameObject);
            GameEndedUI.SetActive(true);
            GameOverTexto.SetActive(true);
        }
        
    }

}
