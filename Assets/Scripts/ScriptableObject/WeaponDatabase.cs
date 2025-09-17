using System;
using UnityEngine;

// 敵のステータス
[Serializable]
public struct WeaponStatus
{
    [Header("名前")]
    public string Name;
    [Header("攻撃力")]
    public int attackPower;
    [Header("最小攻撃射程")]
    public float attackMinRange;
    [Header("最大攻撃射程")]
    public float attackMaxRange;
}

// 敵のオブジェクト
[Serializable]
public struct WeaponData
{
    [Header("武器のデータ")]
    public WeaponStatus weaponData;         
    [Header("武器のプレハブ")]
    public GameObject weaponPrefab;
    [Header("武器の攻撃用プレハブ")]
    public GameObject weaponAttackPrefab;
}

[CreateAssetMenu(fileName = "WeaponDatabase", menuName = "Scriptable Objects/WeaponDatabase")]
public class EnemyDatabase : ScriptableObject
{
    public WeaponData[] weaponSettings;
}