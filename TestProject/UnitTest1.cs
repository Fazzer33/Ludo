using System;
using System.Collections.Generic;
using System.Linq;
using Ludo.Logic;
using Ludo.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IDice dice = new Dice(1, 6);

            IGameLogic logic = new GameLogic();
            logic.InitializeGame(new List<EPlayerColor>() {EPlayerColor.Blue, EPlayerColor.Green});
            Console.WriteLine(logic.ToString());
     
            //var list =  logic.ValidMoves(6);



            //list.Select(x => x.ToString()).ToList().ForEach(str => Console.WriteLine(str + "\n"));

            logic.MovePiece(new PawnId(EPlayerColor.Blue, 0), 6);
            Console.WriteLine(logic.ToString());

            //list = logic.ValidMoves(6);

            //   list.Select(x => x.ToString()).ToList().ForEach(str => Console.WriteLine(str + "\n"));


            logic.MovePiece(new PawnId(EPlayerColor.Green, 1), 6);

            Console.WriteLine(logic.ToString());


            logic.MovePiece(new PawnId(EPlayerColor.Blue, 0), 6);

            Console.WriteLine(logic.ToString());

            logic.MovePiece(new PawnId(EPlayerColor.Green, 1), 1);
            Console.WriteLine(logic.ToString());

            logic.MovePiece(new PawnId(EPlayerColor.Blue, 0), 5);

            Console.WriteLine(logic.ToString());

            logic.MovePiece(new PawnId(EPlayerColor.Green, 1), 6);

            Console.WriteLine(logic.ToString());

            logic.MovePiece(new PawnId(EPlayerColor.Blue, 0), 0);

            Console.WriteLine(logic.ToString());

            logic.MovePiece(new PawnId(EPlayerColor.Green, 1), 1);

            Console.WriteLine(logic.ToString());

             for (int i = 0; i < 15; i++)
             {
                 logic.MovePiece(new PawnId(EPlayerColor.Blue, 0), dice.Role());

                 Console.WriteLine(logic.ToString());

                 logic.MovePiece(new PawnId(EPlayerColor.Green, 1), dice.Role());

                 Console.WriteLine(logic.ToString());
            }
        }
    }
}
