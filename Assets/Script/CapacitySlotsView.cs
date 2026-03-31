using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CapacitySlotsView : MonoBehaviour
{
    [SerializeField] private Transform _container; 
    [SerializeField] private GameObject _slotPrefab;

    [Header("Animation")]
    [SerializeField] private float _spawnDuration = 0.3f;
    [SerializeField] private float _spawnDelayStep = 0.05f;
    [SerializeField] private float _scaleFrom = 0f;

    private readonly List<GameObject> _spawnedSlots = new List<GameObject>();

    public void AddSlots(int count)
    {
        Sequence sequence = DOTween.Sequence();

        for (int i = 0; i < count; i++)
        {
            GameObject slot = Object.Instantiate(_slotPrefab, _container);
            _spawnedSlots.Add(slot);

            slot.transform.localScale = Vector3.one * _scaleFrom;

            sequence.Insert(i * _spawnDelayStep,
                slot.transform.DOScale(1f, _spawnDuration)
                    .SetEase(Ease.OutBack)
            );
        }
    }
}