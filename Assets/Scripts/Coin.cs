using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    public int coinsToGive;
    private TextMeshProUGUI coinText;
    private void Start()
    {
        coinText = GameObject.FindWithTag("CoinText").GetComponent<TextMeshProUGUI>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            Player player = collision.gameObject.GetComponent<Player>();
            player.coins += coinsToGive;
            coinText.text = player.coins.ToString();
            Destroy(gameObject);
        }
    }
}
