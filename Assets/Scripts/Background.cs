using UnityEngine;

public class Background : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<GameManager>().GameOver(false);
    }
}
