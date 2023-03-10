using UnityEngine;

namespace TowerDefense
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private float m_Radius = 5f;
        [SerializeField] private Turret[] turrets;
        [SerializeField] private AnimationReady m_AnimationReady;

        public float RadiusDetection
        {
            get { return m_Radius; }
            set { m_Radius = value; }
        }
        private Destructible target = null;
        private void Update()
        {
            if (target)
            {
                Vector2 targetVector = target.transform.position - transform.position;
                if (targetVector.magnitude <= m_Radius)
                {
                    foreach (var turret in turrets)
                    {
                        turret.transform.up = targetVector;
                        if (turret.CanFire == true)
                        {
                            m_AnimationReady?.OnAnimation();
                            turret.Fire();
                        }
                    }
                }
                else { target = null; }
            }
            else
            {
                var enter = Physics2D.OverlapCircle(transform.position, m_Radius);
                if (enter)
                {
                    target = enter.transform.root.GetComponent<Destructible>();
                }
            }
        }
        private void Start()
        {
            turrets = GetComponentsInChildren<Turret>();
            m_AnimationReady = GetComponentInChildren<AnimationReady>();
        }
        

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;

            Gizmos.DrawWireSphere(transform.position, m_Radius);
        }
    }
}