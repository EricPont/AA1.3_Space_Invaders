using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HpController : MonoBehaviour
{
    public int playerHp = 3;

    public TextMeshProUGUI  textoVidas;

    public ControllerNave controllerNave;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textoVidas.text = "Lives: \n" + playerHp.ToString(); 
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Enemigo"))
        {
            playerHp = 0;
            controllerNave.playerDied();
        }
    }
}
