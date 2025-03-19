using System.Collections;
using System.Text;
using Assets.Scripts.Constants;
using Assets.Scripts.Models.Dtos;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Managers
{
    public static class NetworkManager
    {
        public static IEnumerator UpdateInventoryStatus(
            InventoryUpdateStatusDto statusDto)
        {
            var request = new UnityWebRequest
            {
                method = "POST",
                url = NetworkConstants.InventoryStatusUpdateUrl,
                uploadHandler = new UploadHandlerRaw(
                    Encoding.UTF8.GetBytes(
                        JsonConvert.SerializeObject(statusDto))),
                downloadHandler = new DownloadHandlerBuffer(),
                timeout = NetworkConstants.Timeout
            };

            request.SetRequestHeader(
                "Content-Type",
                "application/json");
            request.SetRequestHeader(
                "Authorization",
                "Bearer " + NetworkConstants.AuthorizationToken);

            yield return request.SendWebRequest();

            if (request.responseCode == 200)
            {
                Debug.Log(request.downloadHandler.text);
            }
        }
    }
}