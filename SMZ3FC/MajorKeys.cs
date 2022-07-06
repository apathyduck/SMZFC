//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;

//namespace SMZ3FC
//{
//    Total 55
//    static class MajorKeys
//    {

//        SM Majors - Total 16
//        static public string kMorph { get; } = "Morphing Ball";
//        static public string kMorphBombs { get; } = "Morph Bombs";
//        static public string kSpringBall { get; } = "Spring Ball";
//        static public string kCharge { get; } = "Charge Beam";
//        static public string kIce { get; } = "Ice Beam";
//        static public string kSpazer { get; } = "Spazer";
//        static public string kWave { get; } = "Wave Beam";
//        static public string kPlasma { get; } = "Plasma Beam";
//        static public string kVaria { get; } = "Varia Suit";
//        static public string kGrav { get; } = "Gravity Suit";
//        static public string kHJB { get; } = "Hi-Jump Boots";
//        static public string kSpace { get; } = "Space Jump";
//        static public string kSpeed { get; } = "Speed Booster";
//        static public string kScrew { get; } = "Screw Attack";
//        static public string kGrapple { get; } = "Grappling Beam";
//        static public string kXray { get; } = "X-Ray Scope";



//        ALTTP Items
//        y items - Total 23
//        static public string kBow { get; } = "Bow";
//        static public string kSilvers { get; } = "Silver Arrows";
//        static public string kBlueBoom { get; } = "Blue Boomerang";
//        static public string kRedBoom { get; } = "Red Boomerang";
//        static public string kHookshot { get; } = "Hookshot";
//        static public string kPowder { get; } = "Magic Powder";
//        static public string kMushroom { get; } = "Mushroom";
//        static public string kFireRod { get; } = "Fire Rod";
//        static public string kIceRod { get; } = "Ice Rod";
//        static public string kBombos { get; } = "Bombos";
//        static public string kEther { get; } = "Ether";
//        static public string kQuake { get; } = "Quake";
//        static public string kLamp { get; } = "Lamp";
//        static public string kHammer { get; } = "Hammer";
//        static public string kFlute { get; } = "Flute";
//        static public string kShovel { get; } = "Shovel";
//        static public string kBugNet { get; } = "Bug Catching Net";
//        static public string kBook { get; } = "Book of Mudora";
//        static public string kBottle { get; } = "Bottle";
//        static public string kSomaria { get; } = "Cane of Somaria";
//        static public string kByrna { get; } = "Cane of Byrna";
//        static public string kCape { get; } = "Magic Cape";
//        static public string kMirror { get; } = "Magic Mirror";

//        a items - 5
//        static public string kBoots { get; } = "Pegasus Boots";
//        static public string kGlove { get; } = "Progressive Glove";
//        static public string kFlippers { get; } = "Zora's Flippers";
//        static public string kPearl { get; } = "Moon Pearl";

//        other - 11
//        static public string kHalfMagic { get; } = "Half Magic";
//        static public string kSword { get; } = "Progressive Sword";
//        static public string kShield { get; } = "Progressive Shield";
//        static public string kMail { get; } = "Progressive Mail";

//        static public List<string> Items;

//        static MajorKeys()
//        {


//        }

//        public static void Initialize()
//        {
//            Type keys = typeof(MajorKeys);
//            Items = new List<string>();
//            foreach (PropertyInfo pi in keys.GetProperties())
//            {
//                if (pi.PropertyType.Equals(typeof(string)))
//                {
//                    Items.Add(pi.GetValue(null).ToString());
//                }
//            }
//        }

//    }
//}
