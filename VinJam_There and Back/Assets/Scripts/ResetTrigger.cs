using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTrigger : MonoBehaviour
{

    public Transform resetPosition;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            MainGuy_Movement guy = collision.gameObject.GetComponent<MainGuy_Movement>();
            ResetPlayerPosition(guy);
        }

    }

    void ResetPlayerPosition(MainGuy_Movement guy) {
        guy.transform.position = resetPosition.position;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(resetPosition.position, 1f);
        Gizmos.color = Color.white;
        BoxCollider2D coll = GetComponent<BoxCollider2D>();
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }



}
