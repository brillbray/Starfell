using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int damage;
    public int currentHP;

    void Start()
    {
        currentHP = 20;
    }

    public bool TakeDamage(int damageAmount)
    {
        currentHP -= damageAmount;
        if (currentHP <= 0)
        {
            return true;
        }
        return false;
    }
}
