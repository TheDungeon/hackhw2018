using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HackHW2018.Firebase
{
    public class FirebaseEventBus
    {
        FirebaseClient firebaseClient;

        public FirebaseEventBus()
        {
            firebaseClient = new FirebaseClient("https://hack-hw2018.firebaseio.com/");
        }

        public async Task<List<FirebasePlayerFormat>> FetchPlayers()
        {
            var players = await firebaseClient.Child("Players").OnceAsync<FirebasePlayerFormat>();

            List<FirebasePlayerFormat> ret = new List<FirebasePlayerFormat>();
            foreach (var player in players)
            {
                var obj = player.Object;
                obj.Key = player.Key;

                ret.Add(obj);
            }

            return ret;
        }

        public async Task ClearPlayers()
        {
            await firebaseClient.Child("Players").DeleteAsync();
        }

        public async Task SetWaiting()
        {
            await firebaseClient.Child("Waiting").PutAsync("true");
        }

        public async Task SetWaitingFalse()
        {
            await firebaseClient.Child("Waiting").PutAsync("false");
        }

        public async Task<FirebasePlayerFormat> QueryStateByKey(string key)
        {
            var player = await firebaseClient
                .Child("Players")
                .Child(key)
                .OnceSingleAsync<FirebasePlayerFormat>();

            return player;
        }

    }
}
