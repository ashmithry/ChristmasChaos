using UnityEngine;

public class PresentHealth : MonoBehaviour
{
    [Header("Tag Settings")]
    [SerializeField] 
    private string enemyTag = "Enemy";

    private PlayerMovement player;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(enemyTag))
        {
            player.TakeDamage(1);
            other.gameObject.GetComponent<Enemy>().EndSelf();
        }
    }
}
