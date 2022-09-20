using UnityEngine;
public class CharacterPyhsicsController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            EventManager.Broadcast(GameEvent.OnCollectDiamond);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            EventManager.Broadcast(GameEvent.OnLevelEnd);
        }
        if (collision.gameObject.CompareTag("Currency"))
        {
            EventManager.Broadcast(GameEvent.OnIncreaseCurrencyAmount);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            EventManager.Broadcast(GameEvent.OnCollisionObstacle);
            EventManager.Broadcast(GameEvent.OnIncreaseStackAmount);
        }
    }
}


