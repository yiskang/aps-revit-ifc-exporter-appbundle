//
// BIM IFC export alternate UI library: this library works with Autodesk(R) Revit(R) to provide an alternate user interface for the export of IFC files from Revit.
// Copyright (C) 2012  Autodesk, Inc.
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
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Web.Script.Serialization;
using System.Linq;

using Autodesk.Revit.DB;
using Autodesk.Revit.DB.IFC;

using Revit.IFC.Common.Enums;

namespace BIM.IFC.Export
{
    /// <summary>
    /// Compare 2 configurations
    /// </summary>
    public static class ConfigurationComparer
    {
        public static bool ConfigurationsAreEqual<T>(T obj1, T obj2)
        {
            var serializer = new JavaScriptSerializer();
            var obj1Serialized = serializer.Serialize(obj1);
            var obj2Serialized = serializer.Serialize(obj2);
            return obj1Serialized == obj2Serialized;
        }
    }
}
