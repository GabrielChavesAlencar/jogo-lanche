using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "sanduiche",menuName ="ScriptableObject/Sanduiche")]
public class SanduicheSO : ScriptableObject
{
    public string nome;
   // public Sprite [] ingredientes;
    public enum lista_ingredientes {
        alface,
        hamburguer,
        picles,
        queijo,
        tomate
    }
    public lista_ingredientes [] ingredientes;
}
