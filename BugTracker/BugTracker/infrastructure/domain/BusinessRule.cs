using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.infrastructure.domain
{
    public class BusinessRule
    {
        private string _property;
        private string _rule;

        public BusinessRule(string property, string rule) 
        {
            _property = property;
            _rule = rule;
        }

        public string Property 
        {
            get { return _property; }
        }

        public string Rule
        {
            get { return _rule; }
        }
    }
}
