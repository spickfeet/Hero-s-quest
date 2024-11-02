using UnityEngine;
using UnityEngine.EventSystems;
[RequireComponent(typeof(BoxCollider2D), typeof(EventTrigger))]
public class Instrument : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IMinigameWorkStation minigameWorkStation = collision.GetComponent<IMinigameWorkStation>();
        if(minigameWorkStation != null)
        {
            minigameWorkStation.Cook();
        }
    }
}
