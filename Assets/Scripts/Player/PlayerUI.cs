using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public EntityData _data;

    [Header("Health UI")]
    [SerializeField] private GameObject _healthBar;
    [SerializeField] Image _empanada1;
    [SerializeField] Image _empanada2;
    [SerializeField] Image _empanada3;

    [Header("Player UI Management")]
    [SerializeField] Sprite _empanadaFull;
    [SerializeField] Sprite _empanadaHalf;
    [SerializeField] Sprite _empanadaEmpty;


    private void Update()
    {
        HealthCheck();
    }

    public void HealthCheck()
    {
            if (_data.CurrentHealth >= 85f)
            {
                _empanada1.sprite = _empanadaFull;
                _empanada2.sprite = _empanadaFull;
                _empanada3.sprite = _empanadaFull;
            }
            else if (_data.CurrentHealth < 85f && _data.CurrentHealth >= 71f)
            {
                _empanada1.sprite = _empanadaHalf;
                _empanada2.sprite = _empanadaFull;
                _empanada3.sprite = _empanadaFull;
            }
            else if (_data.CurrentHealth < 71f && _data.CurrentHealth >= 57f)
            {
                _empanada1.sprite = _empanadaEmpty;
                _empanada2.sprite = _empanadaFull;
                _empanada3.sprite = _empanadaFull;
            }
            else if (_data.CurrentHealth < 57f && _data.CurrentHealth >= 42f)
            {
                _empanada1.sprite = _empanadaEmpty;
                _empanada2.sprite = _empanadaHalf;
                _empanada3.sprite = _empanadaFull;
            }
            else if (_data.CurrentHealth < 42f && _data.CurrentHealth >= 28f)
            {
                _empanada1.sprite = _empanadaEmpty;
                _empanada2.sprite = _empanadaEmpty;
                _empanada3.sprite = _empanadaFull;
            }
            else if (_data.CurrentHealth < 28f && _data.CurrentHealth > 0f)
            {
                _empanada1.sprite = _empanadaEmpty;
                _empanada2.sprite = _empanadaEmpty;
                _empanada3.sprite = _empanadaHalf;
            }
            else if (_data.CurrentHealth <= 0f)
            {
                _empanada1.sprite = _empanadaEmpty;
                _empanada2.sprite = _empanadaEmpty;
                _empanada3.sprite = _empanadaEmpty;
            }

    }

}