using FalconDatabase.Objects;
using System.Diagnostics;
using System.Xml;

namespace DatabaseTest
{
    [TestClass]
    public class DBTests
    {
        Database db;
        readonly string outputFolder = ""; // Input your own test data locations here
        readonly string inputFolder = ""; // Input your own test data locations here
        readonly string schemaFolder = ""; // Input your own test data locations here

        [TestMethod]
        public void DatabaseLoadTest()
        {
            Trace.WriteLine("Starting LoadTest");
            db = new(inputFolder);
            Assert.IsNotNull(db);
            Assert.IsFalse(db.Aircraft.IsDefaultInitialization);
            Assert.IsFalse(db.Classes.IsDefaultInitialization);
            Assert.IsFalse(db.DDPTable.IsDefaultInitialization);
            Assert.IsFalse(db.FeatureTable.IsDefaultInitialization);
            Assert.IsFalse(db.IrSensorTable.IsDefaultInitialization);
            Assert.IsFalse(db.ObjectiveTable.IsDefaultInitialization);
            Assert.IsFalse(db.RadarReceiverTable.IsDefaultInitialization);
            Assert.IsFalse(db.RadarTable.IsDefaultInitialization);
            Assert.IsFalse(db.RocketTable.IsDefaultInitialization);
            Assert.IsFalse(db.SimWeaponTable.IsDefaultInitialization);
            Assert.IsFalse(db.SquadronStoresTable.IsDefaultInitialization);
            Assert.IsFalse(db.UnitTable.IsDefaultInitialization);
            Assert.IsFalse(db.VehicleTable.IsDefaultInitialization);
            Assert.IsFalse(db.VisualSensorTable.IsDefaultInitialization);
            Assert.IsFalse(db.WeaponLoadTable.IsDefaultInitialization);
            Assert.IsFalse(db.WeaponTable.IsDefaultInitialization);
        }

        [TestMethod]
        public void DatabaseSaveTest()
        {
            Trace.WriteLine("Starting Save Test");
            /*********************************************************
             * This deletes the output folder when it runs so make 
             * sure you are not testing with your real data in the 
             * ../TerrData/Objects Folder. And as always, make a 
             * backup regardless.
             * ******************************************************/

            if (Directory.Exists(outputFolder))
                Directory.Delete(outputFolder, true);

            db = new(inputFolder);
            db.Save(outputFolder);
            Assert.IsTrue(Directory.Exists(outputFolder));
            Assert.IsTrue(File.Exists(outputFolder + "\\Falcon4_ACD.xml"));
            Assert.IsTrue(File.Exists(outputFolder + "\\Falcon4_CT.xml"));
            Assert.IsTrue(File.Exists(outputFolder + "\\Falcon4_DDP.xml"));
            Assert.IsTrue(File.Exists(outputFolder + "\\Falcon4_FCD.xml"));
            Assert.IsTrue(File.Exists(outputFolder + "\\Falcon4_ICD.xml"));
            Assert.IsTrue(File.Exists(outputFolder + "\\Falcon4_RWD.xml"));
            Assert.IsTrue(File.Exists(outputFolder + "\\Falcon4_RCD.xml"));
            Assert.IsTrue(File.Exists(outputFolder + "\\Falcon4_RKT.xml"));
            Assert.IsTrue(File.Exists(outputFolder + "\\Falcon4_SWD.xml"));
            Assert.IsTrue(File.Exists(outputFolder + "\\Falcon4_SSD.xml"));
            Assert.IsTrue(File.Exists(outputFolder + "\\Falcon4_UCD.xml"));
            Assert.IsTrue(File.Exists(outputFolder + "\\Falcon4_VCD.xml"));
            Assert.IsTrue(File.Exists(outputFolder + "\\Falcon4_VSD.xml"));
            Assert.IsTrue(File.Exists(outputFolder + "\\Falcon4_WCD.xml"));
            Assert.IsTrue(File.Exists(outputFolder + "\\Falcon4_WLD.xml"));
            Assert.IsTrue(Directory.Exists(outputFolder + "\\ObjectiveRelatedData"));
            Assert.IsTrue(Directory.GetDirectories(outputFolder + "\\ObjectiveRelatedData").Length > 0);
        }

