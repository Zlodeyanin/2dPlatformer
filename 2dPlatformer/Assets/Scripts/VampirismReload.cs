using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VampirismReload : MonoBehaviour
{
    [SerializeField] private TMP_Text _reloadText;
    [SerializeField] private float _reloadTime;
    [SerializeField] private Button _vampirizm;

    private float _oneSecond = 1;
    private string _vampirismText = "Vampirism";
    private Coroutine _vampirismReload;

    private void Update()
    {
        if (_reloadTime == 0 && _vampirismReload != null)
        {
            _reloadText.text = _vampirismText;
            StopCoroutine(_vampirismReload);
            _vampirizm.interactable = true;
            _reloadTime = 6;
            gameObject.SetActive(false);
        }
    }

    public void OnButtonClick()
    {
        _vampirismReload = StartCoroutine(ReloadVampirism());
        _vampirizm.interactable = false;
    }

    private IEnumerator ReloadVampirism()
    {
        WaitForSeconds oneSecond = new WaitForSeconds(_oneSecond);
        
        while (_reloadTime != 0)
        {
            _reloadTime -= _oneSecond;
            _reloadText.text = _reloadTime.ToString();
            yield return oneSecond; 
        }
    }
}