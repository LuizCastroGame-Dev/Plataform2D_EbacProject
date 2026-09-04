using UnityEngine;

public class HealthBase : MonoBehaviour
{
    [Header("Health config")]
    public int startLife = 10;
    private int _currentLife;
    private bool _isDead;

    public bool destroyOnKill = false;

    public float delayToKill = 0f;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _isDead = false;
        _currentLife = startLife;
    }

    public void Damage(int damage)
    {
        if (_isDead) return;

        _currentLife -= damage;

        if(_currentLife <= 0 )
        {
            Kill();
        }
    }

    private void Kill()
    {
        _isDead = true;

        if (destroyOnKill)
        {
            Destroy(gameObject, delayToKill);
        }
    }
}
