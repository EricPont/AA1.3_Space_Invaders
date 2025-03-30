using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edificio : MonoBehaviour
{
    public int hp = 15;
    public bool a;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hp == 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

 
        if (other.CompareTag("BalaEnemigo") || other.CompareTag("BalaJugador"))
        {
            transform.localScale -= new Vector3(0.1f, 0, 0);
            --hp;
        }
        



    }
}
