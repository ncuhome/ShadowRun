using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : MonoBehaviour
{
    private GameConfig_SO gameConfig_SO;
    private Vector2 moveDir = new Vector2(1, 0);
    private Rigidbody2D rb;
    void Awake()
    {
        gameConfig_SO = Resources.Load("GameConfig_SO") as GameConfig_SO;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = moveDir.normalized * gameConfig_SO.blackChaseSpeed;
    }
}
