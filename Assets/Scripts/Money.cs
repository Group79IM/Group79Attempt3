using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public static int bankAccount = 0;
    
    public void AddMoney(int amount) {
        bankAccount = bankAccount + amount;
        Debug.Log("Money: " + bankAccount);
    }

    public void DecreaseMoney(int amount) {
        bankAccount = bankAccount - amount;
    }

}
