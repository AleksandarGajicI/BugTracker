using BugTracker.infrastructure.contracts.responses;
using BugTracker.infrastructure.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.helpers
{
    public static class ResponseBaseExtensions
    {
        public static ResponseBase ReturnErrorResponseWith(this ResponseBase res, string message)
        {
            res.Success = false;
            res.Errors.Add(message);
            return res;
        }

        public static ResponseBase ReturnErrorResponseWithMultiple(this ResponseBase res,
                                                                    ICollection<BusinessRule> brokenRules)
        {
            res.Success = false;
            foreach (var brokenRule in brokenRules)
            {
                res.Errors.Add(brokenRule.Rule);
            }
            return res;
        }
    }
}
