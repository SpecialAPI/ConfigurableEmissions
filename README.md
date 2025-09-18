# Configurable Emissions and Backgrounds
Adds new appearance behaviours to the game, mainly for JSONLoader users.

# Appearances
This mod adds 4 new appearance behaviours:
 * `spapi.inscryption.configemissions.ConfigurableEmissionColor` - changes the emission color to the one loaded from extended properties of the card using the prefix `customEmissionColor`.
 * `spapi.inscryption.configemissions.ConfigurableBackground` - changes the card's background to the one loaded from a texture with the name stored in the extended property `customBackground`
 * `spapi.inscryption.configemissions.ConfigurableStatColors` - changes the portrait color to the one loaded from extneded properties of the card using the prefix `customPortraitColor`, the attack color to the one loaded using the prefix `customAttackColor`, health to the one loaded using the prefix `customHealthColor` and name color to the one loaded using the prefix `customNameColor`.
 * `spapi.inscryption.configemissions.ExpandedPortrait` - expands the card portrait to a full sized one. I'm not actually sure this works for jsonloader users (that depends on whether jsonloader automatically converts loaded images to textures or if it just gives api the path to them)

# What about forced emission?
This mod does *NOT* include a forced emission appearance. That is because, it already exists in the game and is called `DefaultEmission` (or if you want forced red emission you can use the basegame appearance `RedEmission`)

# What does "changes the x color to the one loaded from extended properties of the card using the prefix y" mean?
Well, that means that it tries to load the color using many different ways from the extended properties.
The color load order is:
 * `{prefix}HEX` - firstly it tries to read the color in the HEX format from this extended property. HEX colors should be formatted like `#RRGGBB` where R, G and B are hex color components. Red color example: `#FF0000`.
 * `{prefix}255` - then if HEX isnt found, it tries to load it from a RGB 0-255 format from this extneded property. RGB 0-255 colors should be formateed like `R,G,B` where R, G and B are values ranging from 0 (black) to 255 (white). Red color example: `255,0,0` 
 * `{prefix}1` - if RGB 0-255 isnt found, it tries to load it from a RGB 0.0-1.0 format from this extended property. RGB 0.0-1.0 should be formatted like `R,G,B` where R, G and B are values ranging from 0.0 (black) and 1.0 (white). Red color example: `1.0,0.0,0.0`
 * `{prefix}HSV` - if RGB 0.0-1.0 isnt found, it tries to load it from a HSV format from this extended property. HSV should be formatted like `H,S,V` where H is a value ranging from 0 to 360 and S and V are values ranging from 0 to 100. Red color example: `0,100,100`
 * `{prefix}HSV1` - if HSV isnt found, it tries to load it from a HSV 0.0-1.0 format from this extended property. HSV 0.0-1.0 should be formatted like `H,S,V` where H, S and V are values ranging from 0.0 to 1.0. Red color example: `0.0,1.0,1.0`
 * `prefix` - if the above methods fail, it tries to load the color from an extneded property with the name of only the prefix. It tries to load it from a HEX format, and if that fails it will try to load from an RGB 0-255 format. If that fails, it will default to no color.

# How to use - JSONLoader users
To use this, just add the appearances to the list of appearances (called `appearanceBehaviour`) by their names as listed in the appearance list.
Then add their respective extended properties to the list of extended properties (called `extensionProperties`).
Should look like this:
```
{
	"appearanceBehaviour": [
		add appearances here
	],
	"extensionProperties": [
		"add extension property names like this": "and their values like this"
	],
	other card info goes here
}
```

# How to use - C# users
To use this, just add the appearances to your card's list of appearances using `yourcard.AddAppearances()` and to load the appearance enums use `GuidManager.GetEnumValue<AppearanceBehaviour.Appearance>("spapi.inscryption.configemissions", "appearance's name without the guid, for example ConfigurableEmissionColor")`
Then add their respective extended properties to the list of extneded properties using `yourcard.SetExtendedProperty("property name", "property value")`