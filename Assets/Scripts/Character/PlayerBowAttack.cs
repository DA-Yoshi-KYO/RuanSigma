using UnityEngine;

public class PlayerBowAttack : MonoBehaviour
{
    [SerializeField]
    float m_fChargeMaxTime = 2.0f;  // 銃撃チャージ時間

    float m_fChargeTime = 0.0f; // チャージ時間用タイマー
    bool m_bCharge = false;     // チャージ開始したかどうか
    PlayerWeapon m_Weapon;      // プレイヤーが現在装備中の武器

    // Start is called before the first frame update
    void Start()
    {
        // 現在の武器情報を取得
        m_Weapon = GetComponent<PlayerWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        // 左クリックを押した瞬間チャージを開始する
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            m_bCharge = true;
        }

        // 左クリックを話したときのチャージ時間によって速度を決定する
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            // プレイヤーの正面方向ベクトルを取得
            Vector3 v3Velocity = transform.forward;
            // チャージ時間を掛けあわせる
            // イージングを使うことで最大溜めに近付くほど急激に射程が伸びるようにする
            v3Velocity *= (m_Weapon.m_CurrentWeapon.weaponData.attackMaxLength * Easing.EaseInCubic(m_fChargeTime, m_fChargeMaxTime)) + m_Weapon.m_CurrentWeapon.weaponData.attackMinLength;

            // 矢を生成する
            GameObject arrow = Instantiate(m_Weapon.m_CurrentWeapon.weaponAttackPrefab,transform.position, Quaternion.identity);
            // 速度のセット
            arrow.GetComponent<Arrow>().m_v3Velocity = v3Velocity;

            // チャージ時間のリセット
            m_fChargeTime = 0.0f;
        }
    }

    void FixedUpdate()
    {
        // チャージ時間中
        if (m_bCharge)
        {
            // タイムを加算する
            m_fChargeTime += Time.deltaTime;
            // 最大チャージ時間までに留めておく
            m_fChargeTime = Mathf.Min(m_fChargeTime, m_fChargeMaxTime);
        }
    }
}
