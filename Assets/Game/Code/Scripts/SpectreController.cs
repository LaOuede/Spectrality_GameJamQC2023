using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpectreController : MonoBehaviour
{
    private MyInputs _myInputs;
    private GameObject ToolTip;

    public LayerMask viewLayer;
    public Interacter interacter;

    [SerializeField] Animation _animation;
    [SerializeField] CameraDetach _cameraSetup;
    [SerializeField] CinemachineVirtualCamera _camera;
    [SerializeField] MovementControler _movementControler;

    void Start()
    {
        _myInputs = new MyInputs();
        ToolTip = GameManager.Instance.ToolTip;

        _myInputs.Enable();
        GameManager.Instance.AudioManager.ChangeBGM(GameManager.Instance.SpecterMusic);
        GameManager.Instance.PostProcessControl.SetSpectreProcess();

        _myInputs.InGame.Move.performed += Move;
        _myInputs.InGame.Move.canceled += Move;
        _myInputs.InGame.Interact.performed += Interact;

        GameManager.Instance.MainCamera.cullingMask = viewLayer;

        _animation.Play("Anim_Spectre_Spawn");
    }
    void Update()
    {
        A_Interactible corpse = interacter.Interactable;

        bool CBP; // Now useless cause corpse dispawn instead
        if (corpse)
            CBP = corpse.GetComponentInParent<A_Player>().CanBePossessed;
        else
            CBP = false;

        if (!ToolTip.activeSelf && corpse && corpse.isUsable && CBP) {
            ToolTip.GetComponent<TextMeshProUGUI>().SetText("Press [E] to possess");
            ToolTip.SetActive(true);
        }
        else if (ToolTip.activeSelf && !(corpse && corpse.isUsable && CBP))
            ToolTip.SetActive(false);
    }

    private void Interact(InputAction.CallbackContext obj)
    {
        if (interacter.Interact()) {
            DisableInput();

            GameManager.Instance.PostProcessControl.SetNormalProcess();
            GameManager.Instance.AudioManager.ChangeBGM(GameManager.Instance.NormalMusic);

            _animation.Play("Anim_Spectre_Despawn");
            _camera.Priority = 0;

            Destroy(_cameraSetup.gameObject, 2);
            Destroy(gameObject, 2);
        }
    }

    private void DisableInput()
    {
        _myInputs.InGame.Move.performed -= Move;
        _myInputs.InGame.Move.canceled -= Move;

        _myInputs.InGame.Interact.performed -= Interact;
    }

    void Move(InputAction.CallbackContext ctx)
    {
        _movementControler.MoveInput = ctx.ReadValue<Vector2>();
    }
}
