using UnityEngine;

public class BackgroundMoving : MonoBehaviour
{
    [SerializeField][Range(-1.0f, 1.0f)]
    private float moveSpeed = 0.1f;
    private Material _material;

    private void Awake()
    {
        _material = GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        _material.SetTextureOffset("_MainTex", Vector2.right * (moveSpeed * Time.time));
    }
}
