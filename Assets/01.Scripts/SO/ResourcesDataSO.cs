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
    public float rate; //�������� ��� �� Ȯ��
    public GameObject itemPrefab;

    public ResourceType resourceType;
    public int minAmount = 1, maxAmount = 5;

    public AudioClip useSound;
    public Color popupTextColor;
    public int GetAmount()
    {
        return Random.Range(minAmount, maxAmount + 1); //int�ϱ� ���������� +1 ����� ��
    }
}
