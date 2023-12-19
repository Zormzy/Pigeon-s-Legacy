using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PL_Enemy_SpriteAnim : MonoBehaviour
{
    [SerializeField] private Transform transformPlayer;
    [SerializeField] private Transform transformEnemy;
    private Transform transformSprite;
    [SerializeField] List<Sprite> sprites = new List<Sprite>();
    private SpriteRenderer spriteRenderer;
    private bool front = false;

    private void Awake()
    {
        Initialize();
    }

    private void Update()
    {
        LookAtPlayer();
        AnimateEnemy();
        IsFront();
    }

    private void Initialize()
    {
        transformSprite = transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void LookAtPlayer()
    {
        transformSprite.LookAt(transformPlayer);
    }

    private void AnimateEnemy()
    {
            StartCoroutine(AnimateWait());
    }


    private IEnumerator AnimateWait()
    {
        yield return new WaitForSeconds(0.6f);
        if (front)
        {
            spriteRenderer.sprite = (spriteRenderer.sprite == sprites[0]) ? sprites[1] : sprites[0];
        }
        else
        {
            spriteRenderer.sprite = (spriteRenderer.sprite == sprites[2]) ? sprites[3] : sprites[2];
        }
        StopAllCoroutines();
    }

    private void IsFront()
    {
        if (Vector3.Angle(transformPlayer.position - transformEnemy.position, transformEnemy.forward) > 180f - 90 * 0.5f && Vector3.Angle(transformPlayer.position - transformEnemy.position, transformEnemy.forward) < 180f + 90 * 0.5f)
        {
            //print("L'ennemi tourne le dos au joueur !");
            front = false;
        }
        else
        {
            //("L'ennemi est face au joueur !");
            front = true;
        }
    }
}
