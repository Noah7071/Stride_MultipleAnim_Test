using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core;
using Stride.Core.Mathematics;
using Stride.Animations;
using Stride.Input;
using Stride.Engine;

namespace Stride_MultipleAnim_Test
{
    [DataContract("PlayAnimation")]
    public class PlayAnimation
    {
        public AnimationClip Clip;
        public AnimationBlendOperation BlendOperation = AnimationBlendOperation.LinearBlend;
        public double StartTime = 0;
    }

    /// <summary>
    /// Script which starts a few animations on its entity
    /// </summary>
    public class AnimationStart : StartupScript
    {
        /// <summary>
        /// A list of animations to be loaded when the script starts
        /// </summary>
        public readonly List<PlayAnimation> Animations = new List<PlayAnimation>();

        public override void Start()
        {
            var animComponent = Entity.GetOrCreate<AnimationComponent>();

  //          animComponent.Play("rotate");

animComponent.Play("updown");
//animComponent.Play("sideways");
        }

        private void PlayAnimations(AnimationComponent animComponent)
        {
            foreach (var anim in Animations)
            {
                if (anim.Clip != null)
                    animComponent.Add(anim.Clip, anim.StartTime, anim.BlendOperation);
            }

            Animations.Clear();
        }
    }
}
