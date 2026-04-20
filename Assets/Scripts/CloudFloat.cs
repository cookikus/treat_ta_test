using UnityEngine;

public class CloudFloat : MonoBehaviour
{
    public float speed = 0.5f;
    public float distance = 2.0f;

    private Vector3 startPos;
    private float offset;

    void Start()
    {
        startPos = transform.position;

        offset = Random.Range(0f, 2f * Mathf.PI);
    }

    void Update()
    {
        float movement = Mathf.Sin((Time.time * speed) + offset) * distance;
        transform.position = startPos + new Vector3(movement, 0, 0);
    }
}