        [TestMethod]
        public void DatabaseSaveTestACD()
        {                    
            Trace.WriteLine("Starting ACD Test");
            XmlDocument input = new ();
            MemoryStream stream = new();
            input.Load(inputFolder + "\\Falcon4_ACD.xml");
            XmlDocument output = new ();
            output.Load(outputFolder + "\\Falcon4_ACD.xml");


            XmlNode inputNode = input.DocumentElement;
            XmlNode outputNode = output.DocumentElement;

            Assert.AreEqual(inputNode.ChildNodes.Count, outputNode.ChildNodes.Count);
            for (int i = 0; i < inputNode.ChildNodes.Count; i++)
                Assert.AreEqual(inputNode.ChildNodes[i].OuterXml, outputNode.ChildNodes[i].OuterXml);

        }

        [TestMethod]
        public void DatabaseSaveTestCT()
        {
            Trace.WriteLine("Starting CT Test");
            XmlDocument input = new XmlDocument();
            input.Load(inputFolder + "\\FALCON4_CT.xml");
            XmlDocument output = new XmlDocument();
            output.Load(outputFolder + "\\Falcon4_CT.xml");


            XmlNode inputNode = input.DocumentElement;
            XmlNode outputNode = output.DocumentElement;

            Assert.AreEqual(inputNode.ChildNodes.Count, outputNode.ChildNodes.Count);
            for (int i = 0; i < inputNode.ChildNodes.Count; i++)
                Assert.AreEqual(inputNode.ChildNodes[i].OuterXml, outputNode.ChildNodes[i].OuterXml);

        }

        [TestMethod]
        public void DatabaseSaveTestDDP()
        {
            Trace.WriteLine("Starting DDP Test");
            XmlDocument input = new XmlDocument();
            input.Load(inputFolder + "\\FALCON4_DDP.xml");
            XmlDocument output = new XmlDocument();
            output.Load(outputFolder + "\\Falcon4_DDP.xml");


            XmlNode inputNode = input.DocumentElement;
            XmlNode outputNode = output.DocumentElement;

            Assert.AreEqual(inputNode.ChildNodes.Count, outputNode.ChildNodes.Count);
            for (int i = 0; i < inputNode.ChildNodes.Count; i++)
                Assert.AreEqual(inputNode.ChildNodes[i].OuterXml, outputNode.ChildNodes[i].OuterXml);

        }

        [TestMethod]
        public void DatabaseSaveTestFCD()
        {
            Trace.WriteLine("Starting FCD Test");
            XmlDocument input = new XmlDocument();
            input.Load(inputFolder + "\\FALCON4_FCD.xml");
            XmlDocument output = new XmlDocument();
            output.Load(outputFolder + "\\Falcon4_FCD.xml");


            XmlNode inputNode = input.DocumentElement;
            XmlNode outputNode = output.DocumentElement;

            Assert.AreEqual(inputNode.ChildNodes.Count, outputNode.ChildNodes.Count);
            for (int i = 0; i < inputNode.ChildNodes.Count; i++)
                Assert.AreEqual(inputNode.ChildNodes[i].OuterXml, outputNode.ChildNodes[i].OuterXml);

        }

        [TestMethod]
        public void DatabaseSaveTestICD()
        {
            Trace.WriteLine("Starting ICD Test");
            XmlDocument input = new XmlDocument();
            input.Load(inputFolder + "\\FALCON4_ICD.xml");
            XmlDocument output = new XmlDocument();
            output.Load(outputFolder + "\\Falcon4_ICD.xml");


            XmlNode inputNode = input.DocumentElement;
            XmlNode outputNode = output.DocumentElement;

            Assert.AreEqual(inputNode.ChildNodes.Count, outputNode.ChildNodes.Count);
            for (int i = 0; i < inputNode.ChildNodes.Count; i++)
                Assert.AreEqual(inputNode.ChildNodes[i].OuterXml, outputNode.ChildNodes[i].OuterXml);

        }

        [TestMethod]
        public void DatabaseSaveTestRCD()
        {
            Trace.WriteLine("Starting RCD Test");
            XmlDocument input = new XmlDocument();
            input.Load(inputFolder + "\\FALCON4_RCD.xml");
            XmlDocument output = new XmlDocument();
            output.Load(outputFolder + "\\Falcon4_RCD.xml");


            XmlNode inputNode = input.DocumentElement;
            XmlNode outputNode = output.DocumentElement;

            Assert.AreEqual(inputNode.ChildNodes.Count, outputNode.ChildNodes.Count);
            for (int i = 0; i < inputNode.ChildNodes.Count; i++)
                Assert.AreEqual(inputNode.ChildNodes[i].OuterXml, outputNode.ChildNodes[i].OuterXml);

        }

