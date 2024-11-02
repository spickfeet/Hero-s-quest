using UnityEngine;

public class Instrument : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IWorkStation bowl = collision.GetComponent<IWorkStation>();
        if(bowl != null)
        {
            bowl.Cook();
        }
    }
}
