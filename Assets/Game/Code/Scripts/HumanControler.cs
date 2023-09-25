using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using TMPro;

// This ended up being used to control everything, not just humans. Wacky...
public class HumanControler : A_Player
{
    [SerializeField] MovementControler _movementControler;
    [SerializeField] CinemachineVirtualCamera _camera;
    [SerializeField] Interacter _interacter;

    private GameObject ToolTip;

    void Start()
    {
        _myInputs = new MyInputs();
        ToolTip = GameManager.Instance.ToolTip;

        _myInputs.Enable();

        if (!IsAlive)
            _camera.Priority = 0;

        UpdateInputs();

        Exit.OnExit += OnExit;
    }

    private void OnExit()
    {
        _myInputs.Disable();
    }

    private void OnDestroy()
    {
        Exit.OnExit -= OnExit;
    }

    void Update()
    {
        if (IsAlive) {
            if (!ToolTip.activeSelf && _interacter.Interactable && _interacter.Interactable.isUsable) {
                ToolTip.GetComponent<TextMeshProUGUI>().SetText("Press [E] to use");
                ToolTip.SetActive(true);
            }
            else if (ToolTip.activeSelf && !(_interacter.Interactable && _interacter.Interactable.isUsable))
                ToolTip.SetActive(false);
        }
    }

    private void Interact_performed(InputAction.CallbackContext obj)
    {
        _interacter.Interact();
    }

    void Move(InputAction.CallbackContext ctx)
    {
        _movementControler.MoveInput = ctx.ReadValue<Vector2>();
    }

    protected override void UpdateInputs()
    {
        if (IsAlive)
        {
            _myInputs.InGame.Move.performed += Move;
            _myInputs.InGame.Move.canceled += Move;
            _myInputs.InGame.Interact.performed += Interact_performed;
            _myInputs.InGame.Consume.performed += ConsumePoison;
        }
        else
        {
            _myInputs.InGame.Move.performed -= Move;
            _myInputs.InGame.Move.canceled -= Move;
            _myInputs.InGame.Interact.performed -= Interact_performed;
            _myInputs.InGame.Consume.performed -= ConsumePoison;
            _movementControler.MoveInput = new Vector2(0, 0);
        }
    }

    public override void Unalive(bool isPermaDeath)
    {
        if (IsAlive)
        {
            IsAlive = false;
            UpdateInputs();

            if (type == "Rat")
                GameManager.Instance.AudioManager.PlaySFX(GameManager.Instance.SFX.RatDeath);
            else if (type == "Human")
                GameManager.Instance.AudioManager.PlaySFX(GameManager.Instance.SFX.HumanDeath);
            else if (type == "Bat")
                GameManager.Instance.AudioManager.PlaySFX(GameManager.Instance.SFX.BatDeath);
            
            DoDeath();
            _camera.Priority = 0;
            OnDeath?.Invoke();

            if (isPermaDeath)
                Destroy(gameObject);
        }
    }

    public override void GetPossessed()

    {
        if (!IsAlive && CanBePossessed) {
            IsAlive = true;
            UpdateInputs();

            if (type == "Rat")
                GameManager.Instance.AudioManager.PlaySFX(GameManager.Instance.SFX.RatSpawn);
            else if (type == "Human")
                GameManager.Instance.AudioManager.PlaySFX(GameManager.Instance.SFX.HumanSpawn);
            else if (type == "Bat")
                GameManager.Instance.AudioManager.PlaySFX(GameManager.Instance.SFX.BatSpawn);

            _camera.Priority = 1;
            OnPossess?.Invoke();
        }
    }
}
