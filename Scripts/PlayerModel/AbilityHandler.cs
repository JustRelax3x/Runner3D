using System.Collections;
using UnityEngine;

public class AbilityHandler : MonoBehaviour
{
    [SerializeField]
    private ViewUI _viewUI;

    [SerializeField]
    private GameObject[] _manAndWoman;

    private Coroutine _slowMotionCoroutine;

    private PlayerData _playerData = new PlayerData();

    private bool _isMan = true;

    public void SetCurrentBitcoin(int value)
    {
        if (value < 1) value = 1;
        _playerData.SetCurrentBitcoin(value);
        _viewUI.UpdateBitcoinValue(value);
    }

    public void DamagePlayer()
    {
        SetCurrentBitcoin(PlayerData.CurrentBitcoin / GameConstants.BulletDamageDivisionCoef);
    }

    private void Start()
    {
        _viewUI.AddListenerAgeButton(ChangeSex);
        _viewUI.AddListenerSlowMotionButton(SlowMotion);
    }

    private void ChangeSex()
    {
        _isMan = !_isMan;
        _manAndWoman[0].SetActive(_isMan);
        _manAndWoman[1].SetActive(!_isMan);
    }

    private void SlowMotion()
    {
        if (_slowMotionCoroutine != null) return;
        _slowMotionCoroutine = StartCoroutine(SlowMotionCoroutine());
    }

    private IEnumerator SlowMotionCoroutine()
    {
        Time.timeScale = GameConstants.SlowMotionValue;
        yield return new WaitForSeconds(GameConstants.SlowMotionAction);
        Time.timeScale = 1f;
        StopSlowMotionCoroutine();
    }

    private void StopSlowMotionCoroutine()
    {
        if (_slowMotionCoroutine == null) return;
        StopCoroutine(_slowMotionCoroutine);
        _slowMotionCoroutine = null;
    }
}