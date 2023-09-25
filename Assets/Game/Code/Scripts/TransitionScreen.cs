using UnityEngine;

public class TransitionScreen : MonoBehaviour
{
    [SerializeField] Animation _animation;

    void Start()
    {
        Exit.OnExit += OnExit;
    }

    private void OnExit()
    {
        _animation.Play("Anim_TransitionScreen_HideScreen");
    }

    private void OnDestroy()
    {
        Exit.OnExit -= OnExit;
    }
}
