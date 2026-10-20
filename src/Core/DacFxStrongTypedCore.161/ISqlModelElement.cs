//------------------------------------------------------------------------------
//<copyright company="Microsoft">
//
//    The MIT License (MIT)
//    
//    Copyright (c) 2015 Microsoft
//    
//    Permission is hereby granted, free of charge, to any person obtaining a copy
//    of this software and associated documentation files (the "Software"), to deal
//    in the Software without restriction, including without limitation the rights
//    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//    copies of the Software, and to permit persons to whom the Software is
//    furnished to do so, subject to the following conditions:
//    
//    The above copyright notice and this permission notice shall be included in all
//    copies or substantial portions of the Software.
//    
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//    SOFTWARE.
//</copyright>
//------------------------------------------------------------------------------
using System.Collections.Generic;
using Microsoft.SqlServer.Dac.Model;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Microsoft.SqlServer.Dac.Extensions.Prototype;

#pragma warning disable CA1716 // Preserve upstream public parameter names for callers using named arguments.
public interface ISqlModelElement
{
    public ObjectIdentifier Name { get; }
    public TSqlObject Element { get; }
    public TSqlScript GetAst();
    public IEnumerable<TSqlObject> GetChildren();
    public IEnumerable<TSqlObject> GetChildren(DacQueryScopes queryScopes);
    public object GetMetadata(ModelMetadataClass metadata);
    public T GetMetadata<T>(ModelMetadataClass metadata);
    public TSqlObject GetParent();
    public TSqlObject GetParent(DacQueryScopes queryScopes);
    public object GetProperty(ModelPropertyClass property);
    public T GetProperty<T>(ModelPropertyClass property);
    public IEnumerable<TSqlObject> GetReferenced();
    public IEnumerable<TSqlObject> GetReferenced(DacQueryScopes queryScopes);
    public IEnumerable<TSqlObject> GetReferenced(ModelRelationshipClass relationshipType);
    public IEnumerable<TSqlObject> GetReferenced(ModelRelationshipClass relationshipType, DacQueryScopes queryScopes);
    public IEnumerable<ModelRelationshipInstance> GetReferencedRelationshipInstances();
    public IEnumerable<ModelRelationshipInstance> GetReferencedRelationshipInstances(DacExternalQueryScopes queryScopes);
    public IEnumerable<ModelRelationshipInstance> GetReferencedRelationshipInstances(DacQueryScopes queryScopes);
    public IEnumerable<ModelRelationshipInstance> GetReferencedRelationshipInstances(ModelRelationshipClass relationshipType);
    public IEnumerable<ModelRelationshipInstance> GetReferencedRelationshipInstances(ModelRelationshipClass relationshipType, DacExternalQueryScopes queryScopes);
    public IEnumerable<ModelRelationshipInstance> GetReferencedRelationshipInstances(ModelRelationshipClass relationshipType, DacQueryScopes queryScopes);
    public IEnumerable<TSqlObject> GetReferencing();
    public IEnumerable<TSqlObject> GetReferencing(DacQueryScopes queryScopes);
    public IEnumerable<TSqlObject> GetReferencing(ModelRelationshipClass relationshipType);
    public IEnumerable<TSqlObject> GetReferencing(ModelRelationshipClass relationshipType, DacQueryScopes queryScopes);
    public IEnumerable<ModelRelationshipInstance> GetReferencingRelationshipInstances();
    public IEnumerable<ModelRelationshipInstance> GetReferencingRelationshipInstances(DacQueryScopes queryScopes);
    public IEnumerable<ModelRelationshipInstance> GetReferencingRelationshipInstances(ModelRelationshipClass relationshipType);
    public IEnumerable<ModelRelationshipInstance> GetReferencingRelationshipInstances(ModelRelationshipClass relationshipType, DacQueryScopes queryScopes);
    public string GetScript();
    public SourceInformation GetSourceInformation();
    public ModelTypeClass ObjectType { get; }
    public object this[ModelPropertyClass property] { get; }
    public bool TryGetAst(out TSqlScript objectAst);
    public bool TryGetScript(out string objectScript);
}
#pragma warning restore CA1716