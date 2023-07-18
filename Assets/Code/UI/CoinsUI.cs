using System;
using UnityEngine;
using Code.Coins;
using TMPro;

namespace Code.UI
{
    public class CoinsUI:MonoBehaviour
    {
        [SerializeField] private TMP_Text _UiTextCoins;
        private CoinVault _coins;
        
        private void Start()
        {
            _coins = gameObject.AddComponent<CoinVault>();
        }

        private void Update()
        {
            _UiTextCoins.text = Convert.ToString(_coins.Value);
        }

        public void AddCoins(BoxCollider2D boxCollider2D)
        {
            _coins.TryAddCoins(boxCollider2D);
        }
    }
}