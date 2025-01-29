using UnityEngine;

public class Mover : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float moveSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * GameManager.Instance.CalculateGameSpeed() * Time.deltaTime;
    }
}
