using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.Translate(0f, 0f, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // For now, just destroy on hit.
        Destroy(gameObject);
    }
}