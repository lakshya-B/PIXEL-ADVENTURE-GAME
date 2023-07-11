using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rd;
    private Animator anim;
    [SerializeField] private AudioSource deathSoundEffect;
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Trap")) 
        {
            die();
            deathSoundEffect.Play();
        }
    }

    private void die()
    {
        rd.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void levelReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
