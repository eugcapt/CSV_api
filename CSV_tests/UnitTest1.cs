using CSV_api.Models;
using CSV_api.Services.Interfaces;
using Moq;
using Moq.AutoMock;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel.Design;
using System.Threading.Tasks;

namespace CSV_tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodComment()
        {
            var comment = new Comment();
            var commentDto = new CommentDto(1, "TestText2", DateTime.Now, DateTime.Now, 1);
            var commentMock = new Mock<ICommentService>();
            commentMock.Setup(x => x.Create(commentDto)).Returns(comment);
            commentMock.Object.Create(commentDto);
            commentMock.Verify(x => x.Create(commentDto));
            commentMock.Setup(x => x.Update(commentDto)).Returns(comment);
            commentMock.Object.Update(commentDto);
            commentMock.Verify(x => x.Update(commentDto));
            commentMock.Setup(x => x.Delete(1));
            commentMock.Object.Delete(1);
            commentMock.Verify(x => x.Delete(1));
        }
    }
}