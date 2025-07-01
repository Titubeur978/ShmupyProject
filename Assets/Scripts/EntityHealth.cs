using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HealthChangeType { Add, Remove }

public class EntityHealth : MonoBehaviour
{
    public int currentHealth, maxHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void ModifyHealth(int amount, HealthChangeType changeType)
    {
        switch (changeType)
        {
            case HealthChangeType.Add:
                SetHealth(currentHealth + amount);
                break;
            case HealthChangeType.Remove:
                SetHealth(currentHealth - amount);
                break;
        }
    }

    public void SetHealth(int value)
    {
        currentHealth = Mathf.Clamp(value, 0, maxHealth); //si le soin dépasse la vie max alors les pv sont sets aux pv max
        if (currentHealth <= 0)                           //si les dégâts emmènent l'entité en dessous de 0 alors ses pv sont sets à 0
            Die();                                        //puis il meurt.
    }

    private void Die()
    {
        Destroy(gameObject);
        Debug.Log($"{gameObject.name} is dead.");
        // Tu peux appeler une méthode custom ici via delegate ou event
    }

    public bool IsFullHealth()
    {
        if (currentHealth == maxHealth)
            return true;
        else
            return false;
    }

}
