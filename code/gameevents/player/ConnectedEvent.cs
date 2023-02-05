using Sandbox;

namespace TTTReborn.Events.Player
{
    [GameEvent("player_connected"), HideInEditor]
    public partial class ConnectedEvent : ClientGameEvent
    {
        /// <summary>
        /// Occurs when a player connects.
        /// <para>The <strong><see cref="IClient"/></strong> instance of the player who connected.</para>
        /// </summary>
        public ConnectedEvent(IClient client) : base(client) { }
    }
}
