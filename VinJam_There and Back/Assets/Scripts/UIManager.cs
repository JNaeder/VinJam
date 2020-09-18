using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    GameManager gM;

    public TMP_Text diamondNum;

    // Start is called before the first frame update
    void Start()
    {
        gM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        diamondNum.text = gM.totalDiamonds.ToString();


    }


    
}
