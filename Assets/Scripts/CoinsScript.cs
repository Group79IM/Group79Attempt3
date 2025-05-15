using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("Money"))
        {
            Destroy(gameObject);
            Money bankAccount = FindObjectOfType<Money>();
            bankAccount.AddMoney(1);
        }
    }
}
