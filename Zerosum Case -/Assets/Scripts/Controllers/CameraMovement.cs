using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float _distance;
    private Transform _playerTransform;

    private void LateUpdate()
    {
        var position = transform.position;
        if (_playerTransform != null)
        {
            position = Vector3.Lerp(position,
                new Vector3(position.x, position.y, _playerTransform.position.z - _distance), 1.5f);
            transform.position = position;
        }
    }

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnPlaying,SetTarget);
    }

    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnPlaying,SetTarget);
    }

    void SetTarget()
    {
        _playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        _distance = _playerTransform.position.z - transform.position.z;
    }
}
