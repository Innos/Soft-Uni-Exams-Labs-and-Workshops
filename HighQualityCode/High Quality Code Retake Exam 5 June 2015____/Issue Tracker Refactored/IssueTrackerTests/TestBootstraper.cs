namespace IssueTrackerTests
{
    using System.Globalization;
    using System.Threading;
    using IssueManager;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestBootstraper
    {
        protected IssueTracker tracker { get; private set; }

        [TestInitialize]
        public void InitializeTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            this.tracker = new IssueTracker();
        }
    }
}
