using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFileBrowser;
using System.IO;
using UnityEngine.SceneManagement;

public class FileLoader : MonoBehaviour
{
    public void OpenBrowser()
    {
        FileBrowser.SetFilters(true, new FileBrowser.Filter("Text Files", ".txt", ".json"));
        FileBrowser.SetDefaultFilter(".json");
        FileBrowser.AddQuickLink("Users", "C:\\Users", null);
        StartCoroutine(ShowLoadDialogCoroutine());
    }

    IEnumerator ShowLoadDialogCoroutine()
    {
        yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.FilesAndFolders, true, null, null, "Load Files and Folders", "Load");
        Debug.Log(FileBrowser.Success);

        if (FileBrowser.Success)
        {
            for (int i = 0; i < FileBrowser.Result.Length; i++)
                Debug.Log(FileBrowser.Result[i]);

            byte[] bytes = FileBrowserHelpers.ReadBytesFromFile(FileBrowser.Result[0]);

            string destinationPath = Path.Combine(Application.persistentDataPath, FileBrowserHelpers.GetFilename(FileBrowser.Result[0]));
            FileBrowserHelpers.CopyFile(FileBrowser.Result[0], destinationPath);
            string json = File.ReadAllText(destinationPath);
            Debug.Log(json);
            NickClear.Instance.PlayerData = JsonUtility.FromJson<PlayerData>(json);
            SceneManager.LoadScene("Main");
        }
    }
}
