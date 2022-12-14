using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volocidadeinimigo : MonoBehaviour
{
    private float velocidade=-0.3f;

    //Tempo e velocidade do jogo para o celular
    private float Tempo = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Temporizador();
    }


    void inimigovelocidade()
    {
        transform.position = new Vector3(transform.position.x + velocidade, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Destruir"))
        {
            Destroy(gameObject);
        }
    }

    //Tempo
    void Temporizador()
    {
        Tempo += Time.deltaTime;

        if (Tempo > 0.01f)
        {
            inimigovelocidade();
        }
    }

}
