using System;
using TMPro;
using UnityEngine;

namespace Code.Coins
{
    public class CoinCollector : MonoBehaviour
    {
        private const string LayerMaskCoins = "Coins";
    
        [SerializeField] private TMP_Text _UiTextCoins;
        
        private int _coins;

        private void Start()
        {
            _coins = 0;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.layer == LayerMask.NameToLayer(LayerMaskCoins))
            {
                _coins++;
                _UiTextCoins.text = _coins.ToString();
                col.GetComponent<SpriteRenderer>().enabled = false; 
                col.GetComponent<Collider2D>().enabled = false;
                col.GetComponent<CoinSound>().PlaySound();
                Destroy(col.gameObject,col.GetComponent<CoinSound>().GetSoundLenght());
            }
        }
    }
}
