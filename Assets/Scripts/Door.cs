using System.Collections.Generic;
using System.Linq;
using Characters;
using Constants;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
public class Door : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private bool isAutomatic;
    [SerializeField] private bool isLockable;
    [SerializeField] private bool isLocked;
    [SerializeField] private bool isOpen;

    private List<BoxCollider2D> _triggers;
    private ShadowCaster2D _shadowCaster2D;
    private int _occupierCount;

    public int OccupierCount
    {
        get => _occupierCount;
        private set
        {
            _occupierCount = value;
            IsOpen = _occupierCount > 0;
        }
    }

    public bool IsOpen
    {
        get => isOpen;
        private set
        {
            isOpen = value;
            if (_shadowCaster2D != null) _shadowCaster2D.enabled = !IsOpen;
            animator.SetBool(AnimatorConstants.IsOpen, isOpen);
        }
    }

    public bool IsAutomatic
    {
        get => isAutomatic;
        set
        {
            isAutomatic = value;
            _triggers.ForEach(trigger => trigger.enabled = isAutomatic);
        }
    }

    public void Awake()
    {
        _triggers = GetComponents<BoxCollider2D>().Where(cols => cols.isTrigger).ToList();
    }

    public void Start()
    {
        _triggers.ForEach(trigger => trigger.enabled = isAutomatic);
        _shadowCaster2D = GetComponent<ShadowCaster2D>();
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
