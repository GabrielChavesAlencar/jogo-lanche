using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class jogo : MonoBehaviour
{
    [SerializeField] SanduicheSO sanduicheSO;

    public string nome;
    public bool seguir_mouse;


    public RectTransform item;

    public RectTransform hamburger_UI;
    public RectTransform alface_UI;
    public RectTransform picles_UI;
    public RectTransform queijo_UI;
    public RectTransform tomate_UI;
    public Camera cam;
    public float Vel_mouse = 0.1f;

    /*
        public Image ingr1;
        public Image ingr2;
        public Image ingr3;
    */
    public int indice_ingrediente;
    public GameObject [] ingredientes;
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

    }
    public void updateItem() {
        nome = sanduicheSO.nome;
        /*

        ingr1.sprite = sanduicheSO.ingredientes[0];
        ingr2.sprite = sanduicheSO.ingredientes[1];
        ingr3.sprite = sanduicheSO.ingredientes[2];
        

        print(sanduicheSO.ingredientes[0].name+" o nome da imagem: "+ ingr1.sprite.name);
        if (ingr1.sprite.name=="hamburguer") { ingr1.transform.localPosition = new Vector3(2.3f,-131,0); }
        else if (ingr1.sprite.name == "alface") { ingr1.transform.localPosition = new Vector3(2.3f, -136, 0); }
        else if (ingr1.sprite.name == "picles") { ingr1.transform.localPosition = new Vector3(2.3f, -127, 0); }
        else if (ingr1.sprite.name == "tomate") { ingr1.transform.localPosition = new Vector3(0, -122, 0); }
        else if (ingr1.sprite.name == "queijo") { ingr1.transform.localPosition = new Vector3(2.3f, -132, 0); }

      
        if (ingr2.sprite.name == "hamburguer") { ingr2.transform.localPosition = new Vector3(2.3f, -125 , 0); }
        else if (ingr2.sprite.name == "alface") { ingr2.transform.localPosition = new Vector3(2.3f, -130, 0); }
        else if (ingr2.sprite.name == "picles") { ingr2.transform.localPosition = new Vector3(2.3f, -120, 0); }
        else if (ingr2.sprite.name == "tomate") { ingr2.transform.localPosition = new Vector3(2.3f, -116, 0); }
        else if (ingr2.sprite.name == "queijo") { ingr2.transform.localPosition = new Vector3(2.3f, -126, 0); }

        if (ingr3.sprite.name == "hamburguer") { ingr3.transform.localPosition = new Vector3(2.3f, -119, 0); }
        else if (ingr3.sprite.name == "alface") { ingr3.transform.localPosition = new Vector3(2.3f, -120, 0); }
        else if (ingr3.sprite.name == "picles") { ingr3.transform.localPosition = new Vector3(2.3f, -108, 0); }
        else if (ingr3.sprite.name == "tomate") { ingr3.transform.localPosition = new Vector3(0f, -103, 0); }
        else if (ingr3.sprite.name == "queijo") { ingr3.transform.localPosition = new Vector3(2.3f, -115, 0); }
        */

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
            //if (item == alface_UI) { }
            Instantiate(ingredientes[indice_ingrediente],new Vector3(-0.15f, -1.45f, 0),Quaternion.identity); 
            seguir_mouse = false;
        }

    }
}
