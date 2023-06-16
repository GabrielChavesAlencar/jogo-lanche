using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class menu : MonoBehaviour
{
    public PlayableDirector animacao;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void inciar_jogo() {
        animacao.Play();
    }
}
