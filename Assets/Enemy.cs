using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Enemy : MonoBehaviour
    {
        [System.Obsolete]
        public void Use(EnemyAsset asset)
        {
           var spriteRenderer = transform.FindChild("Sprite").GetComponent<SpriteRenderer>();
           spriteRenderer.color = asset.color;
        }
    }
}