# Revit IFC Exporter Appbundle for Autodesk Forge Design Automation

[![Design Automation](https://img.shields.io/badge/Design%20Automation-v3-green.svg)](http://developer.autodesk.com/)

![Windows](https://img.shields.io/badge/Plugins-Windows-lightgrey.svg)
![.NET](https://img.shields.io/badge/.NET%20Framework-4.8-blue.svg)

[![Revit-2021](https://img.shields.io/badge/Revit-2021-lightgrey.svg)](http://autodesk.com/revit)
[![Revit-2022](https://img.shields.io/badge/Revit-2022-lightgrey.svg)](http://autodesk.com/revit)
[![Revit-2023](https://img.shields.io/badge/Revit-2023-lightgrey.svg)](http://autodesk.com/revit)

![Advanced](https://img.shields.io/badge/Level-Advanced-red.svg)
[![MIT](https://img.shields.io/badge/License-MIT-blue.svg)](http://opensource.org/licenses/MIT)

# Description

This sample demonstrates how to implement Revit exporter that supports IFC export options of [Autodesk Revit IFC](https://github.com/Autodesk/revit-ifc)

# Development Setup

## Prerequisites

1. **Forge Account**: Learn how to create a Forge Account, activate subscription and create an app at [this tutorial](http://learnforge.autodesk.io/#/account/). 
2. **Visual Studio 2019 and later** (Windows).
3. **Revit 2021 and later**: required to compile changes into the plugin

## Design Automation Setup

### Activity example

```json
{
    "id": "RevitIfcExportorActivity",
    "commandLine": [
        "$(engine.path)\\\\revitcoreconsole.exe /i \"$(args[inputFile].path)\" /al \"$(appbundles[RevitIfcExportor].path)\""
    ],
    "parameters": {
        "inputFile": {
            "verb": "get",
            "description": "Input Revit File",
            "required": true,
            "localName": "$(inputFile)"
        },
        "userPropertySetsFile": {
            "verb": "get",
            "description": "IFC user defined property set definition file",
            "localName": "userDefinedParameterSets.txt"
        },
        "userParameterMappingFile": {
            "verb": "get",
            "description": "IFC user defined parameter mapping file",
            "localName": "userDefinedParameterMapping.txt"
        },
        "inputJson": {
            "verb": "get",
            "description": "input Json parameters",
            "localName": "params.json"
        },
        "outputIFC": {
            "zip": true,
            "verb": "put",
            "description": "Exported IFC files",
            "localName": "ifc"
        }
    },
    "engine": "Autodesk.Revit+2022",
    "appbundles": [
        "Autodesk.RevitIfcExportor+dev"
    ],
    "description": "Activity of Revit IFC Exporter with Autodesk IFC export options support"
}
```

### Workitem example

#### Use userPropertySets filename defined in the IFC export configuration sets and specify addin settings via inline json

```json
{
    "activityId": "Autodesk.RevitIfcExportorActivity+dev",
    "arguments": {
        "inputFile": {
            "verb": "get",
            "url": "https://developer.api.autodesk.com/oss/v2/apptestbucket/9d3be632-a4fc-457d-bc5d-9e75cefc54b7?region=US"
        },
        "userPropertySetsFile": {
            "verb": "get",
            "url": "https://developer.api.autodesk.com/oss/v2/apptestbucket/97095bbc-1ce3-469f-99ba-0157bbcab73b?region=US"
        },
        "inputJson": {
            "url": "data:application/json,{\"exportSettingName\":\"IFC2x3 Coordination View 2.0\"}"
        },
        "outputIFC": {
            "verb": "put",
            "url": "https://developer.api.autodesk.com/oss/v2/apptestbucket/9d3be632-a4fc-457d-bc5d-9e75cefc54b7?region=US",
            "headers": {
                "Content-Type": "application/octet-stream"
            }
        }
    }
}
```

**Note.** While providing inuptJSON by inline format, DA will save it as `param.json` after DA starts processing the workitem.

### Use userPropertySets and userDefinedParameterMapping filename defined in the IFC export configuration sets, and specify addin settings via concrete JSON file

```json
{
    "activityId": "Autodesk.RevitIfcExportorActivity+dev",
    "arguments": {
        "inputFile": {
            "verb": "get",
            "url": "https://developer.api.autodesk.com/oss/v2/apptestbucket/9d3be632-a4fc-457d-bc5d-9e75cefc54b7?region=US"
        },
        "userPropertySetsFile": {
            "verb": "get",
            "url": "https://developer.api.autodesk.com/oss/v2/apptestbucket/97095bbc-1ce3-469f-99ba-0157bbcab73b?region=US"
        },
        "userParameterMappingFile": {
            "verb": "get",
            "url": "https://developer.api.autodesk.com/oss/v2/apptestbucket/f0ff99e0-75dc-4aa1-acd4-3933657013d6?region=US"
        },
        "inputJson": {
            "verb": "get",
            "url": "https://developer.api.autodesk.com/oss/v2/apptestbucket/ab593357-6c6e-44dc-8308-8a7c92b25494?region=US"
        },
        "outputIFC": {
            "verb": "put",
            "url": "https://developer.api.autodesk.com/oss/v2/apptestbucket/9d3be632-a4fc-457d-bc5d-9e75cefc54b7?region=US",
            "headers": {
                "Content-Type": "application/octet-stream"
            }
        }
    }
}
```

### Use userPropertySets filename override and specify addin settings via inline json

```json
{
    "activityId": "Autodesk.RevitIfcExportorActivity+dev",
    "arguments": {
        "inputFile": {
            "verb": "get",
            "url": "https://developer.api.autodesk.com/oss/v2/apptestbucket/9d3be632-a4fc-457d-bc5d-9e75cefc54b7?region=US"
        },
        "userPropertySetsFile": {
            "verb": "get",
            "url": "https://developer.api.autodesk.com/oss/v2/apptestbucket/97095bbc-1ce3-469f-99ba-0157bbcab73b?region=US",
            "localName": "FmUserDefinedPropSets.txt"
        },
        "inputJson": {
            "url": "data:application/json,{\"exportSettingName\":\"My IFC Export Setup\", \"userDefinedPropertySetsFilenameOverride\": \"FmUserDefinedPropSets.txt\"}"
        },
        "outputIFC": {
            "verb": "put",
            "url": "https://developer.api.autodesk.com/oss/v2/apptestbucket/9d3be632-a4fc-457d-bc5d-9e75cefc54b7?region=US",
            "headers": {
                "Content-Type": "application/octet-stream"
            }
        }
    }
}
```

### Export only elements visible in the given view unique id via inline JSON

```json
{
    "activityId": "Autodesk.RevitIfcExportorActivity+dev",
    "arguments": {
        "inputFile": {
            "verb": "get",
            "url": "https://developer.api.autodesk.com/oss/v2/apptestbucket/9d3be632-a4fc-457d-bc5d-9e75cefc54b7?region=US"
        },
        "inputJson": {
            "url": "data:application/json,{\"exportSettingName\":\"My IFC Export Setup\", \"viewId\": \"44745acb-ebea-4fb9-a091-88d28bd746c7-000ea86d\"}"
        },
        "outputIFC": {
            "verb": "put",
            "url": "https://developer.api.autodesk.com/oss/v2/apptestbucket/9d3be632-a4fc-457d-bc5d-9e75cefc54b7?region=US",
            "headers": {
                "Content-Type": "application/octet-stream"
            }
        }
    }
}
```

What if the IFC expected setup hasn't checked the `"Export only elements visible in view"` option? No worry, we just need to specify `"onlyExportVisibleElementsInView": true` in the `inputJson` like below to turn it on on the fly.

```json
{
    "activityId": "Autodesk.RevitIfcExportorActivity+dev",
    "arguments": {
        "inputFile": {
            "verb": "get",
            "url": "https://developer.api.autodesk.com/oss/v2/apptestbucket/9d3be632-a4fc-457d-bc5d-9e75cefc54b7?region=US"
        },
        "inputJson": {
            "url": "data:application/json,{\"exportSettingName\":\"My IFC Export Setup\", \"viewId\": \"44745acb-ebea-4fb9-a091-88d28bd746c7-000ea86d\", \"onlyExportVisibleElementsInView\": \"true\"}"
        },
        "outputIFC": {
            "verb": "put",
            "url": "https://developer.api.autodesk.com/oss/v2/apptestbucket/9d3be632-a4fc-457d-bc5d-9e75cefc54b7?region=US",
            "headers": {
                "Content-Type": "application/octet-stream"
            }
        }
    }
}
```

### Example of params.json

Here is an example of the available options in the params.json. Only `exportSettingName` is required.

```json
{
    "exportSettingName": "My IFC Export Setup",
    "userDefinedPropertySetsFilenameOverride": "DasUserDefinedPropSets.txt",
    "userDefinedParameterMappingFilenameOverride": "DasUserDefinedParameterMapping.txt",
    "onlyExportVisibleElementsInView": true,
    "viewId": "44745acb-ebea-4fb9-a091-88d28bd746c7-000ea86d"
}
```

### Example of userPropertySetsFile for IFC

```
#
# User Defined PropertySet Definition File
#
# Format:
#    PropertySet:	<Pset Name>	I[nstance]/T[ype]	<element list separated by ','>
#	<Property Name 1>	<Data type>	<[opt] Revit parameter name, if different from IFC>
#	<Property Name 2>	<Data type>	<[opt] Revit parameter name, if different from IFC>
#	...
#
# Data types supported: Area, Boolean, ClassificationReference, ColorTemperature, Count, Currency, 
#	ElectricalCurrent, ElectricalEfficacy, ElectricalVoltage, Force, Frequency, Identifier, 
#	Illuminance, Integer, Label, Length, Logical, LuminousFlux, LuminousIntensity, 
#	NormalisedRatio, PlaneAngle, PositiveLength, PositivePlaneAngle, PositiveRatio, Power, 
#	Pressure, Ratio, Real, Text, ThermalTransmittance, ThermodynamicTemperature, Volume, 
#	VolumetricFlowRate
# 
# Example property set definition for COBie:
#
#PropertySet:	COBie_Specification	T	IfcElementType
#	NominalLength	Real	COBie.Type.NominalLength
#	NominalWidth	Real	COBie.Type.NominalWidth
#	NominalHeight	Real	COBie.Type.NominalHeight
#	Shape		Text	COBie.Type.Shape
#	Size		Text	COBie.Type.Size
#	Color		Text	COBie.Type.Color
#	Finish		Text	COBie.Type.Finish
#	Grade		Text	COBie.Type.Grade
#	Material	Text	COBie.Type.Material
#	Constituents	Text	COBie.Type.Constituents
#	Features	Text	Cobie.Type.Features
#	AccessibilityPerformance	Text	COBie.Type.AccessibilityPerformance
#	CodePerformance	Text	COBie.Type.CodePerformance
#	SustainabilityPerformance	Text	COBie.Type.SustainabilityPerformance
# 

PropertySet:	DAS Parameters	I	IfcRoof
	FM ID	Text
```

## Todo

 - [ ] Support exporting IFC from Revit links
 - [ ] Support site placement related options
 - [ ] Support IFCExchangeRequirements
 - [x] Support exporting only elements visible in specified view

## License

This sample is licensed under the terms of the [MIT License](http://opensource.org/licenses/MIT). Please see the [LICENSE](LICENSE) file for full details.

## Written by

Eason Kang [@yiskang](https://twitter.com/yiskang), [Forge Partner Development](http://forge.autodesk.com)