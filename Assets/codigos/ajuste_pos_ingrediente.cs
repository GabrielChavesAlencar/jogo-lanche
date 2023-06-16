using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ajuste_pos_ingrediente : MonoBehaviour
{
   
    public GameObject item_abaixo;

    // Start is called before the first frame update
    void Start()
    {
        ajustar();
    }

    // Update is called once per frame
    void Update()
    {
        ajustar();
    }

    //atualiza a posição dos ingredientes na UI
    public void ajustar() {
        string temp = item_abaixo.GetComponent<Image>().sprite.name;
        string nome = GetComponent<Image>().sprite.name;
       

        if (temp == "pao parte de baixo") {
            if (nome == "hamburguer") { transform.position = item_abaixo.transform.position + new Vector3(0, 0.08f, 0); }
            else if (nome == "queijo") { transform.position = item_abaixo.transform.position + new Vector3(0, 0.03f, 0); }
            else if (nome == "alface") { transform.position = item_abaixo.transform.position + new Vector3(0, 0.01f, 0); }
            else if (nome == "tomate") { transform.position = item_abaixo.transform.position + new Vector3(-0.06f, 0.2f, 0); }
            else if (nome == "picles") { transform.position = item_abaixo.transform.position + new Vector3(0, 0.15f, 0); }
            
        }
        else if (temp == "hamburguer") {
            if (nome == "hamburguer") { transform.position = item_abaixo.transform.position + new Vector3(0, 0.16f, 0); }
            else if (nome == "queijo") { transform.position = item_abaixo.transform.position + new Vector3(0, 0.13f, 0); }
            else if (nome == "alface") { transform.position = item_abaixo.transform.position + new Vector3(0, 0.07f, 0); }
            else if (nome == "tomate") { transform.position = item_abaixo.transform.position + new Vector3(-0.06f, 0.3f, 0); }
            else if (nome == "picles") { transform.position = item_abaixo.transform.position + new Vector3(0, 0.22f, 0); }
            else if (nome == "pao parte de cima") { transform.position = item_abaixo.transform.position + new Vector3(0, 0.38f, 0); }
        }
        else if (temp == "queijo")
        {
            if (nome == "hamburguer") { transform.position = item_abaixo.transform.position + new Vector3(0, 0.05f, 0); }
            else if (nome == "queijo") { transform.position = item_abaixo.transform.position + new Vector3(0, 0.13f, 0); }
            else if (nome == "alface") { transform.position = item_abaixo.transform.position + new Vector3(0, 0.01f, 0); }
            else if (nome == "tomate") { transform.position = item_abaixo.transform.position + new Vector3(-0.06f, 0.2f, 0); }
            else if (nome == "picles") { transform.position = item_abaixo.transform.position + new Vector3(0, 0.1f, 0); }
            else if (nome == "pao parte de cima") { transform.position = item_abaixo.transform.position + new Vector3(0, 0.26f, 0); }
        }
        else if (temp == "alface")
        {
            if (nome == "hamburguer") { transform.position = item_abaixo.transform.position + new Vector3(0, 0.1f, 0); }
            else if (nome == "queijo") { transform.position = item_abaixo.transform.position + new Vector3(0, 0.13f, 0); }
            else if (nome == "alface") { transform.position = item_abaixo.transform.position + new Vector3(0, 0.001f, 0); }
            else if (nome == "tomate") { transform.position = item_abaixo.transform.position + new Vector3(-0.06f, 0.23f, 0); }
            else if (nome == "picles") { transform.position = item_abaixo.transform.position + new Vector3(0, 0.16f, 0); }
            else if (nome == "pao parte de cima") { transform.position = item_abaixo.transform.position + new Vector3(0, 0.27f, 0); }
        }
        else if (temp == "tomate")
        {
            if (nome == "hamburguer") { transform.position = item_abaixo.transform.position + new Vector3(0.06f, 0.2f, 0); }
            else if (nome == "queijo") { transform.position = item_abaixo.transform.position + new Vector3(0.06f, -0.08f, 0); }
            else if (nome == "alface") { transform.position = item_abaixo.transform.position + new Vector3(0.06f, 0.001f, 0); }
            else if (nome == "tomate") { transform.position = item_abaixo.transform.position + new Vector3(0, 0.23f, 0); }
            else if (nome == "picles") { transform.position = item_abaixo.transform.position + new Vector3(0.06f, 0.02f, 0); }
            else if (nome == "pao parte de cima") { transform.position = item_abaixo.transform.position + new Vector3(0.06f, 0.15f, 0); }
        }
        else if (temp == "picles")
        {
            if (nome == "hamburguer") { transform.position = item_abaixo.transform.position + new Vector3(0, 0.013f, 0); }
            else if (nome == "queijo") { transform.position = item_abaixo.transform.position + new Vector3(0, -0.02f, 0); }
            else if (nome == "alface") { transform.position = item_abaixo.transform.position + new Vector3(0, 0.001f, 0); }
            else if (nome == "tomate") { transform.position = item_abaixo.transform.position + new Vector3(-0.06f, 0.16f, 0); }
            else if (nome == "picles") { transform.position = item_abaixo.transform.position + new Vector3(0, 0.1f, 0); }
            else if (nome == "pao parte de cima") { transform.position = item_abaixo.transform.position + new Vector3(0, 0.23f, 0); }
        }
    }
}
