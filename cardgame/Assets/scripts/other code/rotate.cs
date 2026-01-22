using UnityEngine;

public class rotate : MonoBehaviour
{
    float rotationsPerMinute;

    private void Awake()
    {
        rotationsPerMinute = 10f;
    }
    void  Update()
    {
        transform.Rotate(0, 6.0f * rotationsPerMinute * Time.deltaTime, 0);
    }
}