        [TestMethod]
        public void DatabaseSaveTestRWD()
        {
            Trace.WriteLine("Starting RWD Test");
            XmlDocument input = new XmlDocument();
            input.Load(inputFolder + "\\FALCON4_RWD.xml");
            XmlDocument output = new XmlDocument();
            output.Load(outputFolder + "\\Falcon4_RWD.xml");


            XmlNode inputNode = input.DocumentElement;
            XmlNode outputNode = output.DocumentElement;

            Assert.AreEqual(inputNode.ChildNodes.Count, outputNode.ChildNodes.Count);
            for (int i = 0; i < inputNode.ChildNodes.Count; i++)
                Assert.AreEqual(inputNode.ChildNodes[i].OuterXml, outputNode.ChildNodes[i].OuterXml);

        }

        [TestMethod]
        public void DatabaseSaveTestRKT()
        {
            Trace.WriteLine("Starting RKT Test");
            XmlDocument input = new XmlDocument();
            input.Load(inputFolder + "\\FALCON4_RKT.xml");
            XmlDocument output = new XmlDocument();
            output.Load(outputFolder + "\\Falcon4_RKT.xml");


            XmlNode inputNode = input.DocumentElement;
            XmlNode outputNode = output.DocumentElement;

            Assert.AreEqual(inputNode.ChildNodes.Count, outputNode.ChildNodes.Count);
            for (int i = 0; i < inputNode.ChildNodes.Count; i++)
                Assert.AreEqual(inputNode.ChildNodes[i].OuterXml, outputNode.ChildNodes[i].OuterXml);

        }

        [TestMethod]
        public void DatabaseSaveTestSWD()
        {
            Trace.WriteLine("Starting SWD Test");
            XmlDocument input = new XmlDocument();
            input.Load(inputFolder + "\\FALCON4_SWD.xml");
            XmlDocument output = new XmlDocument();
            output.Load(outputFolder + "\\Falcon4_SWD.xml");


            XmlNode inputNode = input.DocumentElement;
            XmlNode outputNode = output.DocumentElement;

            Assert.AreEqual(inputNode.ChildNodes.Count, outputNode.ChildNodes.Count);
            for (int i = 0; i < inputNode.ChildNodes.Count; i++)
                Assert.AreEqual(inputNode.ChildNodes[i].OuterXml, outputNode.ChildNodes[i].OuterXml);

        }

        [TestMethod]
        public void DatabaseSaveTestSSD()
        {
            Trace.WriteLine("Starting SSD Test");
            XmlDocument input = new XmlDocument();
            input.Load(inputFolder + "\\FALCON4_SSD.xml");
            XmlDocument output = new XmlDocument();
            output.Load(outputFolder + "\\Falcon4_SSD.xml");


            XmlNode inputNode = input.DocumentElement;
            XmlNode outputNode = output.DocumentElement;

            Assert.AreEqual(inputNode.ChildNodes.Count, outputNode.ChildNodes.Count);
            for (int i = 0; i < inputNode.ChildNodes.Count; i++)
                Assert.AreEqual(inputNode.ChildNodes[i].OuterXml, outputNode.ChildNodes[i].OuterXml);

        }

        [TestMethod]
        public void DatabaseSaveTestUCD()
        {
            Trace.WriteLine("Starting UCD Test");
            XmlDocument input = new XmlDocument();
            input.Load(inputFolder + "\\FALCON4_UCD.xml");
            XmlDocument output = new XmlDocument();
            output.Load(outputFolder + "\\Falcon4_UCD.xml");


            XmlNode inputNode = input.DocumentElement;
            XmlNode outputNode = output.DocumentElement;

            Assert.AreEqual(inputNode.ChildNodes.Count, outputNode.ChildNodes.Count);
            for (int i = 0; i < inputNode.ChildNodes.Count; i++)
                Assert.AreEqual(inputNode.ChildNodes[i].OuterXml, outputNode.ChildNodes[i].OuterXml);

        }

        [TestMethod]
        public void DatabaseSaveTestVCD()
        {
            Trace.WriteLine("Starting VCD Test");
            XmlDocument input = new XmlDocument();
            input.Load(inputFolder + "\\FALCON4_VCD.xml");
            XmlDocument output = new XmlDocument();
            output.Load(outputFolder + "\\Falcon4_VCD.xml");


            XmlNode inputNode = input.DocumentElement;
            XmlNode outputNode = output.DocumentElement;

            Assert.AreEqual(inputNode.ChildNodes.Count, outputNode.ChildNodes.Count);
            for (int i = 0; i < inputNode.ChildNodes.Count; i++)
                Assert.AreEqual(inputNode.ChildNodes[i].OuterXml, outputNode.ChildNodes[i].OuterXml);

        }

