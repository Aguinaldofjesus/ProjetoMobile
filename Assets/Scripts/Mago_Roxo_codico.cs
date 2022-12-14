using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mago_Roxo_codico : MonoBehaviour
{
    public int hp_Mago_Roxo = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void perdeHP(int dano)
    {
        hp_Mago_Roxo = hp_Mago_Roxo - dano;
        if(hp_Mago_Roxo <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
