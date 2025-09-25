using Unity.VisualScripting;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [DoNotSerialize]
    public Vector3 m_v3Velocity;    // 矢速

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("矢の速度:" + m_v3Velocity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        // 座標の更新
        transform.position += m_v3Velocity * Time.deltaTime;   
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            // ダメージ処理
        }

        // プレイヤー以外のオブジェクトにぶつかったら矢を削除する
        if (!collider.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
