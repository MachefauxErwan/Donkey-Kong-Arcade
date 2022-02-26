using UnityEngine;
using System.Collections;

public class PlayerHealfManager : MonoBehaviour
{
    public int NbMaxLifes = 2;
    public int NbLifes;
    public bool isInvinsible = false;
    public float InvisibleFlashDelay = 0.2f;
    public float InvisibleTimeAfterHit = 3f;
    public SpriteRenderer graphics;
    public LifeManager LifeManager;

    public static PlayerHealfManager instance;

    private void Awake()
    {
        if(instance !=null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerHealfManager dans la scene");
            return;
        }
        instance = this;
    }
    void Start()
    {
        NbLifes = NbMaxLifes;
        LifeManager.setMaxLife(NbMaxLifes);
    }

    public void TakeDomage(int dommage)
    {
        if (!isInvinsible)
        {
            if (NbLifes > 0)
            {
                NbLifes -= dommage;
                LifeManager.setLife(NbLifes);
                isInvinsible = true;
                StartCoroutine(InvincibilityFlash());
                StartCoroutine(HandleInvincibilityDelay());
            }
            else
            {
                Die();
                return;
            }
        }
       
    }

    public void Die()
    {
        Debug.Log("player Dead");
        PlayerMovementManager.instance.enabled = false;
        PlayerMovementManager.instance.animator.SetTrigger("Die");
        PlayerMovementManager.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovementManager.instance.rb.velocity =  Vector3.zero;
        PlayerMovementManager.instance.playerCollider.enabled = false;
        GameOverManager.instance.OnPlayerDeath();
    }
    public void Win()
    {
        Debug.Log("player Win");
        PlayerMovementManager.instance.enabled = false;
        PlayerMovementManager.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovementManager.instance.rb.velocity = Vector3.zero;
        PlayerMovementManager.instance.playerCollider.enabled = false;
        GameOverManager.instance.OnPlayerWin();
    }
    public IEnumerator InvincibilityFlash()
    {
        while(isInvinsible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(InvisibleFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(InvisibleFlashDelay);
        }
    }
    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(InvisibleTimeAfterHit);
        isInvinsible = false;
    }
}
