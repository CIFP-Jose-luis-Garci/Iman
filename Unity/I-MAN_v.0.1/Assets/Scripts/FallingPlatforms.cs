using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatforms : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("I-MAN sprite sheet 1.psd_0"))
        {
            Invoke("DropPlatform", 2f);
            Destroy(gameObject, 4f);
        }
    }
    void DropPlatform()
    {
        rb.isKinematic = false;
    }
}

