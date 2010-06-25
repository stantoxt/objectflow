﻿using System;
using System.Collections.Generic;
using Rainbow.ObjectFlow.Interfaces;
namespace Rainbow.ObjectFlow.Constraints
{
    /// <summary>
    /// Container class for constraint functions built by helper class
    /// </summary>
    public class Condition : ICheckConstraint
    {
        private readonly Func<bool> _condition;
        private readonly IList<ICheckConstraint> _contraints;

        ///<summary>
        ///</summary>
        ///<param name="condition"></param>
        public Condition(Func<bool> condition)
        {
            _condition = condition;
        }

        ///<summary>
        ///</summary>
        ///<param name="condition"></param>
        ///<param name="constraints"></param>
        ///<exception cref="NotImplementedException"></exception>
        public Condition(Func<bool> condition, IList<ICheckConstraint> constraints)
            : this(condition)
        {
            _contraints = constraints;
        }

        /// <summary>
        /// Evaluates the constraint
        /// </summary>
        /// <returns>True if the constraint evaluated to true, false otherwise</returns>
        public bool Matches()
        {
            if (_contraints != null && _contraints.Count > 0)
            {
                bool match = Matches(_condition.Invoke());
                return match;
            }

            return _condition.Invoke();
        }

        /// <summary>
        /// Evaluates the constraint
        /// </summary>
        /// <returns>True if the constraint evaluated to true, false otherwise</returns>
        public bool Matches(bool matches)
        {
            bool match = false;
            for (int i = 0; i < _contraints.Count; i++)
            {
                match = _contraints[i].Matches(matches);
            }

            return match;
        }
    }
}