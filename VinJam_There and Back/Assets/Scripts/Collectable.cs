using UnityEngine;

public class Collectable : MonoBehaviour
{
    GameManager gM;

    // Start is called before the first frame update
    void Start()
    {
        gM = FindObjectOfType<GameManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            gM.AddDiamond();
            MainGuy_Movement guy = collision.gameObject.GetComponent<MainGuy_Movement>();
            guy.PlayCollectableSound();

            Destroy(gameObject);

        }
    }
}
