﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rainbow.ObjectFlow.Interfaces;

namespace Rainbow.ObjectFlow.Stateful.Framework
{
	/// <summary>
	/// Represents a series of choices that are a result of a condition
	/// </summary>
	public interface IBranchingExpression<T>
		where T : class, IStatefulObject
	{
		/// <summary>
		/// Break out of the workflow execution immediately without setting state
		/// </summary>
		IStatefulWorkflow<T> Break();

		/// <summary>
		/// Go to the specified branch location if the condition is true. Otherwise keep executing
		/// </summary>
		IStatefulWorkflow<T> BranchTo(IDeclaredOperation location);
	}
}
