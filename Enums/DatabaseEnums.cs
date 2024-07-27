using Utilities.Attributes;

namespace FalconDatabase.Enums
{

    /// <summary>
    /// A Generic Enum that encompasses the Types of objects available in a given class.
    /// The final entry in each collection indicates the end of that group and be used for
    /// iterating collections based on the value: for (int i = 1; i LT (int)AIR_UNITS; i++)...
    /// </summary>
    public enum ClasstableType
    {
        /// <summary>
        /// The object does not have a Type assigned.
        /// </summary>
        [StringValue("Nothing")]
        NOTHING = 1,

        /// <summary>
        /// An Air Tasking Manager.
        /// </summary>
        [StringValue("Air Tasking Manager")]
        ATM = 1,

        /// <summary>
        /// A Ground Tasking Manager used by the Campaign Engine to manage ground units.
        /// </summary>
        [StringValue("Ground Tasking Manager")]
        GTM = 1,

        /// <summary>
        /// Naval Tasking Manager used by the Campaign Engine to manage Naval Assets.
        /// </summary>
        [StringValue("Naval Tasking Manager")]
        NTM = 1,

        /// <summary>
        /// A logical collection of assets and political groups collectively attempting to accomplish a single shared goal.
        /// </summary>
        [StringValue("Team")]
        TEAM = 1,

        /// <summary>
        /// Collection of highly reflective metal shards designed to confuse Radar Signals.
        /// </summary>
        [StringValue("Chaff")]
        CHAFF = 5,
        /// <summary>
        /// A bright, hot countermeasure deployed from aircraft designed to confuse Ifrared Sensors.
        /// </summary>
        [StringValue("Flare")]
        FLARE = 6,
        /// <summary>
        /// A rapid movement expelling an individual from an aircraft or vehicle in an emergency.
        /// </summary>
        [StringValue("Eject")]
        EJECT = 9,

        // abstract/abstract
        /// <summary>
        /// A method of controlling the Simulated Aircraft in BMS.
        /// </summary>
        [StringValue("Flying Eye")]
        FLYING_EYE = 1,

        // these are all unknown and unreferenced
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        ARMADA = 1,
        END_MISSION = 1,
        TEST = 15,
        COCKPIT = 3,
        DEBRIS = 1,
        AEXPLOSION = 1,
        CANOPY = 7,
        EXPLOSION = 1,
        FIRE = 2,
        DUST = 3,
        SMOKE = 4,
        CLOUD = 1,
        HULK = 2,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    };

    /// <summary>
    /// The different Environments where a Unit, Vehicle, or object exists and operates.
    /// </summary>
    public enum ClasstableDomain
    {
        /// <summary>
        /// The Domain is unknown for this object.
        /// </summary>
        [StringValue("Unknown")]
        Unknown = 0,
        /// <summary>
        /// The object is abstract and does not interact with the 3D world.
        /// </summary>
        [StringValue("Abstract")]
        Abstract = 1,
        /// <summary>
        /// The object is designed to operate in the air.
        /// </summary>
        [StringValue("Air")]
        Air = 2,
        /// <summary>
        /// The object is designed to operate on the ground.
        /// </summary>
        [StringValue("Land")]
        Land = 3,
        /// <summary>
        /// The object is designed to operate in the water.
        /// </summary>
        [StringValue("Sea")]
        Sea = 4,
        /// <summary>
        /// The object is designed to operate in space.
        /// </summary>
        [StringValue("Space")]
        Space = 5,
        /// <summary>
        /// The object is designed to operate under the ground.
        /// </summary>
        [StringValue("Underground")]
        Underground = 6,
        /// <summary>
        /// The object is designed to operate under the water.
        /// </summary>
        [StringValue("Undersea")]
        Undersea = 7,
    };

    /// <summary>
    /// Available Classes of objects in the Database Class Table.
    /// </summary>
    public enum ClasstableClass
    {
        /// <summary>
        /// Unknown Object that cannot be interacted with.
        /// </summary>
        [StringValue("Unknown")]
        Unknown = 0,
        /// <summary>
        /// An animal or other scenery object that cannot be interacted with.
        /// </summary>
        [StringValue("Animal")]
        Animal = 1,
        /// <summary>
        /// A Building, Runway, or other static componen of the 3D World which can be interacted with.
        /// Objectives, such as an Air Base, are made up of a collection of Features.
        /// </summary>
        [StringValue("Feature")]
        Feature = 2,
        /// <summary>
        /// One of the Component Managers for the Campaign Engine. This could be the Air Tasking Manager,
        /// Ground Tasking Manager, or Naval Tasking Manager. Each Team has their own set of managers.
        /// </summary>
        [StringValue("Manager")]
        Manager = 3,
        /// <summary>
        /// A Collection of Features which make up a location, installation, or other area of
        /// interest on the map that can be interacted with.
        /// </summary>
        [StringValue("Objective")]
        Objective = 4,
        /// <summary>
        /// A Sound Effect for a particular action or event in the Game.
        /// </summary>
        [StringValue("Sound Effect")]
        SoundEffect = 5,
        /// <summary>
        /// A Generic Class representing all movable objects in the 2D world.
        /// </summary>
        [StringValue("Unit")]
        Unit = 6,
        /// <summary>
        /// An moveable object in the 3D world capable of interacting with other objects.
        /// </summary>
        [StringValue("Vehicle")]
        Vehicle = 7,
        /// <summary>
        /// An object that can be attached to,fired from, or carried on a Unit to cause damage to another object.
        /// </summary>
        [StringValue("Weapon")]
        Weapon = 8,
        /// <summary>
        /// A Class encompassing the 3D Weather Components and their underlying configurations and behavior.
        /// </summary>
        [StringValue("Weather")]
        Weather = 9,
        /// <summary>
        /// A single iteration of the game being active without being closed.
        /// </summary>
        [StringValue("Session")]
        Session = 10,
        /// <summary>
        /// An instance of the Game.
        /// </summary>
        [StringValue("Game")]
        Game = 11,
        /// <summary>
        /// A Collection of Database Objects.
        /// </summary>
        [StringValue("Group")]
        Group = 12,
        /// <summary>
        /// A UI Element that can be interacted with.
        /// </summary>
        [StringValue("Dialog")]
        Dialog = 13,
        /// <summary>
        /// Abstract object that can be interacted with.
        /// </summary>
        [StringValue("Abstract")]
        Abstract = 13,
    };

