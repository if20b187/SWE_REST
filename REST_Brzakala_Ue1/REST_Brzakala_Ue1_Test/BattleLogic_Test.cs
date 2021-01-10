using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using REST_BRZAKALA_core;

namespace REST_Brzakala_Ue1_Test
{
    public class BattleLogic_Test
    {


        [Test]
        public void GoblinDragon()
        {
            Battle battle = new Battle();

            string winner = battle.SetWinner("David", "Michael", "Goblin", "spell", "water", 37, "Dragon", "monster", "fire", 42);

            Assert.AreEqual("Michael", winner);

        }
        [Test]
        public void DragonGoblin()
        {
            Battle battle = new Battle();

            string winner = battle.SetWinner("David", "Michael", "Dragon", "monster", "fire", 42, "Goblin", "spell", "water", 37);

            Assert.AreEqual("David", winner);

        }
        [Test]
        public void WizzardOrk()
        {
            Battle battle = new Battle();

            string winner = battle.SetWinner("David", "Michael", "Wizzard", "spell", "normal", 9, "Ork", "monster", "water", 39);

            Assert.AreEqual("David", winner);

        }
        [Test]
        public void OrkWizzard()
        {
            Battle battle = new Battle();

            string winner = battle.SetWinner("David", "Michael", "Ork", "monster", "water", 9, "Wizzard", "spell", "normal", 9);

            Assert.AreEqual("Michael", winner);

        }
        [Test]
        public void KnightWizzard()
        {
            Battle battle = new Battle();

            string winner = battle.SetWinner("David", "Michael", "Knight", "monster", "normal", 11, "Wizzard", "spell", "normal", 9);

            Assert.AreEqual("Michael", winner);

        }
        [Test]
        public void WizzardKnight()
        {
            Battle battle = new Battle();

            string winner = battle.SetWinner("David", "Michael", "Wizzard", "spell", "normal", 9, "Knight", "monster", "normal", 11);

            Assert.AreEqual("Michael", winner);

        }
        [Test]
        public void KnightSpellWater()
        {
            Battle battle = new Battle();

            string winner = battle.SetWinner("David", "Michael", "Knight", "monster", "normal", 11, "Goblin", "spell", "water", 9);

            Assert.AreEqual("Michael", winner);

        }
        [Test]
        public void SpellWaterKnight()
        {
            Battle battle = new Battle();

            string winner = battle.SetWinner("David", "Michael", "Goblin", "spell", "water", 9, "Knight", "monster", "normal", 11);

            Assert.AreEqual("David", winner);

        }
        [Test]
        public void KrakenKraken()
        {
            Battle battle = new Battle();

            string winner = battle.SetWinner("David", "Michael", "Kraken", "monster", "water", 43, "Kraken", "monster", "water", 43);

            Assert.AreEqual("draw", winner);

        }
        [Test]
        public void KrakenSpell()
        {
            Battle battle = new Battle();

            string winner = battle.SetWinner("David", "Michael", "Kraken", "monster", "water", 43, "Goblin", "spell", "water", 37);

            Assert.AreEqual("David", winner);

        }
        [Test]
        public void SpellKraken()
        {
            Battle battle = new Battle();

            string winner = battle.SetWinner("Michael", "David", "Kraken", "monster", "water", 43, "Goblin", "spell", "water", 37);

            Assert.AreEqual("Michael", winner);

        }
        [Test]
        public void FireElvesDragon()
        {
            Battle battle = new Battle();

            string winner = battle.SetWinner("David", "Michael", "Elves", "monster", "fire", 29, "Dragon", "monster", "fire", 42);

            Assert.AreEqual("David", winner);

        }
        [Test]
        public void DragonFireElves()
        {
            Battle battle = new Battle();

            string winner = battle.SetWinner("Michael", "David", "Elves", "monster", "fire", 29, "Dragon", "monster", "fire", 42);

            Assert.AreEqual("Michael", winner);

        }
        [Test]
        public void SpellWaterSpellFire()
        {
            Battle battle = new Battle();

            string winner = battle.SetWinner("David", "Michael", "Goblin", "spell", "water", 37, "Spell", "spell", "fire", 44);

            Assert.AreEqual("David", winner);

        }
        [Test]
        public void SpellFireSpellWater()
        {
            Battle battle = new Battle();

            string winner = battle.SetWinner("Michael", "David", "Goblin", "spell", "water", 37, "Spell", "spell", "fire", 44);

            Assert.AreEqual("Michael", winner);

        }
        [Test]
        public void SpellWaterSpellWater()
        {
            Battle battle = new Battle();

            string winner = battle.SetWinner("Michael", "David", "Goblin", "spell", "water", 37, "Troll", "spell", "water", 18);

            Assert.AreEqual("Michael", winner);

        }
        [Test]
        public void SpellWaterSpellWater2()
        {
            Battle battle = new Battle();

            string winner = battle.SetWinner("David", "Michael", "Goblin", "spell", "water", 37, "Troll", "spell", "water", 18);

            Assert.AreEqual("David", winner);

        }
        [Test]
        public void MonsterWaterSpellWater()
        {
            Battle battle = new Battle();

            string winner = battle.SetWinner("David", "Michael", "Kraken", "monster", "water", 43, "Troll", "spell", "water", 18);

            Assert.AreEqual("David", winner);

        }
        [Test]
        public void SpellWaterMonsterWater()
        {
            Battle battle = new Battle();

            string winner = battle.SetWinner("Michael", "David", "Kraken", "monster", "water", 43, "Troll", "spell", "water", 18);

            Assert.AreEqual("Michael", winner);

        }
        [Test]
        public void MonsterFireSpellFire()
        {
            Battle battle = new Battle();

            string winner = battle.SetWinner("Michael", "David", "Dragon", "monster", "fire", 42, "Troll", "spell", "fire", 38);

            Assert.AreEqual("Michael", winner);

        }
        [Test]
        public void SpellFireMonsterFire()
        {
            Battle battle = new Battle();

            string winner = battle.SetWinner("David", "Michael", "Dragon", "monster", "fire", 42, "Troll", "spell", "fire", 38);

            Assert.AreEqual("David", winner);

        }



    }
}
