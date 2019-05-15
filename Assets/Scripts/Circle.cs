using UnityEngine;

public class Circle : MonoBehaviour
{
    public float Lifespan { get; protected set; } = 3;
    protected float Lifetime { get; private set; }

    protected void Update()
    {
        Lifetime += Time.deltaTime;
        if (Lifetime >= Lifespan)
            Die();
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
