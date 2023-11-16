using System;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnterTransfer : MonoBehaviour
{
    [Header("Empty = will always trigger")]
    [SerializeField] private string compareTag;
    [SerializeField] private UnityEvent<Collider> onTriggerEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (!String.IsNullOrEmpty(compareTag))
        {
            if (!other.gameObject.CompareTag(compareTag)) return;
        }
        onTriggerEnter.Invoke(other);
    }
}
