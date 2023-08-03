//
// BIM IFC export alternate UI library: this library works with Autodesk(R) Revit(R) to provide an alternate user interface for the export of IFC files from Revit.
// Copyright (C) 2016  Autodesk, Inc.
// 
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
//
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
//
// ref: https://github.com/Autodesk/revit-ifc/blob/9a6fc912fb8510647f9d2bcc0d57b0451a2194b6/Source/IFCExporterUIOverride/IFCExportConfigurationsMap.cs
//

using Autodesk.Revit.DB;
using Newtonsoft.Json;
using RevitIfcExportor;
using System.IO;

namespace BIM.IFC.Export
{
    /// <summary>
    /// The map to store BuiltIn and Saved configurations.
    /// </summary>
    public partial class IFCExportConfigurationsMap
    {
        /// <summary>
        /// Gets the new duplicated setup name.
        /// </summary>
        /// <param name="configuration">The configuration to duplicate.</param>
        /// <returns>The new duplicated setup name.</returns>
        private string GetDuplicateSetupName(IFCExportConfiguration configuration)
        {
            return GetFirstIncrementalName(configuration.Name);
        }

        /// <summary>
        /// Gets the new incremental name for configuration.
        /// </summary>
        /// <param name="nameRoot">The name of a configuration.</param>
        /// <returns>the new incremental name for configuration.</returns>
        private string GetFirstIncrementalName(string nameRoot)
        {
            bool found = true;
            int number = 0;
            string newName = "";
            do
            {
                number++;
                newName = nameRoot + " " + number;
                if (!this.HasName(newName))
                    found = false;
            }
            while (found);

            return newName;
        }

        public string AddConfigurationFromJson(string json)
        {
            IFCExportConfiguration configuration = JsonConvert.DeserializeObject<IFCExportConfiguration>(json);
            if (configuration == null)
                throw new InvalidDataException($"Invalid input json");

            if (this.HasName(configuration.Name))
                configuration.Name = this.GetFirstIncrementalName(configuration.Name);

            if (configuration.IFCVersion == IFCVersion.IFCBCA)
                configuration.IFCVersion = IFCVersion.IFC2x3CV2;

            this.AddOrReplace(configuration);

            return configuration.Name;
        }
    }
}
