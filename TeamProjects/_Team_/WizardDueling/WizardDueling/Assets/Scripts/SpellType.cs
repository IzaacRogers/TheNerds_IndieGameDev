using UnityEngine;
using System.Collections;

public class SpellType {

    string name;
    float attackCost;
    float blockCost;
    GameObject attack;
    GameObject block;

    public SpellType() { }

    public SpellType(string name, float attackCost, float blockCost, GameObject attackObj, GameObject blockObj) 
    {
        name = this.name;
        attackCost = this.attackCost;
        blockCost = this.blockCost;
        attack = attackObj;
        block = blockObj;
    }

    public GameObject getAttackObj() 
    {
        return attack;
    }
    public GameObject getBlockObj() 
    {
        return block;
    }
    public float getAttackCost() 
    {
        return attackCost;
    }
    public float getBlockCost() 
    {
        return blockCost;
    }
    public string getName() 
    {
        return name;
    }

    public void setAttack(GameObject obj, float cost)
    {
        attack = obj;
        attackCost = cost;
    }
    public void setBlock(GameObject obj, float cost)
    {
        block = obj;
        blockCost = cost;
    }
    public void setName(string s)
    {
        name = s;
    }
}
