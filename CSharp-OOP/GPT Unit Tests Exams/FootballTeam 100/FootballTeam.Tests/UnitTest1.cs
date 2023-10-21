using NUnit.Framework;
using System;

namespace FootballTeam.Tests
{
    public class Tests
    {
        private FootballTeam team;

        [SetUp]
        public void Setup()
        {
            team = new FootballTeam("TestTeam", 15);
        }

        [Test]
        public void Constructor_Should_Initialize_Correctly()
        {
            Assert.IsNotNull(team);
            Assert.AreEqual("TestTeam", team.Name);
            Assert.AreEqual(15, team.Capacity);
        }

        [Test]
        public void NameProperty_Should_Throw_ArgumentException_If_Null_Or_Empty()
        {
            Assert.Throws<ArgumentException>(() => team.Name = "");
        }

        [Test]
        public void CapacityProperty_Should_Throw_ArgumentException_If_Less_Than_15()
        {
            Assert.Throws<ArgumentException>(() => team.Capacity = 10);
        }

        [Test]
        public void AddNewPlayer_Should_Add_Player_If_Capacity_Allows()
        {
            FootballPlayer player = new FootballPlayer("Player1", 1, "Goalkeeper");
            var result = team.AddNewPlayer(player);

            Assert.IsTrue(team.Players.Contains(player));
            Assert.AreEqual($"Added player {player.Name} in position {player.Position} with number {player.PlayerNumber}", result);
        }

        [Test]
        public void AddNewPlayer_Should_Not_Add_Player_If_Capacity_Is_Full()
        {
            for (int i = 1; i <= 15; i++)
            {
                team.AddNewPlayer(new FootballPlayer($"Player{i}", i, "Goalkeeper"));
            }

            FootballPlayer player = new FootballPlayer("Player16", 16, "Goalkeeper");
            var result = team.AddNewPlayer(player);

            Assert.IsFalse(team.Players.Contains(player));
            Assert.AreEqual("No more positions available!", result);
        }

        [Test]
        public void PickPlayer_Should_Return_Player_With_Given_Name()
        {
            FootballPlayer player = new FootballPlayer("Player1", 1, "Goalkeeper");
            team.AddNewPlayer(player);

            var pickedPlayer = team.PickPlayer("Player1");

            Assert.AreEqual(player, pickedPlayer);
        }

        [Test]
        public void PlayerScore_Should_Increase_Score_And_Return_Correct_String()
        {
            FootballPlayer player = new FootballPlayer("Player1", 1, "Goalkeeper");
            team.AddNewPlayer(player);

            var result = team.PlayerScore(1);

            Assert.AreEqual(1, player.ScoredGoals);
            Assert.AreEqual($"{player.Name} scored and now has {player.ScoredGoals} for this season!", result);
        }
    }
}
