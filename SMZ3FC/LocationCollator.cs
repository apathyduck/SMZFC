//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SMZ3FC
//{
//    public static class LocationCollator
//    {
//        public static string kCratName  = "Crateria";
//        public static string kBrinnName  = "Brinnstar";
//        public static string kWSName  = "Wrecked Ship";
//        public static string kMaridiaName = "Maridia";
//        public static string kUNName = "Upper Norfair";
//        public static string kLNName = "Lower Norfair";
//        public static string kLWName = "Light World";
//        public static string kDMName = "Death Mountain";
//        public static string kDWName = "Dark World";
//        public static string kDDMName = "Dark Death Mountain";
//        public static string kEscapeName = "Escape";
//        public static string kEPName = "Eastern Palace";
//        public static string kDPName = "Desert Palace";
//        public static string kHeraName = "Tower of Hera";
//        public static string kPodName = "Palace of Darkness";
//        public static string kSPName = "Swamp Palace";
//        public static string kSWName = "Skull Woods";
//        public static string kTTName = "Thieves Town";
//        public static string kIPName = "Ice Palace";
//        public static string kMMName = "Misery Mire";
//        public static string kTRName = "Turtle Rock";
//        public static string kGTName = "Ganons Tower";

//        public static  List<CollatedLocationData> FinalLocData { get; private set; }

//        static LocationCollator()
//        {
     
//        }

//        public static void ParseFile(string fileloc)
//        {
//            //LogParser.Parse(fileloc);
//            CollateLocations(LogParser.SubLocations, LogParser.ShiftLocationsWithItems);

//        }

//        private static void Initialize()
//        {
//            FinalLocData = new List<CollatedLocationData>();

//            //FinalLocData.Add(new CollatedLocationData(kCratName, Locations.Crateria, new List<string> { Locations.kMoat }, new List<string>()));
//            //FinalLocData.Add(new CollatedLocationData(kBrinnName, Locations.Brinnstar));
//            //FinalLocData.Add(new CollatedLocationData(kWSName, Locations.WreckedShip, new List<string>(), new List<string> { Locations.kMoat }));
//            //FinalLocData.Add(new CollatedLocationData(kMaridiaName, Locations.Maridia));
//            //FinalLocData.Add(new CollatedLocationData(kUNName, Locations.UpperNorfair));
//            //FinalLocData.Add(new CollatedLocationData(kLNName, Locations.LowerNorfair));
//            //FinalLocData.Add(new CollatedLocationData(kLWName, Locations.LightWorld));
//            //FinalLocData.Add(new CollatedLocationData(kDMName, Locations.DeathMountain));
//            //FinalLocData.Add(new CollatedLocationData(kDWName, Locations.DarkWorld));
//            //FinalLocData.Add(new CollatedLocationData(kDDMName, Locations.DarkDeathMountain));
//            //FinalLocData.Add(new CollatedLocationData(kEscapeName, new List<string> { Locations.kEscape }));
//            //FinalLocData.Add(new CollatedLocationData(kEPName, new List<string> { Locations.kEastern }));
//            //FinalLocData.Add(new CollatedLocationData(kDPName, new List<string> { Locations.kDP }));
//            //FinalLocData.Add(new CollatedLocationData(kHeraName, new List<string> { Locations.kHera }));
//            //FinalLocData.Add(new CollatedLocationData(kPodName, new List<string> { Locations.kPoD }));
//            //FinalLocData.Add(new CollatedLocationData(kSPName, new List<string> { Locations.kSP }));
//            //FinalLocData.Add(new CollatedLocationData(kSWName, new List<string> { Locations.kSW }));
//            //FinalLocData.Add(new CollatedLocationData(kTTName, new List<string> { Locations.kTT }));
//            //FinalLocData.Add(new CollatedLocationData(kIPName, new List<string> { Locations.kIP }));
//            //FinalLocData.Add(new CollatedLocationData(kMMName, new List<string> { Locations.kMM }));
//            //FinalLocData.Add(new CollatedLocationData(kTRName, new List<string> { Locations.kTR }));
//            //FinalLocData.Add(new CollatedLocationData(kGTName, new List<string> { Locations.kGT }));

            


//        }

//        static void CollateLocations(List<SubLocationData> sds, List<string> shiftitems)
//        {

//            Initialize();


//            foreach (CollatedLocationData cd in FinalLocData)
//            {
//                foreach (string sl in cd.SubLocations)
//                {
//                    foreach (SubLocationData sd in sds)
//                    {
//                        if (sl.Equals(sd.LocationName))
//                        {
//                            cd.AddSubLocationData(sd);
//                        }
//                    }
//                }

//                foreach (string shift in LogParser.ShiftLocationsWithItems)
//                {
//                    foreach (string ii in cd.ShiftLocsIn)
//                    {
//                        if (ii.Equals(shift))
//                        {
//                            cd.AddTotalItem();
//                        }
//                    }

//                    //foreach (string io in cd.ShiftLocsOut)
//                    //{
//                    //    if (io.Equals(shift))
//                    //    {
//                    //        cd.RemoveTotalItem();
//                    //    }
//                    //}
//                }
//            }
              
//        }


//    }
//}
