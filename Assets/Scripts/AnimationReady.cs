using UnityEngine;

namespace TowerDefense
{
    public class AnimationReady : MonoBehaviour
    {
        [SerializeField] private bool m_AnimtaionFire;
        [SerializeField] private Animator m_Animator;


        public void OnAnimation()
        {
            if(m_AnimtaionFire)
            m_Animator.SetTrigger("Fire");
        }

    }
}