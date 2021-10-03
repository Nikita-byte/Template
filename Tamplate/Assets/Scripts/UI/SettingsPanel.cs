using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;


public class SettingsPanel : BasePanel
{
    [SerializeField] private Button _back;
    [SerializeField] private Button _vibroOn;
    [SerializeField] private Button _vibroOff;
    [SerializeField] private Button _soundOn;
    [SerializeField] private Button _soundOff;
    [SerializeField] private Slider _soundVolume;
 
    private void Awake()
    {
        _back.onClick.AddListener(() => ScreenInterface.Instance.Execute(PanelType.MainMenu));

        _soundOn.onClick.AddListener(() => SoundOn());
        _soundOff.onClick.AddListener(() => SoundOff());
        _vibroOn.onClick.AddListener(() => VibroOn());
        _vibroOff.onClick.AddListener(() => VibroOff());

        SetVolume();
        SoundOn();
        VibroOn();
        
    }

    public override void Hide()
    {
        GetComponent<RectTransform>().DOAnchorPos(new Vector2(-350, 0), 0.3f);
        gameObject.SetActive(false);
    }

    public override void Show()
    {
        gameObject.SetActive(true);
        GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 0.3f);
    }

    public void SetScreen(Sprite screen)
    {
        GetComponent<Image>().sprite = screen;
    }

    public void SetBackButton(Sprite sprite)
    {
        _back.GetComponent<Image>().sprite = sprite;
    }

    public void SetSounOnButton(Sprite sprite)
    {
        _soundOn.GetComponent<Image>().sprite = sprite;
    }

    public void SetSoundOffButton(Sprite sprite)
    {
        _soundOff.GetComponent<Image>().sprite = sprite;
    }

    public void SetVibroOnButton(Sprite sprite)
    {
        _vibroOn.GetComponent<Image>().sprite = sprite;
    }

    public void SetVinroOffButton(Sprite sprite)
    {
        _vibroOff.GetComponent<Image>().sprite = sprite;
    }

    public void ChangeValue(float value)
    {
        SoundManager.Instance.SetVolume(value);
    }

    private void SetVolume()
    {
        SoundManager.Instance.SetVolume(1);
    }

    private void SoundOn()
    {
        //SoundManager.Instance.TurnOn();
        float volume = PlayerPrefs.GetFloat("Volume", 1);
        _soundVolume.value = volume;
        _soundOn.gameObject.SetActive(false);
        _soundOff.gameObject.SetActive(true);
    }

    private void SoundOff()
    {
        //SoundManager.Instance.TurnOff();
        PlayerPrefs.SetFloat("Volume", _soundVolume.value);
        _soundVolume.value = 0;
        _soundOn.gameObject.SetActive(true);
        _soundOff.gameObject.SetActive(false);
    }

    private void VibroOn()
    {
        VibroManager.Instance.TurnOn();
        _vibroOn.gameObject.SetActive(false);
        _vibroOff.gameObject.SetActive(true);
    }

    private void VibroOff()
    {
        VibroManager.Instance.TurnOff(); 
        _vibroOn.gameObject.SetActive(true);
        _vibroOff.gameObject.SetActive(false);
    }
}