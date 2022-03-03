using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerplataforma : MonoBehaviour
{
    [SerializeField] Animator animatorplataforma;
    private void OnTriggerEnter2D(Collider2D other)

    {
        if (other.gameObject.name == "I-MAN sprite sheet 1.psd_0")
        {
            animatorplataforma.SetBool("Trigger", true);

        }
        Destroy(gameObject);
    }
}