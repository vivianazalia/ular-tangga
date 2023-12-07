using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _questionText;
    [SerializeField]
    private TMP_InputField _answerInput;
    [SerializeField]
    private Button _confirmButton;
    [SerializeField]
    private TMP_Text _answerValidation;

    private string _answer;

    public static UnityAction<CardSO> OnSetDataCard;

    private void Awake()
    {
        OnSetDataCard += SetCardData;

        _confirmButton.onClick.RemoveAllListeners();
        _confirmButton.onClick.AddListener(delegate { OnClickConfirmButton(); });
    }

    private void OnDestroy()
    {
        OnSetDataCard -= SetCardData;
    }

    private void SetCardData(CardSO data)
    {
        transform.localScale = Vector3.one;
        _questionText.SetText($"{data.question}");
        _answer = data.answer;
    }

    private void OnClickConfirmButton()
    {
        if(_answerInput.text == _answer)
        {
            StartCoroutine(ValidationAnswer(true));
        }
        else
        {
            StartCoroutine(ValidationAnswer(false));
        }
    }

    private IEnumerator ValidationAnswer(bool answer)
    {
        _answerValidation.gameObject.SetActive(true);
        if (answer)
        {
            _answerValidation.SetText($"<color=\"green\">Jawaban Benar!</color>");
        }
        else
        {
            _answerValidation.SetText($"<color=\"red\">Jawaban Salah!</color>");
            yield return new WaitForSeconds(.5f);
            ResultUI.OnLoseCondition?.Invoke();
        }

        yield return new WaitForSeconds(1f);
        transform.localScale = Vector3.zero;
        _answerValidation.gameObject.SetActive(false);
        _answerInput.text = string.Empty;
    }
}
