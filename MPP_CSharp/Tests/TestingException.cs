using System;

namespace MPP_CSharp.Tests
{
    public class TestingException : Exception
    {
        public TestingException() {}
        public TestingException(string message) : base(message) {}
        public TestingException(string message, Exception inner) : base(message, inner) {}
    }
}