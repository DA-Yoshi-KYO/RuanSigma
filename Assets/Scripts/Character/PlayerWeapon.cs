using Unity.VisualScripting;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [DoNotSerialize]
    public WeaponData m_CurrentWeapon { get; private set; }    // 現在の装備武器


    // Start is called before the first frame update
    void Start()
    {
        // 武器選択画面から初期武器を取得
        m_CurrentWeapon = InitialWeaponSelect.m_tInitialWeapon;

        // 武器のアイコンをインスタンス化し、キャンバス内のUIの子に設定
        GameObject parent = GameObject.Find("MyWeapon");
        GameObject child = Instantiate(m_CurrentWeapon.weaponIconPrefab, parent.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
