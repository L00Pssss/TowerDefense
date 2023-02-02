using TMPro;
using UnityEngine;

namespace TowerDefense
{
    public class TextUpdate : MonoBehaviour
    {
        public enum UpdateSource { Gold, Life }
        public UpdateSource source = UpdateSource.Gold;
        private TextMeshProUGUI m_text;
        void Awake()
        {
            m_text = GetComponent<TextMeshProUGUI>();
            switch (source)
            {
                case UpdateSource.Gold:
                    TDPlayer.OnGoldUpdate += UpdateText;
                    Debug.Log(m_text );
                    break;
                case UpdateSource.Life:
                    TDPlayer.OnLifeUpdate += UpdateText;
                    Debug.Log(m_text + " LIFE");
                    break;
            }
        }

        private void UpdateText(int variable) 
        {
            if(source == UpdateSource.Gold)
                m_text.text = variable.ToString();
            if (source == UpdateSource.Life)
                m_text.text = variable.ToString();
        }
    }
}