﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FalconDatabase {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Schemas {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Schemas() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("FalconDatabase.Schemas", typeof(Schemas).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;xs:schema attributeFormDefault=&quot;unqualified&quot; elementFormDefault=&quot;qualified&quot; xmlns:xs=&quot;http://www.w3.org/2001/XMLSchema&quot;&gt;
        ///	&lt;xs:element name=&quot;ACDRecords&quot;&gt;
        ///		&lt;xs:complexType&gt;
        ///			&lt;xs:sequence&gt;
        ///				&lt;xs:element maxOccurs=&quot;unbounded&quot; name=&quot;ACD&quot;&gt;
        ///					&lt;xs:complexType&gt;
        ///						&lt;xs:sequence&gt;
        ///							&lt;xs:element name=&quot;CombatClass&quot; type=&quot;xs:int&quot; maxOccurs=&quot;1&quot; minOccurs=&quot;1&quot; default=&quot;0&quot; /&gt;
        ///							&lt;xs:element name=&quot;AirframeDatIdx&quot; type=&quot;xs:int&quot; maxOccurs=&quot;1&quot; minOccurs=&quot;1&quot; defa [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ACD {
            get {
                return ResourceManager.GetString("ACD", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;xs:schema attributeFormDefault=&quot;unqualified&quot; elementFormDefault=&quot;qualified&quot; xmlns:xs=&quot;http://www.w3.org/2001/XMLSchema&quot;&gt;	
        ///	&lt;xs:element name=&quot;CTRecords&quot;&gt;
        ///		&lt;xs:complexType&gt;
        ///			&lt;xs:sequence&gt;
        ///				&lt;xs:element maxOccurs=&quot;unbounded&quot; name=&quot;CT&quot;&gt;
        ///					&lt;xs:complexType&gt;
        ///						&lt;xs:sequence&gt;
        ///							&lt;xs:element name=&quot;Id&quot; type=&quot;xs:int&quot; /&gt;
        ///							&lt;xs:element name=&quot;CollisionType&quot; type=&quot;xs:unsignedShort&quot; /&gt;							
        ///							&lt;xs:element name=&quot;CollisionRadius&quot; type=&quot;xs:float&quot; /&gt;		 [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string CT {
            get {
                return ResourceManager.GetString("CT", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;xs:schema attributeFormDefault=&quot;unqualified&quot; elementFormDefault=&quot;qualified&quot; xmlns:xs=&quot;http://www.w3.org/2001/XMLSchema&quot;&gt;
        ///	&lt;xs:element name=&quot;DDPRecords&quot;&gt;
        ///		&lt;xs:complexType&gt;
        ///			&lt;xs:sequence&gt;
        ///				&lt;xs:element maxOccurs=&quot;unbounded&quot; name=&quot;DDP&quot;&gt;
        ///					&lt;xs:complexType&gt;
        ///						&lt;xs:sequence&gt;
        ///							&lt;xs:element name=&quot;Priority&quot; type=&quot;xs:int&quot; /&gt;
        ///						&lt;/xs:sequence&gt;
        ///						&lt;xs:attribute name=&quot;Num&quot; type=&quot;xs:int&quot; use=&quot;required&quot; /&gt;
        ///					&lt;/xs:complexType&gt;
        ///				&lt;/xs:element&gt;
        ///	 [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string DDP {
            get {
                return ResourceManager.GetString("DDP", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;xs:schema attributeFormDefault=&quot;unqualified&quot; elementFormDefault=&quot;qualified&quot; xmlns:xs=&quot;http://www.w3.org/2001/XMLSchema&quot;&gt;	
        ///	&lt;xs:element name=&quot;FCDRecords&quot;&gt;
        ///		&lt;xs:complexType&gt;
        ///			&lt;xs:sequence&gt;
        ///				&lt;xs:element maxOccurs=&quot;unbounded&quot; name=&quot;FCD&quot;&gt;
        ///					&lt;xs:complexType&gt;
        ///						&lt;xs:sequence&gt;
        ///							&lt;xs:element name=&quot;CtIdx&quot; type=&quot;xs:short&quot; /&gt;
        ///							&lt;xs:element name=&quot;RepairTime&quot; type=&quot;xs:short&quot; /&gt;
        ///							&lt;xs:element name=&quot;DisplayPriority&quot; type=&quot;xs:unsignedByte&quot; /&gt;
        ///				 [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string FCD {
            get {
                return ResourceManager.GetString("FCD", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;xs:schema attributeFormDefault=&quot;unqualified&quot; elementFormDefault=&quot;qualified&quot; xmlns:xs=&quot;http://www.w3.org/2001/XMLSchema&quot;&gt;	
        ///	&lt;xs:element name=&quot;FEDRecords&quot;&gt;
        ///		&lt;xs:complexType&gt;
        ///			&lt;xs:sequence&gt;
        ///				&lt;xs:element maxOccurs=&quot;unbounded&quot; name=&quot;FED&quot;&gt;
        ///					&lt;xs:complexType&gt;
        ///						&lt;xs:sequence&gt;
        ///							&lt;xs:element name=&quot;FeatureCtIdx&quot; type=&quot;xs:short&quot; /&gt;
        ///							&lt;xs:element minOccurs=&quot;0&quot; name =&quot;Flags&quot; type =&quot;xs:short&quot; /&gt;
        ///							&lt;xs:element minOccurs=&quot;0&quot; name=&quot;Value&quot; type=&quot;xs: [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string FED {
            get {
                return ResourceManager.GetString("FED", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;xs:schema attributeFormDefault=&quot;unqualified&quot; elementFormDefault=&quot;qualified&quot; xmlns:xs=&quot;http://www.w3.org/2001/XMLSchema&quot;&gt;	
        ///	&lt;xs:element name=&quot;ICDRecords&quot;&gt;
        ///		&lt;xs:complexType&gt;
        ///			&lt;xs:sequence&gt;
        ///				&lt;xs:element maxOccurs=&quot;unbounded&quot; name=&quot;ICD&quot;&gt;
        ///					&lt;xs:complexType&gt;
        ///						&lt;xs:sequence&gt;
        ///							&lt;xs:element name=&quot;Name&quot; type=&quot;xs:string&quot; /&gt;
        ///							&lt;xs:element name=&quot;DetectionRange&quot; type=&quot;xs:float&quot; /&gt;
        ///							&lt;xs:element name=&quot;FOV&quot; type=&quot;xs:float&quot; /&gt;
        ///							&lt;xs:element  [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ICD {
            get {
                return ResourceManager.GetString("ICD", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;xs:schema attributeFormDefault=&quot;unqualified&quot; elementFormDefault=&quot;qualified&quot; xmlns:xs=&quot;http://www.w3.org/2001/XMLSchema&quot;&gt;
        ///	&lt;xs:element name=&quot;OCDRecords&quot;&gt;
        ///		&lt;xs:complexType&gt;
        ///			&lt;xs:sequence&gt;
        ///				&lt;xs:element name=&quot;OCD&quot;&gt;
        ///					&lt;xs:complexType&gt;
        ///						&lt;xs:sequence&gt;
        ///							&lt;xs:element name=&quot;CtIdx&quot; type=&quot;xs:short&quot; /&gt;
        ///							&lt;xs:element name=&quot;Name&quot; type=&quot;xs:string&quot; /&gt;
        ///							&lt;xs:element name=&quot;DataRate&quot; type=&quot;xs:short&quot; /&gt;
        ///							&lt;xs:element name=&quot;DeaggDistance&quot; type=&quot; [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string OCD {
            get {
                return ResourceManager.GetString("OCD", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;xs:schema attributeFormDefault=&quot;unqualified&quot; elementFormDefault=&quot;qualified&quot; xmlns:xs=&quot;http://www.w3.org/2001/XMLSchema&quot;&gt;
        ///	&lt;xs:element name=&quot;PDRecords&quot;&gt;
        ///		&lt;xs:complexType&gt;
        ///			&lt;xs:sequence&gt;
        ///				&lt;xs:element maxOccurs=&quot;unbounded&quot; name=&quot;PD&quot;&gt;
        ///					&lt;xs:complexType&gt;
        ///						&lt;xs:sequence&gt;
        ///							&lt;xs:choice maxOccurs=&quot;unbounded&quot;&gt;
        ///								&lt;xs:element name=&quot;OffsetX&quot; type=&quot;xs:float&quot; /&gt;
        ///								&lt;xs:element name=&quot;OffsetY&quot; type=&quot;xs:float&quot; /&gt;
        ///								&lt;xs:element name=&quot;OffsetZ [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string PDX {
            get {
                return ResourceManager.GetString("PDX", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;xs:schema attributeFormDefault=&quot;unqualified&quot; elementFormDefault=&quot;qualified&quot; xmlns:xs=&quot;http://www.w3.org/2001/XMLSchema&quot;&gt;
        ///	&lt;xs:element name=&quot;PHDRecords&quot;&gt;
        ///		&lt;xs:complexType&gt;
        ///			&lt;xs:sequence&gt;
        ///				&lt;xs:element maxOccurs=&quot;unbounded&quot; name=&quot;PHD&quot;&gt;
        ///					&lt;xs:complexType&gt;
        ///						&lt;xs:sequence&gt;
        ///							&lt;xs:element name=&quot;ObjIdx&quot; type=&quot;xs:short&quot; /&gt;
        ///							&lt;xs:element name=&quot;Type&quot; type=&quot;xs:unsignedByte&quot; /&gt;
        ///							&lt;xs:element name=&quot;PointCount&quot; type=&quot;xs:unsignedShort&quot; /&gt;
        ///							 [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string PHD {
            get {
                return ResourceManager.GetString("PHD", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;xs:schema attributeFormDefault=&quot;unqualified&quot; elementFormDefault=&quot;qualified&quot; xmlns:xs=&quot;http://www.w3.org/2001/XMLSchema&quot;&gt;
        ///	&lt;xs:element name=&quot;RCDRecords&quot;&gt;
        ///		&lt;xs:complexType&gt;
        ///			&lt;xs:sequence&gt;
        ///				&lt;xs:element maxOccurs=&quot;unbounded&quot; name=&quot;RCD&quot;&gt;
        ///					&lt;xs:complexType&gt;
        ///						&lt;xs:sequence&gt;
        ///							&lt;xs:element name=&quot;Name&quot; type=&quot;xs:string&quot; /&gt;
        ///							&lt;xs:element name=&quot;RwrSound&quot; type=&quot;xs:int&quot; /&gt;
        ///							&lt;xs:element name=&quot;RwrSymbol&quot; type=&quot;xs:short&quot; /&gt;
        ///							&lt;xs:element nam [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string RCD {
            get {
                return ResourceManager.GetString("RCD", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;xs:schema attributeFormDefault=&quot;unqualified&quot; elementFormDefault=&quot;qualified&quot; xmlns:xs=&quot;http://www.w3.org/2001/XMLSchema&quot;&gt;
        ///	&lt;xs:element name=&quot;RKTRecords&quot;&gt;
        ///		&lt;xs:complexType&gt;
        ///			&lt;xs:sequence&gt;
        ///				&lt;xs:element maxOccurs=&quot;unbounded&quot; name=&quot;RKT&quot;&gt;
        ///					&lt;xs:complexType&gt;
        ///						&lt;xs:sequence&gt;
        ///							&lt;xs:element name=&quot;RocketPodIdx&quot; type=&quot;xs:short&quot; /&gt;
        ///							&lt;xs:element name=&quot;RocketWpnIdx&quot; type=&quot;xs:short&quot; /&gt;
        ///							&lt;xs:element name=&quot;RocketCount&quot; type=&quot;xs:short&quot; /&gt;
        ///						&lt; [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string RKT {
            get {
                return ResourceManager.GetString("RKT", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;xs:schema attributeFormDefault=&quot;unqualified&quot; elementFormDefault=&quot;qualified&quot; xmlns:xs=&quot;http://www.w3.org/2001/XMLSchema&quot;&gt;
        ///	&lt;xs:element name=&quot;RWDRecords&quot;&gt;
        ///		&lt;xs:complexType&gt;
        ///			&lt;xs:sequence&gt;
        ///				&lt;xs:element maxOccurs=&quot;unbounded&quot; name=&quot;RWD&quot;&gt;
        ///					&lt;xs:complexType&gt;
        ///						&lt;xs:sequence&gt;
        ///							&lt;xs:element name=&quot;Name&quot; type=&quot;xs:string&quot; /&gt;
        ///							&lt;xs:element name=&quot;DetectionRange&quot; type=&quot;xs:float&quot; /&gt;
        ///							&lt;xs:element name=&quot;ScanAngleTop&quot; type=&quot;xs:float&quot; /&gt;
        ///							&lt;xs: [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string RWD {
            get {
                return ResourceManager.GetString("RWD", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;xs:schema attributeFormDefault=&quot;unqualified&quot; elementFormDefault=&quot;qualified&quot; xmlns:xs=&quot;http://www.w3.org/2001/XMLSchema&quot;&gt;
        ///	&lt;xs:element name=&quot;SSDRecords&quot;&gt;
        ///		&lt;xs:complexType&gt;
        ///			&lt;xs:sequence&gt;
        ///				&lt;xs:element maxOccurs=&quot;unbounded&quot; name=&quot;SSD&quot;&gt;
        ///					&lt;xs:complexType&gt;
        ///						&lt;xs:sequence&gt;
        ///							&lt;xs:choice maxOccurs=&quot;unbounded&quot;&gt;
        ///								&lt;xs:element name=&quot;WpnStores_0&quot; type=&quot;xs:unsignedByte&quot; minOccurs=&quot;0&quot; /&gt;
        ///								&lt;xs:element name=&quot;WpnStores_1&quot; type=&quot;xs:unsignedByte&quot; [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SSD {
            get {
                return ResourceManager.GetString("SSD", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;xs:schema attributeFormDefault=&quot;unqualified&quot; elementFormDefault=&quot;qualified&quot; xmlns:xs=&quot;http://www.w3.org/2001/XMLSchema&quot;&gt;
        ///	&lt;xs:element name=&quot;SWDRecords&quot;&gt;
        ///		&lt;xs:complexType&gt;
        ///			&lt;xs:sequence&gt;
        ///				&lt;xs:element maxOccurs=&quot;unbounded&quot; name=&quot;SWD&quot;&gt;
        ///					&lt;xs:complexType&gt;
        ///						&lt;xs:sequence&gt;
        ///							&lt;xs:element name=&quot;Flags&quot; type=&quot;xs:int&quot; /&gt;
        ///							&lt;xs:element name=&quot;Drag&quot; type=&quot;xs:float&quot; /&gt;
        ///							&lt;xs:element name=&quot;Weight&quot; type=&quot;xs:float&quot; /&gt;
        ///							&lt;xs:element name=&quot;Area [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SWD {
            get {
                return ResourceManager.GetString("SWD", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;xs:schema attributeFormDefault=&quot;unqualified&quot; elementFormDefault=&quot;qualified&quot; xmlns:xs=&quot;http://www.w3.org/2001/XMLSchema&quot;&gt;
        ///	&lt;xs:element name=&quot;UCDRecords&quot;&gt;
        ///		&lt;xs:complexType&gt;
        ///			&lt;xs:sequence&gt;
        ///				&lt;xs:element maxOccurs=&quot;unbounded&quot; name=&quot;UCD&quot;&gt;
        ///					&lt;xs:complexType&gt;
        ///						&lt;xs:sequence&gt;
        ///							&lt;xs:choice maxOccurs=&quot;unbounded&quot;&gt;
        ///								&lt;xs:element name=&quot;CtIdx&quot; type=&quot;xs:short&quot; /&gt;
        ///
        ///								&lt;xs:element name=&quot;ElementName_0&quot; type=&quot;xs:string&quot; minOccurs=&quot;0&quot; /&gt;
        ///								&lt;x [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string UCD {
            get {
                return ResourceManager.GetString("UCD", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;xs:schema attributeFormDefault=&quot;unqualified&quot; elementFormDefault=&quot;qualified&quot; xmlns:xs=&quot;http://www.w3.org/2001/XMLSchema&quot;&gt;
        ///	&lt;xs:element name=&quot;VCDRecords&quot;&gt;
        ///		&lt;xs:complexType&gt;
        ///			&lt;xs:sequence&gt;
        ///				&lt;xs:element maxOccurs=&quot;unbounded&quot; name=&quot;VCD&quot;&gt;
        ///					&lt;xs:complexType&gt;
        ///						&lt;xs:sequence&gt;
        ///							&lt;xs:element name=&quot;CtIdx&quot; type=&quot;xs:short&quot; /&gt;
        ///							&lt;xs:element name=&quot;HitPoints&quot; type=&quot;xs:short&quot; /&gt;
        ///							&lt;xs:element name=&quot;Flags&quot; type=&quot;xs:unsignedInt&quot; /&gt;
        ///							&lt;xs:elemen [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string VCD {
            get {
                return ResourceManager.GetString("VCD", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;xs:schema attributeFormDefault=&quot;unqualified&quot; elementFormDefault=&quot;qualified&quot; xmlns:xs=&quot;http://www.w3.org/2001/XMLSchema&quot;&gt;
        ///	&lt;xs:element name=&quot;VSDRecords&quot;&gt;
        ///		&lt;xs:complexType&gt;
        ///			&lt;xs:sequence&gt;
        ///				&lt;xs:element maxOccurs=&quot;unbounded&quot; name=&quot;VSD&quot;&gt;
        ///					&lt;xs:complexType&gt;
        ///						&lt;xs:sequence&gt;
        ///							&lt;xs:element name=&quot;Name&quot; type=&quot;xs:string&quot; /&gt;
        ///							&lt;xs:element name=&quot;DetectionRange&quot; type=&quot;xs:float&quot; /&gt;
        ///							&lt;xs:element name=&quot;ScanAngleTop&quot; type=&quot;xs:float&quot; /&gt;
        ///							&lt;xs: [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string VSD {
            get {
                return ResourceManager.GetString("VSD", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;xs:schema attributeFormDefault=&quot;unqualified&quot; elementFormDefault=&quot;qualified&quot; xmlns:xs=&quot;http://www.w3.org/2001/XMLSchema&quot;&gt;
        ///	&lt;xs:element name=&quot;WCDRecords&quot;&gt;
        ///		&lt;xs:complexType&gt;
        ///			&lt;xs:sequence&gt;
        ///				&lt;xs:element maxOccurs=&quot;unbounded&quot; name=&quot;WCD&quot;&gt;
        ///					&lt;xs:complexType&gt;
        ///						&lt;xs:sequence&gt;
        ///							&lt;xs:element name=&quot;CtIdx&quot; type=&quot;xs:short&quot; /&gt;
        ///							&lt;xs:element name=&quot;Strength&quot; type=&quot;xs:unsignedShort&quot; /&gt;
        ///							&lt;xs:element name=&quot;DamageType&quot; type=&quot;xs:unsignedByte&quot; /&gt;
        ///				 [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string WCD {
            get {
                return ResourceManager.GetString("WCD", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;xs:schema attributeFormDefault=&quot;unqualified&quot; elementFormDefault=&quot;qualified&quot; xmlns:xs=&quot;http://www.w3.org/2001/XMLSchema&quot;&gt;
        ///	&lt;xs:element name=&quot;WLDRecords&quot;&gt;
        ///		&lt;xs:complexType&gt;
        ///			&lt;xs:sequence&gt;
        ///				&lt;xs:element maxOccurs=&quot;unbounded&quot; name=&quot;WLD&quot;&gt;
        ///					&lt;xs:complexType&gt;
        ///						&lt;xs:sequence&gt;
        ///							&lt;xs:element name=&quot;Name&quot; type=&quot;xs:string&quot; /&gt;
        ///							&lt;xs:element minOccurs=&quot;0&quot; name=&quot;WpnIdx_0&quot; type=&quot;xs:short&quot; /&gt;
        ///							&lt;xs:element minOccurs=&quot;0&quot; name=&quot;WpnIdx_1&quot; type=&quot;xs:shor [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string WLD {
            get {
                return ResourceManager.GetString("WLD", resourceCulture);
            }
        }
    }
}
