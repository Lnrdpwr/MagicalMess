using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private string[] _tutorialTexts;
    [SerializeField] private Sprite[] _tutorialImages;
    [SerializeField] private Image _firstImage, _secondImage;
    [SerializeField] private TMP_Text _firstText, _secondText;
    [SerializeField] private int _pagesAmount;

    private int _currentPage = 0;

    private void Awake()
    {
        _currentPage = 0;
        _firstImage.sprite = _tutorialImages[0];
        _secondImage.sprite = _tutorialImages[1];
        _firstImage.SetNativeSize();
        _secondImage.SetNativeSize();

        _firstText.text = _tutorialTexts[0];
        _secondText.text = _tutorialTexts[1];
    }

    public void NextPage()
    {
        _currentPage++;
        if(_currentPage < _pagesAmount)
        {
            _firstImage.sprite = _tutorialImages[_currentPage * 2];
            _secondImage.sprite = _tutorialImages[_currentPage * 2 + 1];
            _firstImage.SetNativeSize();
            _secondImage.SetNativeSize();

            _firstText.text = _tutorialTexts[_currentPage * 2];
            _secondText.text = _tutorialTexts[_currentPage * 2 + 1];
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
