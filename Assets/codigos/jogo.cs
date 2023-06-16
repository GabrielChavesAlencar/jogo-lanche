using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;



public class jogo : MonoBehaviour
{
    [SerializeField] TMP_Text tempo_text;
    [SerializeField] TMP_Text score_text;
    [SerializeField] TMP_Text score_final_text;
    public float tempo;

    public int score;
    private bool marcar_ponto;
    private bool diminuir_ponto;
    public static float tempo_espera;
    public GameObject gameover_obj;
    //[SerializeField] SanduicheSO sanduicheSO;

    [SerializeField] SanduicheSO [] sanduiches;

    public Camera cam;
    public string [] nomes_ingrediente;
    public bool seguir_mouse;
    public string [] ingredientes_colocados;



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
    public int numero_lanche;

    


    
    void Start()
    {
        tempo = 120;
        tempo_espera = 0;
        numero_lanche = Random.Range(0, sanduiches.Length);
        updateItem(numero_lanche);

    }
    private void OnValidate()
    {
       // updateItem(8);
    }

    void Update()
    {
        updateItem(numero_lanche);
        if (seguir_mouse) {
            MoveObject();

        }
        
        if (Input.GetKeyDown(KeyCode.A)) { reiniciar_jogo(); }
       
        proximo_lanche();
        if (tempo > 0)
        {
            tempo -= Time.deltaTime;
        }
        else { tempo = 0; gameover_obj.SetActive(true); score_final_text.SetText("sua pontuacao é : " +score); }

        tempo_text.SetText("Tempo: "+tempo.ToString("000"));
    }

    //atualiza o icone e as informações do lanche na UI
    public void updateItem(int ind) {
        nome_lanche.SetText(sanduiches[ind].nome);
        lanche_descricao.SetText("Primeiramente adicione "+ sanduiches[ind].ingredientes[0]+ " depois coloque " + 
            sanduiches[ind].ingredientes[1] +" e por fim acrecente " + sanduiches[ind].ingredientes[2]);

        for (int i = 0; i <= 2; i++) {
            nomes_ingrediente[i] = sanduiches[ind].ingredientes[i] + "";
            if (nomes_ingrediente[i] == "alface") { imgs_ingrediente[i].sprite = sprites_ingrediente[0]; }
            else if (nomes_ingrediente[i] == "hamburguer") { imgs_ingrediente[i].sprite = sprites_ingrediente[1]; }
            else if (nomes_ingrediente[i] == "picles") { imgs_ingrediente[i].sprite = sprites_ingrediente[2]; }
            else if (nomes_ingrediente[i] == "queijo") { imgs_ingrediente[i].sprite = sprites_ingrediente[3]; }
            else if (nomes_ingrediente[i] == "tomate") { imgs_ingrediente[i].sprite = sprites_ingrediente[4]; }
        }
    

    }
    public void selecionar_ingrediente(int num) {
        if (!seguir_mouse&&layer_item<3)
        {

            seguir_mouse = true;
            indice_ingrediente = num;
            if (num == 0) { item = alface_UI; ingredientes_colocados[layer_item] = "alface"; }
            else if (num == 1) { item = hamburger_UI; ingredientes_colocados[layer_item] = "hamburguer"; }
            else if (num == 2) { item = picles_UI; ingredientes_colocados[layer_item] = "picles"; }
            else if (num == 3) { item = queijo_UI; ingredientes_colocados[layer_item] = "queijo"; }
            else if (num == 4) { item = tomate_UI; ingredientes_colocados[layer_item] = "tomate"; }
            pos_inicial_item = item.transform.position;
        }
    }

    //faz o ingrediente seguir o mouse
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
            if (layer_item >= 3){atulizarpontuacao();}
        }

    }

    public void atulizarpontuacao() {
        int cont = 0;
        for (int i = 0; i <= 2; i++)
        {
            if (nomes_ingrediente[i] == ingredientes_colocados[i]) { cont++; }
        }
        if (cont == 3) { marcar_ponto = true; }
        else { diminuir_ponto = true; }
        Instantiate(pao, new Vector3(-0.15f, 1.3f, 0), Quaternion.identity);
       
    }

    public void proximo_lanche() { 
        if (marcar_ponto|| diminuir_ponto) { tempo_espera += Time.deltaTime; }
        if (tempo_espera > 1 && tempo_espera < 1.1f) { 
            if (marcar_ponto) { score++; }
            if (diminuir_ponto) { score--; }
            score_text.SetText("SCORE: " + score.ToString("00"));
            tempo_espera = 1.1f;
        }
        if (tempo_espera > 4) {
            marcar_ponto = false;
            diminuir_ponto = false;
            tempo_espera = 0;
            layer_item = 0;
            for (int i = 0; i <= 2; i++)
            {
                ingredientes_colocados[i] = "";
            }
            numero_lanche = Random.Range(0, sanduiches.Length);
            updateItem(numero_lanche);
            
        }
    }
    public void reiniciar_jogo() {
        SceneManager.LoadScene("SampleScene");
    }
}
