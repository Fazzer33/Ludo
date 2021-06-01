using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludo.Events;

namespace Ludo.Model
{
    public class GameLogic : IGameLogic
    {

        private readonly int diceNumberMoveToStart = 6;

        public int NumberOfCellsInGame
        {
            get {return 40; }
        } 
        private int NumberOfPawnsPerPlayer 
        {
            get {return 4;}
        }

        //Events to be used with ViewModel
        public event EventHandler<GameEndedEventArgs> GameFinishedEvent = delegate { };
        public event EventHandler<CellStatusChangedEventArgs> CellStatusChangedEvent = delegate { };

        private Dictionary<EPlayerColor, List<Pawn>> _pawns;
        private List<EPlayerColor> _playersInGame;
        private EPlayerColor _currentPlayer;
        private List<CellModel> _cells;

        public EPlayerColor CurrentPlayer
        {
            get { return _currentPlayer; }
        }

        public GameLogic()
        {

        }


        private void setNextPlayer()
        {
            Console.WriteLine("in next player");
            int index = _playersInGame.IndexOf(_currentPlayer);
            Console.WriteLine("Logic player: " +_playersInGame[(index + 1) % _playersInGame.Count]);
            _currentPlayer = _playersInGame[(index + 1) % _playersInGame.Count];
        }


        private void InitializePawns()
        {
            _pawns = new Dictionary<EPlayerColor, List<Pawn>>();
            foreach (EPlayerColor color in _playersInGame)
            {
                List<Pawn> pawnsForPlayer = new List<Pawn>();
                for (int i = 0; i < NumberOfPawnsPerPlayer; i++)
                {
                    pawnsForPlayer.Add(new Pawn(new PawnId(color, i)));
                }
                _pawns.Add(color, pawnsForPlayer);
            }
        }


        private void InitializeCells()
        {
            _cells = new List<CellModel>();
            for (int i = 0; i < NumberOfCellsInGame; i++)
            {
                _cells.Add(new CellModel(i));
            }
        }

        public void InitializeGame(List<EPlayerColor> players)
        {
            _playersInGame = players;
            _currentPlayer = players[0];
            Console.WriteLine("Current player: "+_currentPlayer);

            InitializePawns();
            InitializeCells();
        }

        private int DetermineNextCellId(int cellIndexOfPawn, int diceResult)
        {
            return (cellIndexOfPawn + diceResult) % NumberOfCellsInGame;
        }

        private bool CheckIfPawnDidAllRound(Pawn pawn, int nextCellIndex)
        {
            int finishCellId = CellModel.GetStartCellIndexForPlayer(pawn.Id.Color);
            int pawnCellId = pawn.Cell.CellIndex;
            if (pawnCellId < finishCellId && nextCellIndex >= finishCellId)
            {
                return true;
            }
            return false;
        }

        public IReadOnlyList<PawnId> ValidMoves(int diceResult)
        {
            List<PawnId> possiblePawnsToMove = new List<PawnId>();

            //Add to list of valid moves all pawns that are in house, if the start cell is empty
            if (diceResult == diceNumberMoveToStart && _cells[CellModel.GetStartCellIndexForPlayer(_currentPlayer)].PawnInCell == null)
            {
                _pawns[_currentPlayer].Where((pawn) => pawn.State == EPawnState.Start).ToList().ForEach((pawn) => possiblePawnsToMove.Add(pawn.Id));
            }

            List<Pawn> pawnsOnBoardForCurrentPlayer = _pawns[_currentPlayer].Where((pawn) => pawn.State == EPawnState.InGame).ToList();

            foreach (Pawn pawn in pawnsOnBoardForCurrentPlayer)
            {
                CellModel currentPosition = pawn.Cell;
                //Add all pawns that will end the game in next move
                int nextCellId = DetermineNextCellId(currentPosition.CellIndex, diceResult);
                if (CheckIfPawnDidAllRound(pawn, nextCellId))
                {
                    possiblePawnsToMove.Add(pawn.Id);
                    continue;
                }

                //Find if on nextCell is another pawn;
                Pawn pawnsOnNextCell = FindPawnOnCell(nextCellId);
                if (pawnsOnNextCell?.Id.Color == _currentPlayer)
                {
                    continue;
                }
                possiblePawnsToMove.Add(pawn.Id);
            }
            return possiblePawnsToMove;
        }

        private void CheckIfFinished()
        {
            foreach (EPlayerColor color in _playersInGame)
            {
                List<Pawn> pawnsForPlayer = _pawns[color];
                if (pawnsForPlayer.All(p => p.State == EPawnState.Finished))
                {
                    GameFinishedEvent(this, new GameEndedEventArgs());
                }
            }
        }


        public void MovePiece(PawnId pawn, int diceResult)
        {
            //Add somewhere events so the piece was moved
            var validMoves = ValidMoves(diceResult);
            if (validMoves.Any(x => x.Equals(pawn)))
            {
                Pawn toMove = FindPawnWithPawnId(pawn);
                if (toMove.State == EPawnState.Start)
                {
                    toMove.MoveToStart(_cells[CellModel.GetStartCellIndexForPlayer(toMove.Id.Color)]);
                }
                else
                {
                    int newCellIndex = DetermineNextCellId(toMove.Cell.CellIndex, diceResult);
                    if (CheckIfPawnDidAllRound(toMove, newCellIndex))
                    {
                        toMove.MoveToFinish();
                    }
                    else
                    {

                        toMove.MovePawn(_cells[newCellIndex]);
                    }
                }

                CheckIfFinished();
            }
            setNextPlayer();

        }


        private Pawn FindPawnWithPawnId(PawnId id)
        {
            return _pawns.Values.SelectMany(x => x).Where(x => x.Id.Equals(id)).ToList()[0];
        }


        private Pawn FindPawnOnCell(int cellId)
        {
            List<Pawn> allPawns = _pawns.Values.SelectMany(x => x).Where(x => x.State == EPawnState.InGame).Where(x => x.Cell.CellIndex == cellId).ToList();
            if (allPawns.Count == 1)
            {
                return allPawns[0];
            }
            return null;
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.Append("CURRENT PLAYER " + _currentPlayer + "\n");
            text.Append("STATUS OF ALL PAWNS" + "\n");
            _pawns.Values.SelectMany(x => x).ToList().ForEach(x => text.Append("PAWN: " + x.ToString() + "\n"));
            return text.ToString();
        }

    }
}