    /// <summary>
    /// Types of Air Vehicles Available
    /// </summary>
    public enum AirVehicleType
    {
        /// <summary>
        /// The Object is an Aircraft.
        /// </summary>
        [StringValue("Airplane")]
        AIRPLANE = 1,
        /// <summary>
        /// The Object is a Bomb.
        /// </summary>
        [StringValue("Bomb")]
        BOMB = 2,
        /// <summary>
        /// The Object is a Pod.
        /// </summary>
        [StringValue("Pod")]
        POD = 3,
        /// <summary>
        /// The Object is a Fuel Tank.
        /// </summary>
        [StringValue("Fuel Tank")]
        FUEL_TANK = 4,
        /// <summary>
        /// The Object is a Helicopter.
        /// </summary>
        [StringValue("Helicopter")]
        HELICOPTER = 5,
        /// <summary>
        /// The Object is a Missile.
        /// </summary>
        [StringValue("Missile")]
        MISSILE = 6,
        /// <summary>
        /// The Object is a Recon Camera.
        /// </summary>
        [StringValue("Recon Camera")]
        RECON = 7,
        /// <summary>
        /// The Object is a Rocket.
        /// </summary>
        [StringValue("Rocket")]
        ROCKET = 8,
    }

    /// <summary>
    /// Types of Ground Units Available
    /// </summary>
    public enum GroundVehicleType
    {
        /// <summary>
        /// A type of movement where individuals use their feet.
        /// </summary>
        [StringValue("Foot")]
        FOOT = 1,
        /// <summary>
        /// A type of movement where an object is attached to another unit for movement.
        /// </summary>
        [StringValue("Towed")]
        TOWED = 2,
        /// <summary>
        /// A type of vehicle where wheels are covered with a flexible tough material for better traction.
        /// </summary>
        [StringValue("Tracked")]
        TRACKED = 3,
        /// <summary>
        /// A type vehicle that uses wheels to travel across land.
        /// </summary>
        [StringValue("Wheeled")]
        WHEELED = 4,
    }

    /// <summary>
    /// Types of Naval Vehicles Available.
    /// </summary>
    public enum NavalVehicleType
    {
        /// <summary>
        /// A fast, maneuverable sea vehicle.
        /// </summary>
        [StringValue("Assault Ship")]
        ASSAULT = 1,
        /// <summary>
        /// A generic term for sea vehicles.
        /// </summary>
        [StringValue("Boat")]
        BOAT = 2,
        /// <summary>
        /// A floating object used to identify area information or collect and transmit data.
        /// </summary>
        [StringValue("Buoy")]
        BUOY = 3,
        /// <summary>
        /// A large sea vessel capable of engaging in combat and providing command and control support.
        /// </summary>
        [StringValue("Capital Ship")]
        CAPITAL_SHIP = 4,
        /// <summary>
        /// A large sea vessel that carries goods and supplies.
        /// </summary>
        [StringValue("Cargo Ship")]
        CARGO = 5,
        /// <summary>
        /// A medium to large sized sea vessel designed for combat.
        /// </summary>
        [StringValue("Cruiser")]
        CRUISER = 6,
        /// <summary>
        /// An underwater explosive designed to combat submarines.
        /// </summary>
        [StringValue("Depth Charge")]
        DEPTHCHARGE = 7,
        /// <summary>
        /// A small to medium size sea vessel designed for front line combat.
        /// </summary>
        [StringValue("Destroyer")]
        DESTROYER = 8,
        /// <summary>
        /// A small sea vessel designed for front line combat and support.
        /// </summary>
        [StringValue("Frigate")]
        FRIGATE = 9,
        /// <summary>
        /// A small, fast sea vehicle designed to provide security to larger vehicles or ports.
        /// </summary>
        [StringValue("Patrol Boat")]
        PATROL = 10,
        /// <summary>
        /// A very small sea vehicle designed for emergency use.
        /// </summary>
        [StringValue("Raft")]
        RAFT = 11,
        /// <summary>
        /// A generic term applied to large sea vehicles.
        /// </summary>
        [StringValue("Ship")]
        SHIP = 12,
        /// <summary>
        /// A large sea vehicle that transports fuel.
        /// </summary>
        [StringValue("Tanker")]
        TANKER = 13,
        /// <summary>
        /// An underwater weapon capable of propelling itself through water and detonating an explosive against a target.
        /// </summary>
        [StringValue("Torpedo")]
        TORPEDO = 14,
    }

    /// <summary>
    /// Types of Undersea Vehicles Avaialble.
    /// </summary>
    public enum UnderseaVehicleType
    {
        /// <summary>
        /// A pressurized vehicle that is capable of operating under water for extended periods of time.
        /// </summary>
        [StringValue("Submarine")]
        SUBMARINE = 1,
    }

    /// <summary>
    /// List of Country Identifiers in teh Campaign.
    /// This has been changed to be more generic given the inclusion of multiple theaters.
    /// </summary>
    public enum CountryList
    {
        /// <summary>
        /// Country 0
        /// </summary>
        [StringValue("Country 0")]
        COUNTRY_0 = 0,
        /// <summary>
        /// Country 1
        /// </summary>
        [StringValue("Country 1")]
        COUNTRY_1,
        /// <summary>
        /// Country 2
        /// </summary>
        [StringValue("Country 2")]
        COUNTRY_2,
        /// <summary>
        /// Country 3
        /// </summary>
        [StringValue("Country 3")]
        COUNTRY_3,
        /// <summary>
        /// Country 4
        /// </summary>
        [StringValue("Country 4")]
        COUNTRY_4,
        /// <summary>
        /// Country 5
        /// </summary>
        [StringValue("Country 5")]
        COUNTRY_5,
        /// <summary>
        /// Country 6
        /// </summary>
        [StringValue("Country 6")]
        COUNTRY_6,
        /// <summary>
        /// Country 7
        /// </summary>
        [StringValue("Country 7")]
        COUNTRY_7,
    };

