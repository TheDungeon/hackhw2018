using Nez;
using Nez.Sprites;
using Nez.TextureAtlases;
using Nez.Textures;
using Nez.Tiled;
using System.Collections.Generic;

namespace HackHW2018.Factories
{
    public static class ScenePopulationFactory
    {
        public static void PopulateScene(Scene scene, TiledObjectGroup entityLayer)
        {
            var torchIdx = 0;
            TexturePackerAtlas traps = scene.content.Load<TexturePackerAtlas>("TrapTextureAtlas");

            foreach (var torch in entityLayer.objectsWithName("TorchHere"))
            {
                SpriteAnimation torchAnim = new SpriteAnimation(new List<Subtexture>() {
                    traps.getSubtexture("Torch/RoundTorch0001"),
                    traps.getSubtexture("Torch/RoundTorch0002"),
                    traps.getSubtexture("Torch/RoundTorch0003"),
                    traps.getSubtexture("Torch/RoundTorch0004"),
                    traps.getSubtexture("Torch/RoundTorch0005"),
                    traps.getSubtexture("Torch/RoundTorch0006"),
                    traps.getSubtexture("Torch/RoundTorch0007"),
                    traps.getSubtexture("Torch/RoundTorch0008"),
                    traps.getSubtexture("Torch/RoundTorch0009"),
                    traps.getSubtexture("Torch/RoundTorch0010"),
                });

                var torchEntity = scene.createEntity("torch-" + torchIdx.ToString());

                var sprite = new Sprite<int>(0, torchAnim);
                torchEntity.addComponent(sprite);
                torchEntity.transform.setPosition(torch.position.X, torch.position.Y);
                sprite.play(0);

                torchIdx++;
            }
        }
    }
}
