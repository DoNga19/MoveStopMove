using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects/WeaponData", order = 1)]
public class WeaponData : ScriptableObject
{
    [SerializeField] List<WeaponItem> weaponItems;

    public List<WeaponItem> WeaponItems => weaponItems;

    public WeaponItem GetWeaponItem(WeaponTypes weaponType)
    {
        return weaponItems.Single(q => q.type == weaponType);
    }

    public WeaponTypes NextType(WeaponTypes weaponType)
    {
        int index = weaponItems.FindIndex(q => q.type == weaponType);
        index = index + 1 >= weaponItems.Count ? 0 : index + 1;
        return weaponItems[index].type;
    }

    public WeaponTypes PrevType(WeaponTypes weaponType)
    {
        int index = weaponItems.FindIndex(q => q.type == weaponType);
        index = index - 1 < 0 ? weaponItems.Count - 1 : index - 1;
        return weaponItems[index].type;
    }
}

[System.Serializable]
public class WeaponItem
{
    public string name;
    public WeaponTypes type;
    public int cost;
    public int ads;
}
