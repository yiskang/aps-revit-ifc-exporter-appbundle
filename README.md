# Revit IFC Exporter Appbundle for Autodesk Forge Design Automation

[![Design Automation](https://img.shields.io/badge/Design%20Automation-v3-green.svg)](http://developer.autodesk.com/)

![Windows](https://img.shields.io/badge/Plugins-Windows-lightgrey.svg)
![.NET](https://img.shields.io/badge/.NET%20Framework-4.8-blue.svg)
[![Revit-2021](https://img.shields.io/badge/Revit-2021-lightgrey.svg)](http://autodesk.com/revit)

![Advanced](https://img.shields.io/badge/Level-Advanced-red.svg)
[![MIT](https://img.shields.io/badge/License-MIT-blue.svg)](http://opensource.org/licenses/MIT)

# Description

This sample demonstrates how to implement Revit exporter that supports IFC export options of [Autodesk Revit IFC](https://github.com/Autodesk/revit-ifc)

# Development Setup

## Prerequisites

1. **Forge Account**: Learn how to create a Forge Account, activate subscription and create an app at [this tutorial](http://learnforge.autodesk.io/#/account/). 
2. **Visual Studio 2019** (Windows).
3. **Revit 2021**: required to compile changes into the plugin

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
            "localName": "DasUserDefinedParameterSets.txt"
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

## License

This sample is licensed under the terms of the [MIT License](http://opensource.org/licenses/MIT). Please see the [LICENSE](LICENSE) file for full details.

## Written by

Eason Kang [@yiskang](https://twitter.com/yiskang), [Forge Partner Development](http://forge.autodesk.com)