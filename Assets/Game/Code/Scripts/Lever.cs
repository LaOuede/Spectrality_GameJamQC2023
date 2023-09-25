using UnityEngine;

public class Lever : A_Interactible
{
    enum AnimName
    {
        Anim_Lever_OnToOff,
        Anim_LeverOffToOn
    }

    public GameObject obj;

    [SerializeField] Animation _animation;

    private void Start()
    {
        UpdateAnimation(0);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        return;
    }

    protected override void OnTriggerExit(Collider other)
    {
        return;
    }

    public override bool Interact()
    {
        // Debug.Log(other.name + " Switched a lever");
        A_Toggleable toggle = obj.GetComponent<A_Toggleable>();
        UpdateAnimation(0);

        toggle.Toggle();
        if (toggle.IsActive == toggle.HoldActive)
            toggle.IsHeld = true;
        else
            toggle.IsHeld = false;

        return true;
    }

    private void UpdateAnimation(int time)
    {
        if (obj.GetComponent<A_Toggleable>().IsActive)
            _animation.Play(AnimName.Anim_LeverOffToOn.ToString());
        else
            _animation.Play(AnimName.Anim_Lever_OnToOff.ToString());

    }
}
