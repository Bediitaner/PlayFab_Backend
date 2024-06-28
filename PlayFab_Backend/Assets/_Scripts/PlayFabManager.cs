using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

namespace _Scripts
{
    public class PlayFabManager : MonoBehaviour
    {
        #region Fields

        public string playFabTitleId;

        #endregion

        #region Unity: Start

        private void Start()
        {
            LoginPlayFab();
        }

        #endregion

        #region Login: PlayFab

        private void LoginPlayFab()
        {
            var request = new LoginWithCustomIDRequest
            {
                CustomId = SystemInfo.deviceUniqueIdentifier,
                CreateAccount = true
            };

            PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
        }

        #endregion

        #region OnLogin: Success/Failure

        private void OnLoginSuccess(LoginResult result)
        {
            string playFabId = result.PlayFabId;
            Debug.Log("Login successful. PlayFab ID: " + playFabId);
        }


        private void OnLoginFailure(PlayFabError error)
        {
            Debug.Log("Error while logging in/creating account!");
            Debug.Log(error.GenerateErrorReport());
        }

        #endregion
    }
}