    /// <summary>
    /// Type of Objects contained in the Database.
    /// </summary>
    public enum DataType
    {
        /// <summary>
        /// Minimum Value used for indexing.
        /// </summary>
        DMIN = 0,
        /// <summary>
        /// A Feature Object is a component of an Objective.
        /// </summary>
        [StringValue("Feature")]
        FEATURE = 1,
        /// <summary>
        /// Object does not have a type.
        /// </summary>
        [StringValue("None")]
        NONE = 2,
        /// <summary>
        /// An Objective Object is a collection of Features that make up an installation or notable location on a map..
        /// </summary>
        [StringValue("Objective")]
        OBJECTIVE = 3,
        /// <summary>
        /// A Unit Object is an abstract component of the 2D world that cannot interact with other objects in the 3D world.
        /// </summary>
        [StringValue("Unit")]
        UNIT = 4,
        /// <summary>
        /// A Vehicle Object is moveable object of the 3D world capable of interacting with other objects.
        /// </summary>
        [StringValue("Vehicle")]
        VEHICLE = 5,
        /// <summary>
        /// A Weapon Object is used to inflict damage on a target.
        /// </summary>
        [StringValue("Weapon")]
        WEAPON = 6,
        /// <summary>
        /// Max Data Value
        /// </summary>
        DMAX = 7
    };

    /// <summary>
    /// Modes used by the Game to determine Configurations for the Game and Environment.
    /// </summary>
    public enum ModeType
    {
        /// <summary>
        /// Normal Mode.
        /// </summary>
        [StringValue("Normal")]
        MODE_NORMAL = 0,
        /// <summary>
        /// Crimson Mode.
        /// </summary>
        [StringValue("Crimson")]
        MODE_CRIMSON = 1,
        /// <summary>
        /// Shark Mode.
        /// </summary>
        [StringValue("Shark")]
        MODE_SHARK = 2,
        /// <summary>
        /// Viper Mode.
        /// </summary>
        [StringValue("Viper")]
        MODE_VIPER = 3,
        /// <summary>
        /// Tiger Mode.
        /// </summary>
        [StringValue("Tiger")]
        MODE_TIGER = 4,

    };

