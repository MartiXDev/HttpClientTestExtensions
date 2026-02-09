using System;

namespace MartiX.HttpClientTestExtensions;

/// <summary>
/// Indicates that a method is an assertion method.
/// </summary>
[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
sealed partial class AssertionMethodAttribute : Attribute
{
  
}
