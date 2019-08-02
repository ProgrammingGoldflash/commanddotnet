﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Reflection;
using CommandDotNet.ClassModeling.Definitions;
using CommandDotNet.Execution;

namespace CommandDotNet
{
    public class Operand : IArgument
    {
        public Operand(string name, ICustomAttributeProvider customAttributeProvider = null)
        {
            Name = name;
            Aliases = new[] {name};
            CustomAttributes = customAttributeProvider ?? NullCustomAttributeProvider.Instance;
        }

        public string Name { get; }
        public string Description { get; set; }

        public ITypeInfo TypeInfo { get; set; }
        public IArgumentArity Arity { get; set; }
        public object DefaultValue { get; set; }
        public IReadOnlyCollection<string> AllowedValues { get; set; }

        public IReadOnlyCollection<string> Aliases { get; }

        public ICustomAttributeProvider CustomAttributes { get; }

        public IContextData ContextData { get; } = new ContextData();

        public override string ToString()
        {
            return $"Operand: {new ArgumentTemplate(longName:Name, typeDisplayName:TypeInfo.DisplayName)}";
        }

        private bool Equals(Operand other)
        {
            return string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((Operand) obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
    }
}