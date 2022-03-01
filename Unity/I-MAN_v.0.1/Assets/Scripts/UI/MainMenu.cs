using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;// Required when using Event data.

public class MainMenu : MonoBehaviour, ISelectHandler
{

    [SerializeField] Image character;
    [SerializeField] Sprite spriteNew;
    // Start is called before the first frame update
    void Start()
    {
        //character = GameObject.Find("characterSprite");
    }


    public void OnSelect(BaseEventData eventData)
    {
        string nombreBtn = this.gameObject.name;
        Debug.Log("Se ha seleccionado el boton: " + nombreBtn);
        character.sprite = spriteNew;
        //Dependiendo del nombre, o el tag, podemos tomar decisiones
    }
}
