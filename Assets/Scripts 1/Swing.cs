using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        rb.AddForce(new Vector2(Random.Range(0.01f, 0.05f), Random.Range(0.01f,0.05f)),ForceMode2D.Impulse);
    }
}
