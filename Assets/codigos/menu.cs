using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class menu : MonoBehaviour
{
    public PlayableDirector animacao;
 
    // incia a animação de largada da timeline
    public void inciar_jogo() {
        animacao.Play();
    }
}
