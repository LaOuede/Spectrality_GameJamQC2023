using UnityEngine;

public class Poison : A_Interactible
{
    public GameObject Parent;

    protected override void OnTriggerEnter(Collider other)
    {

        A_Player player = other.GetComponentInParent<A_Player>();

        if (player && player.IsAlive && !player.HasPoison)
        {
            //Debug.Log(other.name + " obtained the poison");
            player.HasPoison = true;
            GameManager.Instance.PotionIcon.SetActive(true);
            Destroy(Parent);
        }
    }

    protected override void OnTriggerExit(Collider other)
    {
        return;
    }

    public override bool Interact()
    {
        return true;
    }

}