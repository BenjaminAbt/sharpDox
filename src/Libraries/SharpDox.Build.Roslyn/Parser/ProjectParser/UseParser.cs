﻿using SharpDox.Model.CallTree;
using System.Linq;
using SharpDox.Model.Repository;

namespace SharpDox.Build.Roslyn.Parser.ProjectParser
{
    internal class UseParser
    {
        private readonly SDRepository _sdRepository;

        internal UseParser(SDRepository sdRepository)
        {
            _sdRepository = sdRepository;
        }

        internal void ResolveAllUses()
        {
            var methods = _sdRepository.GetAllMethods();
            foreach (var sdMethod in methods)
            {
                foreach (var call in sdMethod.Calls)
                {
                    ResolveCall(call);
                }
            }
        }

        private void ResolveCall(SDNode call)
        {
            if (call is SDTargetNode)
            {
                var targetNode = call as SDTargetNode;
                var calledType = _sdRepository.GetTypeByIdentifier(targetNode.CalledType.Identifier);
                var callerType = _sdRepository.GetTypeByIdentifier(targetNode.CallerType.Identifier);

                if (calledType != null && callerType != null && calledType.Identifier != callerType.Identifier && !calledType.IsProjectStranger && !callerType.IsProjectStranger)
                {
                    if (!calledType.IsProjectStranger && calledType.UsedBy.SingleOrDefault(u => u.Identifier == callerType.Identifier) == null)
                        calledType.UsedBy.Add(callerType);

                    if (!calledType.IsProjectStranger && callerType.Uses.SingleOrDefault(u => u.Identifier == calledType.Identifier) == null)
                        callerType.Uses.Add(calledType);

                    var calledNamespace = _sdRepository.GetNamespaceByIdentifier(calledType.Namespace.Identifier);
                    var callerNamespace = _sdRepository.GetNamespaceByIdentifier(callerType.Namespace.Identifier);

                    if (calledNamespace != null && callerNamespace != null && calledNamespace.Fullname != callerNamespace.Fullname)
                    {
                        if (calledNamespace.UsedBy.SingleOrDefault(u => u.Fullname == callerNamespace.Fullname) == null)
                            calledNamespace.UsedBy.Add(callerNamespace);

                        if (callerNamespace.Uses.SingleOrDefault(u => u.Fullname == calledNamespace.Fullname) == null)
                            callerNamespace.Uses.Add(calledNamespace);
                    }
                }
            }
            else if (call is SDBlock)
            {
                foreach (var embeddedCall in ((SDBlock)call).Statements)
                {
                    ResolveCall(embeddedCall);
                }
            }
            else if (call is SDConditionalBlock)
            {
                foreach (var embeddedCall in ((SDConditionalBlock)call).TrueStatements)
                {
                    ResolveCall(embeddedCall);
                }
                foreach (var embeddedCall in ((SDConditionalBlock)call).FalseStatements)
                {
                    ResolveCall(embeddedCall);
                }
            }
        }
    }
}
