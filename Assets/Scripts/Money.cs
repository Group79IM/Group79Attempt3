using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private int bankAccount = 0;
    
    public void AddMoney(int amount) {
        bankAccount = bankAccount + amount;
    }

    public void DecreaseMoney(int amount) {
        bankAccount = bankAccount - amount;
    }

}
