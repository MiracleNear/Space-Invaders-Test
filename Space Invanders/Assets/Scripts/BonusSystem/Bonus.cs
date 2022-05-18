using UnityEngine;

public abstract class Bonus : MonoBehaviour
{
    public abstract void Affect(GameObject gameObject);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Border border))
        {
            Destroy();
        }
        
        Affect(other.gameObject);
    }

    protected void Destroy()
    {
        Destroy(this.gameObject);
    }
}
