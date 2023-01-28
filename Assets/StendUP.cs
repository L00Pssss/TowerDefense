using UnityEngine;

namespace TowerDefense
{
    public class StendUP : MonoBehaviour
    {
        private Rigidbody2D rigidbody;

        private SpriteRenderer spriteRenderer;

        private void Start()
        {
            rigidbody= transform.root.GetComponent<Rigidbody2D>();
            spriteRenderer= GetComponent<SpriteRenderer>();
        }
        private void LateUpdate()
        {
            transform.up = Vector2.up;
            var xMotion = rigidbody.velocity.x;
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