using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    public class RoleTest
    {
        [Fact]
        public void Create_ThrowArgumentNullException_NameIsNull()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => Role.Create(null));
            Assert.StartsWith("Имя роли не может быть null.", exception.Message);
            Assert.Equal("Имя", exception.ParamName);

        }

        [Fact]
        public void Create_ThrowArgumentException_NameIsEmpty()
        {
            var exception = Assert.Throws<ArgumentException>(() => Role.Create(string.Empty));
            Assert.StartsWith("Имя роли не может быть пустым или состоять только из пробелов.", exception.Message);
            Assert.Equal("Имя", exception.ParamName);

        }

        [Fact]
        public void Create_ThrowArgumentException_NameIsWhiteSpace()
        {
            var exception = Assert.Throws<ArgumentException>(() => Role.Create("    "));
            Assert.StartsWith("Имя роли не может быть пустым или состоять только из пробелов.", exception.Message);
            Assert.Equal("Имя", exception.ParamName);

        }
    }
}
