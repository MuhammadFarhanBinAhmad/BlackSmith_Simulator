using UnityEngine.UI;
using UnityEngine;

public class Ore : MonoBehaviour
{
    //Check stages
    public int current_Stage = 1;
    public Text current_Stage_Text;
    //material type
    public int material_Ore;
    Renderer type_Ore;

    //stage1
    public float cook_Time = 5;
    //stage2
    public string current_Weapon_Type;
    //stage3
    public int time_Hit_Needed;
    public Text current_Weapon_Type_Text;
    //stage4
    public float cooling_Time = 5;
    //stage5
    //stage6
    public string enchantment;

    private void Start()
    {
        type_Ore = GetComponent<Renderer>();
    }
    void Update()
    {
        current_Stage_Text.text = "CurrentStation:" + current_Stage;
        current_Weapon_Type_Text.text = "WeaponType:" + current_Weapon_Type.ToString();
        //Ore Matarial
        if (material_Ore == 1)
        {
            type_Ore.material.color = Color.gray;
        }
        if (material_Ore == 2)
        {
            type_Ore.material.color = Color.red;
        }
        if (material_Ore == 3)
        {
            type_Ore.material.color = Color.yellow;
        }
        if (material_Ore == 4)
        {
            type_Ore.material.color = Color.black;
        }
        //finish hitting
        if (time_Hit_Needed <= 0 && current_Stage ==3)
        {
            time_Hit_Needed = 0;
            current_Stage = 4;
        }
        //detect oil finish cooling
        if (cooling_Time <= 0)
        {
            cooling_Time = 0;
            current_Stage = 5;
        }

    }
    //change Ore Material
    public void ChangeOre()
    {
        if (material_Ore <= 5)
        {
            material_Ore++;
        }
        if (material_Ore == 5)
        {
            material_Ore = 1;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Oil" && current_Stage == 4)
        {
            if (cooling_Time >=0)
            {
                if (other.GetComponent<Oil>().oil_Type == 1 && material_Ore == 1 || FindObjectOfType<Oil>().oil_Type == 1 && material_Ore == 2)
                {
                    cooling_Time -= Time.deltaTime;
                }
                if (other.GetComponent<Oil>().oil_Type == 2 && material_Ore == 3 || FindObjectOfType<Oil>().oil_Type == 2 && material_Ore == 4)
                {
                    cooling_Time -= Time.deltaTime;
                }
            }
        }
        if(other.name == "FEPotion(Clone)" && current_Stage == 5)
        {
            enchantment = "FE Enchanted";
        }
        if (other.name == "IEPotion(Clone)" && current_Stage == 5)
        {
            enchantment = "IE Enchanted";
        }
        if(other.name == "IFPotion(Clone)" && current_Stage == 5)
        {
            enchantment = "IF Enchanted";
        }
    }
}
