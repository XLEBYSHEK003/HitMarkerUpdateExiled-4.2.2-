using System;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Exiled.Events.Handlers;

namespace HitMarker
{
    public class Plugin : Plugin<Config>
    {
        public override string Author { get; } = "xRoier (Update XLEBYSHEK)";
        public override string Name { get; } = "HitMarker";

        public override void OnEnabled()
        {
            Exiled.Events.Handlers.Player.Hurting += PlayerOnHurting;
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.Hurting -= PlayerOnHurting;
        }
        private static readonly System.Random rnd = new System.Random(); 
        private void PlayerOnHurting(HurtingEventArgs ev)
        {
                ev.Attacker.ShowHint(string.Concat(new object[]
                {
                    Repeat(rnd.Next(1, 14), "\n"),
                    Repeat(rnd.Next(1, 5), " "),
                    " <color=yellow>Попадение! Нанесено:</color> ",
                    Math.Round((double)ev.Amount, 1),
                    " <color=red></color>"
                }), 4f);
            
        }

        private string Repeat(int random, string source)
        {
            string text = String.Empty;
            for (int i = 0; i < random; i++)
                text += source;
            return text;
        }

    }
}
