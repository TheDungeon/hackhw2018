using HackHW2018.Components;
using HackHW2018.State;
using Microsoft.Xna.Framework;
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
            var entity = scene.createEntity(State.PlayerIndex.Ids[NextPlayerIndex]);

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
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }

            NextPlayerIndex++;

            var sprite = new Sprite<PlayerAnimationState>(playerIdleAnimation.frames[0]);
            sprite.addAnimation(PlayerAnimationState.Idle, playerIdleAnimation);
            sprite.addAnimation(PlayerAnimationState.Jumping, playerJumpAnimation);
            sprite.addAnimation(PlayerAnimationState.Running, playerRunAnimation);

            sprite.currentAnimation = PlayerAnimationState.Idle;

            entity.addComponent(sprite);
            entity.transform.setScale(0.2f);

            var background = scene.findEntity("background");
            var tiledMap = background.getComponent<TiledMapComponent>().tiledMap;

            entity.transform.setPosition(148, 366);
            entity.addComponent(new TiledMapMover(tiledMap.getLayer<TiledTileLayer>("TileLayer")));

            var width = playerIdleAnimation.frames[0].sourceRect.Width;
            var height = playerIdleAnimation.frames[0].sourceRect.Height;

            entity.addComponent(new BoxCollider(-width / 2, -height / 2, width, height));

            entity.addComponent<PlayerController>();

            return entity;
        }
    }
}
