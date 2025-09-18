using System;
using UnityEngine;

// �����
public enum WeaponKind
{
    Sword,
    Dagger,
    MiddleBow,
    FarBow
}

// ����̃X�e�[�^�X
[Serializable]
public struct WeaponStatus
{
    [Header("���O")]
    public string Name;
    [Header("�����")]
    public WeaponKind Kind;
    [Header("�U����")]
    public int attackPower;
    [Header("�ŏ��U���˒�")]
    public float attackMinLength;
    [Header("�ő�U���˒�")]
    public float attackMaxLength;
    [Header("�U���͈�")]
    public Vector3 attackRange;
}

// ����̃I�u�W�F�N�g
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
    public WeaponData[] weaponDatas;
}