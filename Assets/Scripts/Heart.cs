using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] private Sprite OnHeart;
    [SerializeField] private Sprite OffHeart;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] int LiveNumber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.Lives >= LiveNumber)    spriteRenderer.sprite = OnHeart;
        else                                            spriteRenderer.sprite = OffHeart;
    }
}
