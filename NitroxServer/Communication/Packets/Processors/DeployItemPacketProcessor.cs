using NitroxModel.DataStructures;
using NitroxModel.DataStructures.GameLogic;
using NitroxModel.Helper;
using NitroxModel.Packets;
using NitroxServer.Communication.Packets.Processors.Abstract;
using NitroxServer.GameLogic;
using NitroxServer.GameLogic.Entities;

namespace NitroxServer.Communication.Packets.Processors
{
    class DeployItemPacketProcessor : AuthenticatedPacketProcessor<DeployItem>
    {
        private readonly EntityManager entityManager;
        private readonly PlayerManager playerManager;
        private readonly EntitySimulation entitySimulation;

        public DeployItemPacketProcessor(EntityManager entityManager, PlayerManager playerManager, EntitySimulation entitySimulation)
        {
            this.entityManager = entityManager;
            this.playerManager = playerManager;
            this.entitySimulation = entitySimulation;
        }

        public override void Process(DeployItem packet, Player droppingPlayer)
        {
            // Save the deployed state to the games save data?
            entityManager.UpdateEntityGameObject(packet.Id, packet.Bytes);

            foreach (Player player in playerManager.GetPlayers())
            {
                bool isOtherPlayer = (player != droppingPlayer);

                if(isOtherPlayer)
                {
                    player.SendPacket(packet);
                }
            }
        }
    }
}
