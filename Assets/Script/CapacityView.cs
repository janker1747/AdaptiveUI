using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CapacityView : MonoBehaviour
{
    [SerializeField] private Image _fillImage;
    [SerializeField] private TextMeshProUGUI _capacityText;
    [SerializeField] private float _animationDuration = 0.5f;

    private Tween _fillTween;
    private Tween _textTween;

    public void SetInstant(float normalized, int current, int max)
    {
        _fillImage.fillAmount = normalized;
        _capacityText.text = $"{current}/{max}";
    }

    public void Animate(float targetNormalized, int current, int max)
    {
        _fillTween?.Kill();
        _textTween?.Kill();

        float startFill = _fillImage.fillAmount;
        int startValue = Mathf.RoundToInt(startFill * max);
        int targetValue = current;

        _fillTween = DOTween.To(
            () => _fillImage.fillAmount,
            x => _fillImage.fillAmount = x,
            targetNormalized,
            _animationDuration
        );

        _textTween = DOTween.To(
            () => startValue,
            x =>
            {
                startValue = x;
                _capacityText.text = $"{startValue}/{max}";
            },
            targetValue,
            _animationDuration
        ).SetEase(Ease.OutCubic);
    }
}