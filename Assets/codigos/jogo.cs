using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;



public class jogo : MonoBehaviour
{
    [SerializeField] SanduicheSO sanduicheSO;

    [SerializeField] SanduicheSO [] sanduiches;

    public Camera cam;
    public string [] nomes_ingrediente;
    public bool seguir_mouse;


    public RectTransform item;

    public RectTransform hamburger_UI;
    public RectTransform alface_UI;
    public RectTransform picles_UI;
    public RectTransform queijo_UI;
    public RectTransform tomate_UI;
    
    public float Vel_mouse = 0.1f;

    public int indice_ingrediente;
    public GameObject [] ingredientes;
    public GameObject pao;
    public Vector3 pos_inicial_item;
    public int layer_item = 0;

    //descrição do lanche
    [SerializeField] TMP_Text nome_lanche;
    [SerializeField] TMP_Text lanche_descricao;

    public Sprite[] sprites_ingrediente;
    public Image[] imgs_ingrediente;



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
        if (seguir_mouse) {
            MoveObject();

        }
        if (layer_item == 3) {
            Instantiate(pao, new Vector3(-0.15f, 1.3f, 0), Quaternion.identity);
            layer_item = 0;
        }
        if (Input.GetKeyDown(KeyCode.A)) { SceneManager.LoadScene("SampleScene"); }

    }
    public void updateItem() {
        nome_lanche.SetText(sanduicheSO.nome);
        lanche_descricao.SetText("Primeiramente adicione "+sanduicheSO.ingredientes[0]+ " depois coloque " + sanduicheSO.ingredientes[1] +" e por fim acrecente " + sanduicheSO.ingredientes[2]);

        for (int i = 0; i <= 2; i++) {
            nomes_ingrediente[i] = sanduicheSO.ingredientes[i] + "";
            if (nomes_ingrediente[i] == "alface") { imgs_ingrediente[i].sprite = sprites_ingrediente[0]; }
            else if (nomes_ingrediente[i] == "hamburguer") { imgs_ingrediente[i].sprite = sprites_ingrediente[1]; }
            else if (nomes_ingrediente[i] == "picles") { imgs_ingrediente[i].sprite = sprites_ingrediente[2]; }
            else if (nomes_ingrediente[i] == "queijo") { imgs_ingrediente[i].sprite = sprites_ingrediente[3]; }
            else if (nomes_ingrediente[i] == "tomate") { imgs_ingrediente[i].sprite = sprites_ingrediente[4]; }
        }
     //   if (sanduicheSO.ingredientes[0] + "" == "alface") { print("deu certo alface!"); }

    }
    public void selecionar_ingrediente(int num) {
        if (!seguir_mouse)
        {

            seguir_mouse = true;
            indice_ingrediente = num;
            if (num == 0) { item = alface_UI; }
            else if (num == 1) { item = hamburger_UI; }
            else if (num == 2) { item = picles_UI; }
            else if (num == 3) { item = queijo_UI; }
            else if (num == 4) { item = tomate_UI; }
            pos_inicial_item = item.transform.position;
        }
    }
    public void MoveObject() {
        Vector3 pos = Input.mousePosition;
        pos.z = 100;
        item.position = Vector3.Lerp(item.position, cam.ScreenToWorldPoint(pos), Vel_mouse);
        item.transform.SetAsLastSibling();
        
    }
    public void colocar_ingrediente() {
        if (seguir_mouse) {
            layer_item++;
            GameObject temp = Instantiate(ingredientes[indice_ingrediente],new Vector3(-0.15f, -1.45f, 0),Quaternion.identity);
            temp.GetComponent<SpriteRenderer>().sortingOrder = layer_item;
            seguir_mouse = false;
            item.transform.position = pos_inicial_item;
        }

    }
}
