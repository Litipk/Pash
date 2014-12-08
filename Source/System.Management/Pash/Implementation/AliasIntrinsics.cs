using System;
using System.Management.Automation;
using System.Collections.Generic;

namespace Pash.Implementation
{
    // TODO sburnicki: Extract common functionality to base class
    internal sealed class AliasIntrinsics
    {
        private SessionStateScope<AliasInfo> _scope;

        internal AliasIntrinsics(SessionStateScope<AliasInfo> aliasScope)
        {
            _scope = aliasScope;
        }

        public bool Exists(string aliasName)
        {
            return (Get(aliasName) != null);
        }

        public AliasInfo Get(string aliasName)
        {
            //Alias names do *not* support scope prefixes
            return _scope.Get(aliasName, false);
        }
           
        public AliasInfo GetAtScope(string aliasName, string scope)
        {
            return _scope.GetAtScope(aliasName, scope);
        }

        public Dictionary<string, AliasInfo> GetAllAtScope(string scope)
        {
            return _scope.GetAllAtScope(scope);
        }

        public Dictionary<string, AliasInfo> GetAll()
        {
            return _scope.GetAll();
        }

        public Dictionary<string, AliasInfo> GetAllLocal()
        {
            return new Dictionary<string, AliasInfo>(_scope.Items);
        }

        public void Set(AliasInfo info, string scope)
        {
            _scope.SetAtScope(info, scope, true);
        }

        public void New(AliasInfo info, string scope)
        {
            _scope.SetAtScope(info, scope, false);
        }

        public void Remove(string aliasName, string scope)
        {
            _scope.RemoveAtScope(aliasName, scope);
        }

        internal void Remove(string aliasName)
        {
            _scope.Remove(aliasName, false);
        }
    }
}

