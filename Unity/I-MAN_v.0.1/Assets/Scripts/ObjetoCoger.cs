using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoCoger : MonoBehaviour
{
    [SerializeField] Animator animatorpuerta;
    private void OnTriggerEnter2D(Collider2D other)

    {
        if (other.gameObject.name == "I-MAN sprite sheet 1.psd_0")
        {
            animatorpuerta.SetBool("Trigger", true);

        }
        Destroy(gameObject);
    }
}