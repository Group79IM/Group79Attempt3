using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializedField] private void bankAccount = 0;
    
    public void AddMoney(amount) {
        bankAccount = bankAccount + amount;
    }

    public void DecreaseMoney(amount) {
        bankAccount = bankAccount - amount;
    }

}
