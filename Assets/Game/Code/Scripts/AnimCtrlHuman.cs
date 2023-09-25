using UnityEngine;

public class AnimCtrlHuman : MonoBehaviour
{
    [SerializeField] HumanControler _humanControler;
    [SerializeField] MovementControler _movementController;
    [SerializeField] Animator _animator;

    void Start()
    {
        _humanControler.OnDeath += OnDeath;
        _humanControler.OnPossess += OnPossess;

        if (!_humanControler.IsAlive)
        {
            _animator.SetBool("IsDead", true);
            _animator.Play("Dead");
        }
    }

    private void OnPossess()
    {
        _animator.SetBool("IsDead", false);
    }

    private void OnDeath()
    {
        _animator.SetBool("IsDead", true);
    }

    void Update()
    {
        float normalizedSpeed = _movementController._rb.velocity.magnitude / _movementController.Speed;
        _animator.SetFloat("Speed", normalizedSpeed);
    }
}
