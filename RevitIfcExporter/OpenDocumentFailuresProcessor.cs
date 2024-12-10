// (C) Copyright 2022 by Autodesk, Inc. 
//
// Permission to use, copy, modify, and distribute this software
// in object code form for any purpose and without fee is hereby
// granted, provided that the above copyright notice appears in
// all copies and that both that copyright notice and the limited
// warranty and restricted rights notice below appear in all
// supporting documentation.
//
// AUTODESK PROVIDES THIS PROGRAM "AS IS" AND WITH ALL FAULTS. 
// AUTODESK SPECIFICALLY DISCLAIMS ANY IMPLIED WARRANTY OF
// MERCHANTABILITY OR FITNESS FOR A PARTICULAR USE.  AUTODESK,
// INC. DOES NOT WARRANT THAT THE OPERATION OF THE PROGRAM WILL
// BE UNINTERRUPTED OR ERROR FREE.
//
// Use, duplication, or disclosure by the U.S. Government is
// subject to restrictions set forth in FAR 52.227-19 (Commercial
// Computer Software - Restricted Rights) and DFAR 252.227-7013(c)
// (1)(ii)(Rights in Technical Data and Computer Software), as
// applicable.
//

using Autodesk.Revit.DB;
using System.Collections.Generic;
using System.Linq;

namespace RevitIfcExporter
{
    internal class OpenDocumentFailuresProcessor : IFailuresProcessor
    {
        public void Dismiss(Document document)
        {
        }

        public FailureProcessingResult ProcessFailures(FailuresAccessor data)
        {
            IList<FailureMessageAccessor> failures = data.GetFailureMessages();

            const int MAX_RESOLUTION_ATTEMPTS = 3;
            bool hasError = false;
            bool hasWarning = false;

            foreach (FailureMessageAccessor f in failures)
            {
                // check how many resolutions types were attempted to try to prevent
                // entering infinite loop
                var resolutionTypeList = data.GetAttemptedResolutionTypes(f);
                if (resolutionTypeList.Count >= MAX_RESOLUTION_ATTEMPTS)
                {
                    MainApp.LogTrace("Failure: Attempted to resolve the failure "
                      + f.GetDescriptionText() + " " + resolutionTypeList.Count
                      + " times with resolution " + f.GetCurrentResolutionType()
                      + ". Rolling back transaction.");
                    return FailureProcessingResult.ProceedWithRollBack;
                }

                FailureSeverity fseverity = data.GetSeverity();

                if (fseverity == FailureSeverity.Error)
                {
                    ICollection<ElementId> failingElementIds = f.GetFailingElementIds();

                    if (failingElementIds.Count > 0)
                    {
                        if (f.HasResolutionOfType(FailureResolutionType.DeleteElements))
                        {
                            MainApp.LogTrace("FailureInstruction `Delete Element(s)` found. It will delete failling elements to resolve the failure.");
#if !SinceRVT2024
                            MainApp.LogTrace($"Following elements will be delted: {string.Join(",", failingElementIds.Select(eid => eid.IntegerValue))}");
#else
                            MainApp.LogTrace($"Following elements will be delted: {string.Join(",", failingElementIds.Select(eid => eid.Value))}");
#endif

                            f.SetCurrentResolutionType(FailureResolutionType.DeleteElements);
                        }

                        if (f.GetFailureDefinitionId() == BuiltInFailures.FamilyFailures.FamilyIsCorruptError)
                        {
                            MainApp.LogTrace("Some families have become unusable. It will reload the families, or delete them from the model.");
                        }

                        hasError = true;
                        data.ResolveFailure(f);
                    }
                }

                // If an attempt to resolve failures are made then return the result with ProceedWithCommit
                // Errors are not removed by resolveErrors - only subsequent regeneration will actually remove them.
                // The removal may also fail - resolution is not guaranteed to succeed. So returning with 
                // FailureProcessingResult.ProceedWithCommit is required
                if (fseverity == FailureSeverity.Warning)
                {
                    hasWarning = true;
                    data.DeleteWarning(f);
                }

                if (hasWarning || hasError)
                {
                    return FailureProcessingResult.ProceedWithCommit;
                }
            }

            return FailureProcessingResult.Continue;
        }
    }
}
