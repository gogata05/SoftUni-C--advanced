using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Guild
{
    public class Guild
    {
        private readonly List<Player> roster;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => roster.Count;

        public void AddPlayer(Player player)
        {
            if (roster.Count < Capacity)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player player = roster.FirstOrDefault(p => p.Name == name);
            if (player != null)
            {
                roster.Remove(player);
                return true;
            }
            return false;
        }

        public void PromotePlayer(string name)
        {
            Player player = roster.FirstOrDefault(p => p.Name == name);
            if (player != null && player.Rank != "Member")
            {
                player.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player player = roster.FirstOrDefault(p => p.Name == name);
            if (player != null && player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string playerClass)
        {
            Player[] players = roster.Where(p => p.Class == playerClass).ToArray();
            roster.RemoveAll(p => p.Class == playerClass);
            return players;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");
            foreach (var player in roster)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString();
        }
    }
}
