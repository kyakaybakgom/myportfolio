using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using static Enums;

public class DataManager : MonoBehaviour
{
    static public DataManager Instance;

    public bool IsReady { get; private set; } = false;

    private void Awake()
    {
        Instance = this;

        _ = InitializeLocalization();
    }

    private async Task InitializeLocalization()
    {
        // 1. Localization 시스템이 완전히 로드될 때까지 대기
        await LocalizationSettings.InitializationOperation.Task;

        // 2. 언어 설정 변경 시 호출될 이벤트 구독
        LocalizationSettings.SelectedLocaleChanged += OnSelectedLocaleChanged;

        IsReady = true;
        Debug.Log("Localization System Ready!");
    }

    public string GetLocalizedText(string tableName, string key)
    {
        // 테이블 이름과 키를 기반으로 텍스트를 찾아서 반환
        return LocalizationSettings.StringDatabase.GetLocalizedString(tableName, key);
    }

    public async Task<string> GetLocalizedTextAsync(string tableName, string key)
    {
        // 비동기로 텍스트 데이터를 요청
        var stringOperation = LocalizationSettings.StringDatabase.GetLocalizedStringAsync(tableName, key);

        // 작업이 완료될 때까지 대기
        await stringOperation.Task;

        return stringOperation.Result;
    }

    public void ChangeLanguage(Enums.LanguageType type)
    {
        if (!IsReady) return;

        string code = GetLocaleCode(type);
        var targetLocale = LocalizationSettings.AvailableLocales.Locales.Find(x => x.Identifier.Code == code);

        if (targetLocale != null)
        {
            LocalizationSettings.SelectedLocale = targetLocale;
        }
        else
        {
            Debug.LogWarning($"{type}에 해당하는 로케일을 찾을 수 없음!");
        }

    }

    private string GetLocaleCode(LanguageType type)
    {
        return type switch
        {
            LanguageType.Korean => "ko",
            LanguageType.English => "en",
            LanguageType.Japanese => "ja",
            _ => "en" // 기본값
        };
    }

    private void OnSelectedLocaleChanged(Locale locale)
    {
        Debug.Log($"언어 변경 감지: {locale.Identifier.Code}냥");

        // 여기서 초기화가 필요한 데이터(예: 런타임에 캐싱된 텍스트 등)를 다시 처리.
        RefreshLocalData();
    }

    private void RefreshLocalData()
    {
        // 언어 변경 시 데이터 매니저 내에서 별도로 갱신해야 할 로직이 있다면 여기에 작성.
    }

    private void OnDestroy()
    {
        // 메모리 누수 방지를 위해 이벤트 구독 해제
        if (LocalizationSettings.Instance != null)
        {
            LocalizationSettings.SelectedLocaleChanged -= OnSelectedLocaleChanged;
        }
    }
}