    /// <summary>
    /// Types of Radar Equipment in the Database.
    /// </summary>
    public enum RadarType
    {
        /// <summary>
        /// No Radar.
        /// </summary>
        [StringValue("None")]
        NO_RADAR = 0,
        /// <summary>
        /// Generic F-16 Radar.
        /// </summary>
        [StringValue("F-16")]
        F16 = 1,
        /// <summary>
        /// Simplified F-16 Radar.
        /// </summary>
        [StringValue("F-16 Simple")]
        F16_SIMPLE = 2,
        /// <summary>
        /// 360 Degree F-16 Radar.
        /// </summary>
        [StringValue("F-16 360")]
        F16_360 = 3,
        /// <summary>
        /// AIM-120 AMRAAM Seeker Head
        /// </summary>
        [StringValue("AMRAAM")]
        AMRAAM = 4,
        /// <summary>
        /// Mig-21 Radar.
        /// </summary>
        [StringValue("Mig-21")]
        Mig21 = 5,
        /// <summary>
        /// Mig-23 Radar.
        /// </summary>
        [StringValue("Mig-23")]
        Mig23 = 6,
        /// <summary>
        /// Mig-25 Radar.
        /// </summary>
        [StringValue("Mig-25")]
        Mig25 = 7,
        /// <summary>
        /// Mig-31 Radar.
        /// </summary>
        [StringValue("Mig-31")]
        Mig31 = 8,
        /// <summary>
        /// 2S6 Radar.
        /// </summary>
        [StringValue("2S6")]
        R2S6 = 9,
        /// <summary>
        /// A-50 Radar.
        /// </summary>
        [StringValue("A-50")]
        A50 = 10,
        /// <summary>
        /// ADATS Radar.
        /// </summary>
        [StringValue("ADATS")]
        ADATS = 11,
        /// <summary>
        /// Aegis Radar.
        /// </summary>
        [StringValue("Aegis")]
        AEGIS = 12,
        /// <summary>
        /// AH-66 Radar.
        /// </summary>
        [StringValue("AH-66")]
        AH66 = 13,
        /// <summary>
        /// AV-8B Radar.
        /// </summary>
        [StringValue("AV-8B")]
        AV8B = 14,
        /// <summary>
        /// Bar Lock Radar.
        /// </summary>
        [StringValue("Bar Lock")]
        BarLock = 15,
        /// <summary>
        /// Chapparal Radar.
        /// </summary>
        [StringValue("Chapparal")]
        Chapparal = 16,
        /// <summary>
        /// E2-C Radar.
        /// </summary>
        [StringValue("E-2C")]
        E2C = 17,
        /// <summary>
        /// E-3 Radar.
        /// </summary>
        [StringValue("e-3")]
        E3 = 18,
        /// <summary>
        /// F-14 Radar.
        /// </summary>
        [StringValue("F-14")]
        F14 = 19,
        /// <summary>
        /// F-15 Radar.
        /// </summary>
        [StringValue("F-15")]
        F15 = 20,
        /// <summary>
        /// Zeus Radar.
        /// </summary>
        [StringValue("Zeus")]
        ZUES = 21,
        /// <summary>
        /// F-22 Radar.
        /// </summary>
        [StringValue("F-22")]
        F22 = 22,
        /// <summary>
        /// F-4 Radar.
        /// </summary>
        [StringValue("F-4")]
        F4 = 23,
        /// <summary>
        /// f-5 Radar.
        /// </summary>
        [StringValue("F-5")]
        F5 = 24,
        /// <summary>
        /// Hawk Radar.
        /// </summary>
        [StringValue("Hawk")]
        Hawk = 27,
        /// <summary>
        /// Nike Radar.
        /// </summary>
        [StringValue("Nike")]
        Nike = 28,
        /// <summary>
        /// J-5 Radar.
        /// </summary>
        [StringValue("J-5")]
        J5 = 29,
        /// <summary>
        /// J-7 Radar.
        /// </summary>
        [StringValue("J-7")]
        J7 = 30,
        /// <summary>
        /// Long Track Radar.
        /// </summary>
        [StringValue("Long Track")]
        LongTrack = 32,
        /// <summary>
        /// Low Blow Search Radar.
        /// </summary>
        [StringValue("Low Blow Search")]
        LowBlowSearch = 33,
        /// <summary>
        /// MPQ-54 Radar.
        /// </summary>
        [StringValue("MPQ-54")]
        MPQ54 = 34,
        /// <summary>
        /// MSQ-48 Radar.
        /// </summary>
        [StringValue("MSQ-48")]
        MSQ48 = 35,
        /// <summary>
        /// MSQ-50 Radar.
        /// </summary>
        [StringValue("MSQ-50")]
        MSQ50 = 36,
        /// <summary>
        /// Patriot Radar.
        /// </summary>
        [StringValue("Patriot")]
        Patriot = 37,
        /// <summary>
        /// Phoenix Radar.
        /// </summary>
        [StringValue("Phoenix")]
        PHOENIX = 38,
        /// <summary>
        /// Fan Song Radar.
        /// </summary>
        [StringValue("Fan Song")]
        FanSong = 39,
        /// <summary>
        /// Low Blow Radar.
        /// </summary>
        [StringValue("Low Blow")]
        LowBlow = 40,
        /// <summary>
        /// Patriot Handoff Radar.
        /// </summary>
        [StringValue("Patriot Handoff")]
        PatHand = 41,
        /// <summary>
        /// Square Pair Radar.
        /// </summary>
        [StringValue("Square Pair")]
        SquarePair = 42,
        /// <summary>
        /// Straight Flush Radar.
        /// </summary>
        [StringValue("Straight Flush")]
        StraightFlush = 43,
        /// <summary>
        /// Land Roll Radar.
        /// </summary>
        [StringValue("Land Roll")]
        LandRoll = 44,
        /// <summary>
        /// SA-9 Radar.
        /// </summary>
        [StringValue("SA-9")]
        SA9 = 45,
        /// <summary>
        /// Flap Lid Radar.
        /// </summary>
        [StringValue("Flap Lid")]
        FlapLid = 46,
        /// <summary>
        /// Snap Shot Radar.
        /// </summary>
        [StringValue("Snap Shot")]
        SnapShot = 47,
        /// <summary>
        /// Slot Back Radar.
        /// </summary>
        [StringValue("Slot Back")]
        Slotback = 48,
        /// <summary>
        /// Spoon Rest Radar.
        /// </summary>
        [StringValue("Spoon Rest")]
        SpoonRest = 49,
        /// <summary>
        /// Su-15 Radar.
        /// </summary>
        [StringValue("Su-15")]
        SU15 = 50,
        /// <summary>
        /// TPS-63 Radar.
        /// </summary>
        [StringValue("TPS-63")]
        TPS63 = 51,
        /// <summary>
        /// SA-15 Radar.
        /// </summary>
        [StringValue("SA-15")]
        SA15 = 52,
        /// <summary>
        /// ANVP-S2 Radar.
        /// </summary>
        [StringValue("AN/VPS2")]
        ANVPS2 = 53,
        /// <summary>
        /// Drum Tilt Radar.
        /// </summary>
        [StringValue("Drum Tilt")]
        DrumTilt = 54,
        /// <summary>
        /// Pop Group Radar.
        /// </summary>
        [StringValue("Pop Group")]
        PopGroup = 55,
        /// <summary>
        /// Top Dome Radar.
        /// </summary>
        [StringValue("Top Dome")]
        TopDome = 56,
        /// <summary>
        /// AN/ASPQ-10 Radar.
        /// </summary>
        [StringValue("AN/ASPQ-10")]
        ANSPS10 = 57,
        /// <summary>
        /// AN/ANPQ-114 Radar.
        /// </summary>
        [StringValue("AN/ANPQ-114")]
        ANAPQ114 = 58,
        /// <summary>
        /// AG Only Radar.
        /// </summary>
        [StringValue("AG Only")]
        AGOnly = 59,
    };

    /// <summary>
    /// The types of damage a Weapon can cause to a target.
    /// </summary>
    public enum DamageDataType
    {
        /// <summary>
        /// Weapon causes no significant damage.
        /// </summary>
        [StringValue("No Damage")]
        NoDamage = 0,
        /// <summary>
        /// Weapon causes penetration damage. 
        /// Effective against hardened targets.
        /// </summary>
        [StringValue("Penetration Damage")]
        PenetrationDam,
        /// <summary>
        /// Weapon detonates an explosion. 
        /// Effective against soft or area targets.
        /// </summary>
        [StringValue("High Explosive Damage")]
        HighExplosiveDam,
        /// <summary>
        /// Weapon causes heave damage leaving craters. 
        /// Effective against Runways.
        /// </summary>
        [StringValue("Heave Damage")]
        HeaveDam,
        /// <summary>
        /// Weapon causes heat or burning damage. 
        /// Effective against troops and other soft targets.
        /// </summary>
        [StringValue("Incendiary Damage")]
        IncendairyDam,
        /// <summary>
        /// Weapon detonates an explosion when it reaches a certain proximity. 
        /// Effective against fast moving targets, such as aircraft.
        /// </summary>
        [StringValue("Proximity Damage")]
        ProximityDam,
        /// <summary>
        /// Weapon fires a projective to damage the target with an impact.
        /// Effective against soft and moderately hardened targets.
        /// </summary>
        [StringValue("Kinetic Damage")]
        KineticDam,
        /// <summary>
        /// Weapon causes damage by detonating an underwater explosion.
        /// Effective against sea vehicles..
        /// </summary>
        [StringValue("Hydrostatic Damage")]
        HydrostaticDam,
        /// <summary>
        /// Weapon causes burning damage or erodes the surface of the target.
        /// Effective against soft or moderately hardened targets.
        /// </summary>
        [StringValue("Checmical Damage")]
        ChemicalDam,
        /// <summary>
        /// Weapon causes significant thermal and kinetic damage through detonation of a Nuclear Device.
        /// </summary>
        [StringValue("Nuclear Damage")]
        NuclearDam,
        /// <summary>
        /// Weapon causes general, unspecified damage to the target.
        /// </summary>
        [StringValue("Other Damage")]
        OtherDam
    }

