using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : MonoBehaviour
{
    private GameConfig_SO gameConfig_SO;
    private Vector2 moveDir = new Vector2(1, 0);
    private Rigidbody2D rb;
    private Transform player;
    private Transform thisTransform;
    void Awake()
    {
        gameConfig_SO = GameConfigManager.instance.gameConfig_SO;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        thisTransform = transform;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = moveDir.normalized * gameConfig_SO.blackChaseSpeed;
        CheckDistance();
    }
    void CheckDistance()
    {
        float distance = player.position.x - thisTransform.position.x;
        if(distance >= gameConfig_SO.maxBlackDistance)
        {
            thisTransform.position = new Vector2(player.position.x - gameConfig_SO.maxBlackDistance, thisTransform.position.y);
        }
    }
}
