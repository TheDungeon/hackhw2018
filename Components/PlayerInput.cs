//using HackHW2018.Scenes;
//using Nez;
//using System;

//namespace HackHW2018.Components
//{
//    public class PlayerInput : Component
//    {
//        public string PlayerKey;
//        public int PlayerId;

//        float BufferTime = 1 / 30f;

//        private IDisposable CallbackHandle;

//        private MainScene _mainScene;

//        private bool _jumpPressed = false;
//        private bool _stopPressed = false;

//        public override void OnAddedToEntity()
//        {
//            base.OnAddedToEntity();

//            _mainScene = (entity.scene as MainScene);

//            PlayerKey = _mainScene.Players[PlayerId].Key;

//            Core.schedule(BufferTime, true, QueryDatabase);
//        }

//        public void QueryDatabase(ITimer timer)
//        {
//            var result = _mainScene.EventBus.QueryStateByKey(PlayerKey).Result;

//            _jumpPressed = result.Jump;
//            _stopPressed = result.Stop;
//        }

//        public bool IsStopping()
//        {
//            return _stopPressed;
//        }

//        public bool IsJumping()
//        {
//            return _jumpPressed;
//        }
//    }
//}
