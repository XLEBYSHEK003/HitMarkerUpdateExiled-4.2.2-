using System;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Exiled.Events.Handlers;

namespace HitMarker
{
    public class Plugin : Plugin<Config>
    {
        public override string Author
        {
            get
            {
                return "xRoier (Update XLEBYSHEK)";
            }
        }

        public override string Name
        {
            get
            {
                return "HitMarker";
            }
        }

        public override void OnEnabled()
        {
            Exiled.Events.Handlers.Player.Hurting += this.PlayerOnHurting;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.Hurting -= this.PlayerOnHurting;
            base.OnDisabled();
        }

        private void PlayerOnHurting(HurtingEventArgs ev)
        {
                ev.Attacker.ShowHint(string.Concat(new object[]
                {
                    this.Repeat(this.RNG.Next(1, 14), "\n"),
                    this.Repeat(this.RNG.Next(1, 5), " "),
                    " <color=yellow>Попадение! Нанесено:</color> ",
                    Math.Round((double)ev.Amount, 1),
                    " <color=red></color>"
                }), 4f);
            
        }

        private string Repeat(int random, string re)
        {
            string text = "";
            for (int i = 0; i < random; i++)
            {
                text += re;
            }
            return text;
        }

        private Random RNG
        {
            get
            {
                return new Random();
            }
        }
    }
}
