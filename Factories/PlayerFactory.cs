using HackHW2018.Components;
using HackHW2018.FSM.Player;
using HackHW2018.Scenes;
using Nez;
using Nez.Sprites;
using Nez.TextureAtlases;
using Nez.Textures;
using Nez.Tiled;
using System.Collections.Generic;

namespace HackHW2018.Factories
{
    public static class PlayerFactory
    {
        static int NextPlayerIndex = 0;

        public static Entity MakePlayer(Scene scene)
        {
            var entity = scene.createEntity(PlayerIndex.Ids[NextPlayerIndex]);

            TexturePackerAtlas playerAtlas = null;
            SpriteAnimation playerJumpAnimation = null;
            SpriteAnimation playerRunAnimation = null;
            SpriteAnimation playerIdleAnimation = null;

            switch (NextPlayerIndex % 4)
            {
                case 0:
                    {
                        playerAtlas = scene.content.Load<TexturePackerAtlas>("BlueTextureAtlas");

                        playerJumpAnimation = new SpriteAnimation(new List<Subtexture>()
                        {
                            playerAtlas.getSubtexture("Jump/BlueJump0001"),
                            playerAtlas.getSubtexture("Jump/BlueJump0002"),
                            playerAtlas.getSubtexture("Jump/BlueJump0003"),
                            playerAtlas.getSubtexture("Jump/BlueJump0004"),
                            playerAtlas.getSubtexture("Jump/BlueJump0005"),
                            playerAtlas.getSubtexture("Jump/BlueJump0006"),
                            playerAtlas.getSubtexture("Jump/BlueJump0007"),
                            playerAtlas.getSubtexture("Jump/BlueJump0008"),
                        });
                        playerJumpAnimation.setFps(5f);

                        playerRunAnimation = new SpriteAnimation(new List<Subtexture>()
                        {
                            playerAtlas.getSubtexture("Run/BlueRunCycle0001"),
                            playerAtlas.getSubtexture("Run/BlueRunCycle0002"),
                            playerAtlas.getSubtexture("Run/BlueRunCycle0003"),
                            playerAtlas.getSubtexture("Run/BlueRunCycle0004"),
                        });
                        playerRunAnimation.setFps(12f);

                        playerIdleAnimation = new SpriteAnimation(playerAtlas.getSubtexture("BlueIdle"));
                    }
                    break;
                case 1:
                    {
                        playerAtlas = scene.content.Load<TexturePackerAtlas>("GreenTextureAtlas");

                        playerJumpAnimation = new SpriteAnimation(new List<Subtexture>()
                        {
                            playerAtlas.getSubtexture("Jump/GreenJump0001"),
                            playerAtlas.getSubtexture("Jump/GreenJump0002"),
                            playerAtlas.getSubtexture("Jump/GreenJump0003"),
                            playerAtlas.getSubtexture("Jump/GreenJump0004"),
                            playerAtlas.getSubtexture("Jump/GreenJump0005"),
                            playerAtlas.getSubtexture("Jump/GreenJump0006"),
                            playerAtlas.getSubtexture("Jump/GreenJump0007"),
                            playerAtlas.getSubtexture("Jump/GreenJump0008"),
                        });
                        playerJumpAnimation.setFps(5f);

                        playerRunAnimation = new SpriteAnimation(new List<Subtexture>()
                        {
                            playerAtlas.getSubtexture("Run/GreenRunCycle0001"),
                            playerAtlas.getSubtexture("Run/GreenRunCycle0002"),
                            playerAtlas.getSubtexture("Run/GreenRunCycle0003"),
                            playerAtlas.getSubtexture("Run/GreenRunCycle0004"),
                        });
                        playerRunAnimation.setFps(12f);

                        playerIdleAnimation = new SpriteAnimation(playerAtlas.getSubtexture("GreenIdle"));
                    }
                    break;
                case 2:
                    {
                        playerAtlas = scene.content.Load<TexturePackerAtlas>("RedTextureAtlas");

                        playerJumpAnimation = new SpriteAnimation(new List<Subtexture>()
                        {
                            playerAtlas.getSubtexture("Jump/RedJump0001"),
                            playerAtlas.getSubtexture("Jump/RedJump0002"),
                            playerAtlas.getSubtexture("Jump/RedJump0003"),
                            playerAtlas.getSubtexture("Jump/RedJump0004"),
                            playerAtlas.getSubtexture("Jump/RedJump0005"),
                            playerAtlas.getSubtexture("Jump/RedJump0006"),
                            playerAtlas.getSubtexture("Jump/RedJump0007"),
                            playerAtlas.getSubtexture("Jump/RedJump0008"),
                        });
                        playerJumpAnimation.setFps(5f);

                        playerRunAnimation = new SpriteAnimation(new List<Subtexture>()
                        {
                            playerAtlas.getSubtexture("Run/RedRunCycle0001"),
                            playerAtlas.getSubtexture("Run/RedRunCycle0002"),
                            playerAtlas.getSubtexture("Run/RedRunCycle0003"),
                            playerAtlas.getSubtexture("Run/RedRunCycle0004"),
                        });
                        playerRunAnimation.setFps(12f);

                        playerIdleAnimation = new SpriteAnimation(playerAtlas.getSubtexture("RedIdle"));
                    }
                    break;
                case 3:
                    {
                        playerAtlas = scene.content.Load<TexturePackerAtlas>("YellowTextureAtlas");

                        playerJumpAnimation = new SpriteAnimation(new List<Subtexture>()
                        {
                            playerAtlas.getSubtexture("Jump/YellowJump0001"),
                            playerAtlas.getSubtexture("Jump/YellowJump0002"),
                            playerAtlas.getSubtexture("Jump/YellowJump0003"),
                            playerAtlas.getSubtexture("Jump/YellowJump0004"),
                            playerAtlas.getSubtexture("Jump/YellowJump0005"),
                            playerAtlas.getSubtexture("Jump/YellowJump0006"),
                            playerAtlas.getSubtexture("Jump/YellowJump0007"),
                            playerAtlas.getSubtexture("Jump/YellowJump0008"),
                        });
                        playerJumpAnimation.setFps(5f);

                        playerRunAnimation = new SpriteAnimation(new List<Subtexture>()
                        {
                            playerAtlas.getSubtexture("Run/YellowRunCycle0001"),
                            playerAtlas.getSubtexture("Run/YellowRunCycle0002"),
                            playerAtlas.getSubtexture("Run/YellowRunCycle0003"),
                            playerAtlas.getSubtexture("Run/YellowRunCycle0004"),
                        });
                        playerRunAnimation.setFps(12f);

                        playerIdleAnimation = new SpriteAnimation(playerAtlas.getSubtexture("YellowIdle"));
                    }
                    break;
            }



            var sprite = new Sprite<PlayerAnimationState>(playerIdleAnimation.frames[0]);
            sprite.addAnimation(PlayerAnimationState.Idle, playerIdleAnimation);
            sprite.addAnimation(PlayerAnimationState.Jumping, playerJumpAnimation);
            sprite.addAnimation(PlayerAnimationState.Running, playerRunAnimation);

            sprite.currentAnimation = PlayerAnimationState.Idle;

            entity.addComponent(sprite);
            entity.transform.setScale(0.2f);

            var background = scene.findEntity("background");
            var tiledMap = background.getComponent<TiledMapComponent>().tiledMap;

            entity.transform.setPosition(148 * NextPlayerIndex, 366);
            entity.addComponent(new TiledMapMover(tiledMap.getLayer<TiledTileLayer>("TileLayer")));

            var width = playerIdleAnimation.frames[0].sourceRect.Width;
            var height = playerIdleAnimation.frames[0].sourceRect.Height;

            entity.addComponent(new BoxCollider(-width / 2, -height / 2, width, height));

            entity.addComponent(new PlayerController());

            var mainScene = (scene as MainScene);
            entity.addComponent(new PlayerInput { PlayerId = NextPlayerIndex });

            NextPlayerIndex++;

            return entity;
        }
    }
}
