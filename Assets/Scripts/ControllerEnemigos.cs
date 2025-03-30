using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ControllerEnemigos : MonoBehaviour
{
    // Start is called before the first frame update
    public bool izquierda;
    public bool ultimaDir;
    public float incrementoVelocidad;
    public float cdBala = 1;

    public TextMeshProUGUI puntuacionTextoInGame;
    public int score = 0;

    public GameObject[] enemigos;
    public GameObject GameEndedUI;
    public GameObject YouWinTexto;
    public TextMeshProUGUI puntuacionTextoFinalJuego;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        puntuacionTextoInGame.text = "Score: \n" + score.ToString();
        
        puntuacionTextoFinalJuego.text = score.ToString();

        if (izquierda != ultimaDir)
        {
            transform.position -= new Vector3(0, 0.2f, 0);
            ultimaDir = izquierda;
        }
        if (IsArrayEmpty(enemigos))
        {
            GameEndedUI.SetActive(true);
            YouWinTexto.SetActive(true);
            
        }
        if (Time.time >= cdBala) // Si ha pasado 1 segundo
        {
            GameObject enemigoSeleccionado;
            int numEnemigo;
            do
            {
                numEnemigo = UnityEngine.Random.Range(0, enemigos.Length);
                enemigoSeleccionado = enemigos[numEnemigo];

            } while (enemigoSeleccionado == null && !IsArrayEmpty(enemigos));
            

            Enemigo scriptEnemigoSeleccionado = enemigoSeleccionado.GetComponent<Enemigo>();

            scriptEnemigoSeleccionado.Disparar();

            cdBala = Time.time + 1;
        }
    }

    public void EnemigoDerrotado()
    {
        Debug.Log("enemigo derrotado");
        incrementoVelocidad += 0.1f;
    }
    bool IsArrayEmpty(GameObject[] array)
    {
        foreach (var item in array)
        {
            if (item != null)
                return false;
        }
        return true;
    }

}
