﻿using LeaguePackets.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LeaguePackets.CommonData;

namespace LeaguePackets.GamePackets
{
    public class NPC_Die : GamePacket // 0x9E
    {
        public override GamePacketID ID => GamePacketID.NPC_Die;
        public DeathDataPacket DeathData { get; set; } = new DeathDataPacket();
        public static NPC_Die CreateBody(PacketReader reader, ChannelID channelID, NetID senderNetID)
        {
            var result = new NPC_Die();
            result.SenderNetID = senderNetID;
            result.ChannelID = channelID;

            result.DeathData = reader.ReadDeathDataPacket();
        
            return result;
        }
        public override void WriteBody(PacketWriter writer)
        {
            writer.WriteDeathDataPacket(DeathData);
        }
    }
}