    /// <summary>
    /// Weapon Types Available.
    /// </summary>
    public enum ClassTableWeaponType
    {
        /// <summary>
        /// The Object is a Mine Sweeper.
        /// </summary>
        [StringValue("Mine Sweep")]
        MINESWEEP = 2,
        /// <summary>
        /// The Object is a Gun.
        /// </summary>
        [StringValue("Gun")]
        GUN = 3,
        /// <summary>
        /// The Object is a Rack.
        /// </summary>
        [StringValue("Rack")]
        RACK = 4,
        /// <summary>
        /// The Object is a Launcher.
        /// </summary>
        [StringValue("Launcher")]
        LAUNCHER = 5,
    }

    /// <summary>
    /// Types of Air Units available.
    /// </summary>
    public enum AirUnit
    {
        /// <summary>
        /// The Object is a Flight.
        /// </summary>
        [StringValue("Flight")]
        FLIGHT = 1,
        /// <summary>
        /// The Object is a Package.
        /// </summary>
        [StringValue("Package")]
        PACKAGE = 2,
        /// <summary>
        /// The Object is a Squadron.
        /// </summary>
        [StringValue("Squadron")]
        SQUADRON = 3,
    }

    /// <summary>
    /// Types of Ground Units Available
    /// </summary>
    public enum GroundUnit
    {
        /// <summary>
        /// A front line land combat unit.
        /// </summary>
        [StringValue("Batallion")]
        BATTALION = 1,
        /// <summary>
        /// A large collection of ground units capable of engaging in multiple efforts simultaneously.
        /// </summary>
        [StringValue("Brigade")]
        BRIGADE = 2,
    }

    /// <summary>
    /// Sea Units Available
    /// </summary>
    public enum SeaUnit
    {
        /// <summary>
        /// A collection of sea vehicles.
        /// </summary>
        [StringValue("Task Force")]
        TASKFORCE = 1,
    }

    /// <summary>
    /// Types of Undersea Units Available
    /// </summary>
    public enum UnderseaUnit
    {
        /// <summary>
        /// A submarine unit
        /// </summary>
        [StringValue("Wolf Pack")]
        WOLFPACK = 1,
    }

