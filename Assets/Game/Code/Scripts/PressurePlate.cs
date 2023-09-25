using UnityEngine;

public class PressurePlate : A_Interactible
{
    public GameObject obj;
    [SerializeField] Animation _animation;

    int _colliderCount = 0;
    protected override void OnTriggerEnter(Collider other)
    {
        SpectreController spectre = other.transform.root.GetComponent<SpectreController>();

        if (spectre != null)
            return;

        _colliderCount++;

        A_Toggleable toggle = obj.GetComponent<A_Toggleable>();
        if (toggle.IsActive)
            return;

        // Debug.Log(other.name + " got on a Pressure Plate");
        _animation.Play("Anim_PressurePlate_Activate");

        if (!toggle.IsHeld)
        {
            if (toggle.HoldActive)
                toggle.Activate();
            else
                toggle.Deactivate();
        }
    }

    protected override void OnTriggerExit(Collider other)
    {

        SpectreController spectre = other.transform.root.GetComponent<SpectreController>();

        if (spectre != null)
            return;

        // Debug.Log(other.name + " got off a Pressure Plate");
        A_Toggleable toggle = obj.GetComponent<A_Toggleable>();

        _colliderCount--;

        if (_colliderCount > 0)
            return;

        _animation.Play("Anim_PressurePlate_Deactivate");

        if (!toggle.IsHeld)
        {
            if (toggle.HoldActive)
                toggle.Deactivate();
            else
                toggle.Activate();
        }
    }

    public override bool Interact()
    {
        return true;
    }
}
