using UnityEngine;

public class LavaClearSameColor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Red") || other.CompareTag("Yellow"))
        {
            ClearColor(other.tag);
        }
    }

    void ClearColor(string colorTag)
    {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag(colorTag);

        foreach (GameObject block in blocks)
        {
            Destroy(block);
        }
    }
}
