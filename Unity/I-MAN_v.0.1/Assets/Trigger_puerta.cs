using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_puerta : MonoBehaviour
{
    [SerializeField] Animator animatorpuerta;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Personaje")
        {
            animatorpuerta.SetBool("Trigger", true);

        }
    }
    /*private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Personaje")
        {
            animatorpuerta.SetBool("Trigger", false);
        }
    }*/
}
