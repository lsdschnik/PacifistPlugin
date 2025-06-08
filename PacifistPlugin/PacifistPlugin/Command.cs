using System;
using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;

namespace PacifistPlugin
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class PacifistCommand : ICommand
    {
        public string Command => "pacifistmode";
        public string[] Aliases => new[] { "pfm" };
        public string Description => "Aktiviert oder deaktiviert den Pazifistenmodus";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("pacifist.toggle"))
            {
                response = "Du hast keine Berechtigung, diesen Befehl zu verwenden.";
                return false;
            }

            if (arguments.Count == 0)
            {
                response = $"Pazifistenmodus ist aktuell: {(Plugin.Instance.Config.PacifistModeEnabled ? "Aktiviert" : "Deaktiviert")}. Nutze: .pacifist on/off";
                return true;
            }

            switch (arguments.At(0).ToLower())
            {
                case "on":
                    Plugin.Instance.Config.PacifistModeEnabled = true;
                    response = "Pazifistenmodus aktiviert.";
                    return true;

                case "off":
                    Plugin.Instance.Config.PacifistModeEnabled = false;
                    response = "Pazifistenmodus deaktiviert.";
                    return true;

                default:
                    response = "⚠ Ungültiges Argument. Nutze: .pacifist on / off";
                    return false;
            }
        }
    }
}
