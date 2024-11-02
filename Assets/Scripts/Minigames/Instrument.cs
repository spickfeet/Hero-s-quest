using UnityEngine;

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
