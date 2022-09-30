using Characters;
using Constants;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
public class Door : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D trigger;
    [SerializeField] private bool isAutomatic;
    [SerializeField] private bool isLockable;
    [SerializeField] private bool isLocked;
    [SerializeField] private bool isOpen;

    private BoxCollider2D _trigger;
    private int _occupierCount;

    public int OccupierCount
    {
        get => _occupierCount;
        private set
        {
            _occupierCount = value;
            animator.SetBool(AnimatorConstants.HasOccupant, value > 0);
        }
    }

    public bool IsAutomatic
    {
        get => isAutomatic;
        set
        {
            isAutomatic = value;
            trigger.enabled = isAutomatic;
        }
    }

    public void Start()
    {
        trigger.enabled = IsAutomatic;
    }
    
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (!isAutomatic || col.GetComponent<PawnInfo>() == null) return;
        OccupierCount++;
    }
    
    public void OnTriggerExit2D(Collider2D col)
    {
        if (!isAutomatic || col.GetComponent<PawnInfo>() == null) return;
        OccupierCount--;
    }
}
