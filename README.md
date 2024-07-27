# FalconDatabase

Library to interact with the Falcon Database Files.

Known Issues: XML Output uses XML Standards for spacing and empty values, source files are different (Hard to do unit tests when the schema is different...) 
Additional testing required to see how the Game reacts to files formatted slightly different--IE, not sure if it is parsing via TextReader.ReadLine() or XMLReader

NOTE: I use the same base class for Application files across several projects so I moved the AppFile Class into the Utilities Project, as well as Logging functionas.
In order for this to compile, you will need to pull the Utilities project and add it as a reference to your project, or at least grab the dll from the /bin folder.
When this is ready for release, I will make sure the Utilities dll is included in the output for the build, but for now it needs to be manually included because I'm still making
some minor tweaks to it.

***** Read Carefully *****

TODO: Save Functions are passing unit tests for accurate input/output matching. Functional tests in the game under way.

TODO: Read/Write functions for binary and text proto are WIP (~70%)
	
