using UnityEngine;

public class BatFlying : MonoBehaviour
{
    [SerializeField] A_Player _batPlayer;
    [SerializeField] Transform _flyingPosition;
    [SerializeField] Transform[] _movingtransform;
    [SerializeField] float _duration = .7f;

    private float _startTransitionTime;
    private Vector3 _previousPosition;
    private Vector3 _targetPosition;

    void Start()
    {
        _batPlayer.OnDeath += OnDeath;
        _batPlayer.OnPossess += OnPossess;

        transform.position = _batPlayer.IsAlive ? _flyingPosition.position : transform.position;
    }

    private void OnPossess()
    {
        _targetPosition = _flyingPosition.localPosition;
        _previousPosition = transform.localPosition;
        _startTransitionTime = Time.time;
    }

    private void OnDeath()
    {
        _targetPosition = Vector3.zero;
        _previousPosition = transform.localPosition;
        _startTransitionTime = Time.time;
    }

    void Update()
    {
        if (Time.time < _startTransitionTime + _duration)
        {
            float t = (Time.time - _startTransitionTime) / _duration;

            for (int i = 0; i < _movingtransform.Length; i++) {

                _movingtransform[i].localPosition = Vector3.Lerp(_previousPosition, _targetPosition, t);
            }
        }
    }
}
