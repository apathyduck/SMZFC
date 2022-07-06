//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;

//namespace SMZ3FC
//{
//    static class LocationKeys
//    {


//        //ALTTP LW
//        public static string kLWNW { get; } = "Light World North West";
//        public static string kLWNE { get; } = "Light World North East";
//        public static string kLWS { get; } = "Light World South";
       

//        //ALTTP DM
//        public static string kDMWest { get; } = "Light World Death Mountain West";
//        public static string kDMEast { get; } = "Light World Death Mountain East";

//        //ALTTP DW 
//        public static string kDWNW { get; } = "Dark World North West";
//        public static string kDWNE { get; } = "Dark World North East";
//        public static string kDWS { get; } = "Dark World South";
//        public static string kDWM { get; } = "Dark World Mire";

//        //ALTTP DDM
//        public static string kDDMW { get; } = "Dark World Death Mountain West";
//        public static string kDDME { get; } = "Dark World Death Mountain East";

//        //ALTTP Dungeons
//        public static string kEscape { get; } = "Hyrule Castle";
//        public static string kEastern { get; } = "Eastern Palace";
//        public static string kDP { get; } = "Desert Palace";
//        public static string kHera { get; } = "Tower of Hera";
//        public static string kPoD { get; } = "Palace of Darkness";
//        public static string kSP { get; } = "Swamp Palace";
//        public static string kSW { get; } = "Skull Woods";
//        public static string kTT { get; } = "Thieves' Town";
//        public static string kIP { get; } = "Ice Palace";
//        public static string kMM { get; }  = "Misery Mire";
//        public static string kTR { get; }  = "Turtle Rock";
//        public static string kGT { get; } = "Ganon's Tower";


//        //SM Crat
//        public static string kCratW { get; } = "Crateria West";
//        public static string kCratCent { get; } = "Crateria Central";
//        public static string kBlueBrinn { get; } = "Brinstar Blue";
        

//        //SM Brinn
//        public static string kGreenBrinn { get; } = "Brinstar Green";
//        public static string kPinkBrinn { get; } = "Brinstar Pink";
//        public static string kRedTower { get; } = "Brinstar Red";
//        public static string kKraid { get; } = "Brinstar Kraid"; //Moat is in Crat East


//        //SM WS
//        public static string kCratEast { get; } = "Crateria East";
//        public static string kWS { get; } = "Wrecked Ship";

//        //SM Maridia
//        public static string kMaridiaOuter { get; } = "Maridia Outer";
//        public static string kMaridiaInner { get; } = "Maridia Inner";

//        //SM Norfair
//        public static string kUNW { get; } = "Norfair Upper West";
//        public static string kUNE { get; } = "Norfair Upper East";
//        public static string kCroc { get; } = "Norfair Upper Crocomire";

//        //SM LN
//        public static string kLNW { get; } = "Norfair Lower West";
//        public static string kLNE { get; } = "Norfair Lower East";



//        //Shift Locations
//        public static string kMoat { get; } = "Missile (Crateria moat)";

//        public static List<string> LocationNames;
//        //public static List<string> LightWorld;
//        //public static List<string> DarkWorld;
//        //public static List<string> DeathMountain;
//        //public static List<string> DarkDeathMountain;
//        //public static List<string> Crateria;
//        //public static List<string> Brinnstar;
//        //public static List<string> WreckedShip;
//        //public static List<string> Maridia;
//        //public static List<string> UpperNorfair;
//        //public static List<string> LowerNorfair;
//        //public static List<string> ShiftLocations;





//        public static void Initialize()
//        {
//            Type locs = typeof(LocationKeys);
//            LocationNames = new List<string>();

//            foreach (PropertyInfo pi in locs.GetProperties())
//            {

//                if (pi.PropertyType.Equals(typeof(string)))
//                {
//                    LocationNames.Add(pi.GetValue(null).ToString());
//                }
//            }

//            //LightWorld = new List<string>();
//            //LightWorld.Add(kLWNE);
//            //LightWorld.Add(kLWNW);
//            //LightWorld.Add(kLWS);

//            //DarkWorld = new List<string>();
//            //DarkWorld.Add(kDWM);
//            //DarkWorld.Add(kDWNE);
//            //DarkWorld.Add(kDWNW);
//            //DarkWorld.Add(kDWS);

//            //DeathMountain = new List<string>();
//            //DeathMountain.Add(kDMEast);
//            //DeathMountain.Add(kDMWest);

//            //DarkDeathMountain = new List<string>();
//            //DarkDeathMountain.Add(kDDME);
//            //DarkDeathMountain.Add(kDDMW);

//            //Crateria = new List<string>();
//            //Crateria.Add(kCratCent);
//            //Crateria.Add(kCratW);
//            //Crateria.Add(kBlueBrinn);

//            //Brinnstar = new List<string>();
//            //Brinnstar.Add(kGreenBrinn);
//            //Brinnstar.Add(kPinkBrinn);
//            //Brinnstar.Add(kRedTower);
//            //Brinnstar.Add(kKraid);

//            //WreckedShip = new List<string>();
//            //WreckedShip.Add(kCratEast);
//            //WreckedShip.Add(kWS);

//            //Maridia = new List<string>();
//            //Maridia.Add(kMaridiaInner);
//            //Maridia.Add(kMaridiaOuter);

//            //UpperNorfair = new List<string>();
//            //UpperNorfair.Add(kUNE);
//            //UpperNorfair.Add(kUNW);
//            //UpperNorfair.Add(kCroc);

//            //LowerNorfair = new List<string>();
//            //LowerNorfair.Add(kLNE);
//            //LowerNorfair.Add(kLNW);

//            //ShiftLocations = new List<string>();
//            //ShiftLocations.Add(kMoat);
//        }

//    }
//}
