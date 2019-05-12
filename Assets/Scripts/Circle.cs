using UnityEngine;

public class Circle : MonoBehaviour
{
    [SerializeField] protected float lifespan = 3;
    protected float lifetime = 0;

    protected void Update()
    {
        lifetime += Time.deltaTime;
        if (lifetime >= lifespan)
            Die();
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
