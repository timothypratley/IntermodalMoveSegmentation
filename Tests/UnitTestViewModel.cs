using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntermodalMoveSegmentation;

namespace Tests
{
    [TestClass]
    public class UnitTestViewModel
    {
        [TestMethod]
        public void TestViewModelCreation()
        {
            var viewModel = new ViewModel();
            Assert.IsNotNull(viewModel.AllPaths);
        }
    }
}
