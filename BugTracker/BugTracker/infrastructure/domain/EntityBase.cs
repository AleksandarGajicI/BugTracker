using BugTracker.infrastructure.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.infrastructure.domain
{
    public abstract class EntityBase
    {
        private IList<BusinessRule> _brokenRules = new List<BusinessRule>();

        public abstract void Validate();

        public IList<BusinessRule> GetBrokenRules()
        {
            _brokenRules.Clear();
            Validate();
            return _brokenRules;
        }

        protected void AddBrokenRule(BusinessRule brokenRule)
        {
            _brokenRules.Add(brokenRule);
        }

        public abstract override string ToString();


    }
}
