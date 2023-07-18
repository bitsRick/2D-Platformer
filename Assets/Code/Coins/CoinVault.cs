using UnityEngine;

namespace Code.Coins
{
    public class CoinVault:MonoBehaviour
    {
        private const string LayerMaskCoins = "Coins";

        public CoinVault()
        {
            Value = 0;
        }
        
        public int Value { get; private set; }

        public void TryAddCoins(BoxCollider2D collision2D)
        {
            if (collision2D.gameObject.layer == LayerMask.NameToLayer(LayerMaskCoins)) 
                Value++;
        }
    }
}