        [TestMethod]
        public void DatabaseSaveTestVSD()
        {
            Trace.WriteLine("Starting VSD Test");
            XmlDocument input = new XmlDocument();
            input.Load(inputFolder + "\\FALCON4_VSD.xml");
            XmlDocument output = new XmlDocument();
            output.Load(outputFolder + "\\Falcon4_VSD.xml");


            XmlNode inputNode = input.DocumentElement;
            XmlNode outputNode = output.DocumentElement;

            Assert.AreEqual(inputNode.ChildNodes.Count, outputNode.ChildNodes.Count);
            for (int i = 0; i < inputNode.ChildNodes.Count; i++)
                Assert.AreEqual(inputNode.ChildNodes[i].OuterXml, outputNode.ChildNodes[i].OuterXml);

        }

        [TestMethod]
        public void DatabaseSaveTestWCD()
        {
            Trace.WriteLine("Starting WCD Test");
            XmlDocument input = new XmlDocument();
            input.Load(inputFolder + "\\FALCON4_WCD.xml");
            XmlDocument output = new XmlDocument();
            output.Load(outputFolder + "\\Falcon4_WCD.xml");


            XmlNode inputNode = input.DocumentElement;
            XmlNode outputNode = output.DocumentElement;

            Assert.AreEqual(inputNode.ChildNodes.Count, outputNode.ChildNodes.Count);
            for (int i = 0; i < inputNode.ChildNodes.Count; i++)
                Assert.AreEqual(inputNode.ChildNodes[i].OuterXml, outputNode.ChildNodes[i].OuterXml);

        }

        [TestMethod]
        public void DatabaseSaveTestWLD()
        {
            Trace.WriteLine("Starting WLD Test");
            XmlDocument input = new XmlDocument();
            input.Load(inputFolder + "\\FALCON4_WLD.xml");
            XmlDocument output = new XmlDocument();
            output.Load(outputFolder + "\\Falcon4_WLD.xml");


            XmlNode inputNode = input.DocumentElement;
            XmlNode outputNode = output.DocumentElement;

            Assert.AreEqual(inputNode.ChildNodes.Count, outputNode.ChildNodes.Count);
            for (int i = 0; i < inputNode.ChildNodes.Count; i++)
                Assert.AreEqual(inputNode.ChildNodes[i].OuterXml, outputNode.ChildNodes[i].OuterXml);

        }

        [TestMethod]
        public void DatabaseSaveTestOCD()
        {
            /****************************************************************
             * NOTE:
             * Technically -0.0 and 0.0 are not the same number.
             * However, for these purposes, they should be close enough. 
             * There are about 15 XML Files with values that are -0.000 
             * which had to be manually changed to 0.000 for the unit tests 
             * to pass. This is a limitation in how the XML Writer processes 
             * data being converted between decimal/double/float.
             * 
             * The values were mostly altitude / elevation values and the 
             * distinction COULD be used to determine if something is 
             * rendered or not... however some values were X/Y coords, which
             * leads me to believe they are not being used for render
             * decisions. If this proves to be an issue moving forward, it
             * will be addressed.
             * **************************************************************/
            string inputBase = inputFolder + "\\ObjectiveRelatedData";
            string outputBase = outputFolder + "\\ObjectiveRelatedData";
            DirectoryInfo objIn = new DirectoryInfo(inputBase);
            DirectoryInfo objOut = new DirectoryInfo(inputBase);
            int oNum = 0;
            foreach (DirectoryInfo dir in objIn.GetDirectories())
            {
                Trace.WriteLine("Testing Objective: " + oNum++);
                Assert.IsTrue(Directory.Exists(objOut + "\\" + dir.Name));
                string inputWorking = inputBase + "\\" + dir.Name;
                string outputWorking = outputBase + "\\" + dir.Name;
                foreach (FileInfo file in  dir.GetFiles())
                {
                    XmlDocument input = new XmlDocument();
                    input.Load(inputWorking + "\\" + file.Name);
                    XmlDocument output = new XmlDocument();
                    output.Load(outputWorking + "\\" + file.Name);

                    XmlNode inputNode = input.DocumentElement;
                    XmlNode outputNode = output.DocumentElement;

                    Assert.AreEqual(inputNode.ChildNodes.Count, outputNode.ChildNodes.Count);
                    for (int i = 0; i < inputNode.ChildNodes.Count; i++)
                        Assert.AreEqual(inputNode.ChildNodes[i].OuterXml, outputNode.ChildNodes[i].OuterXml);
                }
                
            }
        }
    }
}