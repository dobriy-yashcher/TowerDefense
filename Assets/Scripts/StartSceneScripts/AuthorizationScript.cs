using Assets.Data;
using Newtonsoft.Json;                           
using UnityEngine;
using UnityEngine.SceneManagement;              
using UnityEngine.UI;

public class AuthorizationScript : MonoBehaviour
{
    [SerializeField] Text email;   
    [SerializeField] Text password;

    public void Authorize()
    {
        if (email.text != "" && password.text != "")
        {
            var storagedUser = JsonConvert.DeserializeObject<UserData>(PlayerPrefs.GetString("PlayerData"));
            if (storagedUser != null)
            {
                if (storagedUser.Email == email.text && storagedUser.Password == password.text)
                {
                    SceneManager.LoadScene("GameScene");
                }
            }
        }
    }
}
