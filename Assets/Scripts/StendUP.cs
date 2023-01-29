using UnityEngine;

namespace TowerDefense
{
    public class StendUP : MonoBehaviour
    {
        private Rigidbody2D m_rigidbody;

        private SpriteRenderer spriteRenderer;

        private void Start()
        {
            m_rigidbody= transform.root.GetComponent<Rigidbody2D>();
            spriteRenderer= GetComponent<SpriteRenderer>();
        }
        private void LateUpdate()
        {
            transform.up = Vector2.up;
            var xMotion = m_rigidbody.velocity.x;
            if (xMotion > 0.01f)
            {
                spriteRenderer.flipX = false;
            }
            else if (xMotion < 0.01f)
            {
                spriteRenderer.flipX = true;
            }
        }
    }
}