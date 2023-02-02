using UnityEngine;
using UnityEditor;

namespace TowerDefense
{
    [RequireComponent(typeof(TDPatrolController))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int m_damage = 1;
        [SerializeField] private int m_gold = 1;
        public void Use(EnemyAsset asset)
        {
            var spriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
            spriteRenderer.color = asset.color;
            spriteRenderer.transform.localScale = new Vector3(asset.sprtiteScale.x, asset.sprtiteScale.y, 1);

            spriteRenderer.GetComponent<Animator>().runtimeAnimatorController = asset.animations;
            // хп (в спейсшипе преопределяется)
            GetComponent<SpaceShip>().Use(asset);

            GetComponentInChildren<CircleCollider2D>().radius = asset.radius;

            GetComponentInChildren<CircleCollider2D>().offset = asset.offset;


            if (asset.FlipY == true)
            {
                spriteRenderer.flipY = asset.FlipY = true;
            }

            m_damage = asset.damage;
            m_gold = asset.gold;
        }

        public void DamagePlayer()
        {
            TDPlayer.Instance.TakeDamage(m_damage);
        }

        public void GivePlayerGold ()
        {
           TDPlayer.Instance.ChangeGold(m_gold);
        }
    }
    [CustomEditor(typeof(Enemy))]
    public class EnemyInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            // стандарный ГУИ base.OnInspectorGUI();
            base.OnInspectorGUI();
            GUILayout.Label("heya");
            EnemyAsset a = EditorGUILayout.ObjectField(null, typeof(EnemyAsset), false) as EnemyAsset;

            if (a)
            {
                (target as Enemy).Use(a);
            }
        }
    }
}