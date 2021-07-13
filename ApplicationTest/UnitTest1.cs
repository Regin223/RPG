using System;
using Xunit;
using RPGCharacters.Models;

namespace ApplicationTest
{
    public class UnitTest1
    {
        [Fact]
        public void CheckLevel_LevelWhenCreated_ShouldReturn1()
        {
            //Arrange
            int expectedLevel = 1;
            //Act
            Mage mage = new Mage("Mage1");
            int actualLevel = mage.Level; ;
            //Assert
            Assert.Equal(expectedLevel, actualLevel);
        }

        [Fact]
        public void CheckLevel_LevelWhenGainsALevel_ShouldReturn2()
        {
            //Arrange
            int expectedLevel = 2;
            //Act
            Mage mage = new Mage("Mage1");
            mage.LevelUp(1);
            int actualLevel = mage.Level; 
            //Assert
            Assert.Equal(expectedLevel, actualLevel);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void CheckLevel_LevelInvalidNumber_ShouldThrowArgumentException(int inlineData)
        {
            Mage mage = new Mage("Mage1");
            Assert.Throws<ArgumentException>(() => mage.LevelUp(inlineData));
        }

        [Fact]
        public void CheckDefaultAttributes_CorrectAttributesMage_CorrectValues()
        {
            double expectedVitality = 5;
            double expectedStrength = 1;
            double expectedDexterity = 1;
            double expectedIntelligence = 8;
            

            Mage mage = new Mage("Mage1");
            double actualVitality = mage.BasePrimaryAttributes.Vitality;
            double actualStrength = mage.BasePrimaryAttributes.Strength;
            double actualDexterity = mage.BasePrimaryAttributes.Dexterity;
            double actualIntelligence = mage.BasePrimaryAttributes.Intelligence;

            Assert.Equal(expectedVitality, actualVitality);
            Assert.Equal(expectedStrength, actualStrength);
            Assert.Equal(expectedDexterity, actualDexterity);
            Assert.Equal(expectedIntelligence, actualIntelligence);

        }

        [Fact]
        public void CheckDefaultAttributes_CorrectAttributesRanger_CorrectValues()
        {
            double expectedVitality = 8;
            double expectedStrength = 1;
            double expectedDexterity = 7;
            double expectedIntelligence = 1;


            Ranger Ranger = new Ranger("Ranger");
            double actualVitality = Ranger.BasePrimaryAttributes.Vitality;
            double actualStrength = Ranger.BasePrimaryAttributes.Strength;
            double actualDexterity = Ranger.BasePrimaryAttributes.Dexterity;
            double actualIntelligence = Ranger.BasePrimaryAttributes.Intelligence;

            Assert.Equal(expectedVitality, actualVitality);
            Assert.Equal(expectedStrength, actualStrength);
            Assert.Equal(expectedDexterity, actualDexterity);
            Assert.Equal(expectedIntelligence, actualIntelligence);

        }

        [Fact]
        public void CheckDefaultAttributes_CorrectAttributesRouge_CorrectValues()
        {
            double expectedVitality = 8;
            double expectedStrength = 2;
            double expectedDexterity = 6;
            double expectedIntelligence = 1;


            Rogue rogue = new Rogue("Rouge");
            double actualVitality = rogue.BasePrimaryAttributes.Vitality;
            double actualStrength = rogue.BasePrimaryAttributes.Strength;
            double actualDexterity = rogue.BasePrimaryAttributes.Dexterity;
            double actualIntelligence = rogue.BasePrimaryAttributes.Intelligence;

            Assert.Equal(expectedVitality, actualVitality);
            Assert.Equal(expectedStrength, actualStrength);
            Assert.Equal(expectedDexterity, actualDexterity);
            Assert.Equal(expectedIntelligence, actualIntelligence);

        }

        [Fact]
        public void CheckDefaultAttributes_CorrectAttributesWarror_CorrectValues()
        {
            double expectedVitality = 10;
            double expectedStrength = 5;
            double expectedDexterity = 2;
            double expectedIntelligence = 1;


            Warrior warrior = new Warrior("Warrior");
            double actualVitality = warrior.BasePrimaryAttributes.Vitality;
            double actualStrength = warrior.BasePrimaryAttributes.Strength;
            double actualDexterity = warrior.BasePrimaryAttributes.Dexterity;
            double actualIntelligence = warrior.BasePrimaryAttributes.Intelligence;

            Assert.Equal(expectedVitality, actualVitality);
            Assert.Equal(expectedStrength, actualStrength);
            Assert.Equal(expectedDexterity, actualDexterity);
            Assert.Equal(expectedIntelligence, actualIntelligence);

        }

        [Fact]
        public void ChecklevelUpAttributes_CorrectAttributesMage_CorrectValues()
        {
            double expectedVitality = 8;
            double expectedStrength = 2;
            double expectedDexterity = 2;
            double expectedIntelligence = 13;


            Mage mage = new Mage("Mage1");
            mage.LevelUp(1);
            double actualVitality = mage.BasePrimaryAttributes.Vitality;
            double actualStrength = mage.BasePrimaryAttributes.Strength;
            double actualDexterity = mage.BasePrimaryAttributes.Dexterity;
            double actualIntelligence = mage.BasePrimaryAttributes.Intelligence;

            Assert.Equal(expectedVitality, actualVitality);
            Assert.Equal(expectedStrength, actualStrength);
            Assert.Equal(expectedDexterity, actualDexterity);
            Assert.Equal(expectedIntelligence, actualIntelligence);

        }

        [Fact]
        public void ChecklevelUpAttributes_CorrectAttributesRanger_CorrectValues()
        {
            double expectedVitality = 10;
            double expectedStrength = 2;
            double expectedDexterity = 12;
            double expectedIntelligence = 2;


            Ranger ranger = new Ranger("Ranger");
            ranger.LevelUp(1);
            double actualVitality = ranger.BasePrimaryAttributes.Vitality;
            double actualStrength = ranger.BasePrimaryAttributes.Strength;
            double actualDexterity = ranger.BasePrimaryAttributes.Dexterity;
            double actualIntelligence = ranger.BasePrimaryAttributes.Intelligence;

            Assert.Equal(expectedVitality, actualVitality);
            Assert.Equal(expectedStrength, actualStrength);
            Assert.Equal(expectedDexterity, actualDexterity);
            Assert.Equal(expectedIntelligence, actualIntelligence);

        }

        [Fact]
        public void ChecklevelUpAttributes_CorrectAttributesRogue_CorrectValues()
        {
            double expectedVitality = 11;
            double expectedStrength = 3;
            double expectedDexterity = 10;
            double expectedIntelligence = 2;


            Rogue rogue = new Rogue("Rogue");
            rogue.LevelUp(1);
            double actualVitality = rogue.BasePrimaryAttributes.Vitality;
            double actualStrength = rogue.BasePrimaryAttributes.Strength;
            double actualDexterity = rogue.BasePrimaryAttributes.Dexterity;
            double actualIntelligence = rogue.BasePrimaryAttributes.Intelligence;

            Assert.Equal(expectedVitality, actualVitality);
            Assert.Equal(expectedStrength, actualStrength);
            Assert.Equal(expectedDexterity, actualDexterity);
            Assert.Equal(expectedIntelligence, actualIntelligence);

        }

        [Fact]
        public void ChecklevelUpAttributes_CorrectAttributesWarrior_CorrectValues()
        {
            double expectedVitality = 15;
            double expectedStrength = 8;
            double expectedDexterity = 4;
            double expectedIntelligence = 2;


            Warrior warrior = new Warrior("Warrior");
            warrior.LevelUp(1);
            double actualVitality = warrior.BasePrimaryAttributes.Vitality;
            double actualStrength = warrior.BasePrimaryAttributes.Strength;
            double actualDexterity = warrior.BasePrimaryAttributes.Dexterity;
            double actualIntelligence = warrior.BasePrimaryAttributes.Intelligence;

            Assert.Equal(expectedVitality, actualVitality);
            Assert.Equal(expectedStrength, actualStrength);
            Assert.Equal(expectedDexterity, actualDexterity);
            Assert.Equal(expectedIntelligence, actualIntelligence);

        }

        [Fact]
        public void CheckSecondaryAttributes_CorrectAttributesWarrior_CorrectValues()
        {
            double expectedHealth = 150;
            double expectedArmorRating = 12;
            double expectedElementalResistance = 2;

            Warrior warrior = new Warrior("Warrior");
            warrior.LevelUp(1);
            double actualHealth = warrior.SecondarAttributes.Health;
            double actualArmorRating = warrior.SecondarAttributes.ArmorRating;
            double actualElementalResistance = warrior.SecondarAttributes.ElementalResistance;

            Assert.Equal(expectedHealth, actualHealth);
            Assert.Equal(expectedArmorRating, actualArmorRating);
            Assert.Equal(expectedElementalResistance, actualElementalResistance);
        }

    }
}
