using System.Collections;
using UnityEngine;

public class BlackHoleDistance : MonoBehaviour
{
    public GameConfig_SO gameConfig_SO;
    private new Collider2D collider;
    private void Awake()
    {
        collider = GetComponent<Collider2D>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (IsDeadDistance(collision.transform)) CharacterEventManager.instance._OnDead.Invoke();
        }
    }
    private bool IsDeadDistance(Transform player)
    {
        return player.position.x - transform.position.x <= gameConfig_SO.deadDistance;
    }
}