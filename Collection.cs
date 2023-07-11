using UnityEngine;
using UnityEngine.UI;

public class Collection : MonoBehaviour
{
    [SerializeField] private Text FruitsText;
    private int cherries = 0;
    private int strawberries = 0;
    [SerializeField] private AudioSource collectionSoundEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Cherry"))
        {
            Destroy(collision.gameObject);
            cherries++;
            FruitsText.text = "    " + cherries;
            collectionSoundEffect.Play();
        }

        else if (collision.gameObject.CompareTag("Strawberry"))
        {
            Destroy(collision.gameObject);
            strawberries++;
            FruitsText.text = "    " + strawberries;
            collectionSoundEffect.Play();
        }
    }
}
