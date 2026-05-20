using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f; // 子弹飞行速度
    public float lifeTime = 3f; // 子弹存活时间（秒），防止飞出地图永远消耗内存

    private void Start()
    {
        // 子弹生成 3 秒后自动销毁
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        // 让子弹每一帧都朝着自己的“正前方”移动
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    
    // 如果子弹撞到东西（以后可以加敌人或者墙壁的逻辑）
    private void OnTriggerEnter(Collider other)
    {
        // 目前撞到任何带有 Collider 的东西就销毁自己
        // 注意：稍后如果子弹一出生就撞到玩家自己，我们需要特殊处理
        Destroy(gameObject);
    }
}