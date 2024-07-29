# FalconDatabase

Library to interact with the Falcon Database Files.

Depending on how you pull this into your project, you may need to copy the XMLSchemas folder as well. They will b embedded resources when I am ready for a release, but for now you need them in the bin folder because it looks in the "Application" folder for them.

NOTE: I use the same base class for Application files across several projects so I moved the AppFile Class into the Utilities Project, as well as Logging functionas.
In order for this to compile, you will need to pull the Utilities project and add it as a reference to your project, or at least grab the dll from the /bin folder.
When this is ready for release, I will make sure the Utilities dll is included in the output for the build, but for now it needs to be manually included because I'm still making
some minor tweaks to it.

NOTE: I created a Testing Branch with some specific code to format the output to match the source XML for unit testing purposes. 
The master and dev branches have the conversions removed to optimize performance.

***** Read Carefully *****

TODO: Save Functions are passing unit tests for accurate input/output matching. Functional tests in the game under way.

TODO: Map all the Flag Bit Masks.

TODO: Read/Write functions for binary and text proto are WIP (~70%)
	
