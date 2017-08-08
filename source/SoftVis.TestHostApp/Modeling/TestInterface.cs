﻿using System.Collections.Immutable;
using Codartis.SoftVis.Modeling2;
using Codartis.SoftVis.Modeling2.Implementation;

namespace Codartis.SoftVis.TestHostApp.Modeling
{
    internal class TestInterface : TestType
    {
        public TestInterface(ModelItemId id, string displayName, string fullName, string description,
            ModelOrigin origin, ImmutableList<ImmutableModelNodeBase> childNodes, bool isAbstract)
            : base(id, displayName, fullName, description, origin, childNodes, isAbstract)
        {
        }

        protected override ImmutableModelNodeBase CreateInstance(ModelItemId id,
            string displayName, string fullName, string description,
            ModelOrigin origin, ImmutableList<ImmutableModelNodeBase> childNodes)
        {
            return new TestInterface(id, displayName, fullName, description, origin, childNodes, IsAbstract);
        }
    }
}