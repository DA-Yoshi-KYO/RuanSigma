using System;
using UnityEngine;

// �G�̃X�e�[�^�X
[Serializable]
public struct WeaponStatus
{
    [Header("���O")]
    public string Name;
    [Header("�U����")]
    public int attackPower;
    [Header("�ŏ��U���˒�")]
    public float attackMinRange;
    [Header("�ő�U���˒�")]
    public float attackMaxRange;
}

// �G�̃I�u�W�F�N�g
[Serializable]
public struct WeaponData
{
    [Header("����̃f�[�^")]
    public WeaponStatus weaponData;         
    [Header("����̃v���n�u")]
    public GameObject weaponPrefab;
    [Header("����̍U���p�v���n�u")]
    public GameObject weaponAttackPrefab;
}

[CreateAssetMenu(fileName = "WeaponDatabase", menuName = "Scriptable Objects/WeaponDatabase")]
public class EnemyDatabase : ScriptableObject
{
    public WeaponData[] weaponSettings;
}