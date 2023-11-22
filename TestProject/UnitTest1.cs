
namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //arrange
            var number1 = 1;
            var number2 = 2;
            //act
            var result = number1 + number2;
            //assert
            Assert.Equal(3, result);
        }
    }
}