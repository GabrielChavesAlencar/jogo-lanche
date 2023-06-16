using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingrediente : MonoBehaviour
{
   
    //destroy o lanche quando ele está pronto depois de um certo tempo
    void Update()
    {
        if (jogo.tempo_espera > 1.9f) { Destroy(gameObject); }
    }
}
