using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("How fast should the texture scroll?")]
    [SerializeField] private float scrollSpeed;

    [Header("References")]
    [SerializeField] private MeshRenderer meshRenderer;

    private void Start()
    {
        
    }

    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(
            (scrollSpeed * GameManager.Instance.CalculateGameSpeed() * Time.deltaTime) / 20,
            0
        );
    }
}