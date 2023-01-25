using Euphrates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] TriggerChannelSO _loadUI;
    [SerializeField] TriggerChannelSO _loadStudio;
    [SerializeField] TriggerChannelSO _studioLoaded;

    [Space]
    [Header("Scenes")]
    [SerializeField] int _UIScene;
    [SerializeField] int _studioScene;

    private void OnEnable()
    {
        _loadUI.AddListener(LoadUI);
        _loadStudio.AddListener(LoadStudio);
    }

    private void OnDisable()
    {
        _loadUI.RemoveListener(LoadUI);
        _loadStudio.RemoveListener(LoadStudio);
    }

    void LoadUI() => SceneManager.LoadScene(_UIScene, LoadSceneMode.Additive);

    void LoadStudio() => SceneManager.LoadSceneAsync(_studioScene, LoadSceneMode.Additive).completed += StudioLoaded;

    void StudioLoaded(AsyncOperation op)
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(_studioScene));
        _studioLoaded?.Invoke();
    }
}
