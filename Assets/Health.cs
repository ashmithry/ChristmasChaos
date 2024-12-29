using UnityEngine;

public class PresentHealth : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] 
    private int maxHealth = 4;
    
    private int currentHealth;

    [Header("Tag Settings")]
    [SerializeField] 
    private string enemyTag = "Enemy"; 

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(enemyTag))
        {
            TakeDamage(1);
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
           
            Destroy(gameObject); 
        }
    }
}
