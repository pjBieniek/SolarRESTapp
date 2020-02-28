using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestSolarAPI
{
    public abstract class TestTemplate<TContext>
    {
        protected virtual TContext Sut { get; private set; }

        [SetUp]
        public virtual void MainSetup()
        {
            Sut = EstablishContext();
        }

        [TearDown]
        public void TearDown()
        {
            TestCleanup();
        }

        protected abstract TContext EstablishContext();
        protected abstract void TestCleanup();
    }
}
