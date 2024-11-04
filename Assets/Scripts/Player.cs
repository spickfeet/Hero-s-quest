using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _radiusInteraction = 3;

    [SerializeField] private Container _container;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private AudioClip _pickUp;
    
    public Container Container
    {
        get { return _container; }
        set 
        { 
            _container = value; 
            _audioManager.PlaySFX(_pickUp);
        }
    }

    [SerializeField] private Transform _itemAnchor;
    public Transform ItemAnchor => _itemAnchor;

    private void Update()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, _radiusInteraction);

        if (collider2Ds.Length <= 0) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact(collider2Ds);
        }
    }
    private void Interact(Collider2D[] collider2Ds)
    {
        float minDist = 100f;

        Interactable interactable = null;

        foreach (var collider2D in collider2Ds)
        {
            float dist = Vector3.Distance(transform.position, collider2D.transform.position);

            if (collider2D.TryGetComponent(out Interactable tempInteractable))
            {
                if (dist < minDist)
                {
                    minDist = dist;
                    interactable = tempInteractable;
                }
            }
        }
        if (interactable != null)
        {
            interactable.Interact();
        }
    }

    public void Inject(AudioManager audioManager)
    {
        _audioManager = audioManager;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _radiusInteraction);
    }
}
