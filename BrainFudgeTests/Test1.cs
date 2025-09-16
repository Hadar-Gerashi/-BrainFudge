using System;
using BrainFudge;
using BrainFudge.CoreMemory;
using BrainFudge.Engine;
using BrainFudge.IO;

namespace BrainFudgeTests
{
    [TestClass]
    public sealed class Test1
    {

        [DataTestMethod]

        [DataRow("+++++>+++<[->[->+>+<<]>>[-<<+>>]<<<]>[-]", 0, 0, 15, 1)] //פעולת כפל
        [DataRow("+++>++<>[->+<]<[->+<]>>[-<<+>>]<<", 2, 3, 0, 0)] // swap בין 2 מספרים
        //פעולת חזקה
        [DataRow("+++>+++<>[->+<]<[->+<]>>[-<<+>>]<<->[->+>+<<]>>[-<<+>>]<<<[->[->[->+>+<<]>>[-<<+>>]<<<]>[-<+>]>[-<+>]<<>[->+<]<[->+<]>>[-<<+>>]<<<]>>[->+<]<[->+<]>>[-<<+>>]<<[-<+>]<", 3, 0, 27, 0)]
        public void TestInterpreterMultipleCellsAndPointer(string code, int expected0, int expected1, int expected2, int expectedPointer)
        {
            // Arrange
            var memory = new Memory(3);
            var compiler = new Compiler(code);
            var commands = compiler.Compile();
            var terminal = Terminal.Instance;
            var interpreter = new Interpreter(memory, terminal, commands);

            // Act
            interpreter.Run();

            // Assert
            Assert.AreEqual(expected0, memory.GetCell(0), "Cell 0 value mismatch");
            Assert.AreEqual(expected1, memory.GetCell(1), "Cell 1 value mismatch");
            Assert.AreEqual(expected2, memory.GetCell(2), "Cell 2 value mismatch");
            Assert.AreEqual(expectedPointer, memory.GetPointer(), "Pointer position mismatch");
        }



        [DataTestMethod]
        [DataRow("{++:>++}", null)]                  
        [DataRow("{++>++}", "has no ':'")]          
        [DataRow("++:>++", "not inside")]            
        [DataRow("++}", "has no matching '{'")]      
        [DataRow("{++:>++]", "Mismatched '['")]      
        public void TestSyntaxAnalyzerVariousCases(string code, string expectedError)
        {
            // Arrange
            var analyzer = new SyntaxAnalyzer(code);

            if (expectedError == null)
            {
                // Act
                var result = analyzer.Analyze();

                // Assert
                Assert.AreEqual(code, result); 
            }
            else
            {
                // Act & Assert
                var ex = Assert.ThrowsException<Exception>(() => analyzer.Analyze());
                StringAssert.Contains(ex.Message, expectedError);
            }
        }

    }
}
