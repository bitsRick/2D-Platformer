using UnityEngine;

namespace Code.Coins
{
   public class CoinSound : MonoBehaviour
   {
      [SerializeField] private AudioSource _audioSource;

      public void PlaySound() => 
         _audioSource.Play();

      public float GetSoundLenght() => 
         _audioSource.clip.length;
   }
}
