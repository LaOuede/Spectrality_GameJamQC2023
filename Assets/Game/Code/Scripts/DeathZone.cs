using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public bool IsPermanent;

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log(other.name + " touched a death zone");
        A_Player player = other.transform.root.GetComponent<A_Player>();

        if (player != null && player.IsAlive)
            player.Unalive(IsPermanent);
    }
}
