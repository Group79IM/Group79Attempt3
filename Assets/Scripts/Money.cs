using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public int bankAccount = 0; // Player's bank account balance

    public void AddMoney(int amount) // Method to add money to the bank account
    {
        bankAccount = bankAccount + amount;
        Debug.Log("Money: " + bankAccount);
    }

    public void DecreaseMoney(int amount) // Method to decrease the bank account
    {
        bankAccount = bankAccount - amount;
    }

}