    /// <summary>
    /// Types of Land Features Available.
    /// </summary>
    public enum LandFeature
    {
        /// <summary>
        /// An area of depressed land caused by an explosive force.
        /// </summary>
        [StringValue("Crater")]
        CRATER = 1,
        /// <summary>
        /// A vertical structure at an airfield designed to provide control functions for aircraft.
        /// </summary>
        [StringValue("Control Tower")]
        CTRL_TOWER = 2,
        /// <summary>
        /// A small building.
        /// </summary>
        [StringValue("Barn")]
        BARN = 3,
        /// <summary>
        /// A hardened military structure.
        /// </summary>
        [StringValue("Bunker")]
        BUNKER = 4,
        /// <summary>
        /// A small plant.
        /// </summary>
        [StringValue("Bush")]
        BUSH = 5,
        /// <summary>
        /// A collection of factories at an industrial complex.
        /// </summary>
        [StringValue("Factories")]
        FACTORYS = 6,
        /// <summary>
        /// A religious building.
        /// </summary>
        [StringValue("Church")]
        CHURCH = 7,
        /// <summary>
        /// A building or structure used to govern and manage a local area or city.
        /// </summary>
        [StringValue("City Hall")]
        CITY_HALL = 8,
        /// <summary>
        /// A structure that provides access to sea vessels from land.
        /// </summary>
        [StringValue("Dock")]
        DOCK = 9,
        //DEPOT                  = 10, // already in the enum under objectives
        /// <summary>
        /// A large concrete pad used to support takeoff and landing activies of aircraft.
        /// </summary>
        [StringValue("Runway")]
        RUNWAY = 11,
        /// <summary>
        /// A building used to store goods or supplies.
        /// </summary>
        [StringValue("Warehouse")]
        WAREHOUSE = 12,
        /// <summary>
        /// A designated location for helicopters to takeoff and land..
        /// </summary>
        [StringValue("Helipad")]
        HELIPAD = 13,
        /// <summary>
        /// A group of structures that store fuel.
        /// </summary>
        [StringValue("Fuel Tanks")]
        FUEL_TANKS = 14,
        /// <summary>
        /// A structure that produces electrical power using steam generated from Nuclear Fission.
        /// </summary>
        [StringValue("Nuclear Plant")]
        NUKE_PLANT = 15,
        /// <summary>
        /// A structure used to allow land vehicles to cross water.
        /// </summary>
        [StringValue("Bridge")]
        BRIDGES = 16,
        /// <summary>
        /// A large structure designed to allow individuals or small vehicles access to water or sea vehicles from land.
        /// </summary>
        [StringValue("Pier")]
        PIER = 17,
        /// <summary>
        /// A power pole used to support power transmission lines.
        /// </summary>
        [StringValue("Power Pole")]
        PPOLE = 18,
        /// <summary>
        /// A commercial building where goods can be bought and sold.
        /// </summary>
        [StringValue("Shop")]
        SHOP = 19,
        /// <summary>
        /// A large vertical structure used to provide stable support for heavy power transmission lines.
        /// </summary>
        [StringValue("Power Tower")]
        PTOWER = 20,
        /// <summary>
        /// A residential building where multiple families or tenants live.
        /// </summary>
        [StringValue("Apartment")]
        APARTMENT = 21,
        /// <summary>
        /// A small building where a single family or tenant lives.
        /// </summary>
        [StringValue("House")]
        HOUSE = 22,
        /// <summary>
        /// A building where power is generated.
        /// </summary>
        [StringValue("Power Plant")]
        PPLANT = 23,
        /// <summary>
        /// A sign that is posted parallel to an airport Taxiway or Runway indicating airport layout.
        /// </summary>
        [StringValue("Taxi Sign")]
        TAXI_SIGN = 24,
        /// <summary>
        /// A structure used to send navigation signals to aircraft using radio transmissions.
        /// </summary>
        [StringValue("Navigation Beacon")]
        NAV_BEAC = 25,
        /// <summary>
        /// An area where radio transcievers send, receive, and process singals to perform Radio Detecion and Ranging operations.
        /// </summary>
        [StringValue("Radar Site")]
        RADAR_SITE = 26,
        /// <summary>
        /// A collection of depressed land areas.
        /// </summary>
        [StringValue("Craters")]
        CRATERS = 27,
        /// <summary>
        /// A piece of equipment used to perform Radio Detection and Ranging operations.
        /// </summary>
        [StringValue("Radars")]
        RADARS = 28,
        /// <summary>
        /// A vertical structure designed to support radio equipment.
        /// </summary>
        [StringValue("Radio Tower")]
        RTOWER = 29,
        /// <summary>
        /// A strip of concrete designed to allow aircraft to move around an airport.
        /// </summary>
        [StringValue("Taxiway")]
        TAXIWAY = 30,
        /// <summary>
        /// A complex, area, or collection of buildings designed to support rail activities.
        /// </summary>
        [StringValue("Rail Terminals")]
        RAIL_TERMINALS = 31,
        /// <summary>
        /// A group of industrial areas designed to process raw materials into strategic resources.
        /// </summary>
        [StringValue("Refineries")]
        REFINERYS = 32,
        /// <summary>
        /// A Surface to Air Missile Site.
        /// </summary>
        [StringValue("SAM")]
        SAM = 33,
        /// <summary>
        /// A very small storage structure.
        /// </summary>
        [StringValue("Shed")]
        SHED = 34,
        /// <summary>
        /// A building designed to house military personnel on an installation.
        /// </summary>
        [StringValue("Barracks")]
        BARRACKS = 35,
        /// <summary>
        /// A tall plany.
        /// </summary>
        [StringValue("Tree")]
        TREE = 36,
        /// <summary>
        /// A large tower that moves in the wind to generate power.
        /// </summary>
        [StringValue("Wind Tower")]
        WTOWER = 37,
        /// <summary>
        /// A building or small area where management of a town takes place.
        /// </summary>
        [StringValue("Town Hall")]
        TWNHALL = 38,
        /// <summary>
        /// A building at an airport where aircraft can park or load passengers, stores, or supplies.
        /// </summary>
        [StringValue("Air Terminal")]
        AIR_TERMINAL = 39,
        // YARD                   = 39, 
        /// <summary>
        /// A religious building.
        /// </summary>
        [StringValue("Shrine")]
        SHRINE = 40,
        /// <summary>
        /// A small recreation area, typically outdoors.
        /// </summary>
        [StringValue("Park")]
        PARK = 41,
        /// <summary>
        /// An area of a town or city primarily composed of office or commercial buildings.
        /// </summary>
        [StringValue("Office Block")]
        OFF_BLOCK = 42,
        /// <summary>
        /// A building where television signals are broadcast to viewers.
        /// </summary>
        [StringValue("TV Station")]
        TVSTN = 43,
        /// <summary>
        /// A building or group of buildings where individuals can temporarily reside when visiting an area.
        /// </summary>
        [StringValue("Hotel")]
        HOTEL = 44,
        /// <summary>
        /// A large building designed to store aircraft.
        /// </summary>
        [StringValue("Hangar")]
        HANGAR = 45,
        /// <summary>
        /// An electrical device that emits visible light, typically mounted on a pole or an elevated position.
        /// </summary>
        [StringValue("Town")]
        LIGHTS = 46,
        /// <summary>
        /// A group of lights and indicators used for aircraft approaches known as the Visual Approach Slope Indicator.
        /// </summary>
        [StringValue("VASI Lights")]
        VASI = 47,
        /// <summary>
        /// A structure used to store fuel or other liquid resources.
        /// </summary>
        [StringValue("Tank")]
        TANK = 48,
        /// <summary>
        /// A defensive or protective barrier used to mark the edge of a location or area.
        /// </summary>
        [StringValue("Fence")]
        FENCE = 49,
        /// <summary>
        /// An area of concrete used for storing vehicles.
        /// </summary>
        [StringValue("Parking Lot")]
        PARKINGLOT = 50,
        /// <summary>
        /// A vertical structure attached to industrial buildings to allow smoke, steam, or other particulates to leave the building.
        /// </summary>
        [StringValue("Smoke Stack")]
        SMOKESTACK = 51,
        /// <summary>
        /// A generic term for a physical structure.
        /// </summary>
        [StringValue("Building")]
        BUILDING = 52,
        /// <summary>
        /// A tower used for cooling operations at a power plant, particularly with Nuclear Power plants.
        /// </summary>
        [StringValue("Cooling Tower")]
        COOL_TWR = 53,
        /// <summary>
        /// A rounded building component that sits atop a control tower at an airport.
        /// </summary>
        [StringValue("control Dome")]
        CONT_DOME = 54,
        /// <summary>
        /// A small building where security guards work.
        /// </summary>
        [StringValue("Guard House")]
        GUARDHOUSE = 55,
        /// <summary>
        /// A structure or tower where power is converted from one type to another, 
        /// typically by adjusting voltage to allow transfer of high amounts across large distances.
        /// </summary>
        [StringValue("Transformer")]
        TRANSFORMER = 56,
        /// <summary>
        /// A hardened building where ammunition is stored.
        /// </summary>
        [StringValue("Ammo Dump")]
        AMMO_DUMP = 57,
        /// <summary>
        /// A hardened location where Artillery can be deployed.
        /// </summary>
        [StringValue("Artillery Site")]
        ART_SITE = 58,
        /// <summary>
        /// A medium to large structure used for commercial operations.
        /// </summary>
        [StringValue("Office Building")]
        OFFICE = 59,
        /// <summary>
        /// An industrial structure where chemicals are produced, refined, or processed.
        /// </summary>
        [StringValue("Chemical Plant")]
        CHEM_PLANT = 60,
        /// <summary>
        /// A gneric term for a large vertical structure.
        /// </summary>
        [StringValue("Tower")]
        TOWER = 61,
        /// <summary>
        /// A building or area where medical services are provided to sick and wounded.
        /// </summary>
        [StringValue("Hospital")]
        HOSPITAL = 62,
        /// <summary>
        /// A commercial area of a town or city.
        /// </summary>
        [StringValue("Shop Block")]
        SHOPBLK = 63,
        //RUNWAY_NUM             = 64,
        /// <summary>
        /// A persistent object that does not move.
        /// </summary>
        [StringValue("Static Object")]
        STATIC = 64,
        /// <summary>
        /// Numbers and other markings that provide visual identification and information about a runway.
        /// </summary>
        [StringValue("Runway Marker")]
        RUNWAY_MARKER = 65,
        /// <summary>
        /// A large structure used for entertainment or sports activities.
        /// </summary>
        [StringValue("Stadium")]
        STADIUM = 66,
        /// <summary>
        /// A structure or building designed to commemmorate an event, person, or action.
        /// </summary>
        [StringValue("Monument")]
        MONUMENT = 67,
    }

