using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

namespace TowerDefense
{
    [RequireComponent(typeof(TDPatrolController))]
    public class Enemy : MonoBehaviour
    {
        [System.Obsolete]
        public void Use(EnemyAsset asset)
        {
            var spriteRenderer = transform.FindChild("Sprite").GetComponent<SpriteRenderer>();
            spriteRenderer.color = asset.color;
            spriteRenderer.transform.localScale = new Vector3(asset.sprtiteScale.x, asset.sprtiteScale.y, 1);

            spriteRenderer.GetComponent<Animator>().runtimeAnimatorController = asset.animations;
            // хп (в спейсшипе преопределяется)
            GetComponent<SpaceShip>().Use(asset);

            GetComponentInChildren<CircleCollider2D>().radius = asset.radius;


        }
    }
    [CustomEditor(typeof(Enemy))]
    public class EnemyInspector : Editor
    {
        [System.Obsolete]
        public override void OnInspectorGUI()
        {
           // стандарный ГУИ base.OnInspectorGUI();
            GUILayout.Label("heya");
            EnemyAsset a = EditorGUILayout.ObjectField(null, typeof(EnemyAsset), false) as EnemyAsset;

            if (a)
            {
                (target as Enemy).Use(a);
            }
        }
    }
}