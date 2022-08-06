using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ResourceType
{
    None,
    Health,
    Ammo
}


[CreateAssetMenu(menuName="SO/Resources")]
public class ResourcesDataSO : ScriptableObject
{
    public float rate; //아이템이 드롭 될 확률
    public GameObject itemPrefab;

    public ResourceType resourceType;
    public int minAmount = 1, maxAmount = 5;

    public AudioClip useSound;
    public Color popupTextColor;
    public int GetAmount()
    {
        return Random.Range(minAmount, maxAmount + 1); //int니까 마지막에는 +1 해줘야 함
    }
}