    /// <summary>
    /// Types of Land Objectives Available.
    /// </summary>
    public enum LandObjective
    {
        /// <summary>
        /// A large airport with infrastructure and supplies to support sustained flying operations.
        /// </summary>
        [StringValue("Airbase")]
        AIRBASE = 1,
        /// <summary>
        /// An airport with infrastructure and supplies to support limited flying operations.
        /// </summary>
        [StringValue("Airstrip")]
        AIRSTRIP = 2,
        /// <summary>
        /// A large installation with infrastructure and supplies to support sustained ground operations.
        /// </summary>
        [StringValue("Army Base")]
        ARMYBASE = 3,
        /// <summary>
        /// A geographic area where land and water meet.
        /// </summary>
        [StringValue("Beach")]
        BEACH = 4,
        /// <summary>
        /// An abstract line of demarcation between two poilitical entities.
        /// </summary>
        [StringValue("Border")]
        BORDER = 5,
        /// <summary>
        /// A structure that provides a means for land vehicles to cross water.
        /// </summary>
        [StringValue("Bridge")]
        BRIDGE = 6,
        /// <summary>
        /// An industrial complex that produces chemicals.
        /// </summary>
        [StringValue("Chemical")]
        CHEMICAL = 7,
        /// <summary>
        /// A collection of houses, buildings, and other structures in a given area.
        /// </summary>
        [StringValue("City")]
        CITY = 8,
        /// <summary>
        /// A Military installation designed to support Command and Control of assets.
        /// </summary>
        [StringValue("Command & Control")]
        COM_CONTROL = 9,
        /// <summary>
        /// A location to store supplies, fuel, weapons, or other important strategic assets.
        /// </summary>
        [StringValue("Depot")]
        DEPOT = 10,
        /// <summary>
        /// An industrial building capable of producing goods.
        /// </summary>
        [StringValue("Factory")]
        FACTORY = 11,
        /// <summary>
        /// A shallow area of water that can be crossed without need for a bridge or watercraft.
        /// </summary>
        [StringValue("Ford")]
        FORD = 12,
        /// <summary>
        /// A defensive military installation.
        /// </summary>
        [StringValue("Fortification")]
        FORTIFICATION = 13,
        /// <summary>
        /// An elevated tactical position..
        /// </summary>
        [StringValue("Hill Top")]
        HILL_TOP = 14,
        /// <summary>
        /// A crossing of two or more means of travel.
        /// </summary>
        [StringValue("Intersection")]
        INTERSECT = 15,
        /// <summary>
        /// A radio device used to send out navigation information to vehicles.
        /// </summary>
        [StringValue("Navigation Beacon")]
        NAV_BEACON = 16,
        /// <summary>
        /// A Power Plant that uses Nuclear Reactors to create steam pressure that drives turbines for Power Generation.
        /// </summary>
        [StringValue("Nuclear Plant")]
        NUCLEAR = 17,
        /// <summary>
        /// A geographic area with a close proximity to a well-known or easily identified landmark or location.
        /// </summary>
        [StringValue("Pass")]
        PASS = 18,
        /// <summary>
        /// An area extending from land where Sea Vessels can be maintained, stored, repaired, and supplied.
        /// </summary>
        [StringValue("Port")]
        PORT = 19,
        /// <summary>
        /// A facility where power is generated.
        /// </summary>
        [StringValue("Power Plant")]
        POWERPLANT = 20,
        /// <summary>
        /// An installation where Radio Signals are processed for Radio Detection and Ranging of vehicles.
        /// </summary>
        [StringValue("Radar")]
        RADAR = 21,
        /// <summary>
        /// A vertical structure where antennas or other Radio Equipment can be mounted for operational use.
        /// </summary>
        [StringValue("Radio Tower")]
        RADIO_TOWER = 22,
        /// <summary>
        /// A collection of structures and Rail Lines where train vehicles can be maintained, stored, repaired, or supplied.
        /// </summary>
        [StringValue("Rail Terminal")]
        RAIL_TERMINAL = 23,
        /// <summary>
        /// A means for Train Vehicles to travel.
        /// </summary>
        [StringValue("Railroad")]
        RAILROAD = 24,
        /// <summary>
        /// An industrial facility where petroleum or other chemicals can be processed into other, more valuable, strategic resources.
        /// </summary>
        [StringValue("Airbase")]
        REFINERY = 25,
        /// <summary>
        /// A means by which land vehicles can travel.
        /// </summary>
        [StringValue("Road")]
        ROAD = 26,
        /// <summary>
        /// A large body of water.
        /// </summary>
        [StringValue("Sea")]
        SEA = 27,
        /// <summary>
        /// A small collection of buildings and structures in s given area smaller than a city.
        /// </summary>
        [StringValue("Town")]
        TOWN = 28,
        /// <summary>
        /// A very small collection of buildings and structures in s given area smaller than a town.
        /// </summary>
        [StringValue("Village")]
        VILLAGE = 29,
        /// <summary>
        /// A Hardened Artillery Site.
        /// </summary>
        [StringValue("HARTS")]
        HARTS = 30,
        /// <summary>
        /// A location where Surface to Air Missiles can deploy and engage air targets..
        /// </summary>
        [StringValue("SAM Site")]
        SAM_SITE = 31,
    }

