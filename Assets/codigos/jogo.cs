using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jogo : MonoBehaviour
{
    [SerializeField] SanduicheSO sanduicheSO;

    public string nome;
    // Start is called before the first frame update
    void Start()
    {
        updateItem();
    }
    private void OnValidate()
    {
        updateItem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void updateItem() {
        nome = sanduicheSO.nome;
    }
}
