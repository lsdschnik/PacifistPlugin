using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using System;

namespace PacifistPlugin
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "Pacifist Plugin";
        public override string Author => "Pitayus LSD";
        public override string Prefix => "PP";
        public override Version Version => new Version(1, 0, 1);

        public static Plugin Instance;

        public override void OnEnabled()
        {
            Instance = this;
            Exiled.Events.Handlers.Player.Shooting += OnShooting;
            Exiled.Events.Handlers.Player.Hurting += OnHurting;
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Instance = null;
            Exiled.Events.Handlers.Player.Shooting -= OnShooting;
            Exiled.Events.Handlers.Player.Hurting -= OnHurting;
            base.OnDisabled();
        }
        private void OnShooting(ShootingEventArgs ev)
        {
            if (Config.PacifistModeEnabled)
            {
                ev.IsAllowed = false;
                ev.Player.ShowHint("Keine Gewalt erlaubt!", 2);
            }
        }

        private void OnHurting(HurtingEventArgs ev)
        {
            if (Config.PacifistModeEnabled)
            {
                ev.IsAllowed = false;
                ev.Player.ShowHint("Du bist im Pazifistenmodus geschützt!", 2);
            }
        }
    }
}


