#if SinceRVT2025

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

using Revit.IFC.Export.Utility;

namespace BIM.IFC.Export
{
    public class IFCLinkedFileExportAs
    {

        public LinkedFileExportAs ExportAs { get; set; }

        public IFCLinkedFileExportAs(LinkedFileExportAs exportAs)
        {
            ExportAs = exportAs;
        }

        public override string ToString()
        {
            switch (ExportAs)
            {
                case LinkedFileExportAs.DontExport:
                    return "Do not export";
                case LinkedFileExportAs.ExportAsSeparate:
                    return "Export as separate IFCs";
                case LinkedFileExportAs.ExportSameProject:
                    return "Export in same IFCProject";
                case LinkedFileExportAs.ExportSameSite:
                    return "Export in same IFCSite";
                default:
                    return "Do not export";
            }
        }
    }
}
#endif