using System.Collections;
using UnityEngine;

public class BlackHoleDistance : MonoBehaviour
{
    private GameConfig_SO gameConfig_SO;
    private new Collider2D collider;
    private bool isDead = false;
    private void Awake()
    {
        collider = GetComponent<Collider2D>();
        gameConfig_SO=GameConfigManager.instance.gameConfig_SO;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (IsDeadDistance(collision.transform) && !isDead) 
            {
                isDead = true;
                CharacterEventManager.instance._OnDead.Invoke();
            } 
        }
    }
    private bool IsDeadDistance(Transform player)
    {
        return player.position.x - transform.position.x <= gameConfig_SO.deadDistance;
    }
}