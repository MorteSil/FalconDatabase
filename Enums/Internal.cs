using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalconDatabase.Enums
{
    /// <summary>
    /// Available File Types
    /// </summary>
    public enum GameFileType
    {
        NONE = -1,
        DTCINI, // DTC File .ini
        TEMissionINI = 1,  // Mission or TE DTC File .ini
        CampaignINI = 1,  // Same as TEMissionINI .ini
        CampaignCAM,  // Campaign Wrapper File .cam
        CampaignFRC,  // Force Ration File .frc
        CampaignHIS,  // History File .his
        CampaignIFF,  // IFF Plan File .iff
        CampaignCMP, // Embedded Campaign Data within CAM .cmp
        CampaignOBJ, // Embedded Campaign Objective List within CAM .obj
        CampaignOBD, // Embedded Campaign Objective Deltas data within CAM .obd
        CampaignUNI, // Embedded Unit List withing CAM .uni
        CampaignTEA, // Embedded Teams list within CAM .tea
        CampaignEVT, // Embedded Event list within CAM .evt
        CampaignPOL, // Embedded Primary Objectives Lisr within CAM .pol
        CampaignPLT, // Embedded Pilot List within CAM .plt
        CampaignPST, // Embedded Persistent Object List within CAM .pst
        CampaignWWTH, // Embedded Weather within CAM .wth
        CampaignVER, // Embedded Verison Info within CAM .ver
        CampaignTE, // Embedded Victory Conditions within CAM .te
        CampaignPROTO,
        CampaignTWX,
        CampaignTRI,
        CampaignPRI, // Priotities File .pri (Attrit, CAS, Defensem Intdict, Offense)
        CampaignTAC,
        MissionDataXML, // Sets mission Parameters for each Mission Type
        Link16PROTO, // Link 16 Plan .txtpb
        TrainingTRN, // Training Mission File (Same structure as CAM
        TacticalTAC, // Tactical Engagement File (Same structure as CAM
        TheaterMAP,
        TheaterNAM,
        TheaterPAK,
        TheaterTHR,
        TheaterTM,
        TheaterIRC, // Necessary?
        TheaterMEA,
        WeatherINI,
        StationsDAT,
        WeatherFMAP,
        ListLST,
        ACDAT,
        ACPROTO,
        ACAFM,
        BombDAT,
        MissileDAT,
        RadarDAT,
        SensorIRS,
        SensorRWR,
        SensorVSS,
        VehicleVEH,
        SignatureFile,
        ATCDAT,
        BMSCFG,
        BMSUserCFG,
        DatabaseCT,
        DatabaseACD,
        DatabaseDDP,
        DatabaseFCD,
        DatabaseICD,
        DatabaseRCD,
        DatabaseRKT,
        DatabaseRWD,
        DatabaseSSD,
        DatabaseSWD,
        DatabaseUCD,
        DatabaseVCD,
        DatabaseVSD,
        DatabaseWCD,
        DatabaseWLD
    }

    /// <summary>
    /// Type of data conatined within a file
    /// </summary>
    public enum FileStreamType
    {
        Text,
        Binary,
        ProtoBuff,
        XML
    }
}
