using UnityEngine;

public class CorpseInteract : A_Interactible
{
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
        A_Player player = transform.root.GetComponent<A_Player>();

        if (player && player.CanBePossessed)
        {
            player.GetPossessed();
            return true;
        }
        return false;

    }
}
