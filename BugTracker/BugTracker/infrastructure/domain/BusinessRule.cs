using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public static BusinessRule Make<T, TProperty>(Expression<Func<T, TProperty>> action, string error)
            where T : EntityBase
        {
            if (action.NodeType != ExpressionType.MemberAccess)
            {
                throw new Exception("The expression must be a member access!");
            }

            var expression = (MemberExpression) action.Body;

            return new BusinessRule(expression.Member.Name, error);
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
