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


    public void DestroyPlatform()
    {
        print("Me han pisado, me caigo");
        Invoke("DropPlatform", 2f);
        Destroy(gameObject, 4f);

    }


    void DropPlatform()
    {
        rb.isKinematic = false;
    }
}

