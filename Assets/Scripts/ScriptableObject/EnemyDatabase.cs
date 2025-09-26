using System;
using UnityEngine;

// 敵のステータス
[Serializable]
public struct EnemyStatus
{
    [Header("名前")]
    public string Name;
    [Header("攻撃力")]
    public int attackPower;
    [Header("攻撃射程")]
    public float attackLength;
}

// 敵のデータ
[Serializable]
public struct EnemyData
{
    [Header("敵のステータス")]
    public EnemyStatus enemyStatus;
    [Header("敵のプレハブ")]
    public GameObject enemyPrefab;
}

[CreateAssetMenu(fileName = "EnemyDatabase", menuName = "Scriptable Objects/EnemyDatabase")]
public class EnemyDatabase : ScriptableObject
{
    // 敵のデータを格納している配列
    public EnemyData[] m_EnemyDatas;
}
