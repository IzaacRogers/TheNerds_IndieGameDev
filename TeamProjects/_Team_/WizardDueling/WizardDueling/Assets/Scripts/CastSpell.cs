using UnityEngine;
using System.Collections;

public class CastSpell : MonoBehaviour {

    public GameObject caster;
    public float delay = 1;
    public float focus = 100;
    public float maxFocus = 100;
    public float focusRecharge = 1;

    public GameObject[] Attacks;
    public float[] AttackCost;
    public GameObject[] Blocks;
    public float[] BlockCost;

    public int currentCast;

    public CastSpell() { }

    enum spellList : int
    {
        earth=0,
        wind=1,
        water=2,
        fire=3,
        life=4,
        death=5,
        pure=6,
        corrupted=7
    };

    public SpellType[] spell = new SpellType[8];

	// Use this for initialization
	void Start () {
        spell[(int)spellList.earth] =     new SpellType("Earth",     AttackCost[(int)spellList.earth],     BlockCost[(int)spellList.earth],     Attacks[(int)spellList.earth],     Blocks[(int)spellList.earth]);
        spell[(int)spellList.wind] =      new SpellType("Wind",      AttackCost[(int)spellList.wind],      BlockCost[(int)spellList.wind],      Attacks[(int)spellList.wind],      Blocks[(int)spellList.wind]);
        spell[(int)spellList.water] =     new SpellType("Water",     AttackCost[(int)spellList.water],     BlockCost[(int)spellList.water],     Attacks[(int)spellList.water],     Blocks[(int)spellList.water]);
        spell[(int)spellList.fire] =      new SpellType("Fire",      AttackCost[(int)spellList.fire],      BlockCost[(int)spellList.fire],      Attacks[(int)spellList.fire],      Blocks[(int)spellList.fire]);
        spell[(int)spellList.life] =      new SpellType("Life",      AttackCost[(int)spellList.life],      BlockCost[(int)spellList.life],      Attacks[(int)spellList.life],      Blocks[(int)spellList.life]);
        spell[(int)spellList.death] =     new SpellType("Death",     AttackCost[(int)spellList.death],     BlockCost[(int)spellList.death],     Attacks[(int)spellList.death],     Blocks[(int)spellList.death]);
        spell[(int)spellList.pure] =      new SpellType("Pure",      AttackCost[(int)spellList.pure],      BlockCost[(int)spellList.pure],      Attacks[(int)spellList.pure],      Blocks[(int)spellList.pure]);
        spell[(int)spellList.corrupted] = new SpellType("Corrupted", AttackCost[(int)spellList.corrupted], BlockCost[(int)spellList.corrupted], Attacks[(int)spellList.corrupted], Blocks[(int)spellList.corrupted]);
	}
	
	// Update is called once per frame
	void Update () {

        if (focus < maxFocus) 
            focus += focusRecharge * Time.deltaTime;


        if (focus >= AttackCost[currentCast])
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("left click");
                focus = focus - AttackCost[currentCast];
                GameObject cast = (GameObject)Instantiate(spell[currentCast].getAttackObj(), caster.transform.position, caster.transform.rotation);
                Destroy(cast, delay);
            }
        }

        if (focus >= spell[currentCast].getBlockCost())
        {
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("right click");
                focus = focus - AttackCost[currentCast];
                GameObject cast = (GameObject)Instantiate(spell[currentCast].getBlockObj(), caster.transform.position, caster.transform.rotation);
                Destroy(cast, delay);
            }
        }

	}

    public void setCast(int i) 
    {
        currentCast = i;
    }
}
