using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public string NextScene;

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Return))
		{
			SceneManager.LoadScene(NextScene);
		}
	}
}
