using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class player : NetworkBehaviour {
    [SyncVar]
    private bool _isDead = false;
    public bool isDead
    {
        get { return _isDead; }
        protected set { _isDead = value; }
    }

    [SerializeField]
    private int maxHealth = 100;

    [SerializeField]
    private Behaviour[] disableOnDeath;
    private bool[] wasEnabled;

    [SyncVar]
    private int currentHealth;

    public void Setup()
    {
        wasEnabled = new bool[disableOnDeath.Length];
        for (int i = 0; i < wasEnabled.Length; i++)
        {
            wasEnabled[i] = disableOnDeath[i].enabled;  
        }


        SetDefaults();

    }

    [ClientRpc]
    public void RpcTakeDamage(int _amount)
    {
        if (isDead)
            return;

        currentHealth -= _amount;

        Debug.Log(transform.name + " now has " + currentHealth + " health.");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;

        for (int i = 0; i < disableOnDeath.Length; i++)
        {
            disableOnDeath[i].enabled = false;
        }

        Collider col = GetComponent<Collider>();

        if (col != null)
        {
            col.enabled = false;
        }

        Debug.Log(transform.name + " is dead!" );

        //Respawn
    }

    public void SetDefaults()
    {
        isDead = false;

        for (int i = 0; i < disableOnDeath.Length; i++)
        {
            disableOnDeath[i].enabled = wasEnabled[i];
        }
        currentHealth = maxHealth;

        Collider col = GetComponent<Collider>();

        if(col != null)
        {
            col.enabled = true;
        }
        
    }
}
