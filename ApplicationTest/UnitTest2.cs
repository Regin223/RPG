using System;
using Xunit;
using RPGCharacters.Models;
using RPGCharacters.Exceptions;
namespace ApplicationTest
{
    public class UnitTest2
    {
        [Fact]
        public void EquipWeapon_ToHighLevel_ShouldThrowInvalidWeaponException()
        {
            Warrior warrior = new Warrior("warrior");
            Weapon testAxe = new Weapon()
            {
                Name = "Common axe",
                RequiredLevel = 2,
                Slot = Slot.Weapon,
                Type = WeaponType.Axe,
                WeaponAttributes = new WeaponAttributes() { Damage = 7, AttackSpeed = 1.1 }
            };
            Assert.Throws<InvalidWeaponException>(() => warrior.Equip(testAxe));
        }

        [Fact]
        public void EquipArmor_ToHighLevel_ShouldThrowInvalidWeaponException()
        {
            Warrior warrior = new Warrior("warrior");
            
            Armor testPlateBody = new Armor()
           {
               Name = "Common plate body armor",
               RequiredLevel = 2,
               Slot = Slot.Body,
               Type = ArmorType.Plate,
               Armourattributes = new PrimaryAttributes() { Vitality = 2, Strength = 1 }
           };
            Assert.Throws<InvalidArmorException>(() => warrior.Equip(testPlateBody));
        }

        [Fact]
        public void EquipWeapon_WrongWeaponType_ShouldThrowInvalidWeaponException()
        {
            Warrior warrior = new Warrior("warrior");

            Weapon testBow = new Weapon()
            {
                Name = "Common Bow",
                RequiredLevel = 1,
                Slot = Slot.Weapon,
                Type = WeaponType.Bow,
                WeaponAttributes = new WeaponAttributes() { Damage = 12, AttackSpeed = 0.8 }
            };
            Assert.Throws<InvalidWeaponException>(() => warrior.Equip(testBow));
        }

        [Fact]
        public void EquipArmor_WrongArmorType_ShouldThrowInvalidArmorException()
        {
            Warrior warrior = new Warrior("warrior");

            Armor testClothHead = new Armor()
            {
                Name = "Common cloth head armor",
                RequiredLevel = 1,
                Slot = Slot.Head,
                Type = ArmorType.Cloth,
                Armourattributes = new PrimaryAttributes() { Vitality = 1, Strength = 5 }
            };
            Assert.Throws<InvalidArmorException>(() => warrior.Equip(testClothHead));
        }

        [Fact]
        public void EquipWeapon_CorrectWeapon_ShouldReturnValidMessage()
        {
            string expectedMessage = "New weapon equipped!";

            Warrior warrior = new Warrior("Warrior");
            Weapon testAxe = new Weapon()
            {
                Name = "Common axe",
                RequiredLevel = 1,
                Slot = Slot.Weapon,
                Type = WeaponType.Axe,
                WeaponAttributes = new WeaponAttributes() { Damage = 7, AttackSpeed = 1.1 }
            };
            string actualMessage = warrior.Equip(testAxe);

            Assert.Equal(expectedMessage, actualMessage);
        }

        [Fact]
        public void EquipWeapon_CorrectArmor_ShouldReturnValidMessage()
        {
            string expectedMessage = "New armour equipped!";

            Warrior warrior = new Warrior("Warrior");
            Armor testPlateBody = new Armor()
            {
                Name = "Common plate body armor",
                RequiredLevel = 1,
                Slot = Slot.Body,
                Type = ArmorType.Plate,
                Armourattributes = new PrimaryAttributes() { Vitality = 2, Strength = 1 }
            };

            string actualMessage = warrior.Equip(testPlateBody);

            Assert.Equal(expectedMessage, actualMessage);
        }

        [Fact]
        public void CheckDPS_ValidDpsInLevel1_ValidDps()
        {
            double expectedDps = 1 * (1 + (5 / 100));
            Warrior warrior = new Warrior("Warrior");
            double actualDps = warrior.CharacterDPS;

            Assert.Equal(expectedDps, actualDps);
        }

        [Fact]
        public void CheckDPS_ValidDpsWithAxe_CorrectDps()
        {
            double expectedDps = 7 * 1.1 * (1 + (5.0 / 100));
            
            Warrior warrior = new Warrior("Warrior");
            Weapon testAxe = new Weapon()
            {
                Name = "Common axe",
                RequiredLevel = 1,
                Slot = Slot.Weapon,
                Type = WeaponType.Axe,
                WeaponAttributes = new WeaponAttributes() { Damage = 7, AttackSpeed = 1.1 }
            };
            warrior.Equip(testAxe);

            double actualDps = warrior.CharacterDPS;

            Assert.Equal(expectedDps, actualDps);
        }

        [Fact]
        public void CheckDps_ValidDpsWithAxeAndPlate_CorrectDps()
        {
            double expectedDps = (7 * 1.1) * (1 + ((5.0 + 1.0) / 100));

            Warrior warrior = new Warrior("Warrior");
            Weapon testAxe = new Weapon()
            {
                Name = "Common axe",
                RequiredLevel = 1,
                Slot = Slot.Weapon,
                Type = WeaponType.Axe,
                WeaponAttributes = new WeaponAttributes() { Damage = 7, AttackSpeed = 1.1 }
            };
            Armor testPlateBody = new Armor()
            {
                Name = "Common plate body armor",
                RequiredLevel = 1,
                Slot = Slot.Body,
                Type = ArmorType.Plate,
                Armourattributes = new PrimaryAttributes() { Vitality = 2, Strength = 1 }
            };
            warrior.Equip(testAxe);
            warrior.Equip(testPlateBody);

            double actualDps = warrior.CharacterDPS;

            Assert.Equal(expectedDps, actualDps);
        }
    

    }
}
