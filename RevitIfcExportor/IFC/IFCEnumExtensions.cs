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

using Autodesk.Revit.DB;
using Revit.IFC.Common.Enums;

namespace BIM.IFC.Export
{
    internal static class IFCEnumExtensions
    {
        /// <summary>
        /// Converts the <see cref="IFCVersion"/> to string.
        /// </summary>
        /// <returns>The string of IFCVersion.</returns>
        public static string ToLabel(this IFCVersion version)
        {
            switch (version)
            {
                case IFCVersion.IFC2x2:
                    return "IFC 2x2 Coordination View";
                case IFCVersion.IFC2x3:
                    return "IFC 2x3 Coordination View";
                //case IFCVersion.IFCBCA:
                case IFCVersion.IFC2x3CV2:
                    return "IFC 2x3 Coordination View 2.0";
                case IFCVersion.IFC4:
                    return "IFC4 for General Use";
                case IFCVersion.IFCCOBIE:
                    return "IFC 2x3 GSA Concept Design BIM 2010";
                case IFCVersion.IFC2x3FM:
                    return "IFC2x3 COBie 2.4 Design Deliverable View";
                case IFCVersion.IFC4DTV:
                    return "IFC4 Design Transfer View";
                case IFCVersion.IFC4RV:
                    return "IFC4 Reference Vie";
                case IFCVersion.IFC2x3BFM:
                    return "IFC 2x3 Basic FM Handover View";
                case IFCVersion.IFCBCA:
                    return "IFC2x2 Singapore BCA e-Plan Check";
                default:
                    return "Unrecognized IFC version";
            }
        }

        /// <summary>
        /// Converts the <see cref="KnownERNames"/> to string.
        /// </summary>
        /// <returns>The string of .</returns>
        public static string ToShortLabel(this KnownERNames erName)
        {
            switch (erName)
            {
                case KnownERNames.Architecture:
                    return "Architecture";
                case KnownERNames.BuildingService:
                    return "BuildingService";
                case KnownERNames.Structural:
                    return "Structural";
                default:
                    return string.Empty;
            }
        }


        /// <summary>
        /// Get the UI Name for the Exchange Requirement (ER). Note that this string may be localized
        /// </summary>
        /// <param name="erEnum">The ER Enum value</param>
        /// <returns>The localized ER name string</returns>
        public static string ToFullLabel(this KnownERNames erEnum)
        {
            switch (erEnum)
            {
                case KnownERNames.Architecture:
                    return "Architecture";
                case KnownERNames.BuildingService:
                    return "MEP Reference Exchange";
                case KnownERNames.Structural:
                    return "Structural Reference Exchange";
                default:
                    return string.Empty;
            }
        }
    }
}