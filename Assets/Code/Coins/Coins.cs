using UnityEngine;
using UnityEngine.Events;

namespace Code.Coins
{
    public class Coins : MonoBehaviour
    {
        private const string LayerMaskHero = "Hero";
    
        [SerializeField] private UnityEvent _event;
        [SerializeField] private AudioSource _audioSource;

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.layer == LayerMask.NameToLayer(LayerMaskHero))
            {
                GetComponent<SpriteRenderer>().enabled = false; 
                GetComponent<Collider2D>().enabled = false; 
            
                _audioSource.Play();  
                _event.Invoke();
            
                Destroy(gameObject, _audioSource.clip.length);
            }
        }

    }
}
