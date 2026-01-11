using UnityEngine;
using System.Collections.Generic;

public class SameColorMatch : MonoBehaviour
{
    public float checkRadius = 0.7f;
    public int matchCount = 5;

    void OnCollisionEnter2D(Collision2D collision)
    {
        CheckMatch();
    }

    void CheckMatch()
    {
        string myTag = gameObject.tag;

        Collider2D[] hits = Physics2D.OverlapCircleAll(
            transform.position,
            checkRadius
        );

        List<GameObject> sameColor = new List<GameObject>();

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag(myTag))
                sameColor.Add(hit.gameObject);
        }

        if (sameColor.Count >= matchCount)
        {
            ScoreManager.instance.AddScore(myTag);

            foreach (GameObject block in sameColor)
                Destroy(block);
        }
    }
}