    /// <summary>
    /// Types of Movement a Vehicle can perform.
    /// </summary>
    public enum MoveType
    {
        /// <summary>
        /// Object is stationary and cannot move.
        /// </summary>
        [StringValue("No Movement")]
        NoMove = 0,
        /// <summary>
        /// Object is a pedestrian and moves by using it's feet.
        /// </summary>
        [StringValue("Foot")]
        Foot = 1,
        /// <summary>
        /// Object uses Wheels to travel across land.
        /// </summary>
        [StringValue("Wheeled")]
        Wheeled = 2,
        /// <summary>
        /// Object used a large, flxible component wrapped around several wheels to move across land with better traction.
        /// </summary>
        [StringValue("Tracked")]
        Tracked = 3,
        /// <summary>
        /// Object travels through the air at low altitudes, such as a helicopter.
        /// </summary>
        [StringValue("Low Air")]
        LowAir = 4,
        /// <summary>
        /// Object travels through the air at various high and low altitudes.
        /// </summary>
        [StringValue("Air")]
        Air = 5,
        /// <summary>
        /// Object moves thorugh the water.
        /// </summary>
        [StringValue("Naval")]
        Naval = 6,
        /// <summary>
        /// Object travels along tracks or rails.
        /// </summary>
        [StringValue("Rail")]
        Rail = 7,
        /// <summary>
        /// End of Movement Types
        /// </summary>
        MOVEMENT_TYPES
    }

    /// <summary>
    /// Aircraft Combat Classes
    /// </summary>
    public enum CombatClass
    {
        /// <summary>
        /// 3rd Generation Mult Role Aircraft (F4)
        /// </summary>
        [StringValue("Legacy Attack Aircraft")]
        LegacyFighterBomber,
        /// <summary>
        /// 3rd Generation Light Fighter Aircraft, such as the (F5)
        /// </summary>
        [StringValue("Legacy AA Fighter")]
        LegacyInterceptor,
        /// <summary>
        /// Carrier-Base Multi Role Aircraft, such as the (F14)
        /// </summary>
        [StringValue("Modern Carrier-Based Multi-Role Aircraft")]
        MaritimeMultiRole,
        /// <summary>
        /// 4th/5th Gen Fighter Aircraft, such as the (F15)
        /// </summary>
        [StringValue("Modern AA Fighter")]
        AirSuperiority,
        /// <summary>
        /// 4th/5th Gen Multi Role Fighters, such as the (F16)
        /// </summary>
        [StringValue("<odern Multi-Role Aircraft")]
        MultiRole,
        /// <summary>
        /// 4th/5th Gen Light Fighter Aircraft (Mig25)
        /// </summary>
        [StringValue("Modern High-Speed AA Aircraft")]
        Interceptor,
        /// <summary>
        /// 4th/5th Gen Attack/Strike Fighter (Mig27)
        /// </summary>
        [StringValue("Modern Medium-Range Attack Aircraft")]
        FighterBomber,
        /// <summary>
        /// 4th/5th Gen AG/CAS Aircraft (A10)
        /// </summary>
        [StringValue("Modern CAS Aircraft")]
        AirToGroundFighter,
        /// <summary>
        /// Heavy Bomber/Strike Aircraft
        /// </summary>
        [StringValue("Modern Heavy Bomber")]
        Bomber

    }

    /// <summary>
    /// Available Sensor Types
    /// </summary>
    public enum SensorType
    {
        /// <summary>
        /// No Sensor in this Slot.
        /// </summary>
        [StringValue("No Sensor")]
        None = -1,
        /// <summary>
        /// Infrared Sensor
        /// </summary>
        [StringValue("IR Sensor")]
        IR,
        /// <summary>
        /// Radar Sensor
        /// </summary>
        [StringValue("Radar Sensor")]
        Radar,
        /// <summary>
        /// Radar Warning Receiver
        /// </summary>
        [StringValue("Radar Warning Receiver")]
        RWR,
        /// <summary>
        /// Visual Sensor
        /// </summary>
        [StringValue("Visual Sensor")]
        Visual,
        /// <summary>
        /// HARM Targeting System
        /// </summary>
        [StringValue("HARM Targeting Sensor")]
        HTS,
        /// <summary>
        /// Targeting Pod
        /// </summary>
        [StringValue("Targeting Pod")]
        TGP,
        /// <summary>
        /// Semi-Active Radar Homing Sensor
        /// </summary>
        [StringValue("Semi-Active Radar Homeing Sensor")]
        SARH
    }

    /// <summary>
    /// Landing Patterns for Airports
    /// </summary>
    public enum LandingPattern
    {
        /// <summary>
        /// Indicates the Point is not an Approach Point.
        /// Used to help keep the XML File Clean by not outputting unused Fields.
        /// </summary>
        None = -1,
        /// <summary>
        /// Left Approach
        /// </summary>
        [StringValue("Left")]
        Left,
        /// <summary>
        /// Center Approach
        /// </summary>
        [StringValue("Center")]
        Center,
        /// <summary>
        /// Right Approach
        /// </summary>
        [StringValue("Right")]
        Right
    }

}
