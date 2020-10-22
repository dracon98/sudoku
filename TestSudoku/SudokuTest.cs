using SudokuModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestSudoku
{    
    [TestClass()]
    public class SudokuTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        Sudoku sudoku = new Sudoku();

        [TestMethod()]
        public void IsSudokuUniqueTest()
        {
            sudoku.Data = new Byte[,]{
                {1,7,0,0,0,0,0,0,0},
                {0,0,0,2,0,0,0,0,0},
                {0,0,0,0,0,0,6,8,0},
                {8,0,0,0,0,5,4,0,0},
                {0,0,0,0,0,0,0,6,0},
                {3,5,0,6,0,7,1,0,0},
                {0,0,2,1,0,0,3,0,4},
                {5,0,3,0,0,0,0,0,8},
                {0,0,0,0,9,4,0,0,0}
            };

            var actual = sudoku.IsSudokuUnique();
            Assert.AreEqual(true, actual);
        }

        [TestMethod()]
        public void IsSudokuNotUniqueTest()
        {
            sudoku.Data = new Byte[,]{
                {0,0,0,0,0,0,0,9,0},
                {0,0,0,0,9,0,4,6,7},
                {9,0,4,1,0,0,0,2,5},
                {0,0,9,0,0,0,0,0,8},
                {8,7,0,0,6,0,0,1,4},
                {6,0,0,6,0,0,3,0,0},
                {7,4,0,0,0,2,9,0,1},
                {2,9,8,0,3,0,0,0,0},
                {0,1,0,0,0,0,0,0,0}
            };

            var actual = sudoku.IsSudokuUnique();
            Assert.AreEqual(false, actual);
        }

        [TestMethod()]
        public void SolveSuccessTest()
        {
            sudoku.Data = new Byte[,]{
                {1,7,0,0,0,0,0,0,0},
                {0,0,0,2,0,0,0,0,0},
                {0,0,0,0,0,0,6,8,0},
                {8,0,0,0,0,5,4,0,0},
                {0,0,0,0,0,0,0,6,0},
                {3,5,0,6,0,7,1,0,0},
                {0,0,2,1,0,0,3,0,4},
                {5,0,3,0,0,0,0,0,8},
                {0,0,0,0,9,4,0,0,0}
            };

            var actual = sudoku.Solve();
            Assert.AreEqual(true, actual);
        }

        [TestMethod()]
        public void SolveNoSuccessTest()
        {
            sudoku.Data = new Byte[,]{
                {1,7,0,0,0,0,0,0,0},
                {0,0,0,2,0,0,0,0,0},
                {0,0,0,0,0,0,6,8,0},
                {8,0,0,0,0,5,4,0,0},
                {0,0,0,0,0,0,0,6,0},
                {3,5,0,6,0,7,1,0,0},
                {0,0,2,1,0,0,3,0,4},
                {5,0,3,0,0,0,0,0,8},
                {0,0,0,0,9,4,0,0,7}
            };

            var actual = sudoku.Solve();
            Assert.AreEqual(false, actual);
        }

        [TestMethod()]
        public void IsSudokuFeasibleTest()
        {
            sudoku.Data = new Byte[,]{
                {1,7,0,0,0,0,0,0,0},
                {0,0,0,2,0,0,0,0,0},
                {0,0,0,0,0,0,6,8,0},
                {8,0,0,0,0,5,4,0,0},
                {0,0,0,0,0,0,0,6,0},
                {3,5,0,6,0,7,1,0,0},
                {0,0,2,1,0,0,3,0,4},
                {5,0,3,0,0,0,0,0,8},
                {0,0,0,0,9,4,0,0,7}
            };

            var actual = sudoku.IsSudokuFeasible();
            Assert.AreEqual(true, actual);
        }

        [TestMethod()]
        public void IsSudokuNotFeasibleTest()
        {
            sudoku.Data = new Byte[,]{
                {1,7,0,0,0,0,0,0,0},
                {0,0,0,2,0,0,0,0,0},
                {0,0,0,0,0,0,6,8,0},
                {8,0,0,0,0,5,4,0,0},
                {0,0,0,0,0,0,0,6,0},
                {3,5,0,6,0,7,1,0,0},
                {0,0,2,1,0,0,3,0,4},
                {5,0,3,0,0,0,0,0,8},
                {0,0,0,0,9,4,4,0,7}
            };

            var actual = sudoku.IsSudokuFeasible();
            Assert.AreEqual(false, actual);
        }

        [TestMethod()]
        public void GenerateTest()
        {
            sudoku.Data = new Byte[,]{
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0}
            };

            bool actual = sudoku.Generate(30).Item2;
            bool feasible = sudoku.IsSudokuFeasible();
            bool unique = sudoku.IsSudokuUnique();
            bool solve = sudoku.Solve();

            Assert.AreEqual(true, actual && feasible && unique && solve);
        }

        [TestMethod()]
        public void GenerateTestFromTemplate()
        {
            sudoku.Data = new Byte[,]{
                {1,0,0,0,0,0,0,0,2},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,9,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {2,0,0,0,0,0,0,0,1}
            };

            sudoku.Randomizer = new Deterministic(new int[]
                {5,7,6,0,3,6,4,3,2,2,0,4,2,6,1,5,4,3,0,1,9,3,2,3,6,3,1,2,1,2,4,5,5,6,6,7,2,7,7,1,3,4,3,0,5,7,8,5,2,8,8,1,0,3,7,7,4,7,1,6,6,8,9,0,7,3,3,8,4,8,7,8,4,7,1}
            );
            var actual = sudoku.Generate(30);
            bool chkTemplateConserved = sudoku.Data[0, 0] == 1 && sudoku.Data[8, 0] == 2 && sudoku.Data[0, 8] == 2 && sudoku.Data[8, 8] == 1 && sudoku.Data[4, 4] == 9;
            Assert.IsTrue(chkTemplateConserved, "Template not conserved.");
        }
    }

    internal class Deterministic : SudokuModel.IRandomizer
    {
        int[] DeterministicArray
        {
            get;
            set;
        }

        int current = 0;

        public Deterministic(int[] deterministicArray)
        {
            DeterministicArray = deterministicArray;
        }


        public int GetInt(int max)
        {
            return GetNext();
        }

        public int GetInt(int min, int max)
        {
            return GetNext();
        }

        private int GetNext()
        {
            return DeterministicArray[current++];
        }
    }
}
