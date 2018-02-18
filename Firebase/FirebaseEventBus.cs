using Firebase.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HackHW2018.Firebase
{
    public class FirebaseEventBus
    {
        FirebaseClient firebaseClient;

        public delegate void OnPlayerAdded(FirebasePlayerFormat fpf);
        public event OnPlayerAdded PlayerAddedEvent;

        public FirebaseEventBus()
        {
            firebaseClient = new FirebaseClient("https://hack-hw2018.firebaseio.com/");
        }

        public async Task<List<FirebasePlayerFormat>> GetInitialValues()
        {
            var players =  await firebaseClient.Child("Players").OnceAsync<FirebasePlayerFormat>();

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
    }
}
