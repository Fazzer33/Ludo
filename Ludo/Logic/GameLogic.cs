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
            int index = _playersInGame.IndexOf(_currentPlayer);
            Console.WriteLine("Logic player: " +_playersInGame[(index + 1) % _playersInGame.Count]);
            _currentPlayer = _playersInGame[(index + 1) % _playersInGame.Count];
        }
        public void SetPiece(CellModel identifier, Pawn pawn, CellId source)
        {
            if (identifier != null)
            {
                if (pawn.State == EPawnState.Finished)
                {
                    var cell = CellId.Create(pawn.Id.Id, EFieldType.Finish, pawn.Id.Color);
                    CellStatusChangedEvent(this, new CellStatusChangedEventArgs(source, pawn, cell));
                }
                else
                {
                    _cells[identifier.CellIndex].SetPiece(pawn);
                    CellStatusChangedEvent(this, new CellStatusChangedEventArgs(source, pawn, identifier.Identifier));
                }
            }
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
            Console.WriteLine("check if did all round");
            Console.WriteLine(pawnCellId);
            Console.WriteLine(finishCellId);
            Console.WriteLine(nextCellIndex);
            if (pawnCellId < finishCellId && nextCellIndex >= finishCellId || 
                pawn.Id.Color == EPlayerColor.Blue && nextCellIndex < pawnCellId && nextCellIndex >= finishCellId)
            {
                return true;
            }
            return false;
        }

        private int GetFinishCellId(Pawn pawn, int diceResult)
        {
            if (pawn.Id.Color == EPlayerColor.Blue && pawn.Id.Id > 1)
            {
                int finishCellId = CellModel.GetStartCellIndexForPlayer(pawn.Id.Color);
                int pawnCellId = pawn.Cell.CellIndex;
                return pawnCellId + diceResult - NumberOfCellsInGame - finishCellId;
            }
            else
            {
                int finishCellId = CellModel.GetStartCellIndexForPlayer(pawn.Id.Color);
                int pawnCellId = pawn.Cell.CellIndex;
                return pawnCellId - finishCellId + diceResult;
            }
          
        }

        public IReadOnlyList<Pawn> ValidMoves(int diceResult)
        {
            List<Pawn> possiblePawnsToMove = new List<Pawn>();

            //Add to list of valid moves all pawns that are in house, if the start cell is empty or from another color
            if (diceResult == diceNumberMoveToStart && _cells[CellModel.GetStartCellIndexForPlayer(_currentPlayer)].PawnInCell == null 
                || diceResult == diceNumberMoveToStart && _cells[CellModel.GetStartCellIndexForPlayer(_currentPlayer)].PawnInCell != null && _cells[CellModel.GetStartCellIndexForPlayer(_currentPlayer)].PawnInCell.Id.Color != _currentPlayer)
            {
                _pawns[_currentPlayer].Where((pawn) => pawn.State == EPawnState.Start).ToList().ForEach((pawn) => possiblePawnsToMove.Add(pawn));
            }

            List<Pawn> pawnsOnBoardForCurrentPlayer = _pawns[_currentPlayer].Where((pawn) => pawn.State == EPawnState.InGame).ToList();

            foreach (Pawn pawn in pawnsOnBoardForCurrentPlayer)
            {
                CellModel currentPosition = pawn.Cell;
                //Add all pawns that will end the game in next move
                int nextCellId = DetermineNextCellId(currentPosition.CellIndex, diceResult);
                if (CheckIfPawnDidAllRound(pawn, nextCellId))
                {
                    possiblePawnsToMove.Add(pawn);
                    continue;
                }

                //Find if on nextCell is another pawn;
                Pawn pawnsOnNextCell = FindPawnOnCell(nextCellId);
                if (pawnsOnNextCell?.Id.Color == _currentPlayer)
                {
                    continue;
                }
                possiblePawnsToMove.Add(pawn);
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


        public void MovePiece(CellId source, PawnId pawn, int diceResult)
        {
            Console.WriteLine(pawn);
            var validMoves = ValidMoves(diceResult);
            if (validMoves.Any(x => x.Id.Equals(pawn)))
            {
                Pawn toMove = FindPawnWithPawnId(pawn);
                Console.WriteLine("source:");
                Console.WriteLine(source.FieldType);
                Console.WriteLine(source.Index);
                Console.WriteLine(pawn.Color);
                Console.WriteLine(pawn.Id);
                Console.WriteLine("--------------");


                if (toMove.State == EPawnState.Start)
                {
                    if (_cells[CellModel.GetStartCellIndexForPlayer(toMove.Id.Color)].PawnInCell != null)
                    {
                        _cells[CellModel.GetStartCellIndexForPlayer(toMove.Id.Color)].PawnInCell.MoveToHouse();
                    }
                    toMove.MoveToStart(_cells[CellModel.GetStartCellIndexForPlayer(toMove.Id.Color)]);
                }
                else
                {
                    int newCellIndex = DetermineNextCellId(toMove.Cell.CellIndex, diceResult);
                    if (CheckIfPawnDidAllRound(toMove, newCellIndex))
                    {
                        var finishPawn = new Pawn(pawn);
                        var cell = new CellModel(GetFinishCellId(toMove, diceResult));
                        finishPawn.Cell = cell;
                        toMove.MoveToFinish();
                        toMove = finishPawn;
                        toMove.State = EPawnState.Finished;
                        toMove.Cell = cell;
                        toMove.Cell.PawnInCell = finishPawn;

                    }
                    else
                    {

                        toMove.MovePawn(_cells[newCellIndex]);
                    }
                }
                Console.WriteLine("target :");
                Console.WriteLine(toMove.Cell);
                Console.WriteLine(toMove.State);
                Console.WriteLine(toMove.Id.Color);
                Console.WriteLine(toMove.Id.Id);
                Console.WriteLine("--------------");
                SetPiece(toMove.Cell, toMove, source);

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
