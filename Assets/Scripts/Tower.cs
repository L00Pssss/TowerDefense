using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

namespace TowerDefense
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private float m_Radius = 5f;
        [SerializeField] private Turret[] turrets;
        [SerializeField] private AnimationReady m_AnimationReady;

        private Destructible target = null;
        public float RadiusDetection
        {
            get { return m_Radius; }
            set { m_Radius = value; }
        }
        private void Start()
        {
            turrets = GetComponentsInChildren<Turret>();
            m_AnimationReady = GetComponentInChildren<AnimationReady>();
        }

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

        public void Use(TowerAsset TowerAsset)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = TowerAsset.sprite;

            GetComponentInChildren<Turret>().Mode = TowerAsset.Mode;

            GetComponentInChildren<Turret>().SetTurretProprties(TowerAsset.turretProperties);

            GetComponent<Tower>().RadiusDetection = TowerAsset.RadiusDetection;

            if (TowerAsset.AddAnimationHero == true)
            {
                var pref = Instantiate(TowerAsset.PrefabAnimationHero, GetComponent<Transform>().position, Quaternion.identity);
                pref.transform.parent = transform.GetChild(0);
            }
            
  

            foreach (var turret in turrets)
            {
                turret.AssignLoadount(TowerAsset.turretProperties);
            }

            

            var buildSite = GetComponentInChildren<BuildSite>();
            
            buildSite.SetBuildableTowers(TowerAsset.m_UpgradesTo);

        }
        

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;

            Gizmos.DrawWireSphere(transform.position, m_Radius);
        }
    }
}