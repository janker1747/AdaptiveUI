using UnityEngine;
using UnityEngine.UI;

public class CapacityController : MonoBehaviour
{
    [SerializeField] private CapacityView _view;
    [SerializeField] private CapacitySlotsView _slotsView;
    [SerializeField] private Button _upgradeButton;

    [Header("Config")]
    [SerializeField] private int _startCurrent = 150;
    [SerializeField] private int _maxCapacity = 500;
    [SerializeField] private int _upgradeAmount = 50;

    [Header("Slots")]
    [SerializeField] private int _slotsPerUpgrade = 5;

    private CapacityModel _model;

    private void Awake()
    {
        _model = new CapacityModel(_startCurrent, _maxCapacity);
    }

    private void OnEnable()
    {
        _upgradeButton.onClick.AddListener(OnUpgradeClicked);
    }

    private void OnDisable()
    {
        _upgradeButton.onClick.RemoveListener(OnUpgradeClicked);
    }

    private void Start()
    {
        _view.SetInstant(_model.GetNormalized(), _model.Current, _model.Max);
    }

    private void OnUpgradeClicked()
    {
        bool upgraded = _model.TryUpgrade(_upgradeAmount);

        if (upgraded == false)
            return;

        _view.Animate(_model.GetNormalized(), _model.Current, _model.Max);

        _slotsView.AddSlots(_slotsPerUpgrade);
    }
}