using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BULSTests
{
    using BangaloreUniversityLearningSystem.Views;

    public class MockView : View
    {
        public MockView(object model)
            : base(model)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            viewResult.Append(this.Model as string);
        }
    }
}
