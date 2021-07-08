//
// BIM IFC export alternate UI library: this library works with Autodesk(R) Revit(R) to provide an alternate user interface for the export of IFC files from Revit.
// Copyright (C) 2013  Autodesk, Inc.
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
// ref: https://github.com/Autodesk/revit-ifc/tree/9a6fc912fb8510647f9d2bcc0d57b0451a2194b6/Source/Revit.IFC.Common/Enums
//

namespace Revit.IFC.Common.Enums
{
    /// <summary>
    /// Enumeration for the basis of WCS reference coordinates
    /// </summary>
    public enum SiteTransformBasis
    {
        Shared = 0,
        Site = 1,
        Project = 2,
        Internal = 3,
    }
}
