using NUnit.Framework;
using SmartEngineer.Core.Adapter;

namespace SmartEngineer.UnitTests
{
    [TestFixture()]
    public class CoreAdapterUnitTests
    {
        [Test()]
        public void GetMemberByGroupNameUnitTest()
        {
            IMemberAdapter MemberAdapter = new MemberAdapter();
            var members = MemberAdapter.GetMemberByGroupName("Accle Support Team");
            Assert.IsNotNull(members,"No member found!");
            Assert.Greater(members.Count, 0, "No member found!");
        }
    }
}
