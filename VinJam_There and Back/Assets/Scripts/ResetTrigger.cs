using UnityEngine;
using FMODUnity;

public class ResetTrigger : MonoBehaviour
{
    ParticleManager ps;

    public Transform resetPosition;

    [FMODUnity.EventRef]
    public string resetSound;

    private void Start()
    {
        ps = FindObjectOfType<ParticleManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            MainGuy_Movement guy = collision.gameObject.GetComponent<MainGuy_Movement>();
            ResetPlayerPosition(guy);
        }

    }

    void ResetPlayerPosition(MainGuy_Movement guy) {
        ps.StopSystems();
        guy.transform.position = resetPosition.position;
        ps.PlaySystem();
        FMODUnity.RuntimeManager.PlayOneShot(resetSound);

    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawSphere(resetPosition.position, 1f);
        Gizmos.color = Color.white;
        BoxCollider2D coll = GetComponent<BoxCollider2D>();
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }



}
