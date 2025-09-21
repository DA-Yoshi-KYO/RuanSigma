using Unity.VisualScripting;
using UnityEngine;

public class InitialWeaponSelect : MonoBehaviour
{
    [DoNotSerialize]
    static public WeaponData m_tInitialWeapon;  // プレイヤーの初期武器
    [SerializeField]
    [Header("武器のデータベース")]
    WeaponDatabase m_WeaponDatabase;  // 武器のデータベース

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// プレイヤーの初期武器をセットします
    /// </summary>
    /// <param name="index">
    /// 初期武器に使用する武器のデータベース上インデックス(0～3)
    /// </param>
    public void SetInitialWeapon(int index)
    {
        // 初期武器はデータベース内の0～3のインデックス内から選択する
        if (index < 0 || index >= 4)
        {
            Debug.Log("初期武器の範囲外を参照しています");
            return;
        }

        // 配列外チェック
        WeaponData[] weaponDatas = m_WeaponDatabase.m_WeaponDatas;
        if (index >= weaponDatas.Length)
        {
            Debug.Log("武器データベースの配列外を参照しています");
            return;
        }

        // フェード中は武器のセットを行わない
        SceneTransition sceneTransition = GameObject.Find("Fade").GetComponent<SceneTransition>();
        if (sceneTransition.IsFade())
        {
            return;
        }

        // プレイヤーの初期武器としてデータベースのindex番目をセット
        m_tInitialWeapon = weaponDatas[index];
        Debug.Log("選択した武器のデータ");
        Debug.Log("名前：" + m_tInitialWeapon.weaponData.Name);
        Debug.Log("武器種：" + m_tInitialWeapon.weaponData.Kind);
        Debug.Log("攻撃力：" + m_tInitialWeapon.weaponData.attackPower);
        Debug.Log("最小攻撃射程：" + m_tInitialWeapon.weaponData.attackMinLength);
        Debug.Log("最大攻撃射程：" + m_tInitialWeapon.weaponData.attackMaxLength);
        Debug.Log("攻撃範囲：" + m_tInitialWeapon.weaponData.attackRange);

        // 武器を選択したらシーン遷移する(確認場面は後から実装します)
        sceneTransition.SetFadeOut(true);
    }
}
