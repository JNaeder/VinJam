using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public SpriteRenderer trunk, leaves;


    public void WorldA() {
        leaves.gameObject.SetActive(false);

    }

    public void WorldB() {
        leaves.gameObject.SetActive(true);

    }

}
