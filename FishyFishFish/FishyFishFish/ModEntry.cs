using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley.Menus;
using StardewValley.Tools;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace FishyFishFish
{
    /// <summary>The mod entry point.</summary>
    public class ModEntry : Mod
    {
        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            helper.Events.Input.ButtonPressed += this.OnButtonPressed;
            helper.Events.GameLoop.UpdateTicking += this.UpdateTicking;
        }


        private void UpdateTicking(object sender, UpdateTickingEventArgs e)
        {
            // ignore if player hasn't loaded a save yet
            if (!Context.IsWorldReady)
                return;


            if (Game1.player.CurrentTool is FishingRod rod)
            {
                if (Game1.activeClickableMenu is BobberBar bobberBar)
                {
                    float bobberBarHeight = Helper.Reflection.GetField<int>(bobberBar, "bobberBarHeight", true).GetValue();
                    Helper.Reflection.GetField<int>(bobberBar, "bobberBarHeight", true).SetValue(2000);
                }
            }


        }

        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            

            // print button presses to the console window
            this.Monitor.Log($"{Game1.player.Name} pressed {e.Button}.", LogLevel.Debug);
        }
    }
}