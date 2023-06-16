using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingrediente : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (jogo.tempo_espera > 1.9f) { Destroy(gameObject); }
    }
}
