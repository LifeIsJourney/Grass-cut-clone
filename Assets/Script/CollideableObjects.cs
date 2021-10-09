using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideableObjects : MonoBehaviour
{
    [SerializeField] Transform part1, part2;

    public bool special;
   [HideInInspector] public EnvironmentHolder parent;

    private void OnEnable()
    {
        part1.gameObject.SetActive(true);
        part2.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Player"))
        {
            Debug.Log("player hit");
            StartCoroutine(DestroyMe());
            parent.ObjectIsRemoved();
            if (special) Debug.Log("giving coins");
        }
    }
    IEnumerator DestroyMe()
    {
        part1.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        part